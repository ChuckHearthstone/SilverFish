using System;
using System.Text;
using System.Linq;
using System.IO;
using System.Collections.Generic;

namespace HREngine.Bots
{
    //!!!	Under test
    //v0.1.2
    /*
     SUMMARY
     1) Comparison operators (=, !=, >, <) !ONLY NUMERIC VALUE!
     (= - equal, != - not equal, > - greater than, < - less than)
     
     tm - turn mana (default mana at this turn);
     am - available mana (at this turn);
     t - turn;
     overload - overload, which can cause a card in the current round;
     owncarddraw - extra carddraw this turn
     ohhp - own hero health points;
     ehhp - enemy hero health points;
     owa - own weapon attack;
     ewa - enemy weapon attack;
     owd - own weapon durability;
     ewd - enemy weapon durability;
     ohc - own hand cards count (the number of cards in own hand);
     ehc - enemy hand cards count (the number of cards in enemy's hand);
     omc - own minions count (the number of own minions on the board);
     emc - enemy minions count (the number of enemy minions on the board);
     For "ohc", "omc" and "emc" you can use these extensions: 
        :Murlocs (the number of own/enemy Murlocs on the board/in own hand)
        :Demons (the number of own/enemy Demons on the board/in own hand)
        :Mechs (the number of own/enemy Mechs on the board/in own hand)
        :Beasts (the number of own/enemy Beasts on the board/in own hand)
        :Totems (the number of own/enemy Totems on the board/in own hand)
        :Pirates (the number of own/enemy Pirates on the board/in own hand)
        :Dragons (the number of own/enemy Dragons on the board/in own hand)
        :Elems (the number of own/enemy Elementals on the board/in own hand)
        :shields (the number of own/enemy shields on the board/in own hand)
        :taunts (the number of own/enemy taunts on the board/in own hand)
     For "ohc" only:
        :Minions (the number of Minions in own hand)
        :Spells (the number of Spells in own hand)
        :Secrets (the number of Secrets in own hand)
        :Weapons (the number of Weapons in own hand)
     For "omc" and "emc" only: 
        :SHR (the number of own/enemy Silver Hand Recruits on the board)
        :undamaged (the number of undamaged own/enemy minions on the board)
        :damaged (the number of damaged own/enemy minions on the board)
    Also you can compare "ohc" with "ehc" and "omc" with "emc"
     Example:   omc>3 - means that you must have more than 3 minions on the board
                omc:Murlocs>3 - means that you must have more than 3 murlocs on the board
                omc>emc - means that you must have more minions than your opponent
     
     2) Boolean operators (=, !=)
     (= - equal/contain; != - not equal/does't contain)
     
     ob - own board (own board must/must not contain this minion (CardID));
     eb - enemy board (enemy board must/must not contain this minion (CardID));
     oh - own hand (own hand must/must not contain this card (CardID));
     ow - own weapon (CardID);
     ew - enemy weapon (CardID);
     ohero - own hero class (ALL, DRUID, HUNTER, MAGE, PALADIN, PRIEST, ROGUE, SHAMAN, WARLOCK, WARRIOR);
     ehero - enemy hero class;
      
     3) Unique:
     coin - must be a coin in hand at turn start;
     !coin - must not be a coin in hand at turn start;
     noduplicates - if your deck contain no duplicates
     p= - play - card in hand that must be played (CardID);
     p2= - play 2 identical cards - 2 identical card in hand that must be played (CardID);
     a= - attacker - minion on board (CardID);
     For "p=" and "p2=" and "a=" you can use these extensions: 
        :pen= (after CardID) - penalty for playing/attacking this card outside of this rule;
        :tgt= - target - target for spell or for minion/weapon (CardID/hero/!hero);
        You can use comparison operators ( =, !=, >, < !ONLY NUMERIC VALUE!) for these parameters:
        :aAt - attacker's attack (mob/hero)
        :aHp - attacker's health points
        :tAt - target's attack
        :tHp - target's health points
     
     4) Condition binding:
     & - And (condition1&condition2 - true only if the condition 1 AND condition 2 are true);
     || - Or (condition1||condition2 - true if the condition 1 is true OR condition 2 is true);
     Example: cond_1 & cond_2||cond_3||cond_4 & cond_5 - true if condition_1 = true And (condition 2 or 3 or 4) = true And condition_5 = true;
     
     5) Extra info (written with a comma)
     bonus=X - if all conditions are TRUE then this Playfield gets this bonus;
         
     */

    public class RulesEngine
    {
        Dictionary<int, Rule> heapOfRules = new Dictionary<int, Rule>();
        Dictionary<int, List<CardDB.cardIDEnum>> RuleCardIdsPlay = new Dictionary<int, List<CardDB.cardIDEnum>>(); 
        Dictionary<int, List<CardDB.cardIDEnum>> RuleCardIdsAttack = new Dictionary<int, List<CardDB.cardIDEnum>>(); 
        Dictionary<int, List<CardDB.cardIDEnum>> RuleCardIdsHand = new Dictionary<int, List<CardDB.cardIDEnum>>(); 
        Dictionary<int, List<CardDB.cardIDEnum>> RuleCardIdsOwnBoard = new Dictionary<int, List<CardDB.cardIDEnum>>(); 
        Dictionary<int, List<CardDB.cardIDEnum>> RuleCardIdsEnemyBoard = new Dictionary<int, List<CardDB.cardIDEnum>>(); 
        Dictionary<int, int> BoardStateRules = new Dictionary<int, int>(); 
        Dictionary<int, int> BoardStateRulesGame = new Dictionary<int, int>(); 
        Dictionary<int, int> BoardStateRulesTurn = new Dictionary<int, int>(); 
        Dictionary<CardDB.cardIDEnum, List<int>> CardIdRules = new Dictionary<CardDB.cardIDEnum, List<int>>();
        Dictionary<CardDB.cardIDEnum, Dictionary<int, int>> CardIdRulesGame = new Dictionary<CardDB.cardIDEnum, Dictionary<int, int>>(); 
        Dictionary<CardDB.cardIDEnum, Dictionary<int, int>> CardIdRulesPlayGame = new Dictionary<CardDB.cardIDEnum, Dictionary<int, int>>(); 
        Dictionary<CardDB.cardIDEnum, Dictionary<int, int>> CardIdRulesHandGame = new Dictionary<CardDB.cardIDEnum, Dictionary<int, int>>(); 
        Dictionary<CardDB.cardIDEnum, Dictionary<int, int>> CardIdRulesOwnBoardGame = new Dictionary<CardDB.cardIDEnum, Dictionary<int, int>>(); 
        Dictionary<CardDB.cardIDEnum, Dictionary<int, int>> CardIdRulesEnemyBoardGame = new Dictionary<CardDB.cardIDEnum, Dictionary<int, int>>(); 
        Dictionary<CardDB.cardIDEnum, Dictionary<int, int>> AttackerIdRulesGame = new Dictionary<CardDB.cardIDEnum, Dictionary<int, int>>(); 
        Dictionary<CardDB.cardIDEnum, List<int>> CardIdRulesTurnPlay = new Dictionary<CardDB.cardIDEnum, List<int>>(); 
        Dictionary<CardDB.cardIDEnum, List<int>> CardIdRulesTurnHand = new Dictionary<CardDB.cardIDEnum, List<int>>();
        Dictionary<TAG_RACE, List<int>> hcRaceRulesGame = new Dictionary<TAG_RACE, List<int>>();
        Dictionary<TAG_RACE, List<int>> hcRaceRulesTurn = new Dictionary<TAG_RACE, List<int>>();
        List<int> pfStateRulesGame = new List<int>();
        Dictionary<TAG_CLASS, Dictionary<int, int>> RuleOwnClass = new Dictionary<TAG_CLASS, Dictionary<int, int>>();
        Dictionary<TAG_CLASS, Dictionary<int, int>> RuleEnemyClass = new Dictionary<TAG_CLASS, Dictionary<int, int>>();
        Dictionary<int, int> replacedRules = new Dictionary<int, int>();
        string pathToRules = "";

        public bool mulliganRulesLoaded = false;
        Dictionary<string, string> MulliganRules = new Dictionary<string, string>();
        Dictionary<string, Dictionary<string, string>> MulliganRulesDB = new Dictionary<string, Dictionary<string, string>>();
        Dictionary<CardDB.cardIDEnum, string> MulliganRulesManual = new Dictionary<CardDB.cardIDEnum, string>();
        Condition condTmp;
        string condErr;
        Minion target;
        int tmp_counter;
        int printRules = Settings.Instance.printRules;

        Hrtprozis prozis = Hrtprozis.Instance;


        public enum param
        {
            None,
            orcond,
            tm_equal,
            tm_notequal,
            tm_greater,
            tm_less,
            am_equal,
            am_notequal,
            am_greater,
            am_less,
            owa_equal,
            owa_notequal,
            owa_greater,
            owa_less,
            ewa_equal,
            ewa_notequal,
            ewa_greater,
            ewa_less,
            owd_equal,
            owd_notequal,
            owd_greater,
            owd_less,
            ewd_equal,
            ewd_notequal,
            ewd_greater,
            ewd_less,
            omc_equal,
            omc_notequal,
            omc_greater,
            omc_less,
            emc_equal,
            emc_notequal,
            emc_greater,
            emc_less,
            omc_equal_emc,
            omc_notequal_emc,
            omc_greater_emc,
            omc_less_emc,
            omc_murlocs_equal,
            omc_murlocs_notequal,
            omc_murlocs_greater,
            omc_murlocs_less,
            emc_murlocs_equal,
            emc_murlocs_notequal,
            emc_murlocs_greater,
            emc_murlocs_less,
            omc_demons_equal,
            omc_demons_notequal,
            omc_demons_greater,
            omc_demons_less,
            emc_demons_equal,
            emc_demons_notequal,
            emc_demons_greater,
            emc_demons_less,
            omc_mechs_equal,
            omc_mechs_notequal,
            omc_mechs_greater,
            omc_mechs_less,
            emc_mechs_equal,
            emc_mechs_notequal,
            emc_mechs_greater,
            emc_mechs_less,
            omc_beasts_equal,
            omc_beasts_notequal,
            omc_beasts_greater,
            omc_beasts_less,
            emc_beasts_equal,
            emc_beasts_notequal,
            emc_beasts_greater,
            emc_beasts_less,
            omc_totems_equal,
            omc_totems_notequal,
            omc_totems_greater,
            omc_totems_less,
            emc_totems_equal,
            emc_totems_notequal,
            emc_totems_greater,
            emc_totems_less,
            omc_pirates_equal,
            omc_pirates_notequal,
            omc_pirates_greater,
            omc_pirates_less,
            emc_pirates_equal,
            emc_pirates_notequal,
            emc_pirates_greater,
            emc_pirates_less,
            omc_Dragons_equal,
            omc_Dragons_notequal,
            omc_Dragons_greater,
            omc_Dragons_less,
            emc_Dragons_equal,
            emc_Dragons_notequal,
            emc_Dragons_greater,
            emc_Dragons_less,
            omc_elems_equal,
            omc_elems_notequal,
            omc_elems_greater,
            omc_elems_less,
            emc_elems_equal,
            emc_elems_notequal,
            emc_elems_greater,
            emc_elems_less,
            omc_shr_equal,
            omc_shr_notequal,
            omc_shr_greater,
            omc_shr_less,
            emc_shr_equal,
            emc_shr_notequal,
            emc_shr_greater,
            emc_shr_less,
            omc_undamaged_equal,
            omc_undamaged_notequal,
            omc_undamaged_greater,
            omc_undamaged_less,
            emc_undamaged_equal,
            emc_undamaged_notequal,
            emc_undamaged_greater,
            emc_undamaged_less,
            omc_damaged_equal,
            omc_damaged_notequal,
            omc_damaged_greater,
            omc_damaged_less,
            emc_damaged_equal,
            emc_damaged_notequal,
            emc_damaged_greater,
            emc_damaged_less,
            omc_shields_equal,
            omc_shields_notequal,
            omc_shields_greater,
            omc_shields_less,
            emc_shields_equal,
            emc_shields_notequal,
            emc_shields_greater,
            emc_shields_less,
            omc_taunts_equal,
            omc_taunts_notequal,
            omc_taunts_greater,
            omc_taunts_less,
            emc_taunts_equal,
            emc_taunts_notequal,
            emc_taunts_greater,
            emc_taunts_less,
            aAt_equal,
            aAt_notequal,
            aAt_greater,
            aAt_less,
            aHp_equal,
            aHp_notequal,
            aHp_greater,
            aHp_less,
            tAt_equal,
            tAt_notequal,
            tAt_greater,
            tAt_less,
            tHp_equal,
            tHp_notequal,
            tHp_greater,
            tHp_less,
            ohc_equal,
            ohc_notequal,
            ohc_greater,
            ohc_less,
            ehc_equal,
            ehc_notequal,
            ehc_greater,
            ehc_less,
            ohc_equal_ehc,
            ohc_notequal_ehc,
            ohc_greater_ehc,
            ohc_less_ehc,
            ohc_minions_equal,
            ohc_minions_notequal,
            ohc_minions_greater,
            ohc_minions_less,
            ohc_spells_equal,
            ohc_spells_notequal,
            ohc_spells_greater,
            ohc_spells_less,
            ohc_secrets_equal,
            ohc_secrets_notequal,
            ohc_secrets_greater,
            ohc_secrets_less,
            ohc_weapons_equal,
            ohc_weapons_notequal,
            ohc_weapons_greater,
            ohc_weapons_less,
            ohc_murlocs_equal,
            ohc_murlocs_notequal,
            ohc_murlocs_greater,
            ohc_murlocs_less,
            ohc_demons_equal,
            ohc_demons_notequal,
            ohc_demons_greater,
            ohc_demons_less,
            ohc_mechs_equal,
            ohc_mechs_notequal,
            ohc_mechs_greater,
            ohc_mechs_less,
            ohc_beasts_equal,
            ohc_beasts_notequal,
            ohc_beasts_greater,
            ohc_beasts_less,
            ohc_totems_equal,
            ohc_totems_notequal,
            ohc_totems_greater,
            ohc_totems_less,
            ohc_pirates_equal,
            ohc_pirates_notequal,
            ohc_pirates_greater,
            ohc_pirates_less,
            ohc_Dragons_equal,
            ohc_Dragons_notequal,
            ohc_Dragons_greater,
            ohc_Dragons_less,
            ohc_elems_equal,
            ohc_elems_notequal,
            ohc_elems_greater,
            ohc_elems_less,
            ohc_shields_equal,
            ohc_shields_notequal,
            ohc_shields_greater,
            ohc_shields_less,
            ohc_taunts_equal,
            ohc_taunts_notequal,
            ohc_taunts_greater,
            ohc_taunts_less,
            turn_equal,
            turn_notequal,
            turn_greater,
            turn_less,
            overload_equal,
            overload_notequal,
            overload_greater,
            overload_less,
            owncarddraw_equal,
            owncarddraw_notequal,
            owncarddraw_greater,
            owncarddraw_less,
            ohhp_equal,
            ohhp_notequal,
            ohhp_greater,
            ohhp_less,
            ehhp_equal,
            ehhp_notequal,
            ehhp_greater,
            ehhp_less,
            ownboard_contain,
            ownboard_notcontain,
            enboard_contain,
            enboard_notcontain,
            ownhand_contain,
            ownhand_notcontain,
            ownweapon_equal,
            ownweapon_notequal,
            enweapon_equal,
            enweapon_notequal,
            ownhero_equal,
            ownhero_notequal,
            enhero_equal,
            enhero_notequal,
            tgt_equal,
            tgt_notequal,
            noduplicates,
            play,
            play2,
            attacker,
            ur,
            rn,
            rr,
            bonus
        }

        public class Condition
        {
            public param parameter = param.None;
            public int num = int.MinValue;
            public TAG_CLASS hClass = TAG_CLASS.INVALID;
            public CardDB.cardIDEnum cardID = CardDB.cardIDEnum.None;
            public int numCards = 0;
            public int bonus = 0;
            public int orCondNum = -1;
            public List<Condition> orConditions = new List<Condition>();
            public List<Condition> extraConditions = new List<Condition>();
            public string parentRule = "";

            public Condition(param paramtr, int pnum, string pRule)
            {
                this.parameter = paramtr;
                this.num = pnum;
                this.parentRule = pRule;
            }
            public Condition(param paramtr, CardDB.cardIDEnum cID, string pRule)
            {
                this.parameter = paramtr;
                this.cardID = cID;
                this.parentRule = pRule;
            }
            public Condition(param paramtr, TAG_CLASS hClas, string pRule)
            {
                this.parameter = paramtr;
                this.hClass = hClas;
                this.parentRule = pRule;
            }
        }

        public class Rule
        {
            public bool ultimateRule = false;
            public int ruleNumber = 0;
            public int replacedRule = 0;
            public int bonus = 0;
            public List<Condition> conditions = new List<Condition>();
        }

        public class actUnit
        {
            public CardDB.cardIDEnum cardID = CardDB.cardIDEnum.None;
            public Action action = null;
            public int entity = -1;

            public actUnit(CardDB.cardIDEnum cid, Action a, int ent)
            {
                this.cardID = cid;
                this.action = a;
                this.entity = ent;
            }
        }

        private static RulesEngine instance;

        public static RulesEngine Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new RulesEngine();
                }
                return instance;
            }
        }

        private RulesEngine()
        {
        }



        public int getRuleWeight(Playfield p)
        {
            int weight = 0;
            List<int> possibleRules = new List<int>();
            possibleRules.AddRange(this.BoardStateRulesTurn.Keys);
            Dictionary<CardDB.cardIDEnum, int> handCardsWRule = new Dictionary<CardDB.cardIDEnum, int>();
            Dictionary<CardDB.cardIDEnum, List<actUnit>> playedCardsWRule = new Dictionary<CardDB.cardIDEnum, List<actUnit>>();
            Dictionary<CardDB.cardIDEnum, int> playedCardsWRulePen = new Dictionary<CardDB.cardIDEnum, int>();
            Dictionary<CardDB.cardIDEnum, List<actUnit>> attackersWRule = new Dictionary<CardDB.cardIDEnum, List<actUnit>>();
            Dictionary<CardDB.cardIDEnum, int> attackersWRulePen = new Dictionary<CardDB.cardIDEnum, int>();
            foreach (Action a in p.playactions)
            {
                CardDB.cardIDEnum cardID = CardDB.cardIDEnum.None;
                switch (a.actionType)
                {
                    case actionEnum.playcard:
                        cardID = a.card.card.cardIDenum;
                        if (CardIdRulesGame.ContainsKey(cardID))
                        {
                            possibleRules.AddRange(CardIdRulesGame[cardID].Keys);
                            if (playedCardsWRule.ContainsKey(cardID))
                            {
                                playedCardsWRule[cardID].Add(new actUnit(cardID, a, a.card.entity));
                            }
                            else
                            {
                                playedCardsWRule.Add(cardID, new List<actUnit> { new actUnit(cardID, a, a.card.entity) });
                                playedCardsWRulePen.Add(cardID, 0);
                            }
                        }
                        break;
                    case actionEnum.attackWithMinion:
                        cardID = a.own.handcard.card.cardIDenum;
                        if (AttackerIdRulesGame.ContainsKey(cardID))
                        {
                            possibleRules.AddRange(AttackerIdRulesGame[cardID].Keys);
                            if (attackersWRule.ContainsKey(cardID))
                            {
                                attackersWRule[cardID].Add(new actUnit(cardID, a, a.own.entitiyID));
                            }
                            else
                            {
                                attackersWRule.Add(cardID, new List<actUnit> { new actUnit(cardID, a, a.own.entitiyID) });
                                attackersWRulePen.Add(cardID, 0);
                            }
                        }
                        break;
                    case actionEnum.attackWithHero: break;
                    case actionEnum.useHeroPower: break;
                }
            }
            if (possibleRules.Count > 0)
            {
                p.rulesUsed = "";
                possibleRules = possibleRules.Distinct().ToList();
                int count = possibleRules.Count;
                for (int i = 0; i < count; i++)
                {
                    int ruleNum = possibleRules[i];
                    bool ruleBroken = false;
                    List<Tuple<Condition, List<actUnit>>> tmpPen = new List<Tuple<Condition, List<actUnit>>>();
                    foreach (Condition cond in heapOfRules[ruleNum].conditions)
                    {
                        if (cond.orCondNum < 0)
                        {
                            switch (cond.parameter)
                            {
                                
                                case param.play:
                                    if (playedCardsWRule.ContainsKey(cond.cardID))
                                    {
                                        tmpPen.Add(new Tuple<Condition, List<actUnit>>(cond, playedCardsWRule[cond.cardID]));
                                        continue;
                                    }
                                    ruleBroken = true;
                                    continue;
                                case param.play2:
                                    if (playedCardsWRule.ContainsKey(cond.cardID))
                                    {
                                        tmpPen.Add(new Tuple<Condition, List<actUnit>>(cond, playedCardsWRule[cond.cardID]));
                                        if (playedCardsWRule[cond.cardID].Count >= 2) continue;
                                    }
                                    ruleBroken = true;
                                    continue;
                                case param.attacker:
                                    if (attackersWRule.ContainsKey(cond.cardID))
                                    {
                                        tmpPen.Add(new Tuple<Condition, List<actUnit>>(cond, attackersWRule[cond.cardID]));
                                        continue;
                                    }
                                    ruleBroken = true;
                                    continue;
                                default:
                                    if (!ruleBroken && checkCondition(cond, p)) continue;
                                    ruleBroken = true;
                                    continue;
                            }
                        }
                        else
                        {
                            bool orCondBroken = true;
                            foreach (Condition orCond in cond.orConditions)
                            {
                                switch (orCond.parameter)
                                {
                                    
                                    case param.play:
                                        if (playedCardsWRule.ContainsKey(orCond.cardID))
                                        {
                                            tmpPen.Add(new Tuple<Condition, List<actUnit>>(orCond, playedCardsWRule[orCond.cardID]));
                                            orCondBroken = false;
                                        }
                                        break;
                                    case param.play2:
                                        if (playedCardsWRule.ContainsKey(orCond.cardID))
                                        {
                                            tmpPen.Add(new Tuple<Condition, List<actUnit>>(orCond, playedCardsWRule[orCond.cardID]));
                                            if (playedCardsWRule[orCond.cardID].Count >= 2) orCondBroken = false;
                                        }
                                        break;
                                    case param.attacker:
                                        if (attackersWRule.ContainsKey(cond.cardID))
                                        {
                                            tmpPen.Add(new Tuple<Condition, List<actUnit>>(cond, attackersWRule[cond.cardID]));
                                            continue;
                                        }
                                        ruleBroken = true;
                                        continue;
                                    default:
                                        if (checkCondition(orCond, p)) orCondBroken = false;
                                        break;
                                }
                                if (!orCondBroken) break;
                            }
                            if (orCondBroken) ruleBroken = true;
                        }
                    }

                    if (ruleBroken)
                    {
                        foreach (Tuple<Condition, List<actUnit>> condPen in tmpPen)
                        {
                            weight += condPen.Item1.bonus;
                            if (this.printRules > 0) p.rulesUsed += -condPen.Item1.bonus + " broken rule:" + condPen.Item1.parentRule + "@";
                        }
                    }
                    else
                    {
                        int tmpPenBonus = 0;
                        foreach (Tuple<Condition, List<actUnit>> condPen in tmpPen)
                        {
                            foreach (actUnit au in condPen.Item2)
                            {
                                bool actRuleBroken = false;
                                if (condPen.Item1.extraConditions.Count > 0)
                                {
                                    foreach (Condition extraCond in condPen.Item1.extraConditions)
                                    {
                                        if (checkCondition(extraCond, p, au.action)) continue;
                                        actRuleBroken = true;
                                        tmpPenBonus -= condPen.Item1.bonus;
                                        if (this.printRules > 0) p.rulesUsed += -condPen.Item1.bonus + " broken extra condition:" + condPen.Item1.parentRule + "@"; 
                                        break;
                                    }
                                }
                                if (!actRuleBroken)
                                {
                                    tmpPenBonus += heapOfRules[ruleNum].bonus;
                                    if (this.printRules > 0) p.rulesUsed += heapOfRules[ruleNum].bonus + " " + condPen.Item1.parentRule + "@";
                                }
                            }
                        }
                        if (tmpPen.Count > 0) weight -= tmpPenBonus;
                        else
                        {
                            weight -= heapOfRules[ruleNum].bonus;
                            if (this.printRules > 0)
                            {
                                string ruleStr = "no conditions";
                                if (heapOfRules[ruleNum].conditions.Count > 0) ruleStr = heapOfRules[ruleNum].conditions[0].parentRule;
                                p.rulesUsed += heapOfRules[ruleNum].bonus + ruleStr + "@";
                            }
                        }
                    }
                }
            }
            p.ruleWeight = weight;
            return weight;
        }

        public void setCardIdRulesGame(TAG_CLASS ohc, TAG_CLASS ehc)
        {
            CardIdRulesGame.Clear();
            CardIdRulesPlayGame.Clear();
            CardIdRulesHandGame.Clear();
            CardIdRulesOwnBoardGame.Clear();
            CardIdRulesEnemyBoardGame.Clear();
            AttackerIdRulesGame.Clear();
            var sdf = heapOfRules;
            if (RuleOwnClass.ContainsKey(ohc) && RuleEnemyClass.ContainsKey(ehc))
            {
                foreach (int ruleNum in RuleOwnClass[ohc].Keys)
                {
                    if (RuleEnemyClass[ehc].ContainsKey(ruleNum))
                    {
                        if (RuleCardIdsPlay.ContainsKey(ruleNum)) addCardIdRulesGame(RuleCardIdsPlay, CardIdRulesPlayGame, ruleNum);
                        if (RuleCardIdsAttack.ContainsKey(ruleNum)) addAttackerIdRulesGame(ruleNum);
                        if (BoardStateRules.ContainsKey(ruleNum) && !BoardStateRulesGame.ContainsKey(ruleNum)) BoardStateRulesGame.Add(ruleNum, 0);
                    }
                }
            }
            if (RuleOwnClass.ContainsKey(ohc) && RuleEnemyClass.ContainsKey(TAG_CLASS.ALL))
            {
                foreach (int ruleNum in RuleOwnClass[ohc].Keys)
                {
                    if (RuleEnemyClass[TAG_CLASS.ALL].ContainsKey(ruleNum))
                    {
                        if (RuleCardIdsPlay.ContainsKey(ruleNum)) addCardIdRulesGame(RuleCardIdsPlay, CardIdRulesPlayGame, ruleNum);
                        if (RuleCardIdsAttack.ContainsKey(ruleNum)) addAttackerIdRulesGame(ruleNum);
                        if (BoardStateRules.ContainsKey(ruleNum) && !BoardStateRulesGame.ContainsKey(ruleNum)) BoardStateRulesGame.Add(ruleNum, 0);
                    }
                }
            }
            if (RuleOwnClass.ContainsKey(TAG_CLASS.ALL) && RuleEnemyClass.ContainsKey(ehc))
            {
                foreach (int ruleNum in RuleEnemyClass[ehc].Keys)
                {
                    if (RuleOwnClass[TAG_CLASS.ALL].ContainsKey(ruleNum))
                    {
                        if (RuleCardIdsPlay.ContainsKey(ruleNum)) addCardIdRulesGame(RuleCardIdsPlay, CardIdRulesPlayGame, ruleNum);
                        if (RuleCardIdsAttack.ContainsKey(ruleNum)) addAttackerIdRulesGame(ruleNum);
                        if (BoardStateRules.ContainsKey(ruleNum) && !BoardStateRulesGame.ContainsKey(ruleNum)) BoardStateRulesGame.Add(ruleNum, 0);
                    }
                }
            }
            if (RuleOwnClass.ContainsKey(TAG_CLASS.ALL) && RuleEnemyClass.ContainsKey(TAG_CLASS.ALL))
            {
                foreach (int ruleNum in RuleOwnClass[TAG_CLASS.ALL].Keys)
                {
                    if (RuleEnemyClass[TAG_CLASS.ALL].ContainsKey(ruleNum))
                    {
                        if (RuleCardIdsPlay.ContainsKey(ruleNum)) addCardIdRulesGame(RuleCardIdsPlay, CardIdRulesPlayGame, ruleNum);
                        if (RuleCardIdsAttack.ContainsKey(ruleNum)) addAttackerIdRulesGame(ruleNum);
                        if (BoardStateRules.ContainsKey(ruleNum) && !BoardStateRulesGame.ContainsKey(ruleNum)) BoardStateRulesGame.Add(ruleNum, 0);
                    }
                }
            }
        }

        private void addCardIdRulesGame(Dictionary<int, List<CardDB.cardIDEnum>> baseDct, Dictionary<CardDB.cardIDEnum, Dictionary<int, int>> targetDct, int ruleNum)
        {
            foreach (CardDB.cardIDEnum cid in baseDct[ruleNum])
            {
                if (targetDct.ContainsKey(cid))
                {
                    if (replacedRules.ContainsKey(ruleNum))
                    {
                        var oldRules = targetDct[cid];
                        if (oldRules.ContainsKey(replacedRules[ruleNum])) oldRules.Remove(replacedRules[ruleNum]);
                    }
                    if (!targetDct[cid].ContainsKey(ruleNum)) targetDct[cid].Add(ruleNum, 0);
                }
                else targetDct.Add(cid, new Dictionary<int, int>() { { ruleNum, 0 } });
            }

            foreach (CardDB.cardIDEnum cid in baseDct[ruleNum])
            {
                if (CardIdRulesGame.ContainsKey(cid))
                {
                    if (replacedRules.ContainsKey(ruleNum))
                    {
                        var oldRules = CardIdRulesGame[cid];
                        if (oldRules.ContainsKey(replacedRules[ruleNum])) oldRules.Remove(replacedRules[ruleNum]);
                    }
                    if (!CardIdRulesGame[cid].ContainsKey(ruleNum)) CardIdRulesGame[cid].Add(ruleNum, 0);
                }
                else CardIdRulesGame.Add(cid, new Dictionary<int, int>() { { ruleNum, 0 } });
            }
        }

        private void addAttackerIdRulesGame(int ruleNum)
        {
            foreach (CardDB.cardIDEnum cid in RuleCardIdsAttack[ruleNum])
            {
                if (AttackerIdRulesGame.ContainsKey(cid))
                {
                    if (replacedRules.ContainsKey(ruleNum))
                    {
                        var oldRules = AttackerIdRulesGame[cid];
                        if (oldRules.ContainsKey(replacedRules[ruleNum])) oldRules.Remove(replacedRules[ruleNum]);
                    }
                    if (!AttackerIdRulesGame[cid].ContainsKey(ruleNum)) AttackerIdRulesGame[cid].Add(ruleNum, 0);
                }
                else AttackerIdRulesGame.Add(cid, new Dictionary<int, int>() { { ruleNum, 0 } });
            }
        }

        public void setRulesTurn(int gTurn)
        {
            BoardStateRulesTurn.Clear();
            foreach (int rNum in BoardStateRulesGame.Keys)
            {
                bool gonext = false;
                bool noturnrule = true;
                foreach (Condition cond in heapOfRules[rNum].conditions)
                {
                    if (gonext) break;
                    if (cond.orCondNum < 0)
                    {
                        switch (cond.parameter)
                        {
                            case param.turn_equal:
                                noturnrule = false;
                                if (gTurn == cond.num)
                                {
                                    BoardStateRulesTurn.Add(rNum, 0);
                                    gonext = true;
                                }
                                continue;
                            case param.turn_notequal:
                                noturnrule = false;
                                if (gTurn == cond.num)
                                {
                                    if (BoardStateRulesTurn.ContainsKey(gTurn)) BoardStateRulesTurn.Remove(gTurn);
                                    gonext = true;
                                }
                                continue;
                            case param.turn_greater:
                                noturnrule = false;
                                if (gTurn > cond.num) BoardStateRulesTurn.Add(rNum, 0);
                                continue;
                            case param.turn_less:
                                noturnrule = false;
                                if (gTurn < cond.num) BoardStateRulesTurn.Add(rNum, 0);
                                continue;
                        }
                    }
                    else
                    {
                        foreach (Condition orCond in cond.orConditions)
                        {
                            switch (cond.parameter)
                            {
                                case param.turn_equal:
                                    noturnrule = false;
                                    if (gTurn == cond.num)
                                    {
                                        BoardStateRulesTurn.Add(rNum, 0);
                                        gonext = true;
                                    }
                                    continue;
                                case param.turn_notequal:
                                    noturnrule = false;
                                    if (gTurn == cond.num)
                                    {
                                        if (BoardStateRulesTurn.ContainsKey(gTurn)) BoardStateRulesTurn.Remove(gTurn);
                                        gonext = true;
                                    }
                                    continue;
                                case param.turn_greater:
                                    noturnrule = false;
                                    if (gTurn > cond.num) BoardStateRulesTurn.Add(rNum, 0);
                                    continue;
                                case param.turn_less:
                                    noturnrule = false;
                                    if (gTurn < cond.num) BoardStateRulesTurn.Add(rNum, 0);
                                    continue;
                            }
                        }
                    }
                }
                if (noturnrule) BoardStateRulesTurn.Add(rNum, 0);
            }
        }

        public void readRules(string behavName, bool nameIsPath = false)
        {
            pathToRules = behavName;
            if (!nameIsPath)
            {
                if (MulliganRulesDB.ContainsKey(behavName))
                {
                    MulliganRules = MulliganRulesDB[behavName];
                    mulliganRulesLoaded = true;
                    return;
                }

                if (!Silverfish.Instance.BehaviorPath.ContainsKey(behavName))
                {
                    Helpfunctions.Instance.ErrorLog(behavName + ": no special rules.");
                    return;
                }
                pathToRules = Path.Combine(Silverfish.Instance.BehaviorPath[behavName], "_rules.txt");
            }

            if (!System.IO.File.Exists(pathToRules))
            {
                Helpfunctions.Instance.ErrorLog(behavName + ": no special rules.");
                return;
            }
            try
            {
                string[] lines = System.IO.File.ReadAllLines(pathToRules);
                string tmps;
                bool getNextRule;
                MulliganRules.Clear();
                List<Rule> rulesList = new List<Rule>();
                foreach (string s in lines)
                {
                    getNextRule = false;
                    if (s == "" || s == null) continue;
                    if (s.StartsWith("//")) continue;
                    string[] preRule = s.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                    Rule oneRule = new Rule();
                    List<Condition> conditions = new List<Condition>();
                    int orCondNum = 1;
                    foreach (string ss in preRule)
                    {
                        if (getNextRule) break;
                        String[] tmp = ss.Split('=');
                        string condition = tmp[0];
                        switch (condition)
                        {
                            case "ur":
                                oneRule.ultimateRule = true;
                                continue;
                            case "rn":
                                try { oneRule.ruleNumber = Convert.ToInt32(tmp[1]); }
                                catch
                                {
                                    Helpfunctions.Instance.ErrorLog("[RulesEngine] Wrong rule number (must be a number): " + ss);
                                    getNextRule = true;
                                }
                                continue;
                            case "rr":
                                try { oneRule.replacedRule = Convert.ToInt32(tmp[1]); }
                                catch
                                {
                                    Helpfunctions.Instance.ErrorLog("[RulesEngine] Wrong replaced rule number (must be a number): " + ss);
                                    getNextRule = true;
                                }
                                continue;
                            case "bonus":
                                try { oneRule.bonus = Convert.ToInt32(tmp[1]); }
                                catch
                                {
                                    Helpfunctions.Instance.ErrorLog("[RulesEngine] Wrong bonus (must be a number): " + ss);
                                    getNextRule = true;
                                }
                                continue;
                            default:
                                String[] condAnd = ss.Split('&');
                                foreach (string singlecondAnd in condAnd)
                                {
                                    if (getNextRule) break;
                                    if (singlecondAnd.Contains("|"))
                                    {
                                        tmps = singlecondAnd.Replace("||", "|");
                                        String[] condOr = tmps.Split('|');
                                        Condition orCondidion = new Condition(param.orcond, condOr.Count(), (this.printRules == 0) ? "" : s);
                                        orCondidion.orCondNum = orCondNum;
                                        foreach (string singlecondOr in condOr)
                                        {
                                            if (!validateCondition(singlecondOr, s))
                                            {
                                                Helpfunctions.Instance.ErrorLog("[RulesEngine] " + condErr + singlecondOr);
                                                getNextRule = true;
                                            }
                                            if (getNextRule) break;
                                            condTmp.orCondNum = orCondNum;
                                            orCondidion.orConditions.Add(condTmp);
                                        }
                                        conditions.Add(orCondidion);
                                        orCondNum++;
                                        continue;
                                    }
                                    if (validateCondition(singlecondAnd, s))
                                    {
                                        conditions.Add(condTmp);
                                        continue;
                                    }
                                    else
                                    {
                                        Helpfunctions.Instance.ErrorLog("[RulesEngine] " + condErr + singlecondAnd);
                                        getNextRule = true;
                                    }
                                }
                                continue;
                        }
                    }
                    if (getNextRule) continue;
                    oneRule.conditions = conditions;
                    rulesList.Add(oneRule);
                }

                heapOfRules.Clear();
                replacedRules.Clear();
                foreach (Rule r in rulesList) 
                {
                    if (r.ruleNumber == 0) continue;
                    if (heapOfRules.ContainsKey(r.ruleNumber))
                    {
                        Helpfunctions.Instance.ErrorLog("[RulesEngine] Rule rejected. Duplicate numbers: rn=" + r.ruleNumber);
                    }
                    else
                    {
                        heapOfRules.Add(r.ruleNumber, r);
                    }
                }

                Dictionary<int, Rule> tmpRules = new Dictionary<int, Rule>();
                int i = 1;
                foreach (Rule r in rulesList) 
                {
                    if (r.ruleNumber != 0) continue;
                    while (heapOfRules.ContainsKey(i)) i++;
                    r.ruleNumber = i;
                    tmpRules.Add(i, r);
                    i++;
                }
                foreach (Rule r in rulesList) 
                {
                    if (r.replacedRule == 0) continue;
                    if (heapOfRules.ContainsKey(r.replacedRule))
                    {
                        replacedRules.Add(r.ruleNumber, r.replacedRule);
                    }
                    else
                    {
                        Helpfunctions.Instance.ErrorLog("[RulesEngine] No rule to replace: rr=" + r.replacedRule);
                        r.replacedRule = 0;
                    }
                }
                foreach (var r in tmpRules) 
                {
                    if (heapOfRules.ContainsKey(r.Key))
                    {
                        Helpfunctions.Instance.ErrorLog("[RulesEngine] Replaced rule rejected. Duplicate numbers: rr=" + r.Key);
                    }
                    else heapOfRules.Add(r.Key, r.Value);
                }

                Dictionary<TAG_CLASS, int> equalOwnHeroes = new Dictionary<TAG_CLASS, int>();
                Dictionary<TAG_CLASS, int> notequalOwnHeroes = new Dictionary<TAG_CLASS, int>();
                Dictionary<TAG_CLASS, int> equalEnHeroes = new Dictionary<TAG_CLASS, int>();
                Dictionary<TAG_CLASS, int> notequalEnHeroes = new Dictionary<TAG_CLASS, int>();

                foreach (var r in heapOfRules)
                {
                    equalOwnHeroes.Clear();
                    notequalOwnHeroes.Clear();
                    equalEnHeroes.Clear();
                    notequalEnHeroes.Clear();
                    foreach (Condition cond in getAllCondList(r.Value.conditions))
                    {
                        switch (cond.parameter)
                        {
                            case param.ownhero_equal:
                                if (equalOwnHeroes.ContainsKey(cond.hClass)) equalOwnHeroes[cond.hClass]++;
                                else equalOwnHeroes.Add(cond.hClass, 1);
                                continue;
                            case param.ownhero_notequal:
                                if (notequalOwnHeroes.ContainsKey(cond.hClass)) notequalOwnHeroes[cond.hClass]++;
                                else notequalOwnHeroes.Add(cond.hClass, 1);
                                continue;
                            case param.enhero_equal:
                                if (equalEnHeroes.ContainsKey(cond.hClass)) equalEnHeroes[cond.hClass]++;
                                else equalEnHeroes.Add(cond.hClass, 1);
                                continue;
                            case param.enhero_notequal:
                                if (notequalEnHeroes.ContainsKey(cond.hClass)) notequalEnHeroes[cond.hClass]++;
                                else notequalEnHeroes.Add(cond.hClass, 1);
                                continue;
                        }
                    }
                    if (equalOwnHeroes.Count > 0 || notequalOwnHeroes.Count > 0)
                    {
                        foreach (TAG_CLASS hClass in Enum.GetValues(typeof(TAG_CLASS)))
                        {
                            if (hClass == TAG_CLASS.INVALID || hClass == TAG_CLASS.ALL) continue;
                            if (equalOwnHeroes.ContainsKey(hClass))
                            {
                                if (equalOwnHeroes[hClass] > 1) Helpfunctions.Instance.ErrorLog("[RulesEngine] Double own Hero class (equal): " + hClass);
                                if (notequalOwnHeroes.ContainsKey(hClass)) Helpfunctions.Instance.ErrorLog("[RulesEngine] The same equal/notequal own Hero class: " + hClass);
                                if (RuleOwnClass.ContainsKey(hClass)) RuleOwnClass[hClass].Add(r.Key, 0); 
                                else RuleOwnClass.Add(hClass, new Dictionary<int, int>() { { r.Key, 0 } });
                            }
                            else if (equalOwnHeroes.Count < 1)
                            {
                                if (!notequalOwnHeroes.ContainsKey(hClass))
                                {
                                    if (notequalOwnHeroes[hClass] > 1) Helpfunctions.Instance.ErrorLog("[RulesEngine] Double own Hero class (notequal): " + hClass);
                                    if (RuleOwnClass.ContainsKey(hClass)) RuleOwnClass[hClass].Add(r.Key, 0); 
                                    else RuleOwnClass.Add(hClass, new Dictionary<int, int>() { { r.Key, 0 } });
                                }
                            }
                        }
                    }
                    else
                    {
                        if (RuleOwnClass.ContainsKey(TAG_CLASS.ALL)) RuleOwnClass[TAG_CLASS.ALL].Add(r.Key, 0); 
                        else RuleOwnClass.Add(TAG_CLASS.ALL, new Dictionary<int, int>() { { r.Key, 0 } });
                    }
                    if (equalEnHeroes.Count > 0 || notequalEnHeroes.Count > 0)
                    {
                        foreach (TAG_CLASS hClass in Enum.GetValues(typeof(TAG_CLASS)))
                        {
                            if (hClass == TAG_CLASS.INVALID || hClass == TAG_CLASS.ALL) continue;
                            if (equalEnHeroes.ContainsKey(hClass))
                            {
                                if (equalEnHeroes[hClass] > 1) Helpfunctions.Instance.ErrorLog("[RulesEngine] Double enemy Hero class (equal): " + hClass);
                                if (notequalEnHeroes.ContainsKey(hClass)) Helpfunctions.Instance.ErrorLog("[RulesEngine] The same equal/notequal enemy Hero class: " + hClass);
                                if (RuleEnemyClass.ContainsKey(hClass)) RuleEnemyClass[hClass].Add(r.Key, 0); 
                                else RuleEnemyClass.Add(hClass, new Dictionary<int, int>() { { r.Key, 0 } });
                            }
                            else if (equalEnHeroes.Count < 1)
                            {
                                if (!notequalEnHeroes.ContainsKey(hClass))
                                {
                                    if (notequalEnHeroes[hClass] > 1) Helpfunctions.Instance.ErrorLog("[RulesEngine] Double enemy Hero class (notequal): " + hClass);
                                    if (RuleEnemyClass.ContainsKey(hClass)) RuleEnemyClass[hClass].Add(r.Key, 0); 
                                    else RuleEnemyClass.Add(hClass, new Dictionary<int, int>() { { r.Key, 0 } });
                                }
                            }
                        }
                    }
                    else
                    {
                        if (RuleEnemyClass.ContainsKey(TAG_CLASS.ALL)) RuleEnemyClass[TAG_CLASS.ALL].Add(r.Key, 0); 
                        else RuleEnemyClass.Add(TAG_CLASS.ALL, new Dictionary<int, int>() { { r.Key, 0 } });
                    }
                }
            }
            catch (Exception ee)
            {
                Helpfunctions.Instance.ErrorLog("[RulesEngine] _rules.txt - read error. We continue without user-defined rules. Only the default rules.");
                return;
            }

            Helpfunctions.Instance.ErrorLog("[RulesEngine] " + heapOfRules.Count + " rules for " + behavName + " loaded successfully");
            setRuleCardIds();
        }

        private List<Condition> getAllCondList(List<Condition> tmp)
        {
            List<Condition> allCondList = new List<Condition>();
            foreach (Condition cond in tmp)
            {
                if (cond.parameter == param.orcond) allCondList.AddRange(cond.orConditions);
                else allCondList.Add(cond);
            }
            return allCondList;
        }

        public void setRuleCardIds()
        {
            RuleCardIdsPlay.Clear();
            RuleCardIdsHand.Clear();
            RuleCardIdsOwnBoard.Clear();
            RuleCardIdsEnemyBoard.Clear();
            RuleCardIdsAttack.Clear();
            foreach (var oneRule in heapOfRules)
            {
                bool stateRule = false;
                bool playRule = false;
                List<CardDB.cardIDEnum> IDsListPlay = new List<CardDB.cardIDEnum>();
                List<CardDB.cardIDEnum> IDsListHand = new List<CardDB.cardIDEnum>();
                List<CardDB.cardIDEnum> IDsListOB = new List<CardDB.cardIDEnum>();
                List<CardDB.cardIDEnum> IDsListEB = new List<CardDB.cardIDEnum>();
                List<CardDB.cardIDEnum> IDsListAttack = new List<CardDB.cardIDEnum>();
                foreach (Condition cond in getAllCondList(oneRule.Value.conditions))
                {
                    switch (cond.parameter)
                    {
                        case param.play:
                            IDsListPlay.Add(cond.cardID);
                            playRule = true;
                            continue;
                        case param.play2:
                            IDsListPlay.Add(cond.cardID);
                            playRule = true;
                            continue;
                        case param.attacker:
                            IDsListAttack.Add(cond.cardID);
                            playRule = true;
                            continue;
                        case param.ownhero_equal:
                            continue;
                        case param.ownhero_notequal:
                            continue;
                        case param.enhero_equal:
                            continue;
                        case param.enhero_notequal:
                            continue;
                        case param.ownhand_contain:
                            IDsListHand.Add(cond.cardID);
                            stateRule = true;
                            continue;
                        case param.ownhand_notcontain:
                            IDsListHand.Add(cond.cardID);
                            stateRule = true;
                            continue;
                        case param.ownboard_contain:
                            IDsListOB.Add(cond.cardID);
                            stateRule = true;
                            continue;
                        case param.ownboard_notcontain:
                            IDsListOB.Add(cond.cardID);
                            stateRule = true;
                            continue;
                        case param.enboard_contain:
                            IDsListEB.Add(cond.cardID);
                            stateRule = true;
                            continue;
                        case param.enboard_notcontain:
                            IDsListEB.Add(cond.cardID);
                            stateRule = true;
                            continue;
                        default:
                            continue;
                    }
                }
                if (IDsListPlay.Count > 0) RuleCardIdsPlay.Add(oneRule.Key, IDsListPlay.Distinct().ToList());
                if (IDsListHand.Count > 0) RuleCardIdsHand.Add(oneRule.Key, IDsListHand);
                if (IDsListOB.Count > 0) RuleCardIdsOwnBoard.Add(oneRule.Key, IDsListOB);
                if (IDsListEB.Count > 0) RuleCardIdsEnemyBoard.Add(oneRule.Key, IDsListEB);
                if (IDsListAttack.Count > 0) RuleCardIdsAttack.Add(oneRule.Key, IDsListAttack);
                if ((playRule && stateRule) || !playRule) BoardStateRules.Add(oneRule.Key, 0);
            }
        }


        private bool validateCondition(string singlecond, string ruleString)
        {
            switch (singlecond)
            {
                case "omc=emc": condTmp = new Condition(param.omc_equal_emc, 0, (this.printRules == 0) ? "" : ruleString); return true;
                case "omc!=emc": condTmp = new Condition(param.omc_notequal_emc, 0, (this.printRules == 0) ? "" : ruleString); return true;
                case "omc>emc": condTmp = new Condition(param.omc_greater_emc, 0, (this.printRules == 0) ? "" : ruleString); return true;
                case "omc<emc": condTmp = new Condition(param.omc_less_emc, 0, (this.printRules == 0) ? "" : ruleString); return true;
                case "ohc=ehc": condTmp = new Condition(param.ohc_equal_ehc, 0, (this.printRules == 0) ? "" : ruleString); return true;  
                case "ohc!=ehc": condTmp = new Condition(param.ohc_notequal_ehc, 0, (this.printRules == 0) ? "" : ruleString); return true;
                case "ohc>ehc": condTmp = new Condition(param.ohc_greater_ehc, 0, (this.printRules == 0) ? "" : ruleString); return true;
                case "ohc<ehc": condTmp = new Condition(param.ohc_less_ehc, 0, (this.printRules == 0) ? "" : ruleString); return true;
            }

            condErr = "";
            String[] tmp;
            String[] extraParam = new string[0];
            string parameter = "";
            param condParam = param.None;
            string pval = "";
            int pvaltype = 0;


            if (singlecond.StartsWith("p="))
            {
                extraParam = singlecond.Split(':');
                singlecond = extraParam[0];
            }
            else if (singlecond.StartsWith("a="))
            {
                extraParam = singlecond.Split(':');
                singlecond = extraParam[0];
            }

            getSinglecond(singlecond, out tmp, out parameter);

            if (tmp.Length == 2)
            {
                switch (tmp[1])
                {
                    case "coin":
                        pval = "GAME_005";
                        break;
                    case "!coin":
                        pval = "GAME_005";
                        break;
                    default:
                        pval = tmp[1];
                        break;
                }
            }
            else if (tmp.Length == 1)
            {
                switch (tmp[0])
                {
                    case "noduplicates":
                        condTmp = new Condition(param.noduplicates, 0, (this.printRules == 0) ? "" : ruleString);
                        return true;
                    default:
                        condErr = "Wrong condition: ";
                        return false;
                }
            }
            else
            {
                condErr = "Wrong condition: ";
                return false;
            }

            parameter = (tmp[0] + parameter).ToLower();
            switch (parameter)
            {
                case "tm=": condParam = param.tm_equal; break; 
                case "tm!=": condParam = param.tm_notequal; break;
                case "tm>": condParam = param.tm_greater; break;
                case "tm<": condParam = param.tm_less; break;
                case "am=": condParam = param.am_equal; break; 
                case "am!=": condParam = param.am_notequal; break;
                case "am>": condParam = param.am_greater; break;
                case "am<": condParam = param.am_less; break;
                case "owa=": condParam = param.owa_equal; break; 
                case "owa!=": condParam = param.owa_notequal; break;
                case "owa>": condParam = param.owa_greater; break;
                case "owa<": condParam = param.owa_less; break;
                case "ewa=": condParam = param.ewa_equal; break; 
                case "ewa!=": condParam = param.ewa_notequal; break;
                case "ewa>": condParam = param.ewa_greater; break;
                case "ewa<": condParam = param.ewa_less; break;
                case "owd=": condParam = param.owd_equal; break; 
                case "owd!=": condParam = param.owd_notequal; break;
                case "owd>": condParam = param.owd_greater; break;
                case "owd<": condParam = param.owd_less; break;
                case "ewd=": condParam = param.ewd_equal; break; 
                case "ewd!=": condParam = param.ewd_notequal; break;
                case "ewd>": condParam = param.ewd_greater; break;
                case "ewd<": condParam = param.ewd_less; break;
                case "omc=": condParam = param.omc_equal; break; 
                case "omc!=": condParam = param.omc_notequal; break;
                case "omc>": condParam = param.omc_greater; break;
                case "omc<": condParam = param.omc_less; break;
                case "emc=": condParam = param.emc_equal; break; 
                case "emc!=": condParam = param.emc_notequal; break;
                case "emc>": condParam = param.emc_greater; break;
                case "emc<": condParam = param.emc_less; break;

                case "omc:murlocs=": condParam = param.omc_murlocs_equal; break;
                case "omc:murlocs!=": condParam = param.omc_murlocs_notequal; break;
                case "omc:murlocs>": condParam = param.omc_murlocs_greater; break;
                case "omc:murlocs<": condParam = param.omc_murlocs_less; break;
                case "emc:murlocs=": condParam = param.emc_murlocs_equal; break;
                case "emc:murlocs!=": condParam = param.emc_murlocs_notequal; break;
                case "emc:murlocs>": condParam = param.emc_murlocs_greater; break;
                case "emc:murlocs<": condParam = param.emc_murlocs_less; break;
                case "omc:demons=": condParam = param.omc_demons_equal; break;
                case "omc:demons!=": condParam = param.omc_demons_notequal; break;
                case "omc:demons>": condParam = param.omc_demons_greater; break;
                case "omc:demons<": condParam = param.omc_demons_less; break;
                case "emc:demons=": condParam = param.emc_demons_equal; break;
                case "emc:demons!=": condParam = param.emc_demons_notequal; break;
                case "emc:demons>": condParam = param.emc_demons_greater; break;
                case "emc:demons<": condParam = param.emc_demons_less; break;
                case "omc:mechs=": condParam = param.omc_mechs_equal; break;
                case "omc:mechs!=": condParam = param.omc_mechs_notequal; break;
                case "omc:mechs>": condParam = param.omc_mechs_greater; break;
                case "omc:mechs<": condParam = param.omc_mechs_less; break;
                case "emc:mechs=": condParam = param.emc_mechs_equal; break;
                case "emc:mechs!=": condParam = param.emc_mechs_notequal; break;
                case "emc:mechs>": condParam = param.emc_mechs_greater; break;
                case "emc:mechs<": condParam = param.emc_mechs_less; break;
                case "omc:beasts=": condParam = param.omc_beasts_equal; break;
                case "omc:beasts!=": condParam = param.omc_beasts_notequal; break;
                case "omc:beasts>": condParam = param.omc_beasts_greater; break;
                case "omc:beasts<": condParam = param.omc_beasts_less; break;
                case "emc:beasts=": condParam = param.emc_beasts_equal; break;
                case "emc:beasts!=": condParam = param.emc_beasts_notequal; break;
                case "emc:beasts>": condParam = param.emc_beasts_greater; break;
                case "emc:beasts<": condParam = param.emc_beasts_less; break;
                case "omc:totems=": condParam = param.omc_totems_equal; break;
                case "omc:totems!=": condParam = param.omc_totems_notequal; break;
                case "omc:totems>": condParam = param.omc_totems_greater; break;
                case "omc:totems<": condParam = param.omc_totems_less; break;
                case "emc:totems=": condParam = param.emc_totems_equal; break;
                case "emc:totems!=": condParam = param.emc_totems_notequal; break;
                case "emc:totems>": condParam = param.emc_totems_greater; break;
                case "emc:totems<": condParam = param.emc_totems_less; break;
                case "omc:pirates=": condParam = param.omc_pirates_equal; break;
                case "omc:pirates!=": condParam = param.omc_pirates_notequal; break;
                case "omc:pirates>": condParam = param.omc_pirates_greater; break;
                case "omc:pirates<": condParam = param.omc_pirates_less; break;
                case "emc:pirates=": condParam = param.emc_pirates_equal; break;
                case "emc:pirates!=": condParam = param.emc_pirates_notequal; break;
                case "emc:pirates>": condParam = param.emc_pirates_greater; break;
                case "emc:pirates<": condParam = param.emc_pirates_less; break;
                case "omc:Dragons=": condParam = param.omc_Dragons_equal; break;
                case "omc:Dragons!=": condParam = param.omc_Dragons_notequal; break;
                case "omc:Dragons>": condParam = param.omc_Dragons_greater; break;
                case "omc:Dragons<": condParam = param.omc_Dragons_less; break;
                case "emc:Dragons=": condParam = param.emc_Dragons_equal; break;
                case "emc:Dragons!=": condParam = param.emc_Dragons_notequal; break;
                case "emc:Dragons>": condParam = param.emc_Dragons_greater; break;
                case "emc:Dragons<": condParam = param.emc_Dragons_less; break;
                case "omc:elems=": condParam = param.omc_elems_equal; break;
                case "omc:elems!=": condParam = param.omc_elems_notequal; break;
                case "omc:elems>": condParam = param.omc_elems_greater; break;
                case "omc:elems<": condParam = param.omc_elems_less; break;
                case "emc:elems=": condParam = param.emc_elems_equal; break;
                case "emc:elems!=": condParam = param.emc_elems_notequal; break;
                case "emc:elems>": condParam = param.emc_elems_greater; break;
                case "emc:elems<": condParam = param.emc_elems_less; break;
                case "omc:shr=": condParam = param.omc_shr_equal; break;
                case "omc:shr!=": condParam = param.omc_shr_notequal; break;
                case "omc:shr>": condParam = param.omc_shr_greater; break;
                case "omc:shr<": condParam = param.omc_shr_less; break;
                case "emc:shr=": condParam = param.emc_shr_equal; break;
                case "emc:shr!=": condParam = param.emc_shr_notequal; break;
                case "emc:shr>": condParam = param.emc_shr_greater; break;
                case "emc:shr<": condParam = param.emc_shr_less; break;
                case "omc:undamaged=": condParam = param.omc_undamaged_equal; break;
                case "omc:undamaged!=": condParam = param.omc_undamaged_notequal; break;
                case "omc:undamaged>": condParam = param.omc_undamaged_greater; break;
                case "omc:undamaged<": condParam = param.omc_undamaged_less; break;
                case "emc:undamaged=": condParam = param.emc_undamaged_equal; break;
                case "emc:undamaged!=": condParam = param.emc_undamaged_notequal; break;
                case "emc:undamaged>": condParam = param.emc_undamaged_greater; break;
                case "emc:undamaged<": condParam = param.emc_undamaged_less; break;
                case "omc:damaged=": condParam = param.omc_damaged_equal; break;
                case "omc:damaged!=": condParam = param.omc_damaged_notequal; break;
                case "omc:damaged>": condParam = param.omc_damaged_greater; break;
                case "omc:damaged<": condParam = param.omc_damaged_less; break;
                case "emc:damaged=": condParam = param.emc_damaged_equal; break;
                case "emc:damaged!=": condParam = param.emc_damaged_notequal; break;
                case "emc:damaged>": condParam = param.emc_damaged_greater; break;
                case "emc:damaged<": condParam = param.emc_damaged_less; break;
                case "omc:shields=": condParam = param.omc_shields_equal; break;
                case "omc:shields!=": condParam = param.omc_shields_notequal; break;
                case "omc:shields>": condParam = param.omc_shields_greater; break;
                case "omc:shields<": condParam = param.omc_shields_less; break;
                case "emc:shields=": condParam = param.emc_shields_equal; break;
                case "emc:shields!=": condParam = param.emc_shields_notequal; break;
                case "emc:shields>": condParam = param.emc_shields_greater; break;
                case "emc:shields<": condParam = param.emc_shields_less; break;
                case "omc:taunts=": condParam = param.omc_taunts_equal; break;
                case "omc:taunts!=": condParam = param.omc_taunts_notequal; break;
                case "omc:taunts>": condParam = param.omc_taunts_greater; break;
                case "omc:taunts<": condParam = param.omc_taunts_less; break;
                case "emc:taunts=": condParam = param.emc_taunts_equal; break;
                case "emc:taunts!=": condParam = param.emc_taunts_notequal; break;
                case "emc:taunts>": condParam = param.emc_taunts_greater; break;
                case "emc:taunts<": condParam = param.emc_taunts_less; break;
                case "ohc=": condParam = param.ohc_equal; break; 
                case "ohc!=": condParam = param.ohc_notequal; break;
                case "ohc>": condParam = param.ohc_greater; break;
                case "ohc<": condParam = param.ohc_less; break;
                case "ehc=": condParam = param.ehc_equal; break; 
                case "ehc!=": condParam = param.ehc_notequal; break;
                case "ehc>": condParam = param.ehc_greater; break;
                case "ehc<": condParam = param.ehc_less; break;
                //+extensions:
                case "ohc:minions=": condParam = param.ohc_minions_equal; break;
                case "ohc:minions!=": condParam = param.ohc_minions_notequal; break;
                case "ohc:minions>": condParam = param.ohc_minions_greater; break;
                case "ohc:minions<": condParam = param.ohc_minions_less; break;
                case "ohc:spells=": condParam = param.ohc_spells_equal; break;
                case "ohc:spells!=": condParam = param.ohc_spells_notequal; break;
                case "ohc:spells>": condParam = param.ohc_spells_greater; break;
                case "ohc:spells<": condParam = param.ohc_spells_less; break;
                case "ohc:secrets=": condParam = param.ohc_secrets_equal; break;
                case "ohc:secrets!=": condParam = param.ohc_secrets_notequal; break;
                case "ohc:secrets>": condParam = param.ohc_secrets_greater; break;
                case "ohc:secrets<": condParam = param.ohc_secrets_less; break;
                case "ohc:weapons=": condParam = param.ohc_weapons_equal; break;
                case "ohc:weapons!=": condParam = param.ohc_weapons_notequal; break;
                case "ohc:weapons>": condParam = param.ohc_weapons_greater; break;
                case "ohc:weapons<": condParam = param.ohc_weapons_less; break;
                case "ohc:murlocs=": condParam = param.ohc_murlocs_equal; break;
                case "ohc:murlocs!=": condParam = param.ohc_murlocs_notequal; break;
                case "ohc:murlocs>": condParam = param.ohc_murlocs_greater; break;
                case "ohc:murlocs<": condParam = param.ohc_murlocs_less; break;
                case "ohc:demons=": condParam = param.ohc_demons_equal; break;
                case "ohc:demons!=": condParam = param.ohc_demons_notequal; break;
                case "ohc:demons>": condParam = param.ohc_demons_greater; break;
                case "ohc:demons<": condParam = param.ohc_demons_less; break;
                case "ohc:mechs=": condParam = param.ohc_mechs_equal; break;
                case "ohc:mechs!=": condParam = param.ohc_mechs_notequal; break;
                case "ohc:mechs>": condParam = param.ohc_mechs_greater; break;
                case "ohc:mechs<": condParam = param.ohc_mechs_less; break;
                case "ohc:beasts=": condParam = param.ohc_beasts_equal; break;
                case "ohc:beasts!=": condParam = param.ohc_beasts_notequal; break;
                case "ohc:beasts>": condParam = param.ohc_beasts_greater; break;
                case "ohc:beasts<": condParam = param.ohc_beasts_less; break;
                case "ohc:totems=": condParam = param.ohc_totems_equal; break;
                case "ohc:totems!=": condParam = param.ohc_totems_notequal; break;
                case "ohc:totems>": condParam = param.ohc_totems_greater; break;
                case "ohc:totems<": condParam = param.ohc_totems_less; break;
                case "ohc:pirates=": condParam = param.ohc_pirates_equal; break;
                case "ohc:pirates!=": condParam = param.ohc_pirates_notequal; break;
                case "ohc:pirates>": condParam = param.ohc_pirates_greater; break;
                case "ohc:pirates<": condParam = param.ohc_pirates_less; break;
                case "ohc:Dragons=": condParam = param.ohc_Dragons_equal; break;
                case "ohc:Dragons!=": condParam = param.ohc_Dragons_notequal; break;
                case "ohc:Dragons>": condParam = param.ohc_Dragons_greater; break;
                case "ohc:Dragons<": condParam = param.ohc_Dragons_less; break;
                case "ohc:elems=": condParam = param.ohc_elems_equal; break;
                case "ohc:elems!=": condParam = param.ohc_elems_notequal; break;
                case "ohc:elems>": condParam = param.ohc_elems_greater; break;
                case "ohc:elems<": condParam = param.ohc_elems_less; break;
                case "ohc:shields=": condParam = param.ohc_shields_equal; break;
                case "ohc:shields!=": condParam = param.ohc_shields_notequal; break;
                case "ohc:shields>": condParam = param.ohc_shields_greater; break;
                case "ohc:shields<": condParam = param.ohc_shields_less; break;
                case "ohc:taunts=": condParam = param.ohc_taunts_equal; break;
                case "ohc:taunts!=": condParam = param.ohc_taunts_notequal; break;
                case "ohc:taunts>": condParam = param.ohc_taunts_greater; break;
                case "ohc:taunts<": condParam = param.ohc_taunts_less; break;
                case "t=": condParam = param.turn_equal; break; 
                case "t!=": condParam = param.turn_notequal; break;
                case "t>": condParam = param.turn_greater; break;
                case "t<": condParam = param.turn_less; break;
                case "overload=": condParam = param.overload_equal; break; 
                case "overload!=": condParam = param.overload_notequal; break;
                case "overload>": condParam = param.overload_greater; break;
                case "overload<": condParam = param.overload_less; break;
                case "owncarddraw=": condParam = param.owncarddraw_equal; break;
                case "owncarddraw!=": condParam = param.owncarddraw_notequal; break;
                case "owncarddraw>": condParam = param.owncarddraw_greater; break;
                case "owncarddraw<": condParam = param.owncarddraw_less; break;
                case "ohhp=": condParam = param.ohhp_equal; break;
                case "ohhp!=": condParam = param.ohhp_notequal; break;
                case "ohhp>": condParam = param.ohhp_greater; break;
                case "ohhp<": condParam = param.ohhp_less; break;
                case "ehhp=": condParam = param.ehhp_equal; break; 
                case "ehhp!=": condParam = param.ehhp_notequal; break;
                case "ehhp>": condParam = param.ehhp_greater; break;
                case "ehhp<": condParam = param.ehhp_less; break;

                case "ob=": condParam = param.ownboard_contain; pvaltype = 1; break; 
                case "ob!=": condParam = param.ownboard_notcontain; pvaltype = 1; break;
                case "eb=": condParam = param.enboard_contain; pvaltype = 1; break; 
                case "eb!=": condParam = param.enboard_notcontain; pvaltype = 1; break;
                case "oh=": condParam = param.ownhand_contain; pvaltype = 1; break; 
                case "oh!=": condParam = param.ownhand_notcontain; pvaltype = 1; break;
                case "ow=": condParam = param.ownweapon_equal; pvaltype = 1; break; 
                case "ow!=": condParam = param.ownweapon_notequal; pvaltype = 1; break;
                case "ew=": condParam = param.enweapon_equal; pvaltype = 1; break; 
                case "ew!=": condParam = param.enweapon_notequal; pvaltype = 1; break;
                case "ohero=": condParam = param.ownhero_equal; pvaltype = 2; break; 
                case "ohero!=": condParam = param.ownhero_notequal; pvaltype = 2; break;
                case "ehero=": condParam = param.enhero_equal; pvaltype = 2; break; 
                case "ehero!=": condParam = param.enhero_notequal; pvaltype = 2; break;

                case "p=": condParam = param.play; pvaltype = 1; 
                    break;
                case "p2=": condParam = param.play2; pvaltype = 1; 
                    break;
                case "a=": condParam = param.attacker; pvaltype = 1; 
                    break;
                default:
                    condErr = "Wrong parameter: ";
                    return false;
            }

            bool returnRes = false;
            switch (pvaltype)
            {
                case 0:
                    try
                    {
                        condTmp = new Condition(condParam, Convert.ToInt32(pval), (this.printRules == 0) ? "" : ruleString);
                        returnRes = true;
                    }
                    catch
                    {
                        condErr = "Wrong parameter value (must be a number): ";
                        returnRes = false;
                    }
                    break;
                case 1:
                    CardDB.cardIDEnum cardId = CardDB.Instance.cardIdstringToEnum(pval);
                    if (cardId == CardDB.cardIDEnum.None)
                    {
                        condErr = "Wrong CardID: ";
                        returnRes = false;
                    }
                    else
                    {
                        condTmp = new Condition(condParam, cardId, (this.printRules == 0) ? "" : ruleString);
                        returnRes = true;
                    }
                    break;
                case 2:
                    TAG_CLASS hClass = prozis.heroEnumtoTagClass(prozis.heroNametoEnum(pval.ToLower()));
                    if (hClass == TAG_CLASS.INVALID)
                    {
                        condErr = "Wrong Hero Class: ";
                        returnRes = false;
                    }
                    else
                    {
                        condTmp = new Condition(condParam, hClass, (this.printRules == 0) ? "" : ruleString);
                        returnRes = true;
                    }
                    break;
            }
            if (extraParam.Count() > 1 && returnRes)
            {
                List<Condition> extraConds = new List<Condition>();
                int extraParamCount = extraParam.Count();
                for (int i = 1; i < extraParamCount; i++)
                {
                    getSinglecond(extraParam[i], out tmp, out parameter);
                    
                    int pvalInt = 0;
                    CardDB.cardIDEnum pvalCardId = CardDB.cardIDEnum.None;
                    try
                    {
                        switch (tmp[0])
                        {
                            case "tgt":
                                pvalCardId = CardDB.Instance.cardIdstringToEnum(tmp[1]);
                                if (pvalCardId == CardDB.cardIDEnum.None)
                                {
                                    condErr = "Wrong CardID: ";
                                    returnRes = false;
                                }
                                break;
                            default:
                                pvalInt = Convert.ToInt32(tmp[1]);
                                break;
                        }
                    }
                    catch
                    {
                        condErr = "Wrong extra parameter: ";
                        return false;
                    }

                    switch (tmp[0] + parameter)
                    {
                        case "pen=": condTmp.bonus = pvalInt; continue;
                        case "aAt=": condParam = param.aAt_equal; break; 
                        case "aAt!=": condParam = param.aAt_notequal; break;
                        case "aAt>": condParam = param.aAt_greater; break;
                        case "aAt<": condParam = param.aAt_less; break;
                        case "aHp=": condParam = param.aHp_equal; break; 
                        case "aHp!=": condParam = param.aHp_notequal; break;
                        case "aHp>": condParam = param.aHp_greater; break;
                        case "aHp<": condParam = param.aHp_less; break;
                        case "tAt=": condParam = param.tAt_equal; break; 
                        case "tAt!=": condParam = param.tAt_notequal; break;
                        case "tAt>": condParam = param.tAt_greater; break;
                        case "tAt<": condParam = param.tAt_less; break;
                        case "tHp=": condParam = param.tHp_equal; break; 
                        case "tHp!=": condParam = param.tHp_notequal; break;
                        case "tHp>": condParam = param.tHp_greater; break;
                        case "tHp<": condParam = param.tHp_less; break;
                        case "tgt=": condParam = param.tgt_equal; break;
                        case "tgt!=": condParam = param.tgt_notequal; break;
                        default:
                            condErr = "Wrong extra parameter: ";
                            return false;
                    }
                    if (tmp[0] == "tgt") extraConds.Add(new Condition(condParam, pvalCardId, (this.printRules == 0) ? "" : ruleString));
                    else extraConds.Add(new Condition(condParam, pvalInt, (this.printRules == 0) ? "" : ruleString));
                }
                condTmp.extraConditions.AddRange(extraConds);
            }
            return returnRes;
        }

        private void getSinglecond(string singlecond, out String[] tmp, out string parameter)
        {
            parameter = "";
            if (singlecond.Contains("!="))
            {
                tmp = singlecond.Split(new string[] { "!=" }, StringSplitOptions.RemoveEmptyEntries);
                parameter = "!=";
            }
            else if (singlecond.Contains("="))
            {
                tmp = singlecond.Split('=');
                parameter = "=";
            }
            else if (singlecond.Contains(">"))
            {
                tmp = singlecond.Split('>');
                parameter = ">";
            }
            else if (singlecond.Contains("<"))
            {
                tmp = singlecond.Split('<');
                parameter = "<";
            }
            else tmp = singlecond.Split('=');
        }

        private bool checkCondition(Condition cond, Playfield p, Action a = null)
        {
            condErr = "";
            switch (cond.parameter)
            {
                case param.tm_equal: 
                    if (p.ownMaxMana == cond.num) return true;
                    return false;
                case param.tm_notequal:
                    if (p.ownMaxMana != cond.num) return true;
                    return false;
                case param.tm_greater:
                    if (p.ownMaxMana > cond.num) return true;
                    return false;
                case param.tm_less:
                    if (p.ownMaxMana < cond.num) return true;
                    return false;
                case param.am_equal: 
                    if (p.mana == cond.num) return true;
                    return false;
                case param.am_notequal:
                    if (p.mana != cond.num) return true;
                    return false;
                case param.am_greater:
                    if (p.mana > cond.num) return true;
                    return false;
                case param.am_less:
                    if (p.mana < cond.num) return true;
                    return false;
                case param.owa_equal: 
                    if (p.ownWeapon.Angr== cond.num) return true;
                    return false;
                case param.owa_notequal:
                    if (p.ownWeapon.Angr!= cond.num) return true;
                    return false;
                case param.owa_greater:
                    if (p.ownWeapon.Angr> cond.num) return true;
                    return false;
                case param.owa_less:
                    if (p.ownWeapon.Angr< cond.num) return true;
                    return false;
                case param.ewa_equal: 
                    if (p.enemyWeapon.Angr == cond.num) return true;
                    return false;
                case param.ewa_notequal:
                    if (p.enemyWeapon.Angr != cond.num) return true;
                    return false;
                case param.ewa_greater:
                    if (p.enemyWeapon.Angr > cond.num) return true;
                    return false;
                case param.ewa_less:
                    if (p.enemyWeapon.Angr < cond.num) return true;
                    return false;
                case param.owd_equal: 
                    if (p.ownWeapon.Durability == cond.num) return true;
                    return false;
                case param.owd_notequal:
                    if (p.ownWeapon.Durability != cond.num) return true;
                    return false;
                case param.owd_greater:
                    if (p.ownWeapon.Durability > cond.num) return true;
                    return false;
                case param.owd_less:
                    if (p.ownWeapon.Durability < cond.num) return true;
                    return false;
                case param.ewd_equal: 
                    if (p.enemyWeapon.Durability == cond.num) return true;
                    return false;
                case param.ewd_notequal:
                    if (p.enemyWeapon.Durability != cond.num) return true;
                    return false;
                case param.ewd_greater:
                    if (p.enemyWeapon.Durability > cond.num) return true;
                    return false;
                case param.ewd_less:
                    if (p.enemyWeapon.Durability < cond.num) return true;
                    return false;
                case param.omc_equal: 
                    if (p.ownMinions.Count == cond.num) return true;
                    return false;
                case param.omc_notequal:
                    if (p.ownMinions.Count != cond.num) return true;
                    return false;
                case param.omc_greater:
                    if (p.ownMinions.Count > cond.num) return true;
                    return false;
                case param.omc_less:
                    if (p.ownMinions.Count < cond.num) return true;
                    return false;
                case param.emc_equal: 
                    if (p.enemyMinions.Count == cond.num) return true;
                    return false;
                case param.emc_notequal:
                    if (p.enemyMinions.Count != cond.num) return true;
                    return false;
                case param.emc_greater:
                    if (p.enemyMinions.Count > cond.num) return true;
                    return false;
                case param.emc_less:
                    if (p.enemyMinions.Count < cond.num) return true;
                    return false;
                case param.omc_equal_emc: 
                    if (p.ownMinions.Count == p.enemyMinions.Count) return true;
                    return false;
                case param.omc_notequal_emc:
                    if (p.ownMinions.Count != p.enemyMinions.Count) return true;
                    return false;
                case param.omc_greater_emc:
                    if (p.ownMinions.Count > p.enemyMinions.Count) return true;
                    return false;
                case param.omc_less_emc:
                    if (p.ownMinions.Count < p.enemyMinions.Count) return true;
                    return false;
                case param.ohc_equal: 
                    if (p.owncards.Count == cond.num) return true;
                    return false;
                case param.ohc_notequal:
                    if (p.owncards.Count != cond.num) return true;
                    return false;
                case param.ohc_greater:
                    if (p.owncards.Count > cond.num) return true;
                    return false;
                case param.ohc_less:
                    if (p.owncards.Count < cond.num) return true;
                    return false;
                case param.ehc_equal: 
                    if (p.enemyAnzCards == cond.num) return true;
                    return false;
                case param.ehc_notequal:
                    if (p.enemyAnzCards != cond.num) return true;
                    return false;
                case param.ehc_greater:
                    if (p.enemyAnzCards > cond.num) return true;
                    return false;
                case param.ehc_less:
                    if (p.enemyAnzCards < cond.num) return true;
                    return false;
                case param.ohc_equal_ehc:
	                if (p.owncards.Count == p.enemyAnzCards) return true;
	                return false;
                case param.ohc_notequal_ehc:
	                if (p.owncards.Count != p.enemyAnzCards) return true;
	                return false;
                case param.ohc_greater_ehc:
	                if (p.owncards.Count > p.enemyAnzCards) return true;
	                return false;
                case param.ohc_less_ehc:
	                if (p.owncards.Count < p.enemyAnzCards) return true;
	                return false;
                case param.ohc_minions_equal:
                    tmp_counter = 0;
                    foreach (Handmanager.Handcard hc in p.owncards) if (hc.card.type == CardDB.cardtype.MOB) tmp_counter++;
                    if (tmp_counter == cond.num) return true;
                    return false;
                case param.ohc_minions_notequal:
                    tmp_counter = 0;
                    foreach (Handmanager.Handcard hc in p.owncards) if (hc.card.type == CardDB.cardtype.MOB) tmp_counter++;
                    if (tmp_counter != cond.num) return true;
                    return false;
                case param.ohc_minions_greater:
                    tmp_counter = 0;
                    foreach (Handmanager.Handcard hc in p.owncards) if (hc.card.type == CardDB.cardtype.MOB) tmp_counter++;
                    if (tmp_counter > cond.num) return true;
                    return false;
                case param.ohc_minions_less:
                    tmp_counter = 0;
                    foreach (Handmanager.Handcard hc in p.owncards) if (hc.card.type == CardDB.cardtype.MOB) tmp_counter++;
                    if (tmp_counter < cond.num) return true;
                    return false;
                case param.ohc_spells_equal:
                    tmp_counter = 0;
                    foreach (Handmanager.Handcard hc in p.owncards) if (hc.card.type == CardDB.cardtype.SPELL) tmp_counter++;
                    if (tmp_counter == cond.num) return true;
                    return false;
                case param.ohc_spells_notequal:
                    tmp_counter = 0;
                    foreach (Handmanager.Handcard hc in p.owncards) if (hc.card.type == CardDB.cardtype.SPELL) tmp_counter++;
                    if (tmp_counter != cond.num) return true;
                    return false;
                case param.ohc_spells_greater:
                    tmp_counter = 0;
                    foreach (Handmanager.Handcard hc in p.owncards) if (hc.card.type == CardDB.cardtype.SPELL) tmp_counter++;
                    if (tmp_counter > cond.num) return true;
                    return false;
                case param.ohc_spells_less:
                    tmp_counter = 0;
                    foreach (Handmanager.Handcard hc in p.owncards) if (hc.card.type == CardDB.cardtype.SPELL) tmp_counter++;
                    if (tmp_counter < cond.num) return true;
                    return false;
                case param.ohc_secrets_equal:
                    tmp_counter = 0;
                    foreach (Handmanager.Handcard hc in p.owncards) if (hc.card.Secret) tmp_counter++;
                    if (tmp_counter == cond.num) return true;
                    return false;
                case param.ohc_secrets_notequal:
                    tmp_counter = 0;
                    foreach (Handmanager.Handcard hc in p.owncards) if (hc.card.Secret) tmp_counter++;
                    if (tmp_counter != cond.num) return true;
                    return false;
                case param.ohc_secrets_greater:
                    tmp_counter = 0;
                    foreach (Handmanager.Handcard hc in p.owncards) if (hc.card.Secret) tmp_counter++;
                    if (tmp_counter > cond.num) return true;
                    return false;
                case param.ohc_secrets_less:
                    tmp_counter = 0;
                    foreach (Handmanager.Handcard hc in p.owncards) if (hc.card.Secret) tmp_counter++;
                    if (tmp_counter < cond.num) return true;
                    return false;
                case param.ohc_weapons_equal:
                    tmp_counter = 0;
                    foreach (Handmanager.Handcard hc in p.owncards) if (hc.card.type == CardDB.cardtype.WEAPON) tmp_counter++;
                    if (tmp_counter == cond.num) return true;
                    return false;
                case param.ohc_weapons_notequal:
                    tmp_counter = 0;
                    foreach (Handmanager.Handcard hc in p.owncards) if (hc.card.type == CardDB.cardtype.WEAPON) tmp_counter++;
                    if (tmp_counter != cond.num) return true;
                    return false;
                case param.ohc_weapons_greater:
                    tmp_counter = 0;
                    foreach (Handmanager.Handcard hc in p.owncards) if (hc.card.type == CardDB.cardtype.WEAPON) tmp_counter++;
                    if (tmp_counter > cond.num) return true;
                    return false;
                case param.ohc_weapons_less:
                    tmp_counter = 0;
                    foreach (Handmanager.Handcard hc in p.owncards) if (hc.card.type == CardDB.cardtype.WEAPON) tmp_counter++;
                    if (tmp_counter < cond.num) return true;
                    return false;
                case param.ohc_murlocs_equal:
                    tmp_counter = 0;
                    foreach (Handmanager.Handcard hc in p.owncards) if ((TAG_RACE)hc.card.race == TAG_RACE.MURLOC) tmp_counter++;
                    if (tmp_counter == cond.num) return true;
                    return false;
                case param.ohc_murlocs_notequal:
                    tmp_counter = 0;
                    foreach (Handmanager.Handcard hc in p.owncards) if ((TAG_RACE)hc.card.race == TAG_RACE.MURLOC) tmp_counter++;
                    if (tmp_counter != cond.num) return true;
                    return false;
                case param.ohc_murlocs_greater:
                    tmp_counter = 0;
                    foreach (Handmanager.Handcard hc in p.owncards) if ((TAG_RACE)hc.card.race == TAG_RACE.MURLOC) tmp_counter++;
                    if (tmp_counter > cond.num) return true;
                    return false;
                case param.ohc_murlocs_less:
                    tmp_counter = 0;
                    foreach (Handmanager.Handcard hc in p.owncards) if ((TAG_RACE)hc.card.race == TAG_RACE.MURLOC) tmp_counter++;
                    if (tmp_counter < cond.num) return true;
                    return false;
                case param.ohc_demons_equal:
                    tmp_counter = 0;
                    foreach (Handmanager.Handcard hc in p.owncards) if ((TAG_RACE)hc.card.race == TAG_RACE.DEMON) tmp_counter++;
                    if (tmp_counter == cond.num) return true;
                    return false;
                case param.ohc_demons_notequal:
                    tmp_counter = 0;
                    foreach (Handmanager.Handcard hc in p.owncards) if ((TAG_RACE)hc.card.race == TAG_RACE.DEMON) tmp_counter++;
                    if (tmp_counter != cond.num) return true;
                    return false;
                case param.ohc_demons_greater:
                    tmp_counter = 0;
                    foreach (Handmanager.Handcard hc in p.owncards) if ((TAG_RACE)hc.card.race == TAG_RACE.DEMON) tmp_counter++;
                    if (tmp_counter > cond.num) return true;
                    return false;
                case param.ohc_demons_less:
                    tmp_counter = 0;
                    foreach (Handmanager.Handcard hc in p.owncards) if ((TAG_RACE)hc.card.race == TAG_RACE.DEMON) tmp_counter++;
                    if (tmp_counter < cond.num) return true;
                    return false;
                case param.ohc_mechs_equal:
                    tmp_counter = 0;
                    foreach (Handmanager.Handcard hc in p.owncards) if ((TAG_RACE)hc.card.race == TAG_RACE.MECHANICAL) tmp_counter++;
                    if (tmp_counter == cond.num) return true;
                    return false;
                case param.ohc_mechs_notequal:
                    tmp_counter = 0;
                    foreach (Handmanager.Handcard hc in p.owncards) if ((TAG_RACE)hc.card.race == TAG_RACE.MECHANICAL) tmp_counter++;
                    if (tmp_counter != cond.num) return true;
                    return false;
                case param.ohc_mechs_greater:
                    tmp_counter = 0;
                    foreach (Handmanager.Handcard hc in p.owncards) if ((TAG_RACE)hc.card.race == TAG_RACE.MECHANICAL) tmp_counter++;
                    if (tmp_counter > cond.num) return true;
                    return false;
                case param.ohc_mechs_less:
                    tmp_counter = 0;
                    foreach (Handmanager.Handcard hc in p.owncards) if ((TAG_RACE)hc.card.race == TAG_RACE.MECHANICAL) tmp_counter++;
                    if (tmp_counter < cond.num) return true;
                    return false;
                case param.ohc_beasts_equal:
                    tmp_counter = 0;
                    foreach (Handmanager.Handcard hc in p.owncards) if ((TAG_RACE)hc.card.race == TAG_RACE.PET) tmp_counter++;
                    if (tmp_counter == cond.num) return true;
                    return false;
                case param.ohc_beasts_notequal:
                    tmp_counter = 0;
                    foreach (Handmanager.Handcard hc in p.owncards) if ((TAG_RACE)hc.card.race == TAG_RACE.PET) tmp_counter++;
                    if (tmp_counter != cond.num) return true;
                    return false;
                case param.ohc_beasts_greater:
                    tmp_counter = 0;
                    foreach (Handmanager.Handcard hc in p.owncards) if ((TAG_RACE)hc.card.race == TAG_RACE.PET) tmp_counter++;
                    if (tmp_counter > cond.num) return true;
                    return false;
                case param.ohc_beasts_less:
                    tmp_counter = 0;
                    foreach (Handmanager.Handcard hc in p.owncards) if ((TAG_RACE)hc.card.race == TAG_RACE.PET) tmp_counter++;
                    if (tmp_counter < cond.num) return true;
                    return false;
                case param.ohc_totems_equal:
                    tmp_counter = 0;
                    foreach (Handmanager.Handcard hc in p.owncards) if ((TAG_RACE)hc.card.race == TAG_RACE.TOTEM) tmp_counter++;
                    if (tmp_counter == cond.num) return true;
                    return false;
                case param.ohc_totems_notequal:
                    tmp_counter = 0;
                    foreach (Handmanager.Handcard hc in p.owncards) if ((TAG_RACE)hc.card.race == TAG_RACE.TOTEM) tmp_counter++;
                    if (tmp_counter != cond.num) return true;
                    return false;
                case param.ohc_totems_greater:
                    tmp_counter = 0;
                    foreach (Handmanager.Handcard hc in p.owncards) if ((TAG_RACE)hc.card.race == TAG_RACE.TOTEM) tmp_counter++;
                    if (tmp_counter > cond.num) return true;
                    return false;
                    tmp_counter = 0;
                    foreach (Handmanager.Handcard hc in p.owncards) if ((TAG_RACE)hc.card.race == TAG_RACE.TOTEM) tmp_counter++;
                    if (tmp_counter < cond.num) return true;
                    return false;
                case param.ohc_pirates_equal:
                    tmp_counter = 0;
                    foreach (Handmanager.Handcard hc in p.owncards) if ((TAG_RACE)hc.card.race == TAG_RACE.PIRATE) tmp_counter++;
                    if (tmp_counter == cond.num) return true;
                    return false;
                case param.ohc_pirates_notequal:
                    tmp_counter = 0;
                    foreach (Handmanager.Handcard hc in p.owncards) if ((TAG_RACE)hc.card.race == TAG_RACE.PIRATE) tmp_counter++;
                    if (tmp_counter != cond.num) return true;
                    return false;
                case param.ohc_pirates_greater:
                    tmp_counter = 0;
                    foreach (Handmanager.Handcard hc in p.owncards) if ((TAG_RACE)hc.card.race == TAG_RACE.PIRATE) tmp_counter++;
                    if (tmp_counter > cond.num) return true;
                    return false;
                case param.ohc_pirates_less:
                    tmp_counter = 0;
                    foreach (Handmanager.Handcard hc in p.owncards) if ((TAG_RACE)hc.card.race == TAG_RACE.PIRATE) tmp_counter++;
                    if (tmp_counter < cond.num) return true;
                    return false;
                case param.ohc_Dragons_equal:
                    tmp_counter = 0;
                    foreach (Handmanager.Handcard hc in p.owncards) if ((TAG_RACE)hc.card.race == TAG_RACE.DRAGON) tmp_counter++;
                    if (tmp_counter == cond.num) return true;
                    return false;
                case param.ohc_Dragons_notequal:
                    tmp_counter = 0;
                    foreach (Handmanager.Handcard hc in p.owncards) if ((TAG_RACE)hc.card.race == TAG_RACE.DRAGON) tmp_counter++;
                    if (tmp_counter != cond.num) return true;
                    return false;
                case param.ohc_Dragons_greater:
                    tmp_counter = 0;
                    foreach (Handmanager.Handcard hc in p.owncards) if ((TAG_RACE)hc.card.race == TAG_RACE.DRAGON) tmp_counter++;
                    if (tmp_counter > cond.num) return true;
                    return false;
                case param.ohc_Dragons_less:
                    tmp_counter = 0;
                    foreach (Handmanager.Handcard hc in p.owncards) if ((TAG_RACE)hc.card.race == TAG_RACE.DRAGON) tmp_counter++;
                    if (tmp_counter < cond.num) return true;
                    return false;
                case param.ohc_elems_equal:
                    tmp_counter = 0;
                    foreach (Handmanager.Handcard hc in p.owncards) if ((TAG_RACE)hc.card.race == TAG_RACE.ELEMENTAL) tmp_counter++;
                    if (tmp_counter == cond.num) return true;
                    return false;
                case param.ohc_elems_notequal:
                    tmp_counter = 0;
                    foreach (Handmanager.Handcard hc in p.owncards) if ((TAG_RACE)hc.card.race == TAG_RACE.ELEMENTAL) tmp_counter++;
                    if (tmp_counter != cond.num) return true;
                    return false;
                case param.ohc_elems_greater:
                    tmp_counter = 0;
                    foreach (Handmanager.Handcard hc in p.owncards) if ((TAG_RACE)hc.card.race == TAG_RACE.ELEMENTAL) tmp_counter++;
                    if (tmp_counter > cond.num) return true;
                    return false;
                case param.ohc_elems_less:
                    tmp_counter = 0;
                    foreach (Handmanager.Handcard hc in p.owncards) if ((TAG_RACE)hc.card.race == TAG_RACE.ELEMENTAL) tmp_counter++;
                    if (tmp_counter < cond.num) return true;
                    return false;
                case param.ohc_shields_equal:
                    tmp_counter = 0;
                    foreach (Handmanager.Handcard hc in p.owncards) if (hc.card.Shield) tmp_counter++;
                    if (tmp_counter == cond.num) return true;
                    return false;
                case param.ohc_shields_notequal:
                    tmp_counter = 0;
                    foreach (Handmanager.Handcard hc in p.owncards) if (hc.card.Shield) tmp_counter++;
                    if (tmp_counter != cond.num) return true;
                    return false;
                case param.ohc_shields_greater:
                    tmp_counter = 0;
                    foreach (Handmanager.Handcard hc in p.owncards) if (hc.card.Shield) tmp_counter++;
                    if (tmp_counter > cond.num) return true;
                    return false;
                case param.ohc_shields_less:
                    tmp_counter = 0;
                    foreach (Handmanager.Handcard hc in p.owncards) if (hc.card.Shield) tmp_counter++;
                    if (tmp_counter < cond.num) return true;
                    return false;
                case param.ohc_taunts_equal:
                    tmp_counter = 0;
                    foreach (Handmanager.Handcard hc in p.owncards) if (hc.card.tank) tmp_counter++;
                    if (tmp_counter == cond.num) return true;
                    return false;
                case param.ohc_taunts_notequal:
                    tmp_counter = 0;
                    foreach (Handmanager.Handcard hc in p.owncards) if (hc.card.tank) tmp_counter++;
                    if (tmp_counter != cond.num) return true;
                    return false;
                case param.ohc_taunts_greater:
                    tmp_counter = 0;
                    foreach (Handmanager.Handcard hc in p.owncards) if (hc.card.tank) tmp_counter++;
                    if (tmp_counter > cond.num) return true;
                    return false;
                case param.ohc_taunts_less:
                    tmp_counter = 0;
                    foreach (Handmanager.Handcard hc in p.owncards) if (hc.card.tank) tmp_counter++;
                    if (tmp_counter < cond.num) return true;
                    return false;
                case param.aAt_equal: 
                    if (a.own != null && a.own.Angr == cond.num) return true;
                    return false;
                case param.aAt_notequal:
                    if (a.own != null && a.own.Angr != cond.num) return true;
                    return false;
                case param.aAt_greater:
                    if (a.own != null && a.own.Angr > cond.num) return true;
                    return false;
                case param.aAt_less:
                    if (a.own != null && a.own.Angr < cond.num) return true;
                    return false;
                case param.aHp_equal: 
                    if (a.own != null && a.prevHpOwn == cond.num) return true;
                    return false;
                case param.aHp_notequal:
                    if (a.own != null && a.prevHpOwn != cond.num) return true;
                    return false;
                case param.aHp_greater:
                    if (a.own != null && a.prevHpOwn > cond.num) return true;
                    return false;
                case param.aHp_less:
                    if (a.own != null && a.prevHpOwn < cond.num) return true;
                    return false;
                case param.tAt_equal: 
                    if (a.target != null && a.target.Angr == cond.num) return true;
                    return false;
                case param.tAt_notequal:
                    if (a.target != null && a.target.Angr != cond.num) return true;
                    return false;
                case param.tAt_greater:
                    if (a.target != null && a.target.Angr > cond.num) return true;
                    return false;
                case param.tAt_less:
                    if (a.target != null && a.target.Angr < cond.num) return true;
                    return false;
                case param.tHp_equal: 
                    if (a.target != null && a.prevHpTarget == cond.num) return true;
                    return false;
                case param.tHp_notequal:
                    if (a.target != null && a.prevHpTarget != cond.num) return true;
                    return false;
                case param.tHp_greater:
                    if (a.target != null && a.prevHpTarget > cond.num) return true;
                    return false;
                case param.tHp_less:
                    if (a.target != null && a.prevHpTarget < cond.num) return true;
                    return false;
                case param.omc_murlocs_equal:
                    tmp_counter = 0;
                    foreach (Minion m in p.ownMinions) if ((TAG_RACE)m.handcard.card.race == TAG_RACE.MURLOC) tmp_counter++;
                    if (tmp_counter == cond.num) return true;
                    return false;
                case param.omc_murlocs_notequal:
                    tmp_counter = 0;
                    foreach (Minion m in p.ownMinions) if ((TAG_RACE)m.handcard.card.race == TAG_RACE.MURLOC) tmp_counter++;
                    if (tmp_counter != cond.num) return true;
                    return false;
                case param.omc_murlocs_greater:
                    tmp_counter = 0;
                    foreach (Minion m in p.ownMinions) if ((TAG_RACE)m.handcard.card.race == TAG_RACE.MURLOC) tmp_counter++;
                    if (tmp_counter > cond.num) return true;
                    return false;
                case param.omc_murlocs_less:
                    tmp_counter = 0;
                    foreach (Minion m in p.ownMinions) if ((TAG_RACE)m.handcard.card.race == TAG_RACE.MURLOC) tmp_counter++;
                    if (tmp_counter < cond.num) return true;
                    return false;
                case param.emc_murlocs_equal:
                    tmp_counter = 0;
                    foreach (Minion m in p.enemyMinions) if ((TAG_RACE)m.handcard.card.race == TAG_RACE.MURLOC) tmp_counter++;
                    if (tmp_counter == cond.num) return true;
                    return false;
                case param.emc_murlocs_notequal:
                    tmp_counter = 0;
                    foreach (Minion m in p.enemyMinions) if ((TAG_RACE)m.handcard.card.race == TAG_RACE.MURLOC) tmp_counter++;
                    if (tmp_counter != cond.num) return true;
                    return false;
                case param.emc_murlocs_greater:
                    tmp_counter = 0;
                    foreach (Minion m in p.enemyMinions) if ((TAG_RACE)m.handcard.card.race == TAG_RACE.MURLOC) tmp_counter++;
                    if (tmp_counter > cond.num) return true;
                    return false;
                case param.emc_murlocs_less:
                    tmp_counter = 0;
                    foreach (Minion m in p.enemyMinions) if ((TAG_RACE)m.handcard.card.race == TAG_RACE.MURLOC) tmp_counter++;
                    if (tmp_counter < cond.num) return true;
                    return false;
                case param.omc_demons_equal:
                    tmp_counter = 0;
                    foreach (Minion m in p.ownMinions) if ((TAG_RACE)m.handcard.card.race == TAG_RACE.DEMON) tmp_counter++;
                    if (tmp_counter == cond.num) return true;
                    return false;
                case param.omc_demons_notequal:
                    tmp_counter = 0;
                    foreach (Minion m in p.ownMinions) if ((TAG_RACE)m.handcard.card.race == TAG_RACE.DEMON) tmp_counter++;
                    if (tmp_counter != cond.num) return true;
                    return false;
                case param.omc_demons_greater:
                    tmp_counter = 0;
                    foreach (Minion m in p.ownMinions) if ((TAG_RACE)m.handcard.card.race == TAG_RACE.DEMON) tmp_counter++;
                    if (tmp_counter > cond.num) return true;
                    return false;
                case param.omc_demons_less:
                    tmp_counter = 0;
                    foreach (Minion m in p.ownMinions) if ((TAG_RACE)m.handcard.card.race == TAG_RACE.DEMON) tmp_counter++;
                    if (tmp_counter < cond.num) return true;
                    return false;
                case param.emc_demons_equal:
                    tmp_counter = 0;
                    foreach (Minion m in p.enemyMinions) if ((TAG_RACE)m.handcard.card.race == TAG_RACE.DEMON) tmp_counter++;
                    if (tmp_counter == cond.num) return true;
                    return false;
                case param.emc_demons_notequal:
                    tmp_counter = 0;
                    foreach (Minion m in p.enemyMinions) if ((TAG_RACE)m.handcard.card.race == TAG_RACE.DEMON) tmp_counter++;
                    if (tmp_counter != cond.num) return true;
                    return false;
                case param.emc_demons_greater:
                    tmp_counter = 0;
                    foreach (Minion m in p.enemyMinions) if ((TAG_RACE)m.handcard.card.race == TAG_RACE.DEMON) tmp_counter++;
                    if (tmp_counter > cond.num) return true;
                    return false;
                case param.emc_demons_less:
                    tmp_counter = 0;
                    foreach (Minion m in p.enemyMinions) if ((TAG_RACE)m.handcard.card.race == TAG_RACE.DEMON) tmp_counter++;
                    if (tmp_counter < cond.num) return true;
                    return false;
                case param.omc_mechs_equal:
                    tmp_counter = 0;
                    foreach (Minion m in p.ownMinions) if ((TAG_RACE)m.handcard.card.race == TAG_RACE.MECHANICAL) tmp_counter++;
                    if (tmp_counter == cond.num) return true;
                    return false;
                case param.omc_mechs_notequal:
                    tmp_counter = 0;
                    foreach (Minion m in p.ownMinions) if ((TAG_RACE)m.handcard.card.race == TAG_RACE.MECHANICAL) tmp_counter++;
                    if (tmp_counter != cond.num) return true;
                    return false;
                case param.omc_mechs_greater:
                    tmp_counter = 0;
                    foreach (Minion m in p.ownMinions) if ((TAG_RACE)m.handcard.card.race == TAG_RACE.MECHANICAL) tmp_counter++;
                    if (tmp_counter > cond.num) return true;
                    return false;
                case param.omc_mechs_less:
                    tmp_counter = 0;
                    foreach (Minion m in p.ownMinions) if ((TAG_RACE)m.handcard.card.race == TAG_RACE.MECHANICAL) tmp_counter++;
                    if (tmp_counter < cond.num) return true;
                    return false;
                case param.emc_mechs_equal:
                    tmp_counter = 0;
                    foreach (Minion m in p.enemyMinions) if ((TAG_RACE)m.handcard.card.race == TAG_RACE.MECHANICAL) tmp_counter++;
                    if (tmp_counter == cond.num) return true;
                    return false;
                case param.emc_mechs_notequal:
                    tmp_counter = 0;
                    foreach (Minion m in p.enemyMinions) if ((TAG_RACE)m.handcard.card.race == TAG_RACE.MECHANICAL) tmp_counter++;
                    if (tmp_counter != cond.num) return true;
                    return false;
                case param.emc_mechs_greater:
                    tmp_counter = 0;
                    foreach (Minion m in p.enemyMinions) if ((TAG_RACE)m.handcard.card.race == TAG_RACE.MECHANICAL) tmp_counter++;
                    if (tmp_counter > cond.num) return true;
                    return false;
                case param.emc_mechs_less:
                    tmp_counter = 0;
                    foreach (Minion m in p.enemyMinions) if ((TAG_RACE)m.handcard.card.race == TAG_RACE.MECHANICAL) tmp_counter++;
                    if (tmp_counter < cond.num) return true;
                    return false;
                case param.omc_beasts_equal:
                    tmp_counter = 0;
                    foreach (Minion m in p.ownMinions) if ((TAG_RACE)m.handcard.card.race == TAG_RACE.PET) tmp_counter++;
                    if (tmp_counter == cond.num) return true;
                    return false;
                case param.omc_beasts_notequal:
                    tmp_counter = 0;
                    foreach (Minion m in p.ownMinions) if ((TAG_RACE)m.handcard.card.race == TAG_RACE.PET) tmp_counter++;
                    if (tmp_counter != cond.num) return true;
                    return false;
                case param.omc_beasts_greater:
                    tmp_counter = 0;
                    foreach (Minion m in p.ownMinions) if ((TAG_RACE)m.handcard.card.race == TAG_RACE.PET) tmp_counter++;
                    if (tmp_counter > cond.num) return true;
                    return false;
                case param.omc_beasts_less:
                    tmp_counter = 0;
                    foreach (Minion m in p.ownMinions) if ((TAG_RACE)m.handcard.card.race == TAG_RACE.PET) tmp_counter++;
                    if (tmp_counter < cond.num) return true;
                    return false;
                case param.emc_beasts_equal:
                    tmp_counter = 0;
                    foreach (Minion m in p.enemyMinions) if ((TAG_RACE)m.handcard.card.race == TAG_RACE.PET) tmp_counter++;
                    if (tmp_counter == cond.num) return true;
                    return false;
                case param.emc_beasts_notequal:
                    tmp_counter = 0;
                    foreach (Minion m in p.enemyMinions) if ((TAG_RACE)m.handcard.card.race == TAG_RACE.PET) tmp_counter++;
                    if (tmp_counter != cond.num) return true;
                    return false;
                case param.emc_beasts_greater:
                    tmp_counter = 0;
                    foreach (Minion m in p.enemyMinions) if ((TAG_RACE)m.handcard.card.race == TAG_RACE.PET) tmp_counter++;
                    if (tmp_counter > cond.num) return true;
                    return false;
                case param.emc_beasts_less:
                    tmp_counter = 0;
                    foreach (Minion m in p.enemyMinions) if ((TAG_RACE)m.handcard.card.race == TAG_RACE.PET) tmp_counter++;
                    if (tmp_counter < cond.num) return true;
                    return false;
                case param.omc_totems_equal:
                    tmp_counter = 0;
                    foreach (Minion m in p.ownMinions) if ((TAG_RACE)m.handcard.card.race == TAG_RACE.TOTEM) tmp_counter++;
                    if (tmp_counter == cond.num) return true;
                    return false;
                case param.omc_totems_notequal:
                    tmp_counter = 0;
                    foreach (Minion m in p.ownMinions) if ((TAG_RACE)m.handcard.card.race == TAG_RACE.TOTEM) tmp_counter++;
                    if (tmp_counter != cond.num) return true;
                    return false;
                case param.omc_totems_greater:
                    tmp_counter = 0;
                    foreach (Minion m in p.ownMinions) if ((TAG_RACE)m.handcard.card.race == TAG_RACE.TOTEM) tmp_counter++;
                    if (tmp_counter > cond.num) return true;
                    return false;
                case param.omc_totems_less:
                    tmp_counter = 0;
                    foreach (Minion m in p.ownMinions) if ((TAG_RACE)m.handcard.card.race == TAG_RACE.TOTEM) tmp_counter++;
                    if (tmp_counter < cond.num) return true;
                    return false;
                case param.emc_totems_equal:
                    tmp_counter = 0;
                    foreach (Minion m in p.enemyMinions) if ((TAG_RACE)m.handcard.card.race == TAG_RACE.TOTEM) tmp_counter++;
                    if (tmp_counter == cond.num) return true;
                    return false;
                case param.emc_totems_notequal:
                    tmp_counter = 0;
                    foreach (Minion m in p.enemyMinions) if ((TAG_RACE)m.handcard.card.race == TAG_RACE.TOTEM) tmp_counter++;
                    if (tmp_counter != cond.num) return true;
                    return false;
                case param.emc_totems_greater:
                    tmp_counter = 0;
                    foreach (Minion m in p.enemyMinions) if ((TAG_RACE)m.handcard.card.race == TAG_RACE.TOTEM) tmp_counter++;
                    if (tmp_counter > cond.num) return true;
                    return false;
                case param.emc_totems_less:
                    tmp_counter = 0;
                    foreach (Minion m in p.enemyMinions) if ((TAG_RACE)m.handcard.card.race == TAG_RACE.TOTEM) tmp_counter++;
                    if (tmp_counter < cond.num) return true;
                    return false;
                case param.omc_pirates_equal:
                    tmp_counter = 0;
                    foreach (Minion m in p.ownMinions) if ((TAG_RACE)m.handcard.card.race == TAG_RACE.PIRATE) tmp_counter++;
                    if (tmp_counter == cond.num) return true;
                    return false;
                case param.omc_pirates_notequal:
                    tmp_counter = 0;
                    foreach (Minion m in p.ownMinions) if ((TAG_RACE)m.handcard.card.race == TAG_RACE.PIRATE) tmp_counter++;
                    if (tmp_counter != cond.num) return true;
                    return false;
                case param.omc_pirates_greater:
                    tmp_counter = 0;
                    foreach (Minion m in p.ownMinions) if ((TAG_RACE)m.handcard.card.race == TAG_RACE.PIRATE) tmp_counter++;
                    if (tmp_counter > cond.num) return true;
                    return false;
                case param.omc_pirates_less:
                    tmp_counter = 0;
                    foreach (Minion m in p.ownMinions) if ((TAG_RACE)m.handcard.card.race == TAG_RACE.PIRATE) tmp_counter++;
                    if (tmp_counter < cond.num) return true;
                    return false;
                case param.emc_pirates_equal:
                    tmp_counter = 0;
                    foreach (Minion m in p.enemyMinions) if ((TAG_RACE)m.handcard.card.race == TAG_RACE.PIRATE) tmp_counter++;
                    if (tmp_counter == cond.num) return true;
                    return false;
                case param.emc_pirates_notequal:
                    tmp_counter = 0;
                    foreach (Minion m in p.enemyMinions) if ((TAG_RACE)m.handcard.card.race == TAG_RACE.PIRATE) tmp_counter++;
                    if (tmp_counter != cond.num) return true;
                    return false;
                case param.emc_pirates_greater:
                    tmp_counter = 0;
                    foreach (Minion m in p.enemyMinions) if ((TAG_RACE)m.handcard.card.race == TAG_RACE.PIRATE) tmp_counter++;
                    if (tmp_counter > cond.num) return true;
                    return false;
                case param.emc_pirates_less:
                    tmp_counter = 0;
                    foreach (Minion m in p.enemyMinions) if ((TAG_RACE)m.handcard.card.race == TAG_RACE.PIRATE) tmp_counter++;
                    if (tmp_counter < cond.num) return true;
                    return false;
                case param.omc_Dragons_equal:
                    tmp_counter = 0;
                    foreach (Minion m in p.ownMinions) if ((TAG_RACE)m.handcard.card.race == TAG_RACE.DRAGON) tmp_counter++;
                    if (tmp_counter == cond.num) return true;
                    return false;
                case param.omc_Dragons_notequal:
                    tmp_counter = 0;
                    foreach (Minion m in p.ownMinions) if ((TAG_RACE)m.handcard.card.race == TAG_RACE.DRAGON) tmp_counter++;
                    if (tmp_counter != cond.num) return true;
                    return false;
                case param.omc_Dragons_greater:
                    tmp_counter = 0;
                    foreach (Minion m in p.ownMinions) if ((TAG_RACE)m.handcard.card.race == TAG_RACE.DRAGON) tmp_counter++;
                    if (tmp_counter > cond.num) return true;
                    return false;
                case param.omc_Dragons_less:
                    tmp_counter = 0;
                    foreach (Minion m in p.ownMinions) if ((TAG_RACE)m.handcard.card.race == TAG_RACE.DRAGON) tmp_counter++;
                    if (tmp_counter < cond.num) return true;
                    return false;
                case param.emc_Dragons_equal:
                    tmp_counter = 0;
                    foreach (Minion m in p.enemyMinions) if ((TAG_RACE)m.handcard.card.race == TAG_RACE.DRAGON) tmp_counter++;
                    if (tmp_counter == cond.num) return true;
                    return false;
                case param.emc_Dragons_notequal:
                    tmp_counter = 0;
                    foreach (Minion m in p.enemyMinions) if ((TAG_RACE)m.handcard.card.race == TAG_RACE.DRAGON) tmp_counter++;
                    if (tmp_counter != cond.num) return true;
                    return false;
                case param.emc_Dragons_greater:
                    tmp_counter = 0;
                    foreach (Minion m in p.enemyMinions) if ((TAG_RACE)m.handcard.card.race == TAG_RACE.DRAGON) tmp_counter++;
                    if (tmp_counter > cond.num) return true;
                    return false;
                case param.emc_Dragons_less:
                    tmp_counter = 0;
                    foreach (Minion m in p.enemyMinions) if ((TAG_RACE)m.handcard.card.race == TAG_RACE.DRAGON) tmp_counter++;
                    if (tmp_counter < cond.num) return true;
                    return false;
                case param.omc_elems_equal:
                    tmp_counter = 0;
                    foreach (Minion m in p.ownMinions) if ((TAG_RACE)m.handcard.card.race == TAG_RACE.ELEMENTAL) tmp_counter++;
                    if (tmp_counter == cond.num) return true;
                    return false;
                case param.omc_elems_notequal:
                    tmp_counter = 0;
                    foreach (Minion m in p.ownMinions) if ((TAG_RACE)m.handcard.card.race == TAG_RACE.ELEMENTAL) tmp_counter++;
                    if (tmp_counter != cond.num) return true;
                    return false;
                case param.omc_elems_greater:
                    tmp_counter = 0;
                    foreach (Minion m in p.ownMinions) if ((TAG_RACE)m.handcard.card.race == TAG_RACE.ELEMENTAL) tmp_counter++;
                    if (tmp_counter > cond.num) return true;
                    return false;
                case param.omc_elems_less:
                    tmp_counter = 0;
                    foreach (Minion m in p.ownMinions) if ((TAG_RACE)m.handcard.card.race == TAG_RACE.ELEMENTAL) tmp_counter++;
                    if (tmp_counter < cond.num) return true;
                    return false;
                case param.emc_elems_equal:
                    tmp_counter = 0;
                    foreach (Minion m in p.enemyMinions) if ((TAG_RACE)m.handcard.card.race == TAG_RACE.ELEMENTAL) tmp_counter++;
                    if (tmp_counter == cond.num) return true;
                    return false;
                case param.emc_elems_notequal:
                    tmp_counter = 0;
                    foreach (Minion m in p.enemyMinions) if ((TAG_RACE)m.handcard.card.race == TAG_RACE.ELEMENTAL) tmp_counter++;
                    if (tmp_counter != cond.num) return true;
                    return false;
                case param.emc_elems_greater:
                    tmp_counter = 0;
                    foreach (Minion m in p.enemyMinions) if ((TAG_RACE)m.handcard.card.race == TAG_RACE.ELEMENTAL) tmp_counter++;
                    if (tmp_counter > cond.num) return true;
                    return false;
                case param.emc_elems_less:
                    tmp_counter = 0;
                    foreach (Minion m in p.enemyMinions) if ((TAG_RACE)m.handcard.card.race == TAG_RACE.ELEMENTAL) tmp_counter++;
                    if (tmp_counter < cond.num) return true;
                    return false;
                case param.omc_shr_equal:
                    tmp_counter = 0;
                    foreach (Minion m in p.ownMinions) if (m.name == CardDB.cardName.silverhandrecruit) tmp_counter++;
                    if (tmp_counter == cond.num) return true;
                    return false;
                case param.omc_shr_notequal:
                    tmp_counter = 0;
                    foreach (Minion m in p.ownMinions) if (m.name == CardDB.cardName.silverhandrecruit) tmp_counter++;
                    if (tmp_counter != cond.num) return true;
                    return false;
                case param.omc_shr_greater:
                    tmp_counter = 0;
                    foreach (Minion m in p.ownMinions) if (m.name == CardDB.cardName.silverhandrecruit) tmp_counter++;
                    if (tmp_counter > cond.num) return true;
                    return false;
                case param.omc_shr_less:
                    tmp_counter = 0;
                    foreach (Minion m in p.ownMinions) if (m.name == CardDB.cardName.silverhandrecruit) tmp_counter++;
                    if (tmp_counter < cond.num) return true;
                    return false;
                case param.emc_shr_equal:
                    tmp_counter = 0;
                    foreach (Minion m in p.enemyMinions) if (m.name == CardDB.cardName.silverhandrecruit) tmp_counter++;
                    if (tmp_counter == cond.num) return true;
                    return false;
                case param.emc_shr_notequal:
                    tmp_counter = 0;
                    foreach (Minion m in p.enemyMinions) if (m.name == CardDB.cardName.silverhandrecruit) tmp_counter++;
                    if (tmp_counter != cond.num) return true;
                    return false;
                case param.emc_shr_greater:
                    tmp_counter = 0;
                    foreach (Minion m in p.enemyMinions) if (m.name == CardDB.cardName.silverhandrecruit) tmp_counter++;
                    if (tmp_counter > cond.num) return true;
                    return false;
                case param.emc_shr_less:
                    tmp_counter = 0;
                    foreach (Minion m in p.enemyMinions) if (m.name == CardDB.cardName.silverhandrecruit) tmp_counter++;
                    if (tmp_counter < cond.num) return true;
                    return false;
                case param.omc_undamaged_equal:
                    tmp_counter = 0;
                    foreach (Minion m in p.ownMinions) if (!m.wounded) tmp_counter++;
                    if (tmp_counter == cond.num) return true;
                    return false;
                case param.omc_undamaged_notequal:
                    tmp_counter = 0;
                    foreach (Minion m in p.ownMinions) if (!m.wounded) tmp_counter++;
                    if (tmp_counter != cond.num) return true;
                    return false;
                case param.omc_undamaged_greater:
                    tmp_counter = 0;
                    foreach (Minion m in p.ownMinions) if (!m.wounded) tmp_counter++;
                    if (tmp_counter > cond.num) return true;
                    return false;
                case param.omc_undamaged_less:
                    tmp_counter = 0;
                    foreach (Minion m in p.ownMinions) if (!m.wounded) tmp_counter++;
                    if (tmp_counter < cond.num) return true;
                    return false;
                case param.emc_undamaged_equal:
                    tmp_counter = 0;
                    foreach (Minion m in p.enemyMinions) if (!m.wounded) tmp_counter++;
                    if (tmp_counter == cond.num) return true;
                    return false;
                case param.emc_undamaged_notequal:
                    tmp_counter = 0;
                    foreach (Minion m in p.enemyMinions) if (!m.wounded) tmp_counter++;
                    if (tmp_counter != cond.num) return true;
                    return false;
                case param.emc_undamaged_greater:
                    tmp_counter = 0;
                    foreach (Minion m in p.enemyMinions) if (!m.wounded) tmp_counter++;
                    if (tmp_counter > cond.num) return true;
                    return false;
                case param.emc_undamaged_less:
                    tmp_counter = 0;
                    foreach (Minion m in p.enemyMinions) if (!m.wounded) tmp_counter++;
                    if (tmp_counter < cond.num) return true;
                    return false;
                case param.omc_damaged_equal:
                    tmp_counter = 0;
                    foreach (Minion m in p.ownMinions) if (m.wounded) tmp_counter++;
                    if (tmp_counter == cond.num) return true;
                    return false;
                case param.omc_damaged_notequal:
                    tmp_counter = 0;
                    foreach (Minion m in p.ownMinions) if (m.wounded) tmp_counter++;
                    if (tmp_counter != cond.num) return true;
                    return false;
                case param.omc_damaged_greater:
                    tmp_counter = 0;
                    foreach (Minion m in p.ownMinions) if (m.wounded) tmp_counter++;
                    if (tmp_counter > cond.num) return true;
                    return false;
                case param.omc_damaged_less:
                    tmp_counter = 0;
                    foreach (Minion m in p.ownMinions) if (m.wounded) tmp_counter++;
                    if (tmp_counter < cond.num) return true;
                    return false;
                case param.emc_damaged_equal:
                    tmp_counter = 0;
                    foreach (Minion m in p.enemyMinions) if (m.wounded) tmp_counter++;
                    if (tmp_counter == cond.num) return true;
                    return false;
                case param.emc_damaged_notequal:
                    tmp_counter = 0;
                    foreach (Minion m in p.enemyMinions) if (m.wounded) tmp_counter++;
                    if (tmp_counter != cond.num) return true;
                    return false;
                case param.emc_damaged_greater:
                    tmp_counter = 0;
                    foreach (Minion m in p.enemyMinions) if (m.wounded) tmp_counter++;
                    if (tmp_counter > cond.num) return true;
                    return false;
                case param.emc_damaged_less:
                    tmp_counter = 0;
                    foreach (Minion m in p.enemyMinions) if (m.wounded) tmp_counter++;
                    if (tmp_counter < cond.num) return true;
                    return false;
                case param.omc_shields_equal:
                    tmp_counter = 0;
                    foreach (Minion m in p.ownMinions) if (m.divineshild) tmp_counter++;
                    if (tmp_counter == cond.num) return true;
                    return false;
                case param.omc_shields_notequal:
                    tmp_counter = 0;
                    foreach (Minion m in p.ownMinions) if (m.divineshild) tmp_counter++;
                    if (tmp_counter != cond.num) return true;
                    return false;
                case param.omc_shields_greater:
                    tmp_counter = 0;
                    foreach (Minion m in p.ownMinions) if (m.divineshild) tmp_counter++;
                    if (tmp_counter > cond.num) return true;
                    return false;
                case param.omc_shields_less:
                    tmp_counter = 0;
                    foreach (Minion m in p.ownMinions) if (m.divineshild) tmp_counter++;
                    if (tmp_counter < cond.num) return true;
                    return false;
                case param.emc_shields_equal:
                    tmp_counter = 0;
                    foreach (Minion m in p.enemyMinions) if (m.divineshild) tmp_counter++;
                    if (tmp_counter == cond.num) return true;
                    return false;
                case param.emc_shields_notequal:
                    tmp_counter = 0;
                    foreach (Minion m in p.enemyMinions) if (m.divineshild) tmp_counter++;
                    if (tmp_counter != cond.num) return true;
                    return false;
                case param.emc_shields_greater:
                    tmp_counter = 0;
                    foreach (Minion m in p.enemyMinions) if (m.divineshild) tmp_counter++;
                    if (tmp_counter > cond.num) return true;
                    return false;
                case param.emc_shields_less:
                    tmp_counter = 0;
                    foreach (Minion m in p.enemyMinions) if (m.divineshild) tmp_counter++;
                    if (tmp_counter < cond.num) return true;
                    return false;
                case param.omc_taunts_equal:
                    tmp_counter = 0;
                    foreach (Minion m in p.ownMinions) if (m.taunt) tmp_counter++;
                    if (tmp_counter == cond.num) return true;
                    return false;
                case param.omc_taunts_notequal:
                    tmp_counter = 0;
                    foreach (Minion m in p.ownMinions) if (m.taunt) tmp_counter++;
                    if (tmp_counter != cond.num) return true;
                    return false;
                case param.omc_taunts_greater:
                    tmp_counter = 0;
                    foreach (Minion m in p.ownMinions) if (m.taunt) tmp_counter++;
                    if (tmp_counter > cond.num) return true;
                    return false;
                case param.omc_taunts_less:
                    tmp_counter = 0;
                    foreach (Minion m in p.ownMinions) if (m.taunt) tmp_counter++;
                    if (tmp_counter < cond.num) return true;
                    return false;
                case param.emc_taunts_equal:
                    tmp_counter = 0;
                    foreach (Minion m in p.enemyMinions) if (m.taunt) tmp_counter++;
                    if (tmp_counter == cond.num) return true;
                    return false;
                case param.emc_taunts_notequal:
                    tmp_counter = 0;
                    foreach (Minion m in p.enemyMinions) if (m.taunt) tmp_counter++;
                    if (tmp_counter != cond.num) return true;
                    return false;
                case param.emc_taunts_greater:
                    tmp_counter = 0;
                    foreach (Minion m in p.enemyMinions) if (m.taunt) tmp_counter++;
                    if (tmp_counter > cond.num) return true;
                    return false;
                case param.emc_taunts_less:
                    tmp_counter = 0;
                    foreach (Minion m in p.enemyMinions) if (m.taunt) tmp_counter++;
                    if (tmp_counter < cond.num) return true;
                    return false;

                case param.turn_equal: 
                    if (p.gTurn == cond.num) return true;
                    return false;
                case param.turn_notequal:
                    if (p.gTurn != cond.num) return true;
                    return false;
                case param.turn_greater:
                    if (p.gTurn > cond.num) return true;
                    return false;
                case param.turn_less:
                    if (p.gTurn < cond.num) return true;
                    return false;
                case param.overload_equal: 
                    if (p.ueberladung == cond.num) return true;
                    return false;
                case param.overload_notequal:
                    if (p.ueberladung != cond.num) return true;
                    return false;
                case param.overload_greater:
                    if (p.ueberladung > cond.num) return true;
                    return false;
                case param.overload_less:
                    if (p.ueberladung < cond.num) return true;
                    return false;
                case param.owncarddraw_equal: 
                    if (p.owncarddraw == cond.num) return true;
                    return false;
                case param.owncarddraw_notequal:
                    if (p.owncarddraw != cond.num) return true;
                    return false;
                case param.owncarddraw_greater:
                    if (p.owncarddraw > cond.num) return true;
                    return false;
                case param.owncarddraw_less:
                    if (p.owncarddraw < cond.num) return true;
                    return false;
                case param.ohhp_equal: 
                    if (p.ownHero.Hp == cond.num) return true;
                    return false;
                case param.ohhp_notequal:
                    if (p.ownHero.Hp != cond.num) return true;
                    return false;
                case param.ohhp_greater:
                    if (p.ownHero.Hp > cond.num) return true;
                    return false;
                case param.ohhp_less:
                    if (p.ownHero.Hp < cond.num) return true;
                    return false;
                case param.ehhp_equal: 
                    if (p.enemyHero.Hp == cond.num) return true;
                    return false;
                case param.ehhp_notequal:
                    if (p.enemyHero.Hp != cond.num) return true;
                    return false;
                case param.ehhp_greater:
                    if (p.enemyHero.Hp > cond.num) return true;
                    return false;
                case param.ehhp_less:
                    if (p.enemyHero.Hp < cond.num) return true;
                    return false;

                case param.ownboard_contain: 
                    foreach (Minion m in p.ownMinions) if (m.handcard.card.cardIDenum == cond.cardID) return true;
                    return false;
                case param.ownboard_notcontain:
                    foreach (Minion m in p.ownMinions) if (m.handcard.card.cardIDenum == cond.cardID) return false;
                    return true;
                case param.enboard_contain: 
                    foreach (Minion m in p.enemyMinions) if (m.handcard.card.cardIDenum == cond.cardID) return true;
                    return false;
                case param.enboard_notcontain:
                    foreach (Minion m in p.enemyMinions) if (m.handcard.card.cardIDenum == cond.cardID) return false;
                    return true;
                case param.ownhand_contain: 
                    foreach (Handmanager.Handcard hc in p.owncards) if (hc.card.cardIDenum == cond.cardID) return true;
                    return false;
                case param.ownhand_notcontain:
                    foreach (Handmanager.Handcard hc in p.owncards) if (hc.card.cardIDenum == cond.cardID) return false;
                    return true;
                case param.ownweapon_equal: 
                    if (p.ownWeapon.card.cardIDenum == cond.cardID) return true;
                    return false;
                case param.ownweapon_notequal:
                    if (p.ownWeapon.card.cardIDenum != cond.cardID) return true;
                    return false;
                case param.enweapon_equal: 
                    if (p.enemyWeapon.card.cardIDenum == cond.cardID) return true;
                    return false;
                case param.enweapon_notequal:
                    if (p.enemyWeapon.card.cardIDenum != cond.cardID) return true;
                    return false;
                case param.ownhero_equal: 
                    if (cond.hClass == TAG_CLASS.ALL) return true;
                    if (p.ownHeroStartClass == cond.hClass) return true;
                    return false;
                case param.ownhero_notequal:
                    if (p.ownHeroStartClass != cond.hClass) return true;
                    return false;
                case param.enhero_equal: 
                    if (cond.hClass == TAG_CLASS.ALL) return true;
                    if (p.enemyHeroStartClass == cond.hClass) return true;
                    return false;
                case param.enhero_notequal:
                    if (p.enemyHeroStartClass != cond.hClass) return true;
                    return false;
                case param.tgt_equal:
                    if (a.target!= null && (a.target.handcard.card.cardIDenum == cond.cardID || (a.target.isHero && cond.cardID == CardDB.cardIDEnum.hero))) return true;
                    return false;
                case param.tgt_notequal:
                    if (a.target != null)
                    {
                        if (a.target.isHero)
                        {
                            if (cond.cardID != CardDB.cardIDEnum.hero) return true;
                            else return false;
                        }
                        else if (a.target.handcard.card.cardIDenum != cond.cardID) return true;
                    }
                    return false;

                
                case param.noduplicates:
                    return p.prozis.noDuplicates;
                default:
                    condErr = "Wrong parameter: ";
                    return false;
            }
        }

    }

}