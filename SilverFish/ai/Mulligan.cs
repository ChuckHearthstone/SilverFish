using System;
using System.Collections.Generic;

namespace HREngine.Bots
{
    /*
    SE Style Mulligans
        Format:
    
            type;self;enemy;card:[count]:[required cards];[coin];[mana border]
            
            type            = "hold" or "discard"
            self            = a class name like "shaman" or "all" for all classes
            enemy           = a class name like "shaman" or "all" for all classes
            card            = a card id like "OG_024" or its English name without any spaces or special characters like "cthunschosen" - search _carddb.txt for the name of your card to find the id
            count           = up to how many copies of the card to keep or discard (default 2)
            required cards  = card,[count],[req #][operator][card,[count],[req #]]...
                            card        = another card that must be present
                            count       = how many copies (0-2) of this card to keep/discard (keep default 1, discard default 0)
                            req #       = how many copies (1-2) of this card are required (default 1)
                            operator    = "+" or "/"
                                        "+" = each card joined by "+" is also required ie. card1 AND card2
                                        "/" = separates required cards and groups of cards that are joined by "+" ie. card1 OR card2 OR (card3 AND card4)
            coin            = "coin" or "nocoin" (default both)
            mana border     = also hold any cards under/equal cost to this value or discard higher/equal cost cards
            
        Examples:
            hold;shaman;all;OG_024:1;coin;2                     \\hold 1 copy of OG_024 if you are shaman vs any class with coin and hold any cards that cost 2 or less
            hold;shaman;all;OG_024:1:CS2_106,0,0+CS2_222,0,2    \\hold 1 copy of OG_024 if you are shaman vs any class and have 1x CS2_106 and 2x CS2_222 but don't hold any CS2_106 or CS2_222 (other rules may hold them before/after this rule)
            hold;shaman;all;OG_024:2:CS2_106,2,2+CS2_222        \\hold up to 2 copies of OG_024 if you are shaman vs any class and have 2x CS2_106 and 1x CS2_222 and hold the 2x CS2_106 and 1x CS2_222
            discard;mage;mage;OG_024:2:EX1_019/CS2_106+CS2_222  \\discard up to 2 copies of OG_024 if you are mage vs mage and have EX1_019 (don't discard any EX1_019), or if you have both CS2_106 and CS2_222 (don't discard any CS2_106 or CS2_222)
            hold;shaman;all;OG_024:2:OG_024,2,2                 \\hold exactly 2x OG_024 if you are shaman vs any class

        Priority:
            Rules are prioritized in the order they are read with the first being lowest priority and the last being highest.
            If your first rule holds a card and your next rule discards it then it will be discarded and vice versa.
            If you have a rule that holds 2 copies and then a rule that holds 1 copy, 2 copies will be held.
            If hold count=1 then the 2nd copy is discarded, if discard count=1 then the 2nd copy is held.
            If any of the "/" requirements (starting with the first set) are matched then the rule is executed using that set of requirements only, thus your most complex requirements should be first if count > 0 for the requirement

        Incompatibilities With Old Rules:
            type;self;enemy;card,card is no longer supported, write rules for each card instead!
            "/" requirements hold 1x of each card from the first valid set of requirements but it used to save 1x from every match


        
    HB Style Mulligans
        Format:
            card;self;enemy;type:[count];requirements
            
            card            = a card id like "OG_024" - search _carddb.txt for the name of your card to find the id
            self            = a class name like "shaman"
            enemy           = a class name like "shaman"
            type            = "Hold" or "Discard"
            count           = up to how many copies of the card to keep or discard (default 2)
            requirements    = "/" - no addition rules, or "0-20" - manarule, or card:card:card:... - more cards required


    mulltest.txt
        Format:
            card,card,card[,card];self;enemy;coin

            card        = a cardid
            self        = your class name like "mage"
            enemy       = enemy class name like "mage"
            coin        = "coin" if you have the coin, anything else = no coin

        Examples:
            OG_114,EX1_319,EX1_162,EX1_310;warlock;mage;coin
            OG_114,EX1_319,EX1_162;warlock;mage;

        Explanation:
            Create a text file in your Silverfish folder and name it mulltest(.txt) and then put a list of hypothetical cards in it and save.
            Then run Silver.exe and it will tell you what cards would be discarded with hints about why.

     */

    public sealed class Mulligan
    {
        public class CardIDEntity
        {
            public CardDB.cardIDEnum id;
            public string idstring;
            public int entity;
            public CardIDEntity(string idstring, int entt)
            {
                id = CardDB.Instance.cardIdstringToEnum(idstring);
                this.idstring = idstring;
                entity = entt;
            }
        }

        class mulliitem
        {
            public bool holdrule;
            public string cardid = "";
            public string enemyclass;
            public string ownclass;
            public int count;
            public string[] requiresCard;
            public int manarule;
            public int coinrule; //0 = for both, 1 = if you are first, 2 if you are second
            
            public mulliitem(bool hrule, string id, string own, string enemy, int number, string[] req = null, int coinr = 0, int mrule = -1)
            {
                if (own == "none") own = "all";
                if (own != "all") own = Hrtprozis.Instance.heroNametoEnum(own).ToString();
                if (enemy == "none") enemy = "all";
                if (enemy != "all") enemy = Hrtprozis.Instance.heroNametoEnum(enemy).ToString();


                holdrule = hrule;
                cardid = id;
                ownclass = own;
                enemyclass = enemy;
                count = number;
                requiresCard = req;
                manarule = mrule;
                coinrule = coinr;

                //warn about invalid data even though we accepted it (parts of reqs may be usable)
                if (id != "#MANARULE" && CardDB.Instance.cardIdstringToEnum(id) == CardDB.cardIDEnum.None)
                {
                    Helpfunctions.Instance.ErrorLog("[Mulligan] CardID: \"" + id + "\" is not a valid card");
                }
                if (own != "all" && Hrtprozis.Instance.heroNametoEnum(own) == HeroEnum.None)
                {
                    Helpfunctions.Instance.ErrorLog("[Mulligan] Class: \"" + own + "\" is not a valid class");
                }
                if (enemy != "all" && Hrtprozis.Instance.heroNametoEnum(enemy) == HeroEnum.None)
                {
                    Helpfunctions.Instance.ErrorLog("[Mulligan] Class: \"" + enemy + "\" is not a valid class");
                }
                if (req != null)
                {
                    foreach (string card in req)
                    {
                        string[] crds = card.Split('+');
                        foreach (string crd in crds)
                        {
                            if (CardDB.Instance.cardIdstringToEnum(crd.Split(',')[0]) == CardDB.cardIDEnum.None)
                            {
                                Helpfunctions.Instance.ErrorLog("[Mulligan] CardID: \"" + crd + "\" is not a valid card");
                            }
                        }
                    }
                }
            }
        }

        class concedeItem
        {
            public HeroEnum urhero = HeroEnum.None;
            public List<HeroEnum> enemhero = new List<HeroEnum>();
        }
        
        private Dictionary<string, int> holdDB = new Dictionary<string, int>(4);
        List<mulliitem> cardlist = new List<mulliitem>(50);
        List<concedeItem> concedelist = new List<concedeItem>();
        public bool loserLoserLoser;

        private string ownClass = Hrtprozis.Instance.heroEnumtoCommonName(Hrtprozis.Instance.heroname);
        private string deckName = Hrtprozis.Instance.deckName;
        private string cleanPath = "";


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
            readMulligan();
        }

        public void updateInstance()
        {
            ownClass = Hrtprozis.Instance.heroEnumtoCommonName(Hrtprozis.Instance.heroname);
            deckName = Hrtprozis.Instance.deckName;
            lock (instance)
            {
                readMulligan();
            }
        }

        public void loggCleanPath()
        {
            Helpfunctions.Instance.logg(cleanPath);
        }

        private void readMulligan()
        {
            string[] lines = new string[] { };
            cardlist.Clear();
            holdDB.Clear();
            concedelist.Clear();
            
            string path = Settings.Instance.path;
            string cleanpath = "Silverfish" + System.IO.Path.DirectorySeparatorChar;
            string datapath = path + "Data" + System.IO.Path.DirectorySeparatorChar;
            string cleandatapath = cleanpath + "Data" + System.IO.Path.DirectorySeparatorChar;
            string classpath = datapath + ownClass + System.IO.Path.DirectorySeparatorChar;
            string cleanclasspath = cleandatapath + ownClass + System.IO.Path.DirectorySeparatorChar;
            string deckpath = classpath + deckName + System.IO.Path.DirectorySeparatorChar;
            string cleandeckpath = cleanclasspath + deckName + System.IO.Path.DirectorySeparatorChar;
            const string filestring = "_mulligan.txt";


            if (deckName != "" && System.IO.File.Exists(deckpath + filestring))
            {
                path = deckpath;
                cleanPath = cleandeckpath + filestring;
            }
            else if (deckName != "" && System.IO.File.Exists(classpath + filestring))
            {
                path = classpath;
                cleanPath = cleanclasspath + filestring;
            }
            else if (deckName != "" && System.IO.File.Exists(datapath + filestring))
            {
                path = datapath;
                cleanPath = cleandatapath + filestring;
            }
            else if (System.IO.File.Exists(path + filestring))
            {
                cleanPath = cleanpath + filestring;
            }
            else
            {
                Helpfunctions.Instance.ErrorLog("[Mulligan] cant find base _mulligan.txt, consider creating one");
                return;
            }
            Helpfunctions.Instance.ErrorLog("[Mulligan] read " + cleanPath);
            
            
            try
            {
                lines = System.IO.File.ReadAllLines(path + "_mulligan.txt");
            }
            catch
            {
                Helpfunctions.Instance.ErrorLog("[Mulligan] _mulligan.txt read error. Continuing without user-defined rules.");
                return;
            }

            foreach (string line in lines)
            {
                string ln = line.Trim();
                if (ln.StartsWith("//")) continue;
                if (ln.Length == 0) continue;

                string entry1 = ln.Split(';')[0];
                if (entry1 == "hold" || entry1 == "discard")
                {
                    addRule(ln);
                }
                else if (entry1 == "None" || CardDB.Instance.cardIdstringToEnum(entry1) != CardDB.cardIDEnum.None)
                {
                    addHBRule(ln);
                }
                else if (entry1 == "loser")
                {
                    loserLoserLoser = true;
                    continue;
                }
                else if (entry1 == "concede:")
                {
                    try
                    {
                        string ownh = ln.Split(':')[1];
                        concedeItem ci = new concedeItem();
                        ci.urhero = Hrtprozis.Instance.heroNametoEnum(ownh);
                        string enemlist = ln.Split(':')[2];
                        foreach (string s in enemlist.Split(','))
                        {
                            ci.enemhero.Add(Hrtprozis.Instance.heroNametoEnum(s));
                        }
                        concedelist.Add(ci);
                    }
                    catch
                    {
                        Helpfunctions.Instance.ErrorLog("[Mulligan] cant read: " + ln);
                    }
                    continue;
                }
                else
                {
                    Helpfunctions.Instance.ErrorLog("[Mulligan] cant read: " + ln);
                }
            }

            if (cardlist.Count > 0) Helpfunctions.Instance.ErrorLog("[Mulligan] " + cardlist.Count + " rules found");
            if (concedelist.Count > 0) Helpfunctions.Instance.ErrorLog("[Mulligan] " + concedelist.Count + " concede rules found");
        }

        private void addRule(string line)
        {
            try
            {
                bool holdrule = (line.Split(';')[0].ToLower() == "hold");
                string ownclass = line.Split(';')[1].ToLower();
                string enemyclass = line.Split(';')[2].ToLower();
                string card = line.Split(';')[3];
                CardDB.cardName cardEnum = CardDB.Instance.cardNamestringToEnum(card);
                if (cardEnum != CardDB.cardName.unknown)
                {
                    card = CardDB.Instance.getCardData(cardEnum).cardIDenum.ToString();
                }
                int coinrule = 0;

                if (line.Split(';').Length >= 5)
                {
                    string coin = line.Split(';')[4];
                    if (coin == "nocoin") coinrule = 1;
                    if (coin == "coin") coinrule = 2;
                }

                if (card.Contains(":"))
                {
                    if ((card.Split(':')).Length == 3)
                    {
                        cardlist.Add(new mulliitem(holdrule, card.Split(':')[0], ownclass, enemyclass, Convert.ToInt32(card.Split(':')[1]), card.Split(':')[2].Split('/'), coinrule, -1));
                    }
                    else
                    {
                        cardlist.Add(new mulliitem(holdrule, card.Split(':')[0], ownclass, enemyclass, Convert.ToInt32(card.Split(':')[1]), null, coinrule, -1));
                    }

                }
                else
                {
                    cardlist.Add(new mulliitem(holdrule, card, ownclass, enemyclass, 2, null, coinrule, -1));
                }

                if (line.Split(';').Length >= 6)
                {
                    string mr = (line.Split(';')[5]);
                    if (mr == "") return;
                    int manarule = Convert.ToInt32(mr);
                    if (manarule <= 0) return;
                    //Console.WriteLine("[Mulligan] found MANA rule: " + mr);
                    cardlist.Add(new mulliitem(holdrule, "#MANARULE", ownclass, enemyclass, 2, null, coinrule, manarule));
                }

            }
            catch
            {
                Helpfunctions.Instance.ErrorLog("[Mulligan] cant read: " + line);
            }
        }

        private void addHBRule(string line)
        {
            try
            {
                string card = line.Split(';')[0];
                string ownclass = line.Split(';')[1].ToLower();
                string enemyclass = line.Split(';')[2].ToLower();
                bool holdrule = (line.Split(';')[3].Split(':')[0].ToLower() == "hold");
                int coinrule = 0;
                
                string reqs = line.Split(';')[4];
                if (reqs.Contains("GAME_005")) coinrule = 2;


                if (reqs != "/")
                {
                    if (reqs.Length < 4) // if length < 4 then it's a manarule
                    {
                        int manarule = Convert.ToInt32(reqs);
                        if (manarule <= 0) return;
                        //Console.WriteLine("[Mulligan] found MANA rule: " + reqs);
                        cardlist.Add(new mulliitem(holdrule, "#MANARULE", ownclass, enemyclass, 2, null, coinrule, manarule));
                    }
                    else
                    {
                        if (line.Split(';')[3].Contains(":"))
                        {
                            cardlist.Add(new mulliitem(holdrule, card, ownclass, enemyclass, Convert.ToInt32(line.Split(';')[3].Split(':')[1]), line.Split(';')[4].Replace(':', '+').Split('/'), coinrule, -1));
                        }
                        else
                        {
                            cardlist.Add(new mulliitem(holdrule, card, ownclass, enemyclass, 2, line.Split(';')[3].Replace(':', '+').Split('/'), coinrule, -1));
                        }
                    }
                }
                else
                {
                    if (line.Split(';')[3].Contains(":"))
                    {
                        cardlist.Add(new mulliitem(holdrule, card, ownclass, enemyclass, Convert.ToInt32(line.Split(';')[3].Split(':')[1]), null, coinrule, -1));
                    }
                    else
                    {
                        cardlist.Add(new mulliitem(holdrule, card, ownclass, enemyclass, 2, null, coinrule, -1));
                    }
                }
            }
            catch
            {
                Helpfunctions.Instance.ErrorLog("[Mulligan] cant read: " + line);
            }
        }

        public bool hasmulliganrules(string ownclass, string enemclass)
        {
            if (cardlist.Count == 0) return false;
            bool hasARule = false;
            foreach (mulliitem mi in cardlist)
            {
                if ((mi.enemyclass == "all" || mi.enemyclass == enemclass) && (mi.ownclass == "all" || mi.ownclass == ownclass)) hasARule = true;
            }
            if (!hasARule) Helpfunctions.Instance.logg("[Mulligan] using default rules for " + ownclass + " vs " + enemclass);
            return hasARule;
        }

        public bool hasHoldListRule(string ownclass, string enemclass)
        {
            bool hasARule = false;
            foreach (mulliitem mi in cardlist)
            {
                if (mi.holdrule && (mi.enemyclass == "all" || mi.enemyclass == enemclass) && (mi.ownclass == "all" || mi.ownclass == ownclass)) hasARule = true;
            }
            return hasARule;
        }

        public List<int> whatShouldIMulligan(List<CardIDEntity> cards, string ownclass, string enemclass, bool hascoin)
        {
            Helpfunctions.Instance.ErrorLog("[Mulligan] do mulligan...");
            if (hascoin)
            {
                Helpfunctions.Instance.ErrorLog("[Mulligan] we hold the coin");
            }
            else
            {
                Helpfunctions.Instance.ErrorLog("[Mulligan] we don't hold the coin");
            }

            List<int> discarditems = new List<int>();
            holdDB.Clear();
            Dictionary<string, int> mullCards = new Dictionary<string, int>(5);
            string mullstring = "";

            for (int i = 0; i < cards.Count; i++)
            {
                CardIDEntity c = cards[i];
                if (mullCards.ContainsKey(c.idstring))
                {
                    mullCards[c.idstring]++;
                }
                else
                {
                    mullCards.Add(c.idstring, 1);
                }
                mullstring += c.idstring;
                if (i + 1 < cards.Count) mullstring += ",";
            }

            mullstring += ";" + ownclass + ";" + enemclass + ";";
            mullstring += (hascoin) ? "coin" : "nocoin";

            Helpfunctions.Instance.logg("[Mulligan] mulltest string: " + mullstring);
            

            foreach (CardIDEntity c in cards)
            {
                setHoldCount(c.idstring, 0); //default hold 0 = discard
                foreach (mulliitem mi in cardlist)
                {
                    if (hascoin && mi.coinrule == 1) continue;
                    if (!hascoin && mi.coinrule == 2) continue;

                    if (mi.cardid == "#MANARULE" && (mi.enemyclass == "all" || mi.enemyclass == enemclass) && (mi.ownclass == "all" || mi.ownclass == ownclass))
                    {
                        if (mi.holdrule)
                        {
                            if (CardDB.Instance.getCardDataFromID(c.id).cost <= mi.manarule)
                            {
                                Helpfunctions.Instance.ErrorLog("[Mulligan] HOLD MANA rule holding: " + c.idstring);
                                setHoldCount(c.idstring, 2);
                            }
                        }
                        else
                        {
                            if (CardDB.Instance.getCardDataFromID(c.id).cost <= mi.manarule)
                            {
                                Helpfunctions.Instance.ErrorLog("[Mulligan] DISCARD MANA rule discarding: " + c.idstring);
                                setHoldCount(c.idstring, -2);
                            }
                            else
                            {
                                Helpfunctions.Instance.ErrorLog("[Mulligan] DISCARD MANA rule holding: " + c.idstring);
                                setHoldCount(c.idstring, 2); //hold 2 so they don't get discarded by default
                            }
                        }
                        continue;
                    }

                    if (c.idstring == mi.cardid && (mi.enemyclass == "all" || mi.enemyclass == enemclass) && (mi.ownclass == "all" || mi.ownclass == ownclass))
                    {
                        if (mi.requiresCard == null)
                        {
                            if (mi.holdrule)
                            {
                                Helpfunctions.Instance.ErrorLog("[Mulligan] HOLD: " + mi.cardid + " x" + mi.count);
                                setHoldCount(mi.cardid, mi.count);
                            }
                            else
                            {
                                Helpfunctions.Instance.ErrorLog("[Mulligan] DISCARD: " + mi.cardid + " x" + mi.count);
                                setHoldCount(mi.cardid, -mi.count);
                            }
                            continue;
                        }
                        else
                        {
                            bool hasReqs = false;

                            foreach (string reqs in mi.requiresCard)
                            {
                                Dictionary<string, int> reqCards = new Dictionary<string, int>();
                                foreach (string req in reqs.Split('+')) //check each card in a "/" subset of requirements
                                {
                                    if (req == "") continue;
                                    string cardid = req.Split(',')[0];
                                    int holdcount = (mi.holdrule) ? 1 : 0;
                                    int reqcount = 1;
                                    if (req.Contains(","))
                                    {
                                        holdcount = Convert.ToInt32(req.Split(',')[1]);
                                        if (req.Split(',').Length == 3)
                                        {
                                            reqcount = Convert.ToInt32(req.Split(',')[2]);
                                        }
                                    }
                                    if (mullCards.ContainsKey(cardid))
                                    {
                                        if (reqcount <= mullCards[cardid])
                                        {
                                            reqCards.Add(cardid, holdcount);
                                        }
                                    }
                                }
                                if (reqs.Split('+').Length == reqCards.Count) //we have a complete set of requirements so stop checking the other sets
                                {
                                    foreach (KeyValuePair<string, int> card in reqCards)
                                    {
                                        if (mi.holdrule)
                                        {
                                            Helpfunctions.Instance.ErrorLog("[Mulligan] HOLD: " + card.Key + " x" + card.Value + ", for: " + mi.cardid + " x" + mi.count);
                                            setHoldCount(card.Key, card.Value);
                                        }
                                        else
                                        {
                                            Helpfunctions.Instance.ErrorLog("[Mulligan] DISCARD: " + card.Key + " x" + card.Value + ", for: " + mi.cardid + " x" + mi.count);
                                            setHoldCount(card.Key, -card.Value);
                                        }
                                    }
                                    hasReqs = true;
                                    break;
                                }
                            }
                            
                            if (hasReqs)
                            {
                                if (mi.holdrule)
                                {
                                    Helpfunctions.Instance.ErrorLog("[Mulligan] HOLD: " + mi.cardid + " x" + mi.count);
                                    setHoldCount(mi.cardid, mi.count);
                                }
                                else
                                {
                                    Helpfunctions.Instance.ErrorLog("[Mulligan] DISCARD: " + mi.cardid + " x" + mi.count);
                                    setHoldCount(mi.cardid, -mi.count);
                                }
                            }
                        }
                    }
                }
            }

            //build the discard list
            string discards = "";
            foreach (CardIDEntity card in cards)
            {
                switch (holdDB[card.idstring])
                {
                    case 2:
                        break;
                    case 1:
                        holdDB[card.idstring] = -2; //discard the next
                        break;
                    case -1:
                        holdDB[card.idstring] = 2; //hold the next
                        discarditems.Add(card.entity);
                        discards += " " + card.idstring;
                        break;
                    case 0:
                    case -2:
                    default:
                        discarditems.Add(card.entity);
                        discards += " " + card.idstring;
                        break;
                }
            }
            Helpfunctions.Instance.logg("[Mulligan] final discards:" + discards);

            return discarditems;

        }

        private void setHoldCount(string cardid, int count)
        {
            //update the max hold count depending on what it currently is
            if (holdDB.ContainsKey(cardid))
            {
                if (holdDB[cardid] != 0 && count == 0) return;
                if (holdDB[cardid] > 0)
                {
                    if (count > 1) holdDB[cardid] = 2;
                    else holdDB[cardid] = count;
                }
                else if (holdDB[cardid] < 0)
                {
                    if (count < -1) holdDB[cardid] = -2;
                    else holdDB[cardid] = count;
                }
                else
                {
                    holdDB[cardid] = count;
                }
            }
            else
            {
                holdDB.Add(cardid, count);
            }
        }

        public void setAutoConcede(bool mode)
        {
            loserLoserLoser = mode;
        }

        public bool shouldConcede(HeroEnum ownhero, HeroEnum enemHero)
        {

            foreach (concedeItem ci in concedelist)
            {
                if (ci.urhero == ownhero && ci.enemhero.Contains(enemHero)) return true;
            }

            return false;
        }

        public void runDebugTest()
        {
            string[] lines = new string[] { };
            try
            {
                string path = Settings.Instance.path;
                lines = System.IO.File.ReadAllLines(path + "mulltest.txt");
            }
            catch
            {
                Helpfunctions.Instance.ErrorLog("[Mulligan] cant find mulltest.txt (only for debugging mulligans)");
                return;
            }
            foreach (string line in lines)
            {
                string ln = line.Trim();
                List<CardIDEntity> cards = new List<CardIDEntity>();

                for (int i = 0; i < ln.Split(';')[0].Split(',').Length; i++)
                {
                    string card = ln.Split(';')[0].Split(',')[i];
                    Helpfunctions.Instance.ErrorLog("[Mulligan] hand contains card: " + card);
                    cards.Add(new CardIDEntity(card, i));
                }
                Instance.whatShouldIMulligan(cards, ln.Split(';')[1], ln.Split(';')[2], (ln.Split(';')[3] == "coin"));
                continue;
            }
        }
    }
}