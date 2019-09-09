using System.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using SilverFish.Helpers;
using Triton.Common.LogUtilities;
using SilverFish.Enums;

namespace HREngine.Bots
{
    public struct targett
    {
        public int target;
        public int targetEntity;

        public targett(int targ, int ent)
        {
            target = targ;
            targetEntity = ent;
        }
    }


    public partial class CardDB
    {
        public CardIdEnum cardIdstringToEnum(string s)
        {
            CardIdEnum CardEnum;
            if (Enum.TryParse<CardIdEnum>(s, false, out CardEnum)) return CardEnum;
            else
            {
                Logger.GetLoggerInstanceForType().ErrorFormat("[Unidentified card ID :" + s + "]");
                return CardIdEnum.None;
            }
        }

        public CardName cardNameStringToEnum(string s, CardIdEnum tempCardIdEnum)
        {
            if (Enum.TryParse(s, false, out CardName nameEnum))
            {
                return nameEnum;
            }
            else
            {
                nameEnum = GetSpecialCardNameEnumFromCardIdEnum(tempCardIdEnum);
                if (nameEnum == CardName.unknown)
                {
                    Logger.GetLoggerInstanceForType()
                        .ErrorFormat("[Unidentified card name :" + s + "]");
                }
            }

            return nameEnum;
        }

        public enum ErrorType2
        {
            INVALID = -1,
            NONE = 0,
            REQ_MINION_TARGET = 1,
            REQ_FRIENDLY_TARGET = 2,
            REQ_ENEMY_TARGET = 3,
            REQ_DAMAGED_TARGET = 4,
            REQ_MAX_SECRETS = 5,
            REQ_FROZEN_TARGET = 6,
            REQ_CHARGE_TARGET = 7,
            REQ_TARGET_MAX_ATTACK = 8,
            REQ_NONSELF_TARGET = 9,
            REQ_TARGET_WITH_RACE = 10,
            REQ_TARGET_TO_PLAY = 11,
            REQ_NUM_MINION_SLOTS = 12,
            REQ_WEAPON_EQUIPPED = 13,
            REQ_ENOUGH_MANA = 14,
            REQ_YOUR_TURN = 15,
            REQ_NONSTEALTH_ENEMY_TARGET = 16,
            REQ_HERO_TARGET = 17,
            REQ_SECRET_ZONE_CAP = 18,
            REQ_MINION_CAP_IF_TARGET_AVAILABLE = 19,
            REQ_MINION_CAP = 20,
            REQ_TARGET_ATTACKED_THIS_TURN = 21,
            REQ_TARGET_IF_AVAILABLE = 22,
            REQ_MINIMUM_ENEMY_MINIONS = 23,
            REQ_TARGET_FOR_COMBO = 24,
            REQ_NOT_EXHAUSTED_ACTIVATE = 25,
            REQ_UNIQUE_SECRET_OR_QUEST = 26,
            REQ_TARGET_TAUNTER = 27,
            REQ_CAN_BE_ATTACKED = 28,
            REQ_ACTION_PWR_IS_MASTER_PWR = 29,
            REQ_TARGET_MAGNET = 30,
            REQ_ATTACK_GREATER_THAN_0 = 31,
            REQ_ATTACKER_NOT_FROZEN = 32,
            REQ_HERO_OR_MINION_TARGET = 33,
            REQ_CAN_BE_TARGETED_BY_SPELLS = 34,
            REQ_SUBCARD_IS_PLAYABLE = 35,
            REQ_TARGET_FOR_NO_COMBO = 36,
            REQ_NOT_MINION_JUST_PLAYED = 37,
            REQ_NOT_EXHAUSTED_HERO_POWER = 38,
            REQ_CAN_BE_TARGETED_BY_OPPONENTS = 39,
            REQ_ATTACKER_CAN_ATTACK = 40,
            REQ_TARGET_MIN_ATTACK = 41,
            REQ_CAN_BE_TARGETED_BY_HERO_POWERS = 42,
            REQ_ENEMY_TARGET_NOT_IMMUNE = 43,
            REQ_ENTIRE_ENTOURAGE_NOT_IN_PLAY = 44,
            REQ_MINIMUM_TOTAL_MINIONS = 45,
            REQ_MUST_TARGET_TAUNTER = 46,
            REQ_UNDAMAGED_TARGET = 47,
            REQ_CAN_BE_TARGETED_BY_BATTLECRIES = 48,
            REQ_STEADY_SHOT = 49,
            REQ_MINION_OR_ENEMY_HERO = 50,
            REQ_TARGET_IF_AVAILABLE_AND_DRAGON_IN_HAND = 51,
            REQ_LEGENDARY_TARGET = 52,
            REQ_FRIENDLY_MINION_DIED_THIS_TURN = 53,
            REQ_FRIENDLY_MINION_DIED_THIS_GAME = 54,
            REQ_ENEMY_WEAPON_EQUIPPED = 55,
            REQ_TARGET_IF_AVAILABLE_AND_MINIMUM_FRIENDLY_MINIONS = 56,
            REQ_TARGET_WITH_BATTLECRY = 57,
            REQ_TARGET_WITH_DEATHRATTLE = 58,
            REQ_TARGET_IF_AVAILABLE_AND_MINIMUM_FRIENDLY_SECRETS = 59,
            REQ_SECRET_ZONE_CAP_FOR_NON_SECRET = 60,
            REQ_TARGET_EXACT_COST = 61,
            REQ_STEALTHED_TARGET = 62,
            REQ_MINION_SLOT_OR_MANA_CRYSTAL_SLOT = 63,
            REQ_MAX_QUESTS = 64,
            REQ_TARGET_IF_AVAILABE_AND_ELEMENTAL_PLAYED_LAST_TURN = 65,
            REQ_TARGET_NOT_VAMPIRE = 66,
            REQ_TARGET_NOT_DAMAGEABLE_ONLY_BY_WEAPONS = 67,
            REQ_NOT_DISABLED_HERO_POWER = 68,
            REQ_MUST_PLAY_OTHER_CARD_FIRST = 69,
            REQ_HAND_NOT_FULL = 70,
            REQ_DRAG_TO_PLAY = 71,
        }

        List<string> namelist = new List<string>();

        public List<Card> CardList { get; } = new List<Card>();

        Dictionary<CardIdEnum, Card> cardidToCardList = new Dictionary<CardIdEnum, Card>();
        List<string> allCardIDS = new List<string>();
        public Card unknownCard;
        public bool installedWrong = false;

        public Card teacherminion;
        public Card illidanminion;
        public Card lepergnome;
        public Card burlyrockjaw;
        private static CardDB instance;

        public static CardDB Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CardDB();
                    //instance.enumCreator();// only call this to get latest cardids
                    // have to do it 2 times (or the kids inside the simcards will not have a simcard :D
                    foreach (Card c in instance.CardList)
                    {
                        c.CardSimulation = CardHelper.GetCardSimulation(c.cardIDenum);
                    }

                    var totalCardSimCount = instance.CardList.Count;
                    var implementedCardSimCount = instance.CardList.Count(x =>x.CardSimulationImplemented);
                    var percentage = implementedCardSimCount / (double)totalCardSimCount;
                    Helpfunctions.Instance.ErrorLog(
                        $"Card simulation implemented {percentage:P}, {implementedCardSimCount}/{totalCardSimCount}");

                    instance.SetAdditionalData();
                }
                return instance;
            }
        }

        private CardDB()
        {
            InitSpecialNames();
            string path = Settings.Instance.DataFolderPath;
            string cardDbPath = Path.Combine(path, "_carddb.txt");
            var lines = File.ReadAllLines(cardDbPath);
            Helpfunctions.Instance.InfoLog("read carddb.txt " + lines.Length + " lines");
            CardList.Clear();
            cardidToCardList.Clear();

            //placeholdercard
            Card plchldr = new Card {name = CardName.unknown, cost = 1000};
            namelist.Add("unknown");
            CardList.Add(plchldr);
            unknownCard = CardList[0];


            Card card = new Card();
            string name = "";
            foreach (string s in lines)
            {
                if (s.Contains("/Entity"))
                {
                    if (card.type == CardType.ENCHANTMENT)
                    {
                        //LogHelper.WriteCombatLog(c.CardID);
                        //LogHelper.WriteCombatLog(c.name);
                        //LogHelper.WriteCombatLog(c.description);
                        continue;
                    }

                    if (name != "")
                    {
                        namelist.Add(name);
                    }

                    name = "";
                    if (card.name != CardName.unknown)
                    {

                        CardList.Add(card);
                        //LogHelper.WriteCombatLog(c.name);
                        if (!cardidToCardList.ContainsKey(card.cardIDenum))
                        {
                            cardidToCardList.Add(card.cardIDenum, card);
                        }
                        else
                        {
                            Logger.GetLoggerInstanceForType()
                                .ErrorFormat("[c.cardIDenum:" + card.cardIDenum + "] already exists in cardidToCardList");
                        }
                    }

                }

                if (s.Contains("<Entity CardID=\"") && s.Contains(" version=\""))
                {
                    card = new Card();
                    string temp = s.Split(new string[] {"CardID=\""}, StringSplitOptions.None)[1];
                    temp = temp.Replace("\">", "");
                    temp = temp.Split(new string[] {"\""}, StringSplitOptions.None)[0];
                    allCardIDS.Add(temp);
                    card.cardIDenum = cardIdstringToEnum(temp);

                    //token:
                    if (temp.EndsWith("t"))
                    {
                        card.isToken = true;
                    }

                    if (temp.Equals("ds1_whelptoken")) card.isToken = true;
                    if (temp.Equals("CS2_mirror")) card.isToken = true;
                    if (temp.Equals("CS2_050")) card.isToken = true;
                    if (temp.Equals("CS2_052")) card.isToken = true;
                    if (temp.Equals("CS2_051")) card.isToken = true;
                    if (temp.Equals("NEW1_009")) card.isToken = true;
                    if (temp.Equals("CS2_152")) card.isToken = true;
                    if (temp.Equals("CS2_boar")) card.isToken = true;
                    if (temp.Equals("EX1_tk11")) card.isToken = true;
                    if (temp.Equals("EX1_506a")) card.isToken = true;
                    if (temp.Equals("skele21")) card.isToken = true;
                    if (temp.Equals("EX1_tk9")) card.isToken = true;
                    if (temp.Equals("EX1_finkle")) card.isToken = true;
                    if (temp.Equals("EX1_598")) card.isToken = true;
                    if (temp.Equals("EX1_tk34")) card.isToken = true;
                    //if (c.isToken) Helpfunctions.Instance.ErrorLog(temp +" is token");

                    continue;
                }

                //health
                if (s.Contains("<Tag enumID=\"45\""))
                {
                    string temp = s.Split(new string[] {"value=\""}, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    card.Health = Convert.ToInt32(temp);
                    continue;
                }

                //Class
                if (s.Contains("Tag enumID=\"199\""))
                {
                    string temp = s.Split(new string[] {"value=\""}, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    card.Class = Convert.ToInt32(temp);
                    continue;
                }

                //attack
                if (s.Contains("<Tag enumID=\"47\""))
                {
                    string temp = s.Split(new string[] {"value=\""}, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    card.Attack.Value = Convert.ToInt32(temp);
                    continue;
                }

                //race
                if (s.Contains("<Tag enumID=\"200\""))
                {
                    string temp = s.Split(new string[] {"value=\""}, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    card.race = Convert.ToInt32(temp);
                    continue;
                }

                //rarity
                if (s.Contains("<Tag enumID=\"203\""))
                {
                    string temp = s.Split(new string[] {"value=\""}, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    card.rarity = Convert.ToInt32(temp);
                    continue;
                }

                //manacost
                if (s.Contains("<Tag enumID=\"48\""))
                {
                    string temp = s.Split(new string[] {"value=\""}, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    card.cost = Convert.ToInt32(temp);
                    continue;
                }

                //cardtype
                if (s.Contains("<Tag enumID=\"202\""))
                {
                    string temp = s.Split(new string[] {"value=\""}, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    if (card.name != CardName.unknown)
                    {
                        //LogHelper.WriteCombatLog(temp);
                    }

                    int crdtype = Convert.ToInt32(temp);
                    if (crdtype == 10)
                    {
                        card.type = CardType.HEROPWR;
                    }

                    if (crdtype == 3)
                    {
                        card.type = CardType.HERO;
                    }

                    if (crdtype == 4)
                    {
                        card.type = CardType.MOB;
                    }

                    if (crdtype == 5)
                    {
                        card.type = CardType.SPELL;
                    }

                    if (crdtype == 6)
                    {
                        card.type = CardType.ENCHANTMENT;
                    }

                    if (crdtype == 7)
                    {
                        card.type = CardType.WEAPON;
                    }

                    continue;
                }

                //cardname
                if (s.Contains("<Tag enumID=\"185\""))
                {
                    string temp = string.Empty;
                    try
                    {
                        temp = s.Split(new string[] {"value=\"0\">"}, StringSplitOptions.RemoveEmptyEntries)[1];
                    }
                    catch(Exception ex)
                    {
                        Helpfunctions.Instance.ErrorLog(ex);
                        Logger.GetLoggerInstanceForType()
                            .ErrorFormat("[Unidentified Tag enumID 185 :" + s + "]");
                        continue;
                    }

                    temp = temp.Split(new string[] {"</Tag>"}, StringSplitOptions.RemoveEmptyEntries)[0];
                    temp = TrimHelper.TrimEnglishName(temp);
                    card.name = cardNameStringToEnum(temp, card.cardIDenum);
                    name = temp;


                    continue;
                }

                //cardtextinhand
                if (s.Contains("<Tag enumID=\"184\""))
                {
                    string temp = s.Split(new string[] {"value=\"0\">"}, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split(new string[] {"</Tag>"}, StringSplitOptions.RemoveEmptyEntries)[0];
                    temp = temp.Replace("&lt;", "");
                    temp = temp.Replace("b&gt;", "");
                    temp = temp.Replace("/b&gt;", "");
                    temp = temp.ToLower(new System.Globalization.CultureInfo("en-US", false));

                    if (temp.Contains("choose one"))
                    {
                        card.choice = true;
                        //LogHelper.WriteCombatLog(c.name + " is choice");
                    }

                    continue;
                }

                //poisonous
                if (s.Contains("<Tag enumID=\"363\""))
                {
                    string temp = s.Split(new string[] {"value=\""}, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    int ti = Convert.ToInt32(temp);
                    if (ti == 1) card.poisonous = true;
                    continue;
                }

                //enrage
                if (s.Contains("<Tag enumID=\"212\""))
                {
                    string temp = s.Split(new string[] {"value=\""}, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    int ti = Convert.ToInt32(temp);
                    if (ti == 1) card.Enrage = true;
                    continue;
                }

                //OneTurnEffect
                if (s.Contains("<Tag enumID=\"338\""))
                {
                    string temp = s.Split(new string[] {"value=\""}, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    int ti = Convert.ToInt32(temp);
                    if (ti == 1) card.oneTurnEffect = true;
                    continue;
                }

                //aura
                if (s.Contains("<Tag enumID=\"362\""))
                {
                    string temp = s.Split(new string[] {"value=\""}, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    int ti = Convert.ToInt32(temp);
                    if (ti == 1) card.Aura = true;
                    continue;
                }

                //taunt
                if (s.Contains("<Tag enumID=\"190\""))
                {
                    string temp = s.Split(new string[] {"value=\""}, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    int ti = Convert.ToInt32(temp);
                    if (ti == 1) card.tank = true;
                    continue;
                }

                //battlecry
                if (s.Contains("<Tag enumID=\"218\""))
                {
                    string temp = s.Split(new string[] {"value=\""}, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    int ti = Convert.ToInt32(temp);
                    if (ti == 1) card.battlecry = true;
                    continue;
                }

                //discover
                if (s.Contains("<Tag enumID=\"415\""))
                {
                    string temp = s.Split(new string[] {"value=\""}, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    int ti = Convert.ToInt32(temp);
                    if (ti == 1) card.discover = true;
                    continue;
                }

                //windfury
                if (s.Contains("<Tag enumID=\"189\""))
                {
                    string temp = s.Split(new string[] {"value=\""}, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    int ti = Convert.ToInt32(temp);
                    if (ti == 1) card.windfury = true;
                    continue;
                }

                //deathrattle
                if (s.Contains("<Tag enumID=\"217\""))
                {
                    string temp = s.Split(new string[] {"value=\""}, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    int ti = Convert.ToInt32(temp);
                    if (ti == 1) card.deathrattle = true;
                    continue;
                }

                //reborn
                if (s.Contains("<Tag enumID=\"1085\""))
                {
                    string temp = s.Split(new string[] { "value=\"" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    int ti = Convert.ToInt32(temp);
                    if (ti == 1)
                    {
                        card.Reborn = true;
                    }
                    continue;
                }

                //Inspire
                if (s.Contains("<Tag enumID=\"403\""))
                {
                    string temp = s.Split(new string[] {"value=\""}, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    int ti = Convert.ToInt32(temp);
                    if (ti == 1) card.Inspire = true;
                    continue;
                }

                //durability
                if (s.Contains("<Tag enumID=\"187\""))
                {
                    string temp = s.Split(new string[] {"value=\""}, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    card.Durability = Convert.ToInt32(temp);
                    continue;
                }

                //elite
                if (s.Contains("<Tag enumID=\"114\""))
                {
                    string temp = s.Split(new string[] {"value=\""}, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    int ti = Convert.ToInt32(temp);
                    if (ti == 1) card.Elite = true;
                    continue;
                }

                //combo
                if (s.Contains("<Tag enumID=\"220\""))
                {
                    string temp = s.Split(new string[] {"value=\""}, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    int ti = Convert.ToInt32(temp);
                    if (ti == 1) card.Combo = true;
                    continue;
                }

                //overload
                if (s.Contains("<Tag enumID=\"296\""))
                {
                    string temp = s.Split(new string[] {"value=\""}, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    card.overload = Convert.ToInt32(temp);
                    continue;
                }

                //lifesteal
                if (s.Contains("<Tag enumID=\"685\""))
                {
                    string temp = s.Split(new string[] {"value=\""}, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    int ti = Convert.ToInt32(temp);
                    if (ti == 1) card.lifesteal = true;
                    continue;
                }

                //untouchable
                if (s.Contains("<Tag enumID=\"448\""))
                {
                    string temp = s.Split(new string[] {"value=\""}, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    int ti = Convert.ToInt32(temp);
                    if (ti == 1) card.untouchable = true;
                    continue;
                }

                //stealh
                if (s.Contains("<Tag enumID=\"191\""))
                {
                    string temp = s.Split(new string[] {"value=\""}, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    int ti = Convert.ToInt32(temp);
                    if (ti == 1) card.Stealth = true;
                    continue;
                }

                //secret
                if (s.Contains("<Tag enumID=\"219\""))
                {
                    string temp = s.Split(new string[] {"value=\""}, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    int ti = Convert.ToInt32(temp);
                    if (ti == 1) card.Secret = true;
                    continue;
                }

                //quest
                if (s.Contains("<Tag enumID=\"462\""))
                {
                    string temp = s.Split(new string[] {"value=\""}, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    int ti = Convert.ToInt32(temp);
                    if (ti == 1) card.Quest = true;
                    continue;
                }

                //freeze
                if (s.Contains("<Tag enumID=\"208\""))
                {
                    string temp = s.Split(new string[] {"value=\""}, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    int ti = Convert.ToInt32(temp);
                    if (ti == 1) card.Freeze = true;
                    continue;
                }

                //adjacentbuff
                if (s.Contains("<Tag enumID=\"350\""))
                {
                    string temp = s.Split(new string[] {"value=\""}, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    int ti = Convert.ToInt32(temp);
                    if (ti == 1) card.AdjacentBuff = true;
                    continue;
                }

                //divineshield
                if (s.Contains("<Tag enumID=\"194\""))
                {
                    string temp = s.Split(new string[] {"value=\""}, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    int ti = Convert.ToInt32(temp);
                    if (ti == 1) card.DivineShield = true;
                    continue;
                }

                //charge
                if (s.Contains("<Tag enumID=\"197\""))
                {
                    string temp = s.Split(new string[] {"value=\""}, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    int ti = Convert.ToInt32(temp);
                    if (ti == 1) card.Charge = true;
                    continue;
                }

                //silence
                if (s.Contains("<Tag enumID=\"339\""))
                {
                    string temp = s.Split(new string[] {"value=\""}, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    int ti = Convert.ToInt32(temp);
                    if (ti == 1) card.Silence = true;
                    continue;
                }

                //morph
                if (s.Contains("<Tag enumID=\"293\""))
                {
                    string temp = s.Split(new string[] {"value=\""}, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    int ti = Convert.ToInt32(temp);
                    if (ti == 1) card.Morph = true;
                    continue;
                }

                //spellpower
                if (s.Contains("<Tag enumID=\"192\""))
                {
                    string temp = s.Split(new string[] {"value=\""}, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    int ti = Convert.ToInt32(temp);
                    if (ti == 1) card.Spellpower = true;
                    card.spellpowervalue = 1;
                    if (card.name == CardName.ancientmage) card.spellpowervalue = 0;
                    if (card.name == CardName.malygos) card.spellpowervalue = 5;
                    if (card.name == CardName.arcanotron) card.spellpowervalue = 2;
                    continue;
                }

                if (s.Contains("<PlayRequirement"))
                {
                    string temp = s.Split(new string[] {"reqID=\""}, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];
                    int reqID = Convert.ToInt32(temp);
                    card.playrequires.Add((ErrorType2) reqID);

                    int param = 0;
                    temp = s.Split(new string[] {"param=\""}, StringSplitOptions.RemoveEmptyEntries)[1];
                    try
                    {
                        if (Char.IsDigit(temp, 0))
                        {
                            temp = temp.Split('\"')[0];
                            param = Convert.ToInt32(temp);
                        }
                    }
                    catch(Exception ex)
                    {
                        Helpfunctions.Instance.ErrorLog(ex);
                        param = 0;
                    }

                    if (param > 0)
                    {
                        switch (reqID)
                        {
                            case 8:
                                card.needWithMaxAttackValueOf = param;
                                continue;
                            case 10:
                                card.needRaceForPlaying = param;
                                continue;
                            case 12:
                                card.needEmptyPlacesForPlaying = param;
                                continue;
                            case 19:
                                card.needMinionsCapIfAvailable = param;
                                continue;
                            case 23:
                                card.needMinNumberOfEnemy = param;
                                continue;
                            case 41:
                                card.needWithMinAttackValueOf = param;
                                continue;
                            case 45:
                                card.needMinTotalMinions = param;
                                continue;
                            case 56:
                                card.needMinOwnMinions = param;
                                continue;
                            case 59:
                                card.needControlaSecret = param;
                                continue;
                        }
                    }
                }

                if (s.Contains("<Tag name="))
                {
                    string temp = s.Split(new string[] {"<Tag name=\""}, StringSplitOptions.RemoveEmptyEntries)[1];
                    temp = temp.Split('\"')[0];

                }


            }

            teacherminion = getCardDataFromID(CardIdEnum.NEW1_026t);
            illidanminion = getCardDataFromID(CardIdEnum.EX1_614t);
            lepergnome = getCardDataFromID(CardIdEnum.EX1_029);
            burlyrockjaw = getCardDataFromID(CardIdEnum.GVG_068);

            Helpfunctions.Instance.InfoLog("CardList:" + cardidToCardList.Count);

        }

        public Card getCardData(CardName cardname)
        {

            foreach (Card ca in CardList)
            {
                if (ca.name == cardname)
                {
                    return ca;
                }
            }

            return unknownCard;
        }

        public Card getCardDataFromID(CardIdEnum id)
        {
            return cardidToCardList.ContainsKey(id) ? cardidToCardList[id] : unknownCard;
        }

        private void enumCreator()
        {
            //call this, if carddb.txt was changed, to get latest public enum cardIDEnum
            LogHelper.WriteMainLog("public enum cardIDEnum");
            LogHelper.WriteMainLog("{");
            LogHelper.WriteMainLog("None,");
            foreach (string cardid in allCardIDS)
            {
                LogHelper.WriteMainLog(cardid + ",");
            }
            LogHelper.WriteMainLog("}");



            LogHelper.WriteMainLog("public cardIDEnum cardIdstringToEnum(string s)");
            LogHelper.WriteMainLog("{");
            foreach (string cardid in allCardIDS)
            {
                LogHelper.WriteMainLog("if(s==\"" + cardid + "\") return CardIdEnum." + cardid + ";");
            }
            LogHelper.WriteMainLog("return CardIdEnum.None;");
            LogHelper.WriteMainLog("}");

            List<string> namelist = new List<string>();

            foreach (string cardid in this.namelist)
            {
                if (namelist.Contains(cardid)) continue;
                namelist.Add(cardid);
            }


            LogHelper.WriteMainLog("public enum cardName");
            LogHelper.WriteMainLog("{");
            foreach (string cardid in namelist)
            {
                LogHelper.WriteMainLog(cardid + ",");
            }
            LogHelper.WriteMainLog("}");

            LogHelper.WriteMainLog("public cardName cardNamestringToEnum(string s)");
            LogHelper.WriteMainLog("{");
            foreach (string cardid in namelist)
            {
                LogHelper.WriteMainLog("if(s==\"" + cardid + "\") return CardName." + cardid + ";");
            }
            LogHelper.WriteMainLog("return CardName.unknown;");
            LogHelper.WriteMainLog("}");

            // simcard creator:

            LogHelper.WriteMainLog("public SimTemplate getSimCard(cardIDEnum id)");
            LogHelper.WriteMainLog("{");
            foreach (string cardid in allCardIDS)
            {
                LogHelper.WriteMainLog("if(id == CardIdEnum." + cardid + ") return new Sim_" + cardid + "();");
            }
            LogHelper.WriteMainLog("return new SimTemplate();");
            LogHelper.WriteMainLog("}");

        }

        private void SetAdditionalData()
        {
            PenaltyManager penaltyManager = PenaltyManager.Instance;

            var triggerType = typeof(CardTrigger);
            var triggerNameArray = Enum.GetNames(triggerType);

            foreach (Card card in CardList)
            {
                if (penaltyManager.cardDrawBattleCryDatabase.ContainsKey(card.name))
                {
                    card.isCarddraw = penaltyManager.cardDrawBattleCryDatabase[card.name];
                }

                if (penaltyManager.DamageTargetSpecialDatabase.ContainsKey(card.name))
                {
                    card.damagesTargetWithSpecial = true;
                }

                if (penaltyManager.DamageTargetDatabase.ContainsKey(card.name))
                {
                    card.damagesTarget = true;
                }

                if (penaltyManager.priorityTargets.ContainsKey(card.name))
                {
                    card.targetPriority = penaltyManager.priorityTargets[card.name];
                }

                if (penaltyManager.specialMinions.ContainsKey(card.name))
                {
                    card.isSpecialMinion = true;
                }
                
                card.Triggers = new List<CardTrigger>();
                var cardSimulationType = card.CardSimulation.GetType();
                foreach (var triggerName in triggerNameArray)
                {
                    try
                    {
                        var methods = cardSimulationType.GetMethods()
                            .Where(x => x.Name.Equals(triggerName, StringComparison.Ordinal));
                        foreach (var methodInfo in methods)
                        {
                            if (methodInfo.DeclaringType == cardSimulationType)
                            {
                                var trigger = (CardTrigger) Enum.Parse(triggerType, triggerName);
                                card.Triggers.Add(trigger);
                            }
                        }
                    }
                    catch(Exception ex)
                    {
                        Helpfunctions.Instance.ErrorLog(ex);
                    }
                }

                if (card.Triggers.Count > 10)
                {
                    Helpfunctions.Instance.ErrorLog($"{cardSimulationType}'s triggers count is {card.Triggers.Count}");
                    card.Triggers.Clear();
                }
            }
        }
    }

}