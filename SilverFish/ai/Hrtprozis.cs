namespace HREngine.Bots
{
    using System;
    using System.Collections.Generic;

    public enum HeroEnum
    {
        None,
        druid,
        hunter,
        priest,
        warlock,
        thief,
        pala,
        warrior,
        shaman,
        mage,
        lordjaraxxus,
        ragnarosthefirelord,
        hogger,
        all
    }

    public sealed class Hrtprozis
    {
        public string deckName = "";

        public int enemyCursedCardsinHand;
        public int ownFenciCoaches;
        public int ownSaboteur;
        public int enemySaboteur;

        public int attackFaceHp = 15;
        public int ownHeroFatigue;
        public int ownDeckSize = 30;
        public int enemyDeckSize = 30;
        public int enemyHeroFatigue;

        public int ownHeroEntity = -1;
        public int enemyHeroEntitiy = -1;
        public DateTime roundstart = DateTime.Now;
        public int currentMana;

        public int heroHp = 30, enemyHp = 30;
        public int heroAtk, enemyAtk;
        public int heroDefence, enemyDefence;
        public bool ownheroisread;
        public int ownHeroNumAttacksThisTurn;
        public bool ownHeroWindfury;
        public bool herofrozen;
        public bool enemyfrozen;

        public List<CardDB.cardIDEnum> ownSecretList = new List<CardDB.cardIDEnum>();
        public int enemySecretCount;

        public Dictionary<CardDB.cardIDEnum, int> startDeck = new Dictionary<CardDB.cardIDEnum, int>();
        public Dictionary<CardDB.cardIDEnum, int> turnDeck = new Dictionary<CardDB.cardIDEnum, int>();
        public bool noDuplicates = false;


        public HeroEnum heroname = HeroEnum.druid, enemyHeroname = HeroEnum.druid;
        public CardDB.Card heroAbility;
        public bool ownAbilityisReady;
        public CardDB.Card enemyAbility;
        public int numOptionsPlayedThisTurn;
        public int numMinionsPlayedThisTurn;

        public int heroPowerUsesThisTurn;
        public int ownHeroPowerUsesThisGame;
        public int enemyHeroPowerUsesThisGame;
        public int lockAndLoads;

        public int numberMinionsDiedThisTurn;
        

        public int cardsPlayedThisTurn;
        public int owedRecall;
        public int ownCurrentRecall;
        public int enemyRecall;

        public int ownMaxMana;
        public int enemyMaxMana;

        public int enemyWeaponDurability;
        public int enemyWeaponAttack;
        public CardDB.cardName enemyHeroWeapon = CardDB.cardName.unknown;

        public int heroWeaponDurability;
        public int heroWeaponAttack;
        public CardDB.cardName ownHeroWeapon = CardDB.cardName.unknown;

        public bool heroImmuneToDamageWhileAttacking;
        public bool heroImmune;
        public bool enemyHeroImmune;


        public List<Minion> ownMinions = new List<Minion>();
        public List<Minion> enemyMinions = new List<Minion>();
        public Minion ownHero = new Minion();
        public Minion enemyHero = new Minion();

        public int anzOgOwnCThunHpBonus;
        public int anzOgOwnCThunAngrBonus;
        public int anzOgOwnCThunTaunt;
        public int anzOwnJadeGolem;
        public int anzEnemyJadeGolem;

        public int ownDragonConsort;
        public int enemyDragonConsort;
        public int ownLoatheb;
        public int enemyLoatheb;
        public int ownMillhouse;
        public int enemyMillhouse;
        public int nextSecretThisTurnCost0;
        public int ownPreparation;

        Helpfunctions help = Helpfunctions.Instance;
        //Imagecomparer icom = Imagecomparer.Instance;
        //HrtNumbers hrtnumbers = HrtNumbers.Instance;
        CardDB cdb = CardDB.Instance;

        private int ownPlayerController;
        
        
        private static readonly Lazy<Hrtprozis> lazy =
            new Lazy<Hrtprozis>(() => new Hrtprozis());

        public static Hrtprozis Instance { get { return lazy.Value; } }

        private Hrtprozis() {}


        public void setAttackFaceHP(int hp)
        {
            this.attackFaceHp = hp;
        }

        public void clearAll()
        {
            ownHeroEntity = -1;
            enemyHeroEntitiy = -1;
            currentMana = 0;
            heroHp = 30;
            enemyHp = 30;
            heroAtk = 0;
            enemyAtk = 0;
            heroDefence = 0; enemyDefence = 0;
            ownheroisread = false;
            ownAbilityisReady = false;
            ownHeroNumAttacksThisTurn = 0;
            ownHeroWindfury = false;
            ownSecretList.Clear();
            enemySecretCount = 0;
            heroname = HeroEnum.druid;
            enemyHeroname = HeroEnum.druid;
            heroAbility = new CardDB.Card();
            enemyAbility = new CardDB.Card();
            herofrozen = false;
            enemyfrozen = false;
            numMinionsPlayedThisTurn = 0;
            cardsPlayedThisTurn = 0;
            owedRecall = 0;
            ownMaxMana = 0;
            enemyMaxMana = 0;
            enemyWeaponDurability = 0;
            enemyWeaponAttack = 0;
            heroWeaponDurability = 0;
            heroWeaponAttack = 0;
            heroImmuneToDamageWhileAttacking = false;
            ownMinions.Clear();
            enemyMinions.Clear();
            heroImmune = false;
            enemyHeroImmune = false;
            numberMinionsDiedThisTurn = 0;
            ownCurrentRecall = 0;
            this.ownHeroWeapon = CardDB.cardName.unknown;
            this.enemyHeroWeapon = CardDB.cardName.unknown;
            noDuplicates = false;
        }

        public void clearDecks()
        {
            startDeck.Clear();
            turnDeck.Clear();
        }

        public void addCardToDecks(CardDB.cardIDEnum card, int num)
        {
            startDeck.Add(card, num);
            turnDeck.Add(card, num);
        }

        public void setTurnDeck(string td)
        {
            turnDeck.Clear();
            string temp = td.Replace("td: ", "");
            foreach (string s in temp.Split(';'))
            {
                string ss = s.Replace(" ", "");
                if (ss == "" || ss == " ") continue;
                string[] pair = ss.Split(',');
                CardDB.cardIDEnum card = CardDB.Instance.cardIdstringToEnum(pair[0]);
                int num = 1;
                if (pair.Length > 1) num = Convert.ToInt32(pair[1]);

                turnDeck.Add(card, num);
            }
        }

        public void setDeckName(string deckname)
        {
            this.deckName = deckname;
        }

        public void setHeroName(string heron)
        {
            this.heroname = this.heroNametoEnum(heron);
        }

        public void setEnemyHeroName(string heron)
        {
            this.enemyHeroname = this.heroNametoEnum(heron);
        }

        public void setOwnPlayer(int player)
        {
            this.ownPlayerController = player;
        }

        public int getOwnController()
        {
            return this.ownPlayerController;
        }

        public void updateJadeGolemsInfo(int anzOwnJG, int anzEmemyJG)
        {
            anzOwnJadeGolem = anzOwnJG;
            anzEnemyJadeGolem = anzEmemyJG;
        }

        public string heroIDtoName(string s)
        {
            switch (s) //keep 1 extra of each for future proofing
            {
                case "HERO_01": return "warrior";
                case "HERO_01a": return "warrior";
                case "HERO_01b": return "warrior";
                case "HERO_02": return "shaman";
                case "HERO_02a": return "shaman";
                case "HERO_02b": return "shaman";
                case "HERO_03": return "thief";
                case "HERO_03a": return "thief";
                case "HERO_04": return "pala";
                case "HERO_04a": return "pala";
                case "HERO_04b": return "pala";
                case "HERO_05": return "hunter";
                case "HERO_05a": return "hunter";
                case "HERO_05b": return "hunter";
                case "HERO_06": return "druid";
                case "HERO_06a": return "druid";
                case "HERO_07": return "warlock";
                case "HERO_07a": return "warlock";
                case "HERO_08": return "mage";
                case "HERO_08a": return "mage";
                case "HERO_08b": return "mage";
                case "HERO_08c": return "mage";
                case "HERO_09": return "priest";
                case "HERO_09a": return "priest";
                case "HERO_09b": return "priest";
                case "EX1_323h": return "lordjaraxxus";
                case "BRM_027h": return "ragnarosthefirelord";
                case "XXX_040": return "hogger";
                default:
                    string retval = CardDB.Instance.getCardDataFromID(CardDB.Instance.cardIdstringToEnum(s)).name.ToString();
                    return retval;
            }
        }

        // for class/deck mulligan paths
        public string heroEnumtoCommonName(HeroEnum he)
        {
            switch (he)
            {
                case HeroEnum.druid: return "Druid";
                case HeroEnum.hunter: return "Hunter";
                case HeroEnum.mage: return "Mage";
                case HeroEnum.pala: return "Paladin";
                case HeroEnum.priest: return "Priest";
                case HeroEnum.shaman: return "Shaman";
                case HeroEnum.thief: return "Rogue";
                case HeroEnum.warlock: return "Warlock";
                case HeroEnum.warrior: return "Warrior";
                default: return "none";
            }
        }


        public static string heroEnumtoName(HeroEnum he)
        {
            switch (he)
            {
                case HeroEnum.druid: return "druid";
                case HeroEnum.hunter: return "hunter";
                case HeroEnum.mage: return "mage";
                case HeroEnum.pala: return "pala";
                case HeroEnum.priest: return "priest";
                case HeroEnum.shaman: return "shaman";
                case HeroEnum.thief: return "thief";
                case HeroEnum.warlock: return "warlock";
                case HeroEnum.warrior: return "warrior";
                case HeroEnum.lordjaraxxus: return "lordjaraxxus";
                case HeroEnum.ragnarosthefirelord: return "ragnarosthefirelord";
                case HeroEnum.hogger: return "hogger";
                default: return "druid";
            }
        }

        public HeroEnum heroNametoEnum(string s)
        {
            switch (s)
            {
                case "all": return HeroEnum.all;
                case "druid": return HeroEnum.druid;
                case "hunter": return HeroEnum.hunter;
                case "mage": return HeroEnum.mage;
                case "pala": return HeroEnum.pala;
                case "paladin": return HeroEnum.pala; //for mulligan/combo/discovery
                case "priest": return HeroEnum.priest;
                case "shaman": return HeroEnum.shaman;
                case "rogue": return HeroEnum.thief; //for mulligan/combo/discovery
                case "thief": return HeroEnum.thief;
                case "warlock": return HeroEnum.warlock;
                case "warrior": return HeroEnum.warrior;
                case "lordjaraxxus": return HeroEnum.lordjaraxxus;
                case "ragnarosthefirelord": return HeroEnum.ragnarosthefirelord;
                case "hogger": return HeroEnum.hogger;
                default: return HeroEnum.None;
            }
        }

        public TAG_CLASS heroEnumtoTagClass(HeroEnum he)
        {
            switch (he)
            {
                case HeroEnum.druid: return TAG_CLASS.DRUID;
                case HeroEnum.hunter: return TAG_CLASS.HUNTER;
                case HeroEnum.mage: return TAG_CLASS.MAGE;
                case HeroEnum.pala: return TAG_CLASS.PALADIN;
                case HeroEnum.priest: return TAG_CLASS.PRIEST;
                case HeroEnum.shaman: return TAG_CLASS.SHAMAN;
                case HeroEnum.thief: return TAG_CLASS.ROGUE;
                case HeroEnum.warlock: return TAG_CLASS.WARLOCK;
                case HeroEnum.warrior: return TAG_CLASS.WARRIOR;
                case HeroEnum.all: return TAG_CLASS.ALL;
                default: return TAG_CLASS.INVALID;
            }
        }

        public HeroEnum heroTAG_CLASSstringToEnum(string s)
        {
            switch (s)
            {
                case "DRUID": return HeroEnum.druid;
                case "HUNTER": return HeroEnum.hunter;
                case "MAGE": return HeroEnum.mage;
                case "PALADIN": return HeroEnum.pala;
                case "PRIEST": return HeroEnum.priest;
                case "SHAMAN": return HeroEnum.shaman;
                case "ROGUE": return HeroEnum.thief;
                case "WARLOCK": return HeroEnum.warlock;
                case "WARRIOR": return HeroEnum.warrior;
                default: return HeroEnum.None;
            }
        }


        public void removeCardFromTurnDeck(CardDB.cardIDEnum crd)
        {
            if (turnDeck.ContainsKey(crd))
            {
                if (turnDeck[crd] > 1) turnDeck[crd]--;
                else turnDeck.Remove(crd);
            }
        }

        public void updateMinions(List<Minion> om, List<Minion> em)
        {
            this.ownMinions.Clear();
            this.enemyMinions.Clear();
            foreach (var item in om)
            {
                this.ownMinions.Add(new Minion(item));
            }
            //this.ownMinions.AddRange(om);
            foreach (var item in em)
            {
                this.enemyMinions.Add(new Minion(item));
            }
            //this.enemyMinions.AddRange(em);

            //sort them 
            updatePositions();
        }

        public void updateSecretStuff(List<string> ownsecs, int numEnemSec)
        {
            this.ownSecretList.Clear();
            foreach (string s in ownsecs)
            {
                this.ownSecretList.Add(CardDB.Instance.cardIdstringToEnum(s));
            }
            this.enemySecretCount = numEnemSec;
        }

        public void updatePlayer(int maxmana, int currentmana, int cardsplayedthisturn, int numMinionsplayed, int optionsPlayedThisTurn, int recall, int heroentity, int enemyentity, int numMinsDied, int currentRecall, int enemRecall, int hrpwrUsesThisTurn, int locknload)
        {
            this.currentMana = currentmana;
            this.ownMaxMana = maxmana;
            this.cardsPlayedThisTurn = cardsplayedthisturn;
            this.numMinionsPlayedThisTurn = numMinionsplayed;
            
            this.ownHeroEntity = heroentity;
            this.enemyHeroEntitiy = enemyentity;
            this.numOptionsPlayedThisTurn = optionsPlayedThisTurn;

            this.numberMinionsDiedThisTurn = numMinsDied;
            this.ownCurrentRecall= currentRecall;
            this.owedRecall = recall;
            this.enemyRecall = enemRecall;

            this.heroPowerUsesThisTurn = hrpwrUsesThisTurn;
            this.lockAndLoads = locknload;
            
        }

        public void setPlayereffects(int ownDragonConsorts, int enemyDragonConsorts, int ownLoathebs, int enemyLoathebs, int ownMillhouses, int enemyMillhouses, int nextSecretThisTurnCost0, int ownPrep, int ownSabo, int enemySabo, int ownFenciCoachess, int enemycurses)
        {
            this.ownDragonConsort = ownDragonConsorts;
            this.enemyDragonConsort = enemyDragonConsorts;

            this.ownLoatheb = ownLoathebs;
            this.enemyLoatheb = enemyLoathebs;

            this.ownMillhouse = ownMillhouses;
            this.enemyMillhouse = enemyMillhouses;

            this.nextSecretThisTurnCost0 = nextSecretThisTurnCost0;

            this.ownPreparation = ownPrep;

            this.ownSaboteur = ownSabo;
            this.enemySaboteur = enemySabo;

            this.ownFenciCoaches = ownFenciCoachess;

            this.enemyCursedCardsinHand = enemycurses;
        }

        public void updateOwnHero(string weapon, int watt, int wdur, string heron, CardDB.Card hab, bool habrdy, Minion Hero, int heroPowerUsesThisGame)
        {
            this.ownHeroWeapon = CardDB.Instance.cardNamestringToEnum(weapon);
            this.heroWeaponAttack = watt;
            this.heroWeaponDurability = wdur;

            this.heroname = this.heroNametoEnum(heron);

            this.heroAbility = hab;
            this.ownAbilityisReady = habrdy;

            this.ownHero = new Minion(Hero);
            this.ownHero.updateReadyness();

            this.ownHeroPowerUsesThisGame = heroPowerUsesThisGame;
        }

        public void updateEnemyHero(string weapon, int weaponAttack, int weaponDurability, string heron, int enemMaxMana, CardDB.Card eab, Minion enemyHero, int heroPowerUsesThisGame)
        {
            this.enemyHeroWeapon = CardDB.Instance.cardNamestringToEnum(weapon);
            this.enemyWeaponAttack = weaponAttack;
            this.enemyWeaponDurability = weaponDurability;

            this.enemyMaxMana = enemMaxMana;

            this.enemyHeroname = this.heroNametoEnum(heron);

            this.enemyAbility = eab;

            this.enemyHero = new Minion(enemyHero);

            this.enemyHeroPowerUsesThisGame = heroPowerUsesThisGame;

        }

        public void updateCThunInfo(int OgOwnCThunAngrBonus, int OgOwnCThunHpBonus, int OgOwnCThunTaunt)
        {
            this.anzOgOwnCThunAngrBonus = OgOwnCThunAngrBonus;
            this.anzOgOwnCThunHpBonus = OgOwnCThunHpBonus;
            this.anzOgOwnCThunTaunt = OgOwnCThunTaunt;
        }

        public void updateFatigueStats(int ods, int ohf, int eds, int ehf)
        {
            this.ownDeckSize = ods;
            this.ownHeroFatigue = ohf;
            this.enemyDeckSize = eds;
            this.enemyHeroFatigue = ehf;
        }

        public void updatePositions()
        {
            this.ownMinions.Sort((a, b) => a.zonepos.CompareTo(b.zonepos));
            this.enemyMinions.Sort((a, b) => a.zonepos.CompareTo(b.zonepos));
            int i = 0;
            foreach (Minion m in this.ownMinions)
            {
                i++;
                m.zonepos = i;

            }
            i = 0;
            foreach (Minion m in this.enemyMinions)
            {
                i++;
                m.zonepos = i;
            }

            /*List<Minion> temp = new List<Minion>();
            temp.AddRange(ownMinions);
            this.ownMinions.Clear();
            this.ownMinions.AddRange(temp.OrderBy(x => x.zonepos).ToList());
            temp.Clear();
            temp.AddRange(enemyMinions);
            this.enemyMinions.Clear();
            this.enemyMinions.AddRange(temp.OrderBy(x => x.zonepos).ToList());*/

        }

        private Minion createNewMinion(Handmanager.Handcard hc, int id)
        {
            Minion m = new Minion
            {
                handcard = new Handmanager.Handcard(hc),
                zonepos = id + 1,
                entityID = hc.entity,
                Angr = hc.card.Attack,
                Hp = hc.card.Health,
                maxHp = hc.card.Health,
                name = hc.card.name,
                playedThisTurn = true,
                numAttacksThisTurn = 0
            };


            if (hc.card.windfury) m.windfury = true;
            if (hc.card.tank) m.taunt = true;
            if (hc.card.Charge)
            {
                m.Ready = true;
                m.charge = 1;
            }
            if (hc.card.Shield) m.divineshild = true;
            if (hc.card.poisionous) m.poisonous = true;

            if (hc.card.Stealth) m.stealth = true;

            if (m.name == CardDB.cardName.lightspawn && !m.silenced)
            {
                m.Angr = m.Hp;
            }


            return m;
        }

        //these functions are not longer updated (moved to playfield.getCompleteBoardForSimulating)
        public void printHero(bool writetobuffer = false)
        {
           
        }

        public void printOwnMinions(bool writetobuffer = false)
        {
            
        }

        public void printEnemyMinions(bool writetobuffer = false)
        {
            
        }


    }

}