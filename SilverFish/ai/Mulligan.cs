using System;
using System.Text;
using System.Linq;
using System.IO;
using System.Collections.Generic;
using Triton.Game.Data;
using log4net;
using Logger = Triton.Common.LogUtilities.Logger;

namespace HREngine.Bots
{
    /*
This programm allows:
    (lowest priority)
    -Hold all cards that cost less than XXX (manarule)
    (average priority)
    -Hold defined cards (possible to select 1 or 2 cards)
    -Discard defined card (all cards)
    (high priority)
    -Creating rules that allow to Discard (all) cards, depending on the presence of other cards.
    (highest priority)
    -Creating rules that allow to Hold 1 or 2 cards, depending on the presence of other cards.
    -Support different sets of rules for different behaviors.
     
as well as

    -Can create rules like: if I have a coin, then ...
    -Can create rules for different pairs of ownHero-enemyHero (any or all).
    -It allowed the simultaneous existence of rules with different priorities for the same card 
     with the same hero pairs (i.e. possible 3 rules at the same time).
     */

    public class Mulligan
    {
        string pathToMulligan = "";
        public bool mulliganRulesLoaded = false;
        Dictionary<string, string> MulliganRules = new Dictionary<string, string>();
        Dictionary<string, Dictionary<string, string>> MulliganRulesDB = new Dictionary<string, Dictionary<string, string>>();
        Dictionary<CardDB.cardIDEnum, string> MulliganRulesManual = new Dictionary<CardDB.cardIDEnum, string>();
        List<CardIDEntity> cards = new List<CardIDEntity>();
        private static readonly ILog Log = Logger.GetLoggerInstanceForType();

        public class CardIDEntity
        {
            public CardDB.cardIDEnum id = CardDB.cardIDEnum.None;
            public int entitiy = 0;
            public int hold = 0;
            public int holdByRule = 0;
            public int holdByManarule = 1;
            public string holdReason = "";
            public CardIDEntity(string id_string, int entt)
            {
                this.id = CardDB.Instance.cardIdstringToEnum(id_string);
                this.entitiy = entt;
            }
        }


        private static Mulligan instance;

        public static Mulligan Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Mulligan();
                }
                return instance;
            }
        }

        private Mulligan()
        {
        }

        private void readRules(string behavName)
        {
            if (MulliganRulesDB.ContainsKey(behavName))
            {
                MulliganRules = MulliganRulesDB[behavName];
                mulliganRulesLoaded = true;
                return;
            }
			
            if (!Silverfish.Instance.BehaviorPath.ContainsKey(behavName))
            {
                Helpfunctions.Instance.ErrorLog(behavName + ": no special mulligan.");
                return;
            }

            pathToMulligan = Path.Combine(Silverfish.Instance.BehaviorPath[behavName], "_mulligan.txt");

            if (!System.IO.File.Exists(pathToMulligan))
            {
                Helpfunctions.Instance.ErrorLog(behavName + ": no special mulligan.");
                return;
            }
            try
            {
                string[] lines = System.IO.File.ReadAllLines(pathToMulligan);
                MulliganRules.Clear();
                foreach (string s in lines)
                {
                    if (s == "" || s == null) continue;
                    if (s.StartsWith("//")) continue;
                    string[] oneRule = s.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);

                    string[] tempKey = oneRule[0].Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries);
                    string[] tempValue = oneRule[1].Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries);
                    string MullRuleKey = joinSomeTxt(tempKey[0], ";", tempKey[1], ";", tempKey[2], ";", (tempValue[1] != "/") ? "1" : "0");
                    string MullRuleValue = joinSomeTxt(tempKey[3], ";", tempValue[0], ";", tempValue[1]);

                    if (MulliganRules.ContainsKey(MullRuleKey)) MulliganRules[MullRuleKey] = MullRuleValue;
                    else MulliganRules.Add(MullRuleKey, MullRuleValue);
                }
            }
            catch (Exception ee)
            {
                Helpfunctions.Instance.ErrorLog("[Mulligan] _mulligan.txt - read error. We continue without user-defined rules. Only the default rules.");
                return;
            }
            Helpfunctions.Instance.ErrorLog("[Mulligan] Load rules for " + behavName);
            validateRule(behavName);
        }

        private void validateRule(string behavName)
        {
            List<string> rejectedRule = new List<string>();
            int repairedRules = 0;
            Dictionary<string, string> MulliganRulesTmp = new Dictionary<string, string>();

            foreach (KeyValuePair<string, string> oneRule in MulliganRules)
            {
                string[] ruleKey = oneRule.Key.Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries);
                string[] ruleValue = oneRule.Value.Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries);
                string ruleValueOne = oneRule.Value;

                if (ruleKey.Length != 4 || ruleValue.Length != 3) { rejectedRule.Add(getClearRule(oneRule.Key)); continue; }

                if (ruleKey[0] != CardDB.Instance.cardIdstringToEnum(ruleKey[0]).ToString()) { rejectedRule.Add(getClearRule(oneRule.Key)); continue; }
                if (ruleKey[1] != Hrtprozis.Instance.heroNametoEnum(ruleKey[1]).ToString()) { rejectedRule.Add(getClearRule(oneRule.Key)); continue; }
                if (ruleKey[2] != Hrtprozis.Instance.heroNametoEnum(ruleKey[2]).ToString()) { rejectedRule.Add(getClearRule(oneRule.Key)); continue; }
                if (ruleValue[0] != "Hold" && ruleValue[0] != "Discard") { rejectedRule.Add(getClearRule(oneRule.Key)); continue; }

                try
                {
                    Convert.ToInt32(ruleValue[1]);
                }
                catch (Exception eee) { rejectedRule.Add(getClearRule(oneRule.Key)); continue; }

                if (ruleValue[2] != "/")
                {
                    if (ruleValue[2].Length < 4) // if lenght < 4 then it a manarule
                    {
                        int manaRule = 4;
                        try
                        {
                            manaRule = Convert.ToInt32(ruleValue[2]);
                        }
                        catch { }
                        if (manaRule < 0) manaRule = 0;
                        else if (manaRule > 100) manaRule = 100;

                        StringBuilder tmpSB = new StringBuilder(ruleValue[0], 500);
                        tmpSB.Append(";").Append(ruleValue[1]).Append(";").Append(manaRule);
                        ruleValueOne = tmpSB.ToString();
                    }
                    else
                    {
                        bool wasBreak = false;
                        string[] addedCards = ruleValue[2].Split(new string[] { "/" }, StringSplitOptions.RemoveEmptyEntries);
                        Dictionary<CardDB.cardIDEnum, string> MulliganRulesManualTmp = new Dictionary<CardDB.cardIDEnum, string>();
                        foreach (string s in addedCards)
                        {
                            CardDB.cardIDEnum tempID = CardDB.Instance.cardIdstringToEnum(s);
                            if (s != tempID.ToString())
                            {
                                rejectedRule.Add(getClearRule(oneRule.Key));
                                wasBreak = true;
                                break;
                            }
                            else
                            {
                                if (MulliganRulesManualTmp.ContainsKey(tempID)) { repairedRules++; continue; }
                                else MulliganRulesManualTmp.Add(tempID, "");
                            }
                        }
                        if (wasBreak) continue;
                        StringBuilder tmpSB = new StringBuilder(ruleValue[0], 500);
                        tmpSB.Append(";").Append(ruleValue[1]).Append(";");
                        for (int i = 0; i < MulliganRulesManualTmp.Count; i++)
                        {
                            if (i + 1 == MulliganRulesManualTmp.Count) break;
                            tmpSB.Append(MulliganRulesManualTmp.ElementAt(i).Key.ToString()).Append("/");
                        }
                        tmpSB.Append(MulliganRulesManualTmp.ElementAt(MulliganRulesManualTmp.Count - 1).Key.ToString());
                        ruleValueOne = tmpSB.ToString();
                    }
                }

                MulliganRulesTmp.Add(oneRule.Key, ruleValueOne);
            }

            if (rejectedRule.Count > 0)
            {
                Helpfunctions.Instance.ErrorLog("[Mulligan] List of rejected Rules:");
                foreach (string tmp in rejectedRule)
                {
                    Helpfunctions.Instance.ErrorLog(tmp);
                }
                Helpfunctions.Instance.ErrorLog("[Mulligan] End list of rejected Rules.");
            }

            if (repairedRules > 0) Helpfunctions.Instance.ErrorLog(repairedRules.ToString() + " repaired rules");
            MulliganRules.Clear();

            foreach (KeyValuePair<string, string> oneRule in MulliganRulesTmp)
            {
                MulliganRules.Add(oneRule.Key, oneRule.Value);
            }

            Helpfunctions.Instance.ErrorLog("[Mulligan] " + (MulliganRules.Count > 0 ? (MulliganRules.Count + " rules loaded successfully") : "No special rules."));
            mulliganRulesLoaded = true;
            if (behavName == "") //oldCompatibility
            {
                MulliganRulesDB.Add("Control", new Dictionary<string, string>(MulliganRules));
                MulliganRulesDB.Add("Rush", new Dictionary<string, string>(MulliganRules));
            }
            else MulliganRulesDB.Add(behavName, new Dictionary<string, string>(MulliganRules));
        }

        private string getClearRule(string ruleKey)
        {
            if (MulliganRules.ContainsKey(ruleKey))
            {
                StringBuilder clearRule = new StringBuilder("", 2000);
                string[] rKey = ruleKey.Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries);
                string[] rValue = MulliganRules[ruleKey].Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries);
                clearRule.Append(rKey[0]).Append(";").Append(rKey[1]).Append(";").Append(rKey[2]).Append(";");
                clearRule.Append(rValue[0]).Append(":").Append(rValue[1]).Append(";").Append(rValue[2]).Append("\r\n");
                return clearRule.ToString();
            }
            else return "noKey";
        }


        private string getMullRuleKey(CardDB.cardIDEnum cardIDM = CardDB.cardIDEnum.None, HeroEnum ownMHero = HeroEnum.None, HeroEnum enemyMHero = HeroEnum.None, int isExtraRule = 0)
        {
            StringBuilder MullRuleKey = new StringBuilder("", 500);
            MullRuleKey.Append(cardIDM).Append(";").Append(ownMHero).Append(";").Append(enemyMHero).Append(";").Append(isExtraRule);
            return MullRuleKey.ToString();
        }
        
        private string joinSomeTxt(string v1 = "", string v2 = "", string v3 = "", string v4 = "", string v5 = "", string v6 = "", string v7 = "")
        {
            StringBuilder retValue = new StringBuilder("", 500);
            retValue.Append(v1).Append(v2).Append(v3).Append(v4).Append(v5).Append(v6).Append(v7);
            return retValue.ToString();
        }

        public bool getHoldList(MulliganData mulliganData, Behavior behave)
        {
            cards.Clear();
            readRules(behave.BehaviorName());
            if (!mulliganRulesLoaded) return false;
            if (!(mulliganData.Cards.Count == 3 || mulliganData.Cards.Count == 4))
            {
                Helpfunctions.Instance.ErrorLog("[Mulligan] Mulligan is not used, since it got number of cards: " + cards.Count.ToString());
                return false;
            }

            Log.InfoFormat("[Mulligan] Apply the {0} rules:", behave.BehaviorName());

            for (var i = 0; i < mulliganData.Cards.Count; i++)
            {
                cards.Add(new CardIDEntity(mulliganData.Cards[i].Entity.Id, i));
            }
            HeroEnum ownHeroClass = Hrtprozis.Instance.heroTAG_CLASSstringToEnum(mulliganData.UserClass.ToString());
            HeroEnum enemyHeroClass = Hrtprozis.Instance.heroTAG_CLASSstringToEnum(mulliganData.OpponentClass.ToString());
            
            int manaRule = 4;
            string MullRuleKey = getMullRuleKey(CardDB.cardIDEnum.None, ownHeroClass, enemyHeroClass, 1);
            if (MulliganRules.ContainsKey(MullRuleKey))
            {
                string[] temp = MulliganRules[MullRuleKey].Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries);
                manaRule = Convert.ToInt32(temp[2]);
            }
            else
            {
                MullRuleKey = getMullRuleKey(CardDB.cardIDEnum.None, ownHeroClass, HeroEnum.None, 1);
                if (MulliganRules.ContainsKey(MullRuleKey))
                {
                    string[] temp = MulliganRules[MullRuleKey].Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries);
                    manaRule = Convert.ToInt32(temp[2]);
                }
            }

            CardIDEntity Coin = new CardIDEntity("GAME_005", -888);
            if (cards.Count == 4) cards.Add(Coin); //we have a coin

            foreach (CardIDEntity CardIDEntityC in cards)
            {
                CardDB.Card c = CardDB.Instance.getCardDataFromID(CardIDEntityC.id);
                if (CardIDEntityC.hold == 0 && CardIDEntityC.holdByRule == 0)
                {
                    if (c.cost < manaRule)
                    {
                        CardIDEntityC.holdByManarule = 2;
                        CardIDEntityC.holdReason = joinSomeTxt("hold because the card cost:", c.cost.ToString(), " is less then Manarule cost:", manaRule.ToString());
                    }
                    else
                    {
                        CardIDEntityC.holdByManarule = -2;
                        CardIDEntityC.holdReason = joinSomeTxt("discard because the card cost:", c.cost.ToString(), " is not less then Manarule cost:", manaRule.ToString());
                    }
                }

                int allowedQuantitySimple = 0;
                int allowedQuantityExtra = 0;
                bool hasRuleClassSimple = false;

                bool hasRule = false;
                string MullRuleKeySimple = getMullRuleKey(c.cardIDenum, ownHeroClass, enemyHeroClass, 0); //Simple key for Class enemy
                if (MulliganRules.ContainsKey(MullRuleKeySimple)) { hasRule = true; hasRuleClassSimple = true; }
                else
                {
                    MullRuleKeySimple = getMullRuleKey(c.cardIDenum, ownHeroClass, HeroEnum.None, 0); //Simple key for ALL enemy
                    if (MulliganRules.ContainsKey(MullRuleKeySimple)) hasRule = true;
                }
                if (hasRule)
                {
                    string[] val = MulliganRules[MullRuleKeySimple].Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries);
                    allowedQuantitySimple = ((val[1] == "2") ? 2 : 1) * ((val[0] == "Hold") ? 1 : -1);
                }
                
                hasRule = false;
                string MullRuleKeyExtra = getMullRuleKey(c.cardIDenum, ownHeroClass, enemyHeroClass, 1); //Extra key for Class enemy
                if (MulliganRules.ContainsKey(MullRuleKeyExtra)) hasRule = true;
                else if (!hasRuleClassSimple)
                {
                    MullRuleKeyExtra = getMullRuleKey(c.cardIDenum, ownHeroClass, HeroEnum.None, 1); //Extra key for ALL enemy
                    if (MulliganRules.ContainsKey(MullRuleKeyExtra)) hasRule = true;
                }
                if (hasRule)
                {
                    string[] val = MulliganRules[MullRuleKeyExtra].Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries);
                    allowedQuantityExtra = ((val[1] == "2") ? 2 : 1) * ((val[0] == "Hold") ? 1 : -1);
                }

                //superimpose Class rules to All rules
                bool useHold = false;
                bool useDiscard = false;
                bool useHoldRule = false;
                bool useDiscardRule = false;

                if (allowedQuantitySimple != 0 && allowedQuantitySimple != allowedQuantityExtra)
                {
                    if (allowedQuantitySimple > 0) useHold = true;
                    else useDiscard = true;
                }
                if (allowedQuantityExtra != 0)
                {
                    if (allowedQuantityExtra < 0) useDiscardRule = true;
                    else useHoldRule = true;
                }

                //apply the rules
                string[] MullRuleValueExtra = new string[3];
                if (allowedQuantityExtra != 0) MullRuleValueExtra = MulliganRules[MullRuleKeyExtra].Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries);
                if (useDiscardRule)
                {
                    if (MullRuleValueExtra[2] != "/")
                    {
                        string[] addedCards = MullRuleValueExtra[2].Split(new string[] { "/" }, StringSplitOptions.RemoveEmptyEntries);
                        MulliganRulesManual.Clear();
                        foreach (string s in addedCards) { MulliganRulesManual.Add(CardDB.Instance.cardIdstringToEnum(s), ""); }

                        foreach (CardIDEntity tmp in cards)
                        {
                            if (CardIDEntityC.entitiy == tmp.entitiy) continue;
                            if (MulliganRulesManual.ContainsKey(tmp.id))
                            {
                                CardIDEntityC.holdByRule = -2;
                                CardIDEntityC.holdReason = joinSomeTxt("discard by rule: ", getClearRule(MullRuleKeyExtra));
                                break;
                            }
                        }
                    }
                }
                else if (useDiscard)
                {
                    CardIDEntityC.hold = -2;
                    CardIDEntityC.holdReason = joinSomeTxt("discard by rule: ", getClearRule(MullRuleKeySimple));
                }

                if (useHoldRule)
                {
                    if (CardIDEntityC.holdByRule == 0)
                    {
                        string[] addedCards = MullRuleValueExtra[2].Split(new string[] { "/" }, StringSplitOptions.RemoveEmptyEntries);
                        MulliganRulesManual.Clear();
                        foreach (string s in addedCards) { MulliganRulesManual.Add(CardDB.Instance.cardIdstringToEnum(s), ""); }

                        bool foundFreeCard = false;
                        for (int i = 0; i < cards.Count; i++)
                        {
                            if (CardIDEntityC.entitiy == cards[i].entitiy) continue;
                            if (MulliganRulesManual.ContainsKey(cards[i].id))
                            {
                                CardIDEntityC.holdByRule = 2;
                                CardIDEntityC.holdReason = joinSomeTxt("hold by rule: ", getClearRule(MullRuleKeyExtra));
                                if (cards[i].holdByRule < 0)
                                {
                                    for (int j = i; j < cards.Count; j++)
                                    {
                                        if (CardIDEntityC.entitiy == cards[j].entitiy) continue;
                                        if (MulliganRulesManual.ContainsKey(cards[j].id))
                                        {
                                            if (cards[j].holdByRule < 0) continue;
                                            foundFreeCard = true;
                                            cards[j].holdByRule = 2;
                                            cards[j].holdReason = joinSomeTxt("hold by rule: ", getClearRule(MullRuleKeyExtra));
                                            break;
                                        }
                                    }
                                    if (!foundFreeCard)
                                    {
                                        foundFreeCard = true;
                                        cards[i].holdByRule = 2;
                                        cards[i].holdReason = joinSomeTxt("hold by rule: ", getClearRule(MullRuleKeyExtra));
                                        break;
                                    }
                                }
                                else
                                {
                                    foundFreeCard = true;
                                    cards[i].holdByRule = 2;
                                    cards[i].holdReason = joinSomeTxt("hold by rule: ", getClearRule(MullRuleKeyExtra));
                                }

                                if (allowedQuantityExtra == 1)
                                {
                                    foreach (CardIDEntity tmp in cards)
                                    {
                                        if (tmp.entitiy == CardIDEntityC.entitiy) continue;
                                        if (tmp.id == CardIDEntityC.id)
                                        {
                                            tmp.holdByRule = -2;
                                            tmp.holdReason = joinSomeTxt("discard by rule: ", getClearRule(MullRuleKeyExtra));
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                if (useHold && CardIDEntityC.holdByRule != -2)
                {
                    if (CardIDEntityC.hold == 0)
                    {
                        CardIDEntityC.hold = 2;
                        CardIDEntityC.holdReason = joinSomeTxt("hold by rule: ", getClearRule(MullRuleKeySimple));
                        if (allowedQuantitySimple == 1)
                        {
                            CardIDEntityC.hold = 1;
                            foreach (CardIDEntity tmp in cards)
                            {
                                if (tmp.entitiy == CardIDEntityC.entitiy) continue;
                                if (tmp.id == CardIDEntityC.id)
                                {
                                    tmp.hold = -2;
                                    tmp.holdReason = joinSomeTxt("discard Second card by rule: ", getClearRule(MullRuleKeySimple));
                                }
                            }
                        }
                    }
                }
            }

            if (cards.Count == 5) cards.Remove(Coin);

            foreach (CardIDEntity c in cards)
            {
                if (c.holdByRule == 0)
                {
                    if (c.hold == 0)
                    {
                        c.holdByRule = c.holdByManarule;
                    }
                    else
                    {
                        c.holdByRule = c.hold;
                    }
                }
            }

            for (var i = 0; i < mulliganData.Cards.Count; i++)
            {
                mulliganData.Mulligans[i] = (cards[i].holdByRule > 0) ? false : true;
                Log.InfoFormat("[Mulligan] {0} {1}.", mulliganData.Cards[i].Entity.Name, cards[i].holdReason);
            }
            return true;
        }

    }

}