namespace HREngine.Bots
{
    using System;
    using System.Collections.Generic;

    public struct triggerCounter
    {
        public int minionsGotHealed;

        public int charsGotHealed;

        public int ownMinionsGotDmg;
        public int enemyMinionsGotDmg;

        public int ownHeroGotDmg;
        public int enemyHeroGotDmg;

        public int ownMinionsDied;
        public int enemyMinionsDied;
        public int ownBeastSummoned;
        public int ownBeastDied;
        public int enemyBeastDied;
        public int ownMechanicDied;
        public int enemyMechanicDied;
        public int ownMurlocDied;
        public int enemyMurlocDied;
        public int ownMinionLosesDivineShield;
        public int enemyMinionLosesDivineShield;

        public bool ownMinionsChanged;
        public bool enemyMininsChanged;
    }

    public struct IDEnumOwner
    {
        public CardDB.cardIDEnum IDEnum;
        public bool own;
    }
	
    //todo save "started" variables outside (they doesnt change)

    public class Playfield
    {
        //Todo: delete all new list<minion>
        //TODO: graveyard change (list <card,owner>)
        //Todo: vanish clear all auras/buffs (NEW1_004)

        public bool logging = false;
        public bool complete = false;
        public int bestBoard = 0;
        public bool dirtyTwoTurnSim = false;
        public bool checkLostAct = false;

        public int nextEntity = 70;
        public int pID = 0;
        public bool isLethalCheck = false;
        public int enemyTurnsCount = 0; 

        public triggerCounter tempTrigger = new triggerCounter();
        public Hrtprozis prozis = Hrtprozis.Instance;
        public int gTurn = 0;
        public int gTurnStep = 0;

        //aura minions##########################
        //todo reduce buffing vars
        public int anzOwnRaidleader = 0;
        public int anzEnemyRaidleader = 0;
        public int anzOwnStormwindChamps = 0;
        public int anzEnemyStormwindChamps = 0;
        public int anzOwnWarhorseTrainer = 0;
        public int anzEnemyWarhorseTrainer = 0;
        public int anzOwnTundrarhino = 0;
        public int anzEnemyTundrarhino = 0;
        public int anzOwnTimberWolfs = 0;
        public int anzEnemyTimberWolfs = 0;
        public int anzOwnMurlocWarleader = 0;
        public int anzEnemyMurlocWarleader = 0;
        public int anzAcidmaw = 0;
        public int anzOwnGrimscaleOracle = 0;
        public int anzEnemyGrimscaleOracle = 0;
        public int anzOwnShadowfiend = 0;
        public int anzOwnAuchenaiSoulpriest = 0;
        public int anzEnemyAuchenaiSoulpriest = 0;
        public int anzOwnSouthseacaptain = 0;
        public int anzEnemySouthseacaptain = 0;
        public int anzOwnMalGanis = 0;
        public int anzEnemyMalGanis = 0;
        public int anzOwnPiratesStarted = 0;
        public int anzOwnMurlocStarted = 0;
        public int anzOwnChromaggus = 0;
        public int anzEnemyChromaggus = 0;
        public int anzOwnDragonConsort = 0;
        public int anzOwnDragonConsortStarted = 0;
        public int anzOwnBolfRamshield = 0;
        public int anzEnemyBolfRamshield = 0;
        public int anzOwnHorsemen = 0;
        public int anzEnemyHorsemen = 0;
        public int anzOwnAnimatedArmor = 0;
        public int anzEnemyAnimatedArmor = 0;
        public int anzMoorabi = 0;

        public int ownAbilityFreezesTarget = 0;
        public int enemyAbilityFreezesTarget = 0;
        public int ownHeroPowerCostLessOnce = 0;
        public int enemyHeroPowerCostLessOnce = 0;
        public int ownHeroPowerExtraDamage = 0;
        public int enemyHeroPowerExtraDamage = 0;
        public int ownHeroPowerAllowedQuantity = 1;
        public int enemyHeroPowerAllowedQuantity = 1;
        public int anzUsedOwnHeroPower = 0;
        public int anzUsedEnemyHeroPower = 0;
        public int anzOwnExtraAngrHp = 0;
        public int anzEnemyExtraAngrHp = 0;

        public int anzOwnMechwarper = 0;
        public int anzOwnMechwarperStarted = 0;
        public int anzEnemyMechwarper = 0;
        public int anzEnemyMechwarperStarted = 0;

        public int anzOgOwnCThun = 0;
        public int anzOgOwnCThunHpBonus = 0;
        public int anzOgOwnCThunAngrBonus = 0;
        public int anzOgOwnCThunTaunt = 0;
        public int anzOwnJadeGolem = 0;
        public int anzEnemyJadeGolem = 0;
        public int anzOwnElementalsThisTurn = 0;
        public int anzOwnElementalsLastTurn = 0;

        public int blackwaterpirate = 0;
        public int blackwaterpirateStarted = 0;
        public int embracetheshadow = 0;
        public int ownCrystalCore = 0;
        public bool ownMinionsInDeckCost0 = false;

        public int anzEnemyTaunt = 0;
        public int anzOwnTaunt = 0;
        public int ownMinionsDiedTurn = 0;
        public int enemyMinionsDiedTurn = 0;

        public bool feugenDead = false;
        public bool stalaggDead = false;

        public bool weHavePlayedMillhouseManastorm = false;
        public bool weHaveSteamwheedleSniper = false;
        public bool enemyHaveSteamwheedleSniper = false;
        public bool ownSpiritclaws = false;
        public bool enemySpiritclaws = false;

        public bool needGraveyard = false;


        public int doublepriest = 0;
        public int enemydoublepriest = 0;
        public int ownMistcaller = 0;

        public int lockandload = 0;
        public int stampede = 0;

        public int ownBaronRivendare = 0;
        public int enemyBaronRivendare = 0;
        public int ownBrannBronzebeard = 0;
        public int enemyBrannBronzebeard = 0;        
        public int ownTurnEndEffectsTriggerTwice = 0;
        public int enemyTurnEndEffectsTriggerTwice = 0;
        public int ownFandralStaghelm = 0;
        //#########################################

        public int tempanzOwnCards = 0; // for Goblin Sapper
        public int tempanzEnemyCards = 0;// for Goblin Sapper

        public bool isOwnTurn = true; // its your turn?
        public int turnCounter = 0;

        public bool attacked = false;
        public int attackFaceHP = 15;

        public int ownController = 0;
        public int evaluatePenality = 0;
        public int ruleWeight = 0;
        public string rulesUsed = "";

        public bool useSecretsPlayAround = false;
        public bool print = false;

        public Int64 hashcode = 0;
        public float value = Int32.MinValue;
        public int guessingHeroHP = 30;
        public float doDirtyTts = 100000;

        public int mana = 0;
        public int manaTurnEnd = 0;

        public List<CardDB.cardIDEnum> ownSecretsIDList = new List<CardDB.cardIDEnum>();
        public List<SecretItem> enemySecretList = new List<SecretItem>();
        public Dictionary<CardDB.cardIDEnum, int> enemyCardsOut = null;

        public List<Playfield> nextPlayfields = new List<Playfield>();

        public int enemySecretCount = 0;

        public Minion ownHero;
        public Minion enemyHero;
        public HeroEnum ownHeroName = HeroEnum.None;
        public HeroEnum enemyHeroName = HeroEnum.None;
        public TAG_CLASS ownHeroStartClass = TAG_CLASS.INVALID;
        public TAG_CLASS enemyHeroStartClass = TAG_CLASS.INVALID;

        public Weapon ownWeapon = new Weapon();
        public Weapon enemyWeapon = new Weapon();

        public List<Minion> ownMinions = new List<Minion>();
        public List<Minion> enemyMinions = new List<Minion>();
        public List<GraveYardItem> diedMinions = null;
        public Dictionary<int, IDEnumOwner> LurkersDB = new Dictionary<int, IDEnumOwner>();
        public Questmanager.QuestItem ownQuest = new Questmanager.QuestItem();
        public Questmanager.QuestItem enemyQuest = new Questmanager.QuestItem();


        public List<Handmanager.Handcard> owncards = new List<Handmanager.Handcard>();
        public int owncarddraw = 0;

        public List<Action> playactions = new List<Action>();
        public List<int> pIdHistory = new List<int>();

        public int enemycarddraw = 0;
        public int enemyAnzCards = 0;

        public int spellpower = 0;
        public int spellpowerStarted = 0;
        public int enemyspellpower = 0;
        public int enemyspellpowerStarted = 0;
        public int wehaveCounterspell = 0;
        public int lethlMissing = 1000;

        public bool nextSecretThisTurnCost0 = false;
        public bool playedPreparation = false;
        public bool nextSpellThisTurnCost0 = false;
        public bool nextMurlocThisTurnCostHealth = false;
        public bool nextSpellThisTurnCostHealth = false;

        public bool loatheb = false;
        public int winzigebeschwoererin = 0;
        public int startedWithWinzigebeschwoererin = 0;
        public int managespenst = 0;
        public int startedWithManagespenst = 0;

        public int ownMinionsCostMore = 0;
        public int ownMinionsCostMoreAtStart = 0;
        public int ownSpelsCostMore = 0;
        public int ownSpelsCostMoreAtStart = 0;
        public int ownDRcardsCostMore = 0;
        public int ownDRcardsCostMoreAtStart = 0;
        
        

        public int beschwoerungsportal = 0;
        public int startedWithbeschwoerungsportal = 0;
        public int myCardsCostLess = 0;
        public int startedWithmyCardsCostLess = 0;
        public int anzOwnAviana = 0;
        public int anzOwnCloakedHuntress = 0;
        public int nerubarweblord = 0;
        public int startedWithnerubarweblord = 0;

        public bool startedWithDamagedMinions = false; // needed for manacalculation of the spell "Crush"

        public int ownWeaponAttackStarted = 0;
        public int ownMobsCountStarted = 0;
        public int ownCardsCountStarted = 0;
        public int enemyMobsCountStarted = 0;
        public int enemyCardsCountStarted = 0;
        public int ownHeroHpStarted = 30;
        public int enemyHeroHpStarted = 30;

        public int mobsplayedThisTurn = 0;
        public int startedWithMobsPlayedThisTurn = 0;
        public int spellsplayedSinceRecalc = 0;
        public int secretsplayedSinceRecalc = 0;

        public int optionsPlayedThisTurn = 0;
        public int cardsPlayedThisTurn = 0;
        public int ueberladung = 0; 
        public int lockedMana = 0;

        public int enemyOptionsDoneThisTurn = 0;

        public int ownMaxMana = 0;
        public int enemyMaxMana = 0;

        public int lostDamage = 0;
        public int lostHeal = 0;
        public int lostWeaponDamage = 0;

        public int ownDeckSize = 30;
        public int enemyDeckSize = 30;
        public int ownHeroFatigue = 0;
        public int enemyHeroFatigue = 0;

        public bool ownAbilityReady = false;
        public Handmanager.Handcard ownHeroAblility;

        public bool enemyAbilityReady = false;
        public Handmanager.Handcard enemyHeroAblility;
        public Playfield bestEnemyPlay = null;
        public Playfield endTurnState = null;

        // just for saving which minion to revive with secrets (=the first one that died);
        public CardDB.cardIDEnum revivingOwnMinion = CardDB.cardIDEnum.None;
        public CardDB.cardIDEnum revivingEnemyMinion = CardDB.cardIDEnum.None;
        public CardDB.cardIDEnum OwnLastDiedMinion = CardDB.cardIDEnum.None;

        public int shadowmadnessed = 0; //minions has switched controllers this turn.
        


        private void addMinionsReal(List<Minion> source, List<Minion> trgt)
        {
            foreach (Minion m in source)
            {
                trgt.Add(new Minion(m));
            }

        }

        private void addCardsReal(List<Handmanager.Handcard> source)
        {

            foreach (Handmanager.Handcard hc in source)
            {
                this.owncards.Add(new Handmanager.Handcard(hc));
            }

        }

        public Playfield()
        {
            this.pID = prozis.getPid();
            if (this.print)
            {
                this.pIdHistory.Add(pID);
            }
            this.nextEntity = 1000;
            this.isLethalCheck = false;
            this.ownController = prozis.getOwnController();

            this.gTurn = (prozis.gTurn + 1) / 2;
            this.gTurnStep = prozis.gTurnStep;
            this.mana = prozis.currentMana;
            this.manaTurnEnd = this.mana;
            this.ownMaxMana = prozis.ownMaxMana;
            this.enemyMaxMana = prozis.enemyMaxMana;
            this.evaluatePenality = 0;
            this.ruleWeight = 0;
            this.rulesUsed = "";
            this.ownSecretsIDList.AddRange(prozis.ownSecretList);
            this.enemySecretCount = prozis.enemySecretCount;

            this.anzOgOwnCThunAngrBonus = prozis.anzOgOwnCThunAngrBonus;
            this.anzOgOwnCThunHpBonus = prozis.anzOgOwnCThunHpBonus;
            this.anzOgOwnCThunTaunt = prozis.anzOgOwnCThunTaunt;
            this.anzOwnJadeGolem = prozis.anzOwnJadeGolem;
            this.anzEnemyJadeGolem = prozis.anzEnemyJadeGolem;
            this.OwnLastDiedMinion = prozis.OwnLastDiedMinion;
            this.anzOwnElementalsThisTurn = prozis.anzOwnElementalsThisTurn;
            this.anzOwnElementalsLastTurn = prozis.anzOwnElementalsLastTurn;

            this.attackFaceHP = prozis.attackFaceHp;

            this.complete = false;

            this.ownHero = new Minion(prozis.ownHero);
            this.enemyHero = new Minion(prozis.enemyHero);
            this.ownWeapon = new Weapon(prozis.ownWeapon);
            this.enemyWeapon = new Weapon(prozis.enemyWeapon);
                 
            addMinionsReal(prozis.ownMinions, ownMinions);
            addMinionsReal(prozis.enemyMinions, enemyMinions);
            addCardsReal(Handmanager.Instance.handCards);            
            this.LurkersDB = new Dictionary<int, IDEnumOwner>(prozis.LurkersDB);

            this.enemySecretList.Clear();
            if (Settings.Instance.useSecretsPlayAround)
            {
                this.useSecretsPlayAround = true;
                foreach (SecretItem si in Probabilitymaker.Instance.enemySecrets)
                {
                    this.enemySecretList.Add(new SecretItem(si));
                }
            }

            this.ownHeroName = prozis.heroname;
            this.enemyHeroName = prozis.enemyHeroname;
            this.ownHeroStartClass = prozis.ownHeroStartClass;
            this.enemyHeroStartClass = prozis.enemyHeroStartClass;
            //####buffs#############################

            this.anzOwnRaidleader = 0;
            this.anzEnemyRaidleader = 0;
            this.anzOwnStormwindChamps = 0;
            this.anzEnemyStormwindChamps = 0;
            this.anzOwnAnimatedArmor = 0;
            this.anzEnemyAnimatedArmor = 0;
            this.anzMoorabi = 0;
            this.anzOwnExtraAngrHp = 0;
            this.anzEnemyExtraAngrHp = 0;
            this.anzOwnWarhorseTrainer = 0;
            this.anzEnemyWarhorseTrainer = 0;
            this.anzOwnTundrarhino = 0;
            this.anzEnemyTundrarhino = 0;
            this.anzOwnTimberWolfs = 0;
            this.anzEnemyTimberWolfs = 0;
            this.anzOwnMurlocWarleader = 0;
            this.anzEnemyMurlocWarleader = 0;
            this.anzAcidmaw = 0;
            this.anzOwnGrimscaleOracle = 0;
            this.anzEnemyGrimscaleOracle = 0;
            this.anzOwnShadowfiend = 0;
            this.anzOwnAuchenaiSoulpriest = 0;
            this.anzEnemyAuchenaiSoulpriest = 0;
            this.anzOwnSouthseacaptain = 0;
            this.anzEnemySouthseacaptain = 0;
            this.anzOwnDragonConsortStarted = 0;
            this.anzOwnPiratesStarted = 0;
            this.anzOwnMurlocStarted = 0;

            this.ownAbilityFreezesTarget = 0;
            this.enemyAbilityFreezesTarget = 0;
            this.ownHeroPowerCostLessOnce = 0;
            this.enemyHeroPowerCostLessOnce = 0;
            this.ownHeroPowerExtraDamage = 0;
            this.enemyHeroPowerExtraDamage = 0;
            this.ownHeroPowerAllowedQuantity = 1;
            this.enemyHeroPowerAllowedQuantity = 1;
            this.anzUsedOwnHeroPower = 0;
            this.anzUsedEnemyHeroPower = 0;

            this.anzEnemyTaunt = 0;
            this.anzOwnTaunt = 0;
            this.ownMinionsDiedTurn = 0;
            this.enemyMinionsDiedTurn = 0;

            this.feugenDead = Probabilitymaker.Instance.feugenDead;
            this.stalaggDead = Probabilitymaker.Instance.stalaggDead;

            this.weHavePlayedMillhouseManastorm = false;

            this.doublepriest = 0;
            this.enemydoublepriest = 0;
            this.ownMistcaller = 0;

            this.lockandload = 0;
            this.stampede = 0;

            this.ownBaronRivendare = 0;
            this.enemyBaronRivendare = 0;
            this.ownBrannBronzebeard = 0;
            this.enemyBrannBronzebeard = 0;
            this.ownTurnEndEffectsTriggerTwice = 0;
            this.enemyTurnEndEffectsTriggerTwice = 0;
            this.ownFandralStaghelm = 0;
            //#########################################

            this.enemycarddraw = 0;
            this.owncarddraw = 0;

            this.enemyAnzCards = Handmanager.Instance.enemyAnzCards;

            this.ownAbilityReady = prozis.ownAbilityisReady;
            this.ownHeroAblility = new Handmanager.Handcard { card = prozis.heroAbility, manacost = prozis.ownHeroPowerCost };
            this.enemyHeroAblility = new Handmanager.Handcard { card = prozis.enemyAbility, manacost = prozis.enemyHeroPowerCost };
            this.enemyAbilityReady = false;
            this.bestEnemyPlay = null;

            this.ownQuest = Questmanager.Instance.ownQuest;
            this.enemyQuest = Questmanager.Instance.enemyQuest;
            this.mobsplayedThisTurn = prozis.numMinionsPlayedThisTurn;
            this.startedWithMobsPlayedThisTurn = prozis.numMinionsPlayedThisTurn;// only change mobsplayedthisturm
            this.cardsPlayedThisTurn = prozis.cardsPlayedThisTurn;
            this.spellsplayedSinceRecalc = 0;
            this.secretsplayedSinceRecalc = 0;
            this.optionsPlayedThisTurn = prozis.numOptionsPlayedThisTurn;

            this.ueberladung = prozis.ueberladung;
            this.lockedMana = prozis.lockedMana;

            this.ownHeroFatigue = prozis.ownHeroFatigue;
            this.enemyHeroFatigue = prozis.enemyHeroFatigue;
            this.ownDeckSize = prozis.ownDeckSize;
            this.enemyDeckSize = prozis.enemyDeckSize;

            //need the following for manacost-calculation
            this.ownHeroHpStarted = this.ownHero.Hp;
            this.enemyHeroHpStarted = this.enemyHero.Hp;
            this.ownWeaponAttackStarted = this.ownWeapon.Angr;
            this.ownCardsCountStarted = this.owncards.Count;
            this.enemyCardsCountStarted = this.enemyAnzCards;
            this.ownMobsCountStarted = this.ownMinions.Count;
            this.enemyMobsCountStarted = this.enemyMinions.Count;

            this.nextSecretThisTurnCost0 = false;
            this.playedPreparation = false;
            this.nextSpellThisTurnCost0 = false;
            this.nextMurlocThisTurnCostHealth = false;
            this.nextSpellThisTurnCostHealth = false;
            this.winzigebeschwoererin = 0;
            this.managespenst = 0;
            this.beschwoerungsportal = 0;
            this.anzOwnAviana = 0;
            this.anzOwnCloakedHuntress = 0;
            this.nerubarweblord = 0;
            this.myCardsCostLess = 0;

            this.startedWithmyCardsCostLess = 0;
            this.startedWithnerubarweblord = 0;
            this.startedWithbeschwoerungsportal = 0;
            this.startedWithManagespenst = 0;
            this.startedWithWinzigebeschwoererin = 0;
            
            this.blackwaterpirate = 0;
            this.blackwaterpirateStarted = 0;
            this.embracetheshadow = 0;
            this.ownCrystalCore = prozis.ownCrystalCore;
            this.ownMinionsInDeckCost0 = prozis.ownMinionsInDeckCost0;

            needGraveyard = true;
            this.loatheb = false;
            this.spellpower = 0;
            this.spellpowerStarted = 0;
            this.enemyspellpower = 0;
            this.enemyspellpowerStarted = 0;

            this.startedWithDamagedMinions = false;

            foreach (Minion m in this.ownMinions)
            {
                if (m.Hp < m.maxHp && m.Hp >= 1) this.startedWithDamagedMinions = true;

                this.spellpowerStarted += m.spellpower;
                if (m.silenced) continue;
                this.spellpowerStarted += m.handcard.card.spellpowervalue;
                this.spellpower = this.spellpowerStarted;
                if (m.taunt) anzOwnTaunt++;

                switch (m.name)
                {
                    case CardDB.cardName.blackwaterpirate:
                        this.blackwaterpirate++;
                        this.blackwaterpirateStarted++;
                        continue;
                    case CardDB.cardName.chogall:
                        if (m.playedThisTurn && this.cardsPlayedThisTurn == this.mobsplayedThisTurn) this.nextSpellThisTurnCostHealth = true; 
                        continue;
                    case CardDB.cardName.seadevilstinger:
                        if (m.playedThisTurn && this.cardsPlayedThisTurn == this.mobsplayedThisTurn) this.nextMurlocThisTurnCostHealth = true; 
                        continue;
                    case CardDB.cardName.prophetvelen:
                        this.doublepriest++;
                        continue;
                    case CardDB.cardName.themistcaller:
                        this.ownMistcaller++;
                        continue;
                    case CardDB.cardName.pintsizedsummoner:
                        this.winzigebeschwoererin++;
                        this.startedWithWinzigebeschwoererin++;
                        continue;
                    case CardDB.cardName.manawraith:
                        this.managespenst++;
                        this.startedWithManagespenst++;
                        continue;
                    case CardDB.cardName.nerubarweblord:
                        this.nerubarweblord++;
                        this.startedWithnerubarweblord++;
                        continue;
                    case CardDB.cardName.venturecomercenary:                        
                        this.ownMinionsCostMore += 3;
                        this.ownMinionsCostMoreAtStart += 3;
                        continue;
                    case CardDB.cardName.corpsewidow:
                        this.ownDRcardsCostMore -= 2;
                        this.ownDRcardsCostMoreAtStart -= 2;
                        continue;
                    case CardDB.cardName.summoningportal:
                        this.beschwoerungsportal++;
                        this.startedWithbeschwoerungsportal++;
                        continue;
                    case CardDB.cardName.vaelastrasz:
                        this.myCardsCostLess += 3;
                        this.startedWithmyCardsCostLess += 3;
                        continue;
                    case CardDB.cardName.aviana:
                        this.anzOwnAviana++;
                        continue;
                    case CardDB.cardName.cloakedhuntress:
                        this.anzOwnCloakedHuntress++;
                        continue;
                    case CardDB.cardName.baronrivendare:
                        this.ownBaronRivendare++;
                        continue;
                    case CardDB.cardName.brannbronzebeard:
                        this.ownBrannBronzebeard++;
                        continue;
                    case CardDB.cardName.drakkarienchanter:
                        this.ownTurnEndEffectsTriggerTwice++;
                        continue;
                    case CardDB.cardName.fandralstaghelm:
                        this.ownFandralStaghelm++;
                        continue;
                    case CardDB.cardName.loatheb:
                        if (m.playedThisTurn) this.loatheb = true;
                        continue;
                    case CardDB.cardName.kelthuzad:
                        this.needGraveyard = true;
                        continue;
                    case CardDB.cardName.leokk:
                        this.anzOwnRaidleader++;
                        continue;
                    case CardDB.cardName.raidleader:
                        this.anzOwnRaidleader++;
                        continue;
                    case CardDB.cardName.warhorsetrainer:
                        this.anzOwnWarhorseTrainer++;
                        continue;
                    case CardDB.cardName.fallenhero:
                        this.ownHeroPowerExtraDamage++;
                        continue;
                    case CardDB.cardName.garrisoncommander:
                        bool another = false;
                        foreach (Minion mnn in this.ownMinions)
                        {
                            if (mnn.name == CardDB.cardName.garrisoncommander && mnn.entitiyID != m.entitiyID) another = true;
                        }
                        if (!another) this.ownHeroPowerAllowedQuantity++;
                        continue;
                    case CardDB.cardName.coldarradrake:
                        this.ownHeroPowerAllowedQuantity += 100;
                        continue;
                    case CardDB.cardName.mindbreaker:
                        this.ownHeroAblility.manacost = 100;
                        this.enemyHeroAblility.manacost = 100;
                        this.ownAbilityReady = false;
                        this.ownAbilityReady = false;
                        continue;
                    case CardDB.cardName.malganis:
                        this.anzOwnMalGanis++;
                        continue;
                    case CardDB.cardName.bolframshield:
                        this.anzOwnBolfRamshield++;
                        continue;
                    case CardDB.cardName.ladyblaumeux:
                        this.anzOwnHorsemen++;
                        continue;
                    case CardDB.cardName.thanekorthazz:
                        this.anzOwnHorsemen++;
                        continue;
                    case CardDB.cardName.sirzeliek:
                        this.anzOwnHorsemen++;
                        continue;
                    case CardDB.cardName.stormwindchampion:
                        this.anzOwnStormwindChamps++;
                        continue;
                    case CardDB.cardName.animatedarmor:
                        this.anzOwnAnimatedArmor++;
                        continue;
                    case CardDB.cardName.moorabi:
                        this.anzMoorabi++;
                        continue;
                    case CardDB.cardName.tundrarhino:
                        this.anzOwnTundrarhino++;
                        continue;
                    case CardDB.cardName.timberwolf:
                        this.anzOwnTimberWolfs++;
                        continue;
                    case CardDB.cardName.murlocwarleader:
                        this.anzOwnMurlocWarleader++;
                        continue;
                    case CardDB.cardName.acidmaw:
                        this.anzAcidmaw++;
                        continue;
                    case CardDB.cardName.grimscaleoracle:
                        this.anzOwnGrimscaleOracle++;
                        continue;
                    case CardDB.cardName.shadowfiend:
                        this.anzOwnShadowfiend++;
                        continue;
                    case CardDB.cardName.auchenaisoulpriest:
                        this.anzOwnAuchenaiSoulpriest++;
                        continue;
                    case CardDB.cardName.radiantelemental: goto case CardDB.cardName.sorcerersapprentice;
                    case CardDB.cardName.sorcerersapprentice:
                        this.ownSpelsCostMore--;
                        this.ownSpelsCostMoreAtStart--;
                        continue;
                    case CardDB.cardName.nerubianunraveler:                        
                        this.ownSpelsCostMore += 2;
                        this.ownSpelsCostMoreAtStart += 2;
                        continue;
                    case CardDB.cardName.electron:
                        this.ownSpelsCostMore -= 3;
                        this.ownSpelsCostMoreAtStart -= 3;
                        
                        
                        continue;
                    case CardDB.cardName.icewalker:
                        this.ownAbilityFreezesTarget++;
                        continue;
                    case CardDB.cardName.southseacaptain:
                        this.anzOwnSouthseacaptain++;
                        continue;
                    case CardDB.cardName.chromaggus:
                        this.anzOwnChromaggus++;
                        continue;
                    case CardDB.cardName.mechwarper:
                        this.anzOwnMechwarper++;
                        this.anzOwnMechwarperStarted++;
                        continue;
                    case CardDB.cardName.steamwheedlesniper:
                        this.weHaveSteamwheedleSniper = true;
                        continue;
                    default:
                        break;
                }

                if (m.name == CardDB.cardName.dragonconsort && anzOwnDragonConsort > 0) this.anzOwnDragonConsortStarted++;
                if (m.handcard.card.race == 23) this.anzOwnPiratesStarted++;
                if (m.handcard.card.race == 14) this.anzOwnMurlocStarted++;

            }

            foreach (Handmanager.Handcard hc in this.owncards)
            {

                if (hc.card.name == CardDB.cardName.kelthuzad)
                {
                    this.needGraveyard = true;
                }
            }

            foreach (Minion m in this.enemyMinions)
            {
                this.enemyspellpowerStarted += m.spellpower;
                if (m.silenced) continue;
                this.enemyspellpowerStarted += m.handcard.card.spellpowervalue;
                this.enemyspellpower = this.enemyspellpowerStarted;
                if (m.taunt) anzEnemyTaunt++;
                
                switch (m.name)
                {
                    case CardDB.cardName.baronrivendare:
                        this.enemyBaronRivendare++;
                        continue;
                    case CardDB.cardName.brannbronzebeard:
                        this.enemyBrannBronzebeard++;
                        continue;
                    case CardDB.cardName.drakkarienchanter:
                        this.enemyTurnEndEffectsTriggerTwice++;
                        continue;
                    case CardDB.cardName.kelthuzad:
                        this.needGraveyard = true;
                        continue;
                    case CardDB.cardName.prophetvelen:
                        this.enemydoublepriest++;
                        continue;
                    case CardDB.cardName.manawraith:
                        this.managespenst++;
                        this.startedWithManagespenst++;
                        continue;
                    case CardDB.cardName.electron:
                        this.ownSpelsCostMore -= 3;
                        this.ownSpelsCostMoreAtStart -= 3;
                        
                        
                        continue;
                    case CardDB.cardName.doomedapprentice:
                        this.ownSpelsCostMore++;
                        this.ownSpelsCostMoreAtStart++;
                        continue;
                    case CardDB.cardName.nerubarweblord:
                        this.nerubarweblord++;
                        this.startedWithnerubarweblord++;
                        continue;
                    case CardDB.cardName.garrisoncommander:
                        bool another = false;
                        foreach (Minion mnn in this.enemyMinions)
                        {
                            if (mnn.name == CardDB.cardName.garrisoncommander && mnn.entitiyID != m.entitiyID) another = true;
                        }
                        if (!another) this.enemyHeroPowerAllowedQuantity++;
                        continue;
                    case CardDB.cardName.coldarradrake:
                        this.enemyHeroPowerAllowedQuantity += 100;
                        continue;
                    case CardDB.cardName.mindbreaker:
                        this.ownHeroAblility.manacost = 100;
                        this.enemyHeroAblility.manacost = 100;
                        this.ownAbilityReady = false;
                        this.ownAbilityReady = false;
                        continue;
                    case CardDB.cardName.fallenhero:
                        this.enemyHeroPowerExtraDamage++;
                        continue;
                    case CardDB.cardName.leokk:
                        this.anzEnemyRaidleader++;
                        continue;
                    case CardDB.cardName.raidleader:
                        this.anzEnemyRaidleader++;
                        continue;
                    case CardDB.cardName.warhorsetrainer:
                        this.anzEnemyWarhorseTrainer++;
                        continue;
                    case CardDB.cardName.malganis:
                        this.anzEnemyMalGanis++;
                        continue;
                    case CardDB.cardName.bolframshield:
                        this.anzEnemyBolfRamshield++;
                        continue;
                    case CardDB.cardName.ladyblaumeux:
                        this.anzEnemyHorsemen++;
                        continue;
                    case CardDB.cardName.thanekorthazz:
                        this.anzEnemyHorsemen++;
                        continue;
                    case CardDB.cardName.sirzeliek:
                        this.anzEnemyHorsemen++;
                        continue;
                    case CardDB.cardName.stormwindchampion:
                        this.anzEnemyStormwindChamps++;
                        continue;
                    case CardDB.cardName.animatedarmor:
                        this.anzEnemyAnimatedArmor++;
                        continue;
                    case CardDB.cardName.moorabi:
                        this.anzMoorabi++;
                        continue;
                    case CardDB.cardName.tundrarhino:
                        this.anzEnemyTundrarhino++;
                        continue;
                    case CardDB.cardName.timberwolf:
                        this.anzEnemyTimberWolfs++;
                        continue;
                    case CardDB.cardName.murlocwarleader:
                        this.anzEnemyMurlocWarleader++;
                        continue;
                    case CardDB.cardName.acidmaw:
                        this.anzAcidmaw++;
                        continue;
                    case CardDB.cardName.grimscaleoracle:
                        this.anzEnemyGrimscaleOracle++;
                        continue;
                    case CardDB.cardName.auchenaisoulpriest:
                        this.anzEnemyAuchenaiSoulpriest++;
                        continue;
                    case CardDB.cardName.steamwheedlesniper:
                        this.enemyHaveSteamwheedleSniper = true;
                        continue;
                    
                    case CardDB.cardName.icewalker:
                        this.enemyAbilityFreezesTarget++;
                        continue;
                    case CardDB.cardName.southseacaptain:
                        this.anzEnemySouthseacaptain++;
                        continue;
                    case CardDB.cardName.chromaggus:
                        this.anzEnemyChromaggus++;
                        continue;
                    case CardDB.cardName.mechwarper:
                        this.anzEnemyMechwarper++;
                        this.anzEnemyMechwarperStarted++;
                        continue;
                }
            }

            if (this.spellpowerStarted > 0) this.ownSpiritclaws = true;
            if (this.enemyspellpowerStarted > 0) this.enemySpiritclaws = true;

            if (this.enemySecretCount >= 1) this.needGraveyard = true;
            if (this.needGraveyard) this.diedMinions = new List<GraveYardItem>(Probabilitymaker.Instance.turngraveyard);

            this.tempanzOwnCards = this.owncards.Count;
            this.tempanzEnemyCards = this.enemyAnzCards;


        }

        public Playfield(Playfield p)
        {
            this.pID = prozis.getPid();
            if (p.print)
            {
                this.print = true;
                this.pIdHistory.AddRange(p.pIdHistory);
                this.pIdHistory.Add(pID);
                this.doDirtyTts = p.doDirtyTts;
                this.dirtyTwoTurnSim = p.dirtyTwoTurnSim;
                this.checkLostAct = p.checkLostAct;
                this.enemyTurnsCount = p.enemyTurnsCount;
            }
            this.isLethalCheck = p.isLethalCheck;
            this.nextEntity = p.nextEntity;

            this.isOwnTurn = p.isOwnTurn;
            this.turnCounter = p.turnCounter;
            this.gTurn = p.gTurn;
            this.gTurnStep = p.gTurnStep;

            this.anzOgOwnCThunAngrBonus = p.anzOgOwnCThunAngrBonus;
            this.anzOgOwnCThunHpBonus = p.anzOgOwnCThunHpBonus;
            this.anzOgOwnCThunTaunt = p.anzOgOwnCThunTaunt;
            this.anzOwnJadeGolem = p.anzOwnJadeGolem;
            this.anzEnemyJadeGolem = p.anzEnemyJadeGolem;
            this.anzOwnElementalsThisTurn = p.anzOwnElementalsThisTurn;
            this.anzOwnElementalsLastTurn = p.anzOwnElementalsLastTurn;
            this.attacked = p.attacked;
            this.ownController = p.ownController;
            this.bestEnemyPlay = p.bestEnemyPlay;
            this.endTurnState = p.endTurnState;

            this.ownSecretsIDList.AddRange(p.ownSecretsIDList);
            this.evaluatePenality = p.evaluatePenality;
            this.ruleWeight = p.ruleWeight;
            this.rulesUsed = p.rulesUsed;

            this.enemySecretCount = p.enemySecretCount;

            this.enemySecretList.Clear();
            if (p.useSecretsPlayAround)
            {
                this.useSecretsPlayAround = true;
                foreach (SecretItem si in p.enemySecretList)
                {
                    this.enemySecretList.Add(new SecretItem(si));
                }
            }

            this.mana = p.mana;
            this.manaTurnEnd = p.manaTurnEnd;
            this.ownMaxMana = p.ownMaxMana;
            this.enemyMaxMana = p.enemyMaxMana;
            if (p.LurkersDB.Count > 0) this.LurkersDB = new Dictionary<int, IDEnumOwner>(p.LurkersDB);
            addMinionsReal(p.ownMinions, ownMinions);
            addMinionsReal(p.enemyMinions, enemyMinions);
            this.ownHero = new Minion(p.ownHero);
            this.enemyHero = new Minion(p.enemyHero);
            this.ownWeapon = new Weapon(p.ownWeapon);
            this.enemyWeapon = new Weapon(p.enemyWeapon);
            addCardsReal(p.owncards);

            this.ownHeroName = p.ownHeroName;
            this.enemyHeroName = p.enemyHeroName;

            this.ownHeroStartClass = p.ownHeroStartClass;
            this.enemyHeroStartClass = p.enemyHeroStartClass;

            this.playactions.AddRange(p.playactions);
            this.complete = false;

            this.attackFaceHP = p.attackFaceHP;

            this.owncarddraw = p.owncarddraw;
            this.enemycarddraw = p.enemycarddraw;
            this.enemyAnzCards = p.enemyAnzCards;
            
            this.lostDamage = p.lostDamage;
            this.lostWeaponDamage = p.lostWeaponDamage;
            this.lostHeal = p.lostHeal;

            this.ownAbilityReady = p.ownAbilityReady;
            this.enemyAbilityReady = p.enemyAbilityReady;
            this.ownHeroAblility = new Handmanager.Handcard(p.ownHeroAblility);
            this.enemyHeroAblility = new Handmanager.Handcard(p.enemyHeroAblility);

            this.ownQuest.Copy(p.ownQuest);
            this.enemyQuest.Copy(p.enemyQuest);
            this.mobsplayedThisTurn = p.mobsplayedThisTurn;
            this.startedWithMobsPlayedThisTurn = p.startedWithMobsPlayedThisTurn;
            this.spellsplayedSinceRecalc = p.spellsplayedSinceRecalc;
            this.secretsplayedSinceRecalc = p.secretsplayedSinceRecalc;
            this.optionsPlayedThisTurn = p.optionsPlayedThisTurn;
            this.cardsPlayedThisTurn = p.cardsPlayedThisTurn;
            this.enemyOptionsDoneThisTurn = p.enemyOptionsDoneThisTurn;
            this.ueberladung = p.ueberladung;
            this.lockedMana = p.lockedMana;

            this.ownDeckSize = p.ownDeckSize;
            this.enemyDeckSize = p.enemyDeckSize;
            this.ownHeroFatigue = p.ownHeroFatigue;
            this.enemyHeroFatigue = p.enemyHeroFatigue;

            //need the following for manacost-calculation
            this.ownHeroHpStarted = p.ownHeroHpStarted;
            this.ownWeaponAttackStarted = p.ownWeaponAttackStarted;
            this.ownCardsCountStarted = p.ownCardsCountStarted;
            this.enemyCardsCountStarted = p.enemyCardsCountStarted;
            this.ownMobsCountStarted = p.ownMobsCountStarted;
            this.enemyMobsCountStarted = p.enemyMobsCountStarted;
            this.nextSecretThisTurnCost0 = p.nextSecretThisTurnCost0;
            this.nextSpellThisTurnCost0 = p.nextSpellThisTurnCost0;
            this.nextMurlocThisTurnCostHealth = p.nextMurlocThisTurnCostHealth;

            this.blackwaterpirate = p.blackwaterpirate;
            this.blackwaterpirateStarted = p.blackwaterpirateStarted;
            this.nextSpellThisTurnCostHealth = p.nextSpellThisTurnCostHealth;
            this.embracetheshadow = p.embracetheshadow;
            this.ownCrystalCore = p.ownCrystalCore;
            this.ownMinionsInDeckCost0 = p.ownMinionsInDeckCost0;

            this.playedPreparation = p.playedPreparation;
            
            this.winzigebeschwoererin = p.winzigebeschwoererin;
            this.startedWithWinzigebeschwoererin = p.startedWithWinzigebeschwoererin;
            this.managespenst = p.managespenst;
            this.startedWithManagespenst = p.startedWithManagespenst;

            
            this.ownSpelsCostMore = p.ownSpelsCostMore;
            this.ownSpelsCostMoreAtStart = p.ownSpelsCostMoreAtStart;
            this.ownMinionsCostMore = p.ownMinionsCostMore;
            this.ownMinionsCostMoreAtStart = p.ownMinionsCostMoreAtStart;
            this.ownDRcardsCostMore = p.ownDRcardsCostMore;
            this.ownDRcardsCostMoreAtStart = p.ownDRcardsCostMoreAtStart;

            this.beschwoerungsportal = p.beschwoerungsportal;
            this.startedWithbeschwoerungsportal = p.startedWithbeschwoerungsportal;
            this.myCardsCostLess = p.myCardsCostLess;
            this.startedWithmyCardsCostLess = p.startedWithmyCardsCostLess;
            this.anzOwnAviana = p.anzOwnAviana;
            this.anzOwnCloakedHuntress = p.anzOwnCloakedHuntress;
            this.nerubarweblord = p.nerubarweblord;
            this.startedWithnerubarweblord = p.startedWithnerubarweblord;

            this.startedWithDamagedMinions = p.startedWithDamagedMinions;

            this.loatheb = p.loatheb;

            this.spellpower = p.spellpower;
            this.spellpowerStarted = p.spellpowerStarted;
            this.enemyspellpower = p.enemyspellpower;
            this.enemyspellpowerStarted = p.enemyspellpowerStarted;

            this.needGraveyard = p.needGraveyard;
            if (p.needGraveyard) this.diedMinions = new List<GraveYardItem>(p.diedMinions);
            this.OwnLastDiedMinion = p.OwnLastDiedMinion;

            //####buffs#############################

            this.anzOwnRaidleader = p.anzOwnRaidleader;
            this.anzEnemyRaidleader = p.anzEnemyRaidleader;
            this.anzOwnWarhorseTrainer = p.anzOwnWarhorseTrainer;
            this.anzEnemyWarhorseTrainer = p.anzEnemyWarhorseTrainer;
            this.anzOwnMalGanis = p.anzOwnMalGanis;
            this.anzEnemyMalGanis = p.anzEnemyMalGanis;
            this.anzOwnBolfRamshield = p.anzOwnBolfRamshield;
            this.anzEnemyBolfRamshield = p.anzEnemyBolfRamshield;
            this.anzOwnHorsemen = p.anzOwnHorsemen;
            this.anzEnemyHorsemen = p.anzEnemyHorsemen;
            this.anzOwnAnimatedArmor = p.anzOwnAnimatedArmor;
            this.anzOwnExtraAngrHp = p.anzOwnExtraAngrHp;
            this.anzEnemyExtraAngrHp = p.anzEnemyExtraAngrHp;
            this.anzEnemyAnimatedArmor = p.anzEnemyAnimatedArmor;
            this.anzMoorabi = p.anzMoorabi;
            this.anzOwnPiratesStarted = p.anzOwnPiratesStarted;
            this.anzOwnMurlocStarted = p.anzOwnMurlocStarted;
            this.anzOwnStormwindChamps = p.anzOwnStormwindChamps;
            this.anzEnemyStormwindChamps = p.anzEnemyStormwindChamps;
            this.anzOwnTundrarhino = p.anzOwnTundrarhino;
            this.anzEnemyTundrarhino = p.anzEnemyTundrarhino;
            this.anzOwnTimberWolfs = p.anzOwnTimberWolfs;
            this.anzEnemyTimberWolfs = p.anzEnemyTimberWolfs;
            this.anzOwnMurlocWarleader = p.anzOwnMurlocWarleader;
            this.anzEnemyMurlocWarleader = p.anzEnemyMurlocWarleader;
            this.anzAcidmaw = p.anzAcidmaw;
            this.anzOwnGrimscaleOracle = p.anzOwnGrimscaleOracle;
            this.anzEnemyGrimscaleOracle = p.anzEnemyGrimscaleOracle;
            this.anzOwnShadowfiend = p.anzOwnShadowfiend;
            this.anzOwnAuchenaiSoulpriest = p.anzOwnAuchenaiSoulpriest;
            this.anzEnemyAuchenaiSoulpriest = p.anzEnemyAuchenaiSoulpriest;
            this.anzOwnSouthseacaptain = p.anzOwnSouthseacaptain;
            this.anzEnemySouthseacaptain = p.anzEnemySouthseacaptain;
            this.anzOwnMechwarper = p.anzOwnMechwarper;
            this.anzOwnMechwarperStarted = p.anzOwnMechwarperStarted;
            this.anzEnemyMechwarper = p.anzEnemyMechwarper;
            this.anzEnemyMechwarperStarted = p.anzEnemyMechwarperStarted;
            this.anzOwnChromaggus = p.anzOwnChromaggus;
            this.anzEnemyChromaggus = p.anzEnemyChromaggus;
            this.anzOwnDragonConsort = p.anzOwnDragonConsort;
            this.anzOwnDragonConsortStarted = p.anzOwnDragonConsortStarted;

            this.ownAbilityFreezesTarget = p.ownAbilityFreezesTarget;
            this.enemyAbilityFreezesTarget = p.enemyAbilityFreezesTarget;
            this.ownHeroPowerCostLessOnce = p.ownHeroPowerCostLessOnce;
            this.enemyHeroPowerCostLessOnce = p.enemyHeroPowerCostLessOnce;
            this.ownHeroPowerExtraDamage = p.ownHeroPowerExtraDamage;
            this.enemyHeroPowerExtraDamage = p.enemyHeroPowerExtraDamage;
            this.ownHeroPowerAllowedQuantity = p.ownHeroPowerAllowedQuantity;
            this.enemyHeroPowerAllowedQuantity = p.enemyHeroPowerAllowedQuantity;
            this.anzUsedOwnHeroPower = p.anzUsedOwnHeroPower;
            this.anzUsedEnemyHeroPower = p.anzUsedEnemyHeroPower;

            this.anzEnemyTaunt = p.anzEnemyTaunt;
            this.anzOwnTaunt = p.anzOwnTaunt;
            this.ownMinionsDiedTurn = p.ownMinionsDiedTurn;
            this.enemyMinionsDiedTurn = p.enemyMinionsDiedTurn;

            this.feugenDead = p.feugenDead;
            this.stalaggDead = p.stalaggDead;

            this.weHavePlayedMillhouseManastorm = p.weHavePlayedMillhouseManastorm;
            this.ownSpiritclaws = p.ownSpiritclaws;
            this.enemySpiritclaws = p.enemySpiritclaws;

            this.doublepriest = p.doublepriest;
            this.enemydoublepriest = p.enemydoublepriest;
            this.ownMistcaller = p.ownMistcaller;

            this.lockandload = p.lockandload;
            this.stampede = p.stampede;

            this.ownBaronRivendare = p.ownBaronRivendare;
            this.enemyBaronRivendare = p.enemyBaronRivendare;
            this.ownBrannBronzebeard = p.ownBrannBronzebeard;
            this.enemyBrannBronzebeard = p.enemyBrannBronzebeard;
            this.ownTurnEndEffectsTriggerTwice = p.ownTurnEndEffectsTriggerTwice;
            this.enemyTurnEndEffectsTriggerTwice = p.enemyTurnEndEffectsTriggerTwice;
            this.ownFandralStaghelm = p.ownFandralStaghelm;

            this.weHaveSteamwheedleSniper = p.weHaveSteamwheedleSniper;
            this.enemyHaveSteamwheedleSniper = p.enemyHaveSteamwheedleSniper;
            //#########################################


            this.tempanzOwnCards = this.owncards.Count;
            this.tempanzEnemyCards = this.enemyAnzCards;

        }

        public void copyValuesFrom(Playfield p)
        {

        }

        public bool isEqual(Playfield p, bool logg)
        {
            if (logg)
            {
                if (this.value != p.value) return false;
            }
            if (this.enemySecretCount != p.enemySecretCount)
            {

                if (logg) Helpfunctions.Instance.logg("enemy secrets changed ");
                return false;
            }

            if (this.enemySecretCount >= 1)
            {
                for (int i = 0; i < this.enemySecretList.Count; i++)
                {
                    if (!this.enemySecretList[i].isEqual(p.enemySecretList[i]))
                    {
                        if (logg) Helpfunctions.Instance.logg("enemy secrets changed! ");
                        return false;
                    }
                }
            }

            if (this.mana != p.mana || this.enemyMaxMana != p.enemyMaxMana || this.ownMaxMana != p.ownMaxMana)
            {
                if (logg) Helpfunctions.Instance.logg("mana changed " + this.mana + " " + p.mana + " " + this.enemyMaxMana + " " + p.enemyMaxMana + " " + this.ownMaxMana + " " + p.ownMaxMana);
                return false;
            }

            if (this.ownDeckSize != p.ownDeckSize || this.enemyDeckSize != p.enemyDeckSize || this.ownHeroFatigue != p.ownHeroFatigue || this.enemyHeroFatigue != p.enemyHeroFatigue)
            {
                if (logg) Helpfunctions.Instance.logg("deck/fatigue changed " + this.ownDeckSize + " " + p.ownDeckSize + " " + this.enemyDeckSize + " " + p.enemyDeckSize + " " + this.ownHeroFatigue + " " + p.ownHeroFatigue + " " + this.enemyHeroFatigue + " " + p.enemyHeroFatigue);
            }

            if (this.cardsPlayedThisTurn != p.cardsPlayedThisTurn || this.mobsplayedThisTurn != p.mobsplayedThisTurn || this.ueberladung != p.ueberladung || this.lockedMana != p.lockedMana || this.ownAbilityReady != p.ownAbilityReady || this.ownQuest.questProgress != p.ownQuest.questProgress)
            {
                if (logg) Helpfunctions.Instance.logg("stuff changed " + this.cardsPlayedThisTurn + " " + p.cardsPlayedThisTurn + " " + this.mobsplayedThisTurn + " " + p.mobsplayedThisTurn + " " + this.ueberladung + " " + p.ueberladung + " " + this.lockedMana + " " + p.lockedMana + " " + this.ownAbilityReady + " " + p.ownAbilityReady + " " + this.ownQuest.questProgress + " " + p.ownQuest.questProgress);
                return false;
            }

            if (this.ownHeroName != p.ownHeroName || this.enemyHeroName != p.enemyHeroName)
            {
                if (logg) Helpfunctions.Instance.logg("hero name changed ");
                return false;
            }

            if (this.ownHero.Hp != p.ownHero.Hp || this.ownHero.Angr != p.ownHero.Angr || this.ownHero.armor != p.ownHero.armor || this.ownHero.frozen != p.ownHero.frozen || this.ownHero.immuneWhileAttacking != p.ownHero.immuneWhileAttacking || this.ownHero.immune != p.ownHero.immune)
            {
                if (logg) Helpfunctions.Instance.logg("ownhero changed " + this.ownHero.Hp + " " + p.ownHero.Hp + " " + this.ownHero.Angr + " " + p.ownHero.Angr + " " + this.ownHero.armor + " " + p.ownHero.armor + " " + this.ownHero.frozen + " " + p.ownHero.frozen + " " + this.ownHero.immuneWhileAttacking + " " + p.ownHero.immuneWhileAttacking + " " + this.ownHero.immune + " " + p.ownHero.immune);
                return false;
            }
            if (this.ownHero.Ready != p.ownHero.Ready || !this.ownWeapon.isEqual(p.ownWeapon) || this.ownHero.numAttacksThisTurn != p.ownHero.numAttacksThisTurn || this.ownHero.windfury != p.ownHero.windfury)
            {
                if (logg) Helpfunctions.Instance.logg("weapon changed " + this.ownHero.Ready + " " + p.ownHero.Ready + " " + this.ownWeapon.Angr + " " + p.ownWeapon.Angr + " " + this.ownWeapon.Durability + " " + p.ownWeapon.Durability + " " + this.ownHero.numAttacksThisTurn + " " + p.ownHero.numAttacksThisTurn + " " + this.ownHero.windfury + " " + p.ownHero.windfury + " " + this.ownWeapon.poisonous + " " + p.ownWeapon.poisonous + " " + this.ownWeapon.lifesteal + " " + p.ownWeapon.lifesteal);
                return false;
            }
            if (this.enemyHero.Hp != p.enemyHero.Hp || !this.enemyWeapon.isEqual(p.enemyWeapon) || this.enemyHero.armor != p.enemyHero.armor || this.enemyHero.frozen != p.enemyHero.frozen || this.enemyHero.immune != p.enemyHero.immune)
            {
                if (logg) Helpfunctions.Instance.logg("enemyhero changed " + this.enemyHero.Hp + " " + p.enemyHero.Hp + " " + this.enemyWeapon.Angr + " " + p.enemyWeapon.Angr + " " + this.enemyHero.armor + " " + p.enemyHero.armor + " " + this.enemyWeapon.Durability + " " + p.enemyWeapon.Durability + " " + this.enemyHero.frozen + " " + p.enemyHero.frozen + " " + this.enemyHero.immune + " " + p.enemyHero.immune + " " + this.enemyWeapon.poisonous + " " + p.enemyWeapon.poisonous + " " + this.enemyWeapon.lifesteal + " " + p.enemyWeapon.lifesteal);
                return false;
            }

            

            if (this.ownHeroAblility.card.name != p.ownHeroAblility.card.name)
            {
                if (logg) Helpfunctions.Instance.logg("hero ability changed ");
                return false;
            }

            if (this.spellpower != p.spellpower)
            {
                if (logg) Helpfunctions.Instance.logg("spellpower changed");
                return false;
            }

            if (this.ownMinions.Count != p.ownMinions.Count || this.enemyMinions.Count != p.enemyMinions.Count || this.owncards.Count != p.owncards.Count)
            {
                if (logg) Helpfunctions.Instance.logg("minions count or hand changed");
                return false;
            }

            bool minionbool = true;
            for (int i = 0; i < this.ownMinions.Count; i++)
            {
                Minion dis = this.ownMinions[i]; Minion pis = p.ownMinions[i];

                if (dis.name != pis.name) minionbool = false;
                if (dis.Angr != pis.Angr || dis.Hp != pis.Hp || dis.maxHp != pis.maxHp || dis.numAttacksThisTurn != pis.numAttacksThisTurn) minionbool = false;
                if (dis.Ready != pis.Ready) minionbool = false; // includes frozen, exhaunted
                if (dis.playedThisTurn != pis.playedThisTurn) minionbool = false;
                if (dis.silenced != pis.silenced || dis.stealth != pis.stealth || dis.taunt != pis.taunt || dis.windfury != pis.windfury || dis.zonepos != pis.zonepos) minionbool = false;
                if (dis.divineshild != pis.divineshild || dis.cantLowerHPbelowONE != pis.cantLowerHPbelowONE || dis.immune != pis.immune) minionbool = false;
                if (dis.ownBlessingOfWisdom != pis.ownBlessingOfWisdom || dis.enemyBlessingOfWisdom != pis.enemyBlessingOfWisdom) minionbool = false;
                if (dis.ownPowerWordGlory != pis.ownPowerWordGlory || dis.enemyPowerWordGlory != pis.enemyPowerWordGlory) minionbool = false;
                if (dis.destroyOnEnemyTurnStart != pis.destroyOnEnemyTurnStart || dis.destroyOnEnemyTurnEnd != pis.destroyOnEnemyTurnEnd || dis.destroyOnOwnTurnEnd != pis.destroyOnOwnTurnEnd || dis.destroyOnOwnTurnStart != pis.destroyOnOwnTurnStart) minionbool = false;
                if (dis.ancestralspirit != pis.ancestralspirit || dis.desperatestand != pis.desperatestand || dis.souloftheforest != pis.souloftheforest || dis.stegodon != pis.stegodon || dis.livingspores != pis.livingspores) minionbool = false;
                if (dis.explorershat != pis.explorershat || dis.returnToHand != pis.returnToHand|| dis.infest != pis.infest || dis.deathrattle2 != pis.deathrattle2) minionbool = false;
                if (dis.hChoice != pis.hChoice || dis.cantBeTargetedBySpellsOrHeroPowers != pis.cantBeTargetedBySpellsOrHeroPowers || dis.poisonous != pis.poisonous || dis.lifesteal != pis.lifesteal) minionbool = false;
            }
            if (minionbool == false)
            {
                if (logg) Helpfunctions.Instance.logg("ownminions changed");
                return false;
            }

            for (int i = 0; i < this.enemyMinions.Count; i++)
            {
                Minion dis = this.enemyMinions[i]; Minion pis = p.enemyMinions[i];

                if (dis.name != pis.name) minionbool = false;
                if (dis.Angr != pis.Angr || dis.Hp != pis.Hp || dis.maxHp != pis.maxHp || dis.numAttacksThisTurn != pis.numAttacksThisTurn) minionbool = false;
                if (dis.Ready != pis.Ready) minionbool = false; // includes frozen, exhaunted
                if (dis.playedThisTurn != pis.playedThisTurn) minionbool = false;
                if (dis.silenced != pis.silenced || dis.stealth != pis.stealth || dis.taunt != pis.taunt || dis.windfury != pis.windfury || dis.zonepos != pis.zonepos) minionbool = false;
                if (dis.divineshild != pis.divineshild || dis.cantLowerHPbelowONE != pis.cantLowerHPbelowONE || dis.immune != pis.immune) minionbool = false;
                if (dis.ownBlessingOfWisdom != pis.ownBlessingOfWisdom || dis.enemyBlessingOfWisdom != pis.enemyBlessingOfWisdom) minionbool = false;
                if (dis.ownPowerWordGlory != pis.ownPowerWordGlory || dis.enemyPowerWordGlory != pis.enemyPowerWordGlory) minionbool = false;
                if (dis.destroyOnEnemyTurnStart != pis.destroyOnEnemyTurnStart || dis.destroyOnEnemyTurnEnd != pis.destroyOnEnemyTurnEnd || dis.destroyOnOwnTurnEnd != pis.destroyOnOwnTurnEnd || dis.destroyOnOwnTurnStart != pis.destroyOnOwnTurnStart) minionbool = false;
                if (dis.ancestralspirit != pis.ancestralspirit || dis.desperatestand != pis.desperatestand || dis.souloftheforest != pis.souloftheforest || dis.stegodon != pis.stegodon || dis.livingspores != pis.livingspores) minionbool = false;
                if (dis.explorershat != pis.explorershat || dis.returnToHand != pis.returnToHand || dis.infest != pis.infest || dis.deathrattle2 != pis.deathrattle2) minionbool = false;
                if (dis.hChoice != pis.hChoice || dis.cantBeTargetedBySpellsOrHeroPowers != pis.cantBeTargetedBySpellsOrHeroPowers || dis.poisonous != pis.poisonous || dis.lifesteal != pis.lifesteal) minionbool = false;
            }
            if (minionbool == false)
            {
                if (logg) Helpfunctions.Instance.logg("enemyminions changed");
                return false;
            }

            for (int i = 0; i < this.owncards.Count; i++)
            {
                Handmanager.Handcard dishc = this.owncards[i]; Handmanager.Handcard pishc = p.owncards[i];
                if (dishc.position != pishc.position || dishc.entity != pishc.entity || dishc.getManaCost(this) != pishc.getManaCost(p))
                {
                    if (logg) Helpfunctions.Instance.logg("handcard changed: " + dishc.card.name);
                    return false;
                }
            }

            for (int i = 0; i < this.ownMinions.Count; i++)
            {
                Minion dis = this.ownMinions[i]; Minion pis = p.ownMinions[i];
                if (dis.entitiyID != pis.entitiyID) Ai.Instance.updateEntitiy(pis.entitiyID, dis.entitiyID);

            }

            for (int i = 0; i < this.enemyMinions.Count; i++)
            {
                Minion dis = this.enemyMinions[i]; Minion pis = p.enemyMinions[i];
                if (dis.entitiyID != pis.entitiyID) Ai.Instance.updateEntitiy(pis.entitiyID, dis.entitiyID);

            }
            if (this.ownSecretsIDList.Count != p.ownSecretsIDList.Count)
            {
                if (logg) Helpfunctions.Instance.logg("secretsCount changed");
                return false;
            }
            for (int i = 0; i < this.ownSecretsIDList.Count; i++)
            {
                if (this.ownSecretsIDList[i] != p.ownSecretsIDList[i])
                {
                    if (logg) Helpfunctions.Instance.logg("secrets changed");
                    return false;
                }
            }
            return true;
        }

        public bool isEqualf(Playfield p)
        {
            if (this.value != p.value) return false;

            if (this.ownMinions.Count != p.ownMinions.Count || this.enemyMinions.Count != p.enemyMinions.Count || this.owncards.Count != p.owncards.Count) return false;

            if (this.cardsPlayedThisTurn != p.cardsPlayedThisTurn || this.mobsplayedThisTurn != p.mobsplayedThisTurn || this.ueberladung != p.ueberladung || this.lockedMana != p.lockedMana || this.ownAbilityReady != p.ownAbilityReady) return false;

            if (this.mana != p.mana || this.enemyMaxMana != p.enemyMaxMana || this.ownMaxMana != p.ownMaxMana || this.ownQuest.questProgress != p.ownQuest.questProgress) return false;

            if (this.ownHeroName != p.ownHeroName || this.enemyHeroName != p.enemyHeroName || this.enemySecretCount != p.enemySecretCount) return false;

            if (this.ownHero.Hp != p.ownHero.Hp || this.ownHero.Angr != p.ownHero.Angr || this.ownHero.armor != p.ownHero.armor || this.ownHero.frozen != p.ownHero.frozen || this.ownHero.immuneWhileAttacking != p.ownHero.immuneWhileAttacking || this.ownHero.immune != p.ownHero.immune) return false;

            if (this.ownHero.Ready != p.ownHero.Ready || !this.ownWeapon.isEqual(p.ownWeapon) || this.ownHero.numAttacksThisTurn != p.ownHero.numAttacksThisTurn || this.ownHero.windfury != p.ownHero.windfury) return false;

            if (this.enemyHero.Hp != p.enemyHero.Hp || !this.enemyWeapon.isEqual(p.enemyWeapon) || this.enemyHero.armor != p.enemyHero.armor || this.enemyHero.frozen != p.enemyHero.frozen || this.enemyHero.immune != p.enemyHero.immune) return false;
            




            if (this.ownHeroAblility.card.name != p.ownHeroAblility.card.name || this.spellpower != p.spellpower) return false;

            bool minionbool = true;
            for (int i = 0; i < this.ownMinions.Count; i++)
            {
                Minion dis = this.ownMinions[i]; Minion pis = p.ownMinions[i];
                //if (dis.entitiyID == 0) dis.entitiyID = pis.entitiyID;
                //if (pis.entitiyID == 0) pis.entitiyID = dis.entitiyID;
                if (dis.entitiyID != pis.entitiyID) minionbool = false;
                if (dis.Angr != pis.Angr || dis.Hp != pis.Hp || dis.maxHp != pis.maxHp || dis.numAttacksThisTurn != pis.numAttacksThisTurn) minionbool = false;
                if (dis.Ready != pis.Ready) minionbool = false; // includes frozen, exhaunted
                if (dis.playedThisTurn != pis.playedThisTurn) minionbool = false;
                if (dis.silenced != pis.silenced || dis.stealth != pis.stealth || dis.taunt != pis.taunt || dis.windfury != pis.windfury || dis.zonepos != pis.zonepos) minionbool = false;
                if (dis.divineshild != pis.divineshild || dis.cantLowerHPbelowONE != pis.cantLowerHPbelowONE || dis.immune != pis.immune) minionbool = false;
                if (dis.ownBlessingOfWisdom != pis.ownBlessingOfWisdom || dis.enemyBlessingOfWisdom != pis.enemyBlessingOfWisdom) minionbool = false;
                if (dis.ownPowerWordGlory != pis.ownPowerWordGlory || dis.enemyPowerWordGlory != pis.enemyPowerWordGlory) minionbool = false;
                if (dis.destroyOnEnemyTurnStart != pis.destroyOnEnemyTurnStart || dis.destroyOnEnemyTurnEnd != pis.destroyOnEnemyTurnEnd || dis.destroyOnOwnTurnEnd != pis.destroyOnOwnTurnEnd || dis.destroyOnOwnTurnStart != pis.destroyOnOwnTurnStart) minionbool = false;
                if (dis.ancestralspirit != pis.ancestralspirit || dis.desperatestand != pis.desperatestand || dis.souloftheforest != pis.souloftheforest || dis.stegodon != pis.stegodon || dis.livingspores != pis.livingspores) minionbool = false;
                if (dis.explorershat != pis.explorershat || dis.returnToHand != pis.returnToHand || dis.infest != pis.infest || dis.deathrattle2 != pis.deathrattle2) minionbool = false;
                if (dis.hChoice != pis.hChoice || dis.cantBeTargetedBySpellsOrHeroPowers != pis.cantBeTargetedBySpellsOrHeroPowers || dis.poisonous != pis.poisonous || dis.lifesteal != pis.lifesteal) minionbool = false;
                if (minionbool == false) break;
            }
            if (minionbool == false)
            {

                return false;
            }

            for (int i = 0; i < this.enemyMinions.Count; i++)
            {
                Minion dis = this.enemyMinions[i]; Minion pis = p.enemyMinions[i];
                //if (dis.entitiyID == 0) dis.entitiyID = pis.entitiyID;
                //if (pis.entitiyID == 0) pis.entitiyID = dis.entitiyID;
                if (dis.entitiyID != pis.entitiyID) minionbool = false;
                if (dis.Angr != pis.Angr || dis.Hp != pis.Hp || dis.maxHp != pis.maxHp || dis.numAttacksThisTurn != pis.numAttacksThisTurn) minionbool = false;
                if (dis.Ready != pis.Ready) minionbool = false; // includes frozen, exhaunted
                if (dis.playedThisTurn != pis.playedThisTurn) minionbool = false;
                if (dis.silenced != pis.silenced || dis.stealth != pis.stealth || dis.taunt != pis.taunt || dis.windfury != pis.windfury || dis.zonepos != pis.zonepos) minionbool = false;
                if (dis.divineshild != pis.divineshild || dis.cantLowerHPbelowONE != pis.cantLowerHPbelowONE || dis.immune != pis.immune) minionbool = false;
                if (dis.ownBlessingOfWisdom != pis.ownBlessingOfWisdom || dis.enemyBlessingOfWisdom != pis.enemyBlessingOfWisdom) minionbool = false;
                if (dis.ownPowerWordGlory != pis.ownPowerWordGlory || dis.enemyPowerWordGlory != pis.enemyPowerWordGlory) minionbool = false;
                if (dis.destroyOnEnemyTurnStart != pis.destroyOnEnemyTurnStart || dis.destroyOnEnemyTurnEnd != pis.destroyOnEnemyTurnEnd || dis.destroyOnOwnTurnEnd != pis.destroyOnOwnTurnEnd || dis.destroyOnOwnTurnStart != pis.destroyOnOwnTurnStart) minionbool = false;
                if (dis.ancestralspirit != pis.ancestralspirit || dis.desperatestand != pis.desperatestand || dis.souloftheforest != pis.souloftheforest || dis.stegodon != pis.stegodon || dis.livingspores != pis.livingspores) minionbool = false;
                if (dis.explorershat != pis.explorershat || dis.returnToHand != pis.returnToHand || dis.infest != pis.infest || dis.deathrattle2 != pis.deathrattle2) minionbool = false;
                if (dis.hChoice != pis.hChoice || dis.cantBeTargetedBySpellsOrHeroPowers != pis.cantBeTargetedBySpellsOrHeroPowers || dis.poisonous != pis.poisonous || dis.lifesteal != pis.lifesteal) minionbool = false;
                if (minionbool == false) break;
            }
            if (minionbool == false)
            {
                return false;
            }

            for (int i = 0; i < this.owncards.Count; i++)
            {
                Handmanager.Handcard dishc = this.owncards[i]; Handmanager.Handcard pishc = p.owncards[i];
                if (dishc.position != pishc.position || dishc.entity != pishc.entity || dishc.manacost != pishc.manacost)
                {
                    return false;
                }
            }

            if (this.enemySecretCount >= 1)
            {
                for (int i = 0; i < this.enemySecretList.Count; i++)
                {
                    if (!this.enemySecretList[i].isEqual(p.enemySecretList[i]))
                    {
                        return false;
                    }
                }
            }

            if (this.ownSecretsIDList.Count != p.ownSecretsIDList.Count)
            {
                return false;
            }
            for (int i = 0; i < this.ownSecretsIDList.Count; i++)
            {
                if (this.ownSecretsIDList[i] != p.ownSecretsIDList[i])
                {
                    return false;
                }
            }

            return true;
        }

        public Int64 GetPHash()
        {
            Int64 retval = 0;
            if (Settings.Instance.ImprovedCalculations > 0)
            {
                if (Settings.Instance.ImprovedCalculations == 1)
                {
                    if (this.playactions.Count > 0)
                    {
                        foreach (Action a in this.playactions)
                        {
                            switch (a.actionType)
                            {
                                case actionEnum.playcard:
                                    retval += a.card.entity;
                                    if (a.target != null)
                                    {
                                        retval += a.target.entitiyID;
                                    }
                                    retval += a.druidchoice;
                                    continue;
                                case actionEnum.attackWithMinion:
                                    retval += a.own.entitiyID + a.target.entitiyID;
                                    continue;
                                case actionEnum.attackWithHero:
                                    retval += a.target.entitiyID;
                                    continue;
                                case actionEnum.useHeroPower:
                                    retval += 100;
                                    if (a.target != null)
                                    {
                                        retval += a.target.entitiyID;
                                    }
                                    retval += a.druidchoice;
                                    continue;
                            }
                        }
                        if (this.playactions[this.playactions.Count - 1].card != null && this.playactions[this.playactions.Count - 1].card.card.type == CardDB.cardtype.MOB) retval++;
                        retval += this.manaTurnEnd;
                    }
                }
                else if (Settings.Instance.ImprovedCalculations == 2)
                {

                }
                retval += this.anzOgOwnCThunAngrBonus + this.anzOwnJadeGolem + this.anzOwnElementalsLastTurn;
                retval *= 1000;

                foreach (Minion m in this.ownMinions)
                {
                    retval += m.entitiyID + m.Angr + m.Hp + (m.taunt ? 1 : 0) + (m.divineshild ? 1 : 0) + (m.wounded ? 0 : 1);
                }
                retval *= 10000000;
            }

            retval += 10000 * this.ownMinions.Count + 100 * this.enemyMinions.Count + 1000 * this.mana + 100000 * (this.ownHero.Hp + this.enemyHero.Hp) + this.owncards.Count + this.enemycarddraw + this.cardsPlayedThisTurn + this.mobsplayedThisTurn + this.ownHero.Angr + this.ownHero.armor + this.ownWeapon.Angr + this.enemyWeapon.Durability + this.spellpower + this.enemyspellpower + this.ownQuest.questProgress;
            return retval;
        }


        //stuff for playing around enemy aoes
        public void enemyPlaysAoe(int pprob, int pprob2)
        {
            if (!this.loatheb)
            {
                Playfield p = new Playfield(this);
                float oldval = Ai.Instance.botBase.getPlayfieldValue(p);
                p.value = int.MinValue;
                p.EnemyCardPlaying(p.enemyHeroStartClass, p.mana, p.enemyAnzCards, pprob, pprob2);
                float newval = Ai.Instance.botBase.getPlayfieldValue(p);
                p.value = int.MinValue;
                if (oldval > newval) // new board is better for enemy (value is smaller)
                {
                    this.copyValuesFrom(p);
                }
            }
        }

        public int EnemyCardPlaying(TAG_CLASS enemyHeroStrtClass, int currmana, int cardcount, int playAroundProb, int pap2)
        {
            int mana = currmana;
            if (cardcount == 0) return currmana;

            bool useAOE = false;
            int mobscount = 0;
            foreach (Minion min in this.ownMinions)
            {
                if (min.maxHp >= 2 && min.Angr >= 2) mobscount++;
            }

            if (mobscount >= 3) useAOE = true;

            if (enemyHeroStrtClass == TAG_CLASS.WARRIOR)
            {
                bool usewhirlwind = true;
                foreach (Minion m in this.enemyMinions)
                {
                    if (m.Hp == 1) usewhirlwind = false;
                }
                if (this.ownMinions.Count <= 3) usewhirlwind = false;

                if (usewhirlwind)
                {
                    mana = EnemyPlaysACard(CardDB.cardName.whirlwind, mana, playAroundProb, pap2);
                }
            }

            if (!useAOE) return mana;

            switch (enemyHeroStrtClass)
            {
                case TAG_CLASS.MAGE:
                    mana = EnemyPlaysACard(CardDB.cardName.flamestrike, mana, playAroundProb, pap2);
                    mana = EnemyPlaysACard(CardDB.cardName.blizzard, mana, playAroundProb, pap2);
                    break;
                case TAG_CLASS.HUNTER:
                    mana = EnemyPlaysACard(CardDB.cardName.unleashthehounds, mana, playAroundProb, pap2);
                    break;
                case TAG_CLASS.PRIEST:
                    mana = EnemyPlaysACard(CardDB.cardName.holynova, mana, playAroundProb, pap2);
                    break;
                case TAG_CLASS.SHAMAN:
                    mana = EnemyPlaysACard(CardDB.cardName.lightningstorm, mana, playAroundProb, pap2);
                    mana = EnemyPlaysACard(CardDB.cardName.maelstromportal, mana, playAroundProb, pap2);
                    break;
                case TAG_CLASS.PALADIN:
                    mana = EnemyPlaysACard(CardDB.cardName.consecration, mana, playAroundProb, pap2);
                    break;
                case TAG_CLASS.DRUID:
                    mana = EnemyPlaysACard(CardDB.cardName.swipe, mana, playAroundProb, pap2);
                    break;
            }

            return mana;
        }

        public int EnemyPlaysACard(CardDB.cardName cardname, int currmana, int playAroundProb, int pap2)
        {
            //todo manacosts
            
            switch (cardname)
            {
                case CardDB.cardName.flamestrike:
                    if (currmana >= 7)
                    {
                        if (wehaveCounterspell == 0)
                        {
                            bool dontkill = false;
                            int prob = Probabilitymaker.Instance.getProbOfEnemyHavingCardInHand(CardDB.cardIDEnum.CS2_032, this.enemyAnzCards, this.enemyDeckSize);
                            if (playAroundProb > prob) return currmana;
                            if (pap2 > prob) dontkill = true;

                            List<Minion> temp = this.ownMinions;
                            int damage = getEnemySpellDamageDamage(4);
                            foreach (Minion enemy in temp)
                            {
                                enemy.cantLowerHPbelowONE = dontkill;
                                this.minionGetDamageOrHeal(enemy, damage);
                                enemy.cantLowerHPbelowONE = false;
                            }
                        }
                        else wehaveCounterspell++;
                        currmana -= 7;
                    }
                    break;

                case CardDB.cardName.blizzard:
                    if (currmana >= 6)
                    {
                        if (wehaveCounterspell == 0)
                        {
                            bool dontkill = false;
                            int prob = Probabilitymaker.Instance.getProbOfEnemyHavingCardInHand(CardDB.cardIDEnum.CS2_028, this.enemyAnzCards, this.enemyDeckSize);
                            if (playAroundProb > prob) return currmana;
                            if (pap2 > prob) dontkill = true;

                            List<Minion> temp = this.ownMinions;
                            int damage = getEnemySpellDamageDamage(2);
                            foreach (Minion enemy in temp)
                            {
                                minionGetFrozen(enemy);
                                enemy.cantLowerHPbelowONE = dontkill;
                                this.minionGetDamageOrHeal(enemy, damage);
                                enemy.cantLowerHPbelowONE = false;
                            }
                        }
                        else wehaveCounterspell++;
                        currmana -= 6;
                    }
                    break;

                case CardDB.cardName.unleashthehounds:
                    if (currmana >= 4)//3
                    {
                        if (wehaveCounterspell == 0)
                        {
                            bool dontkill = false;
                            int prob = Probabilitymaker.Instance.getProbOfEnemyHavingCardInHand(CardDB.cardIDEnum.EX1_538, this.enemyAnzCards, this.enemyDeckSize);
                            if (playAroundProb > prob) return currmana;
                            if (pap2 > prob) dontkill = true;

                            int anz = this.ownMinions.Count;
                            int posi = this.enemyMinions.Count - 1;
                            CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_538t);//hound
                            for (int i = 0; i < anz; i++)
                            {
                                callKid(kid, posi, false);
                            }
                        }
                        else wehaveCounterspell++;
                        currmana -= 3;
                    }
                    break;

                case CardDB.cardName.holynova:
                    if (currmana >= 5)
                    {
                        if (wehaveCounterspell == 0)
                        {
                            bool dontkill = false;
                            int prob = Probabilitymaker.Instance.getProbOfEnemyHavingCardInHand(CardDB.cardIDEnum.CS1_112, this.enemyAnzCards, this.enemyDeckSize);
                            if (playAroundProb > prob) return currmana;
                            if (pap2 > prob) dontkill = true;

                            List<Minion> temp = this.enemyMinions;
                            int heal = getEnemySpellHeal(2);
                            int damage = getEnemySpellDamageDamage(2);
                            foreach (Minion enemy in temp)
                            {
                                this.minionGetDamageOrHeal(enemy, -heal);
                            }
                            this.minionGetDamageOrHeal(this.enemyHero, -heal);
                            temp = this.ownMinions;
                            foreach (Minion enemy in temp)
                            {
                                enemy.cantLowerHPbelowONE = dontkill;
                                this.minionGetDamageOrHeal(enemy, damage);
                                enemy.cantLowerHPbelowONE = false;
                            }
                            this.minionGetDamageOrHeal(this.ownHero, damage);
                        }
                        else wehaveCounterspell++;
                        currmana -= 5;
                    }
                    break;

                case CardDB.cardName.lightningstorm:
                    if (currmana >= 4)//3
                    {
                        if (wehaveCounterspell == 0)
                        {
                            bool dontkill = false;
                            int prob = Probabilitymaker.Instance.getProbOfEnemyHavingCardInHand(CardDB.cardIDEnum.EX1_259, this.enemyAnzCards, this.enemyDeckSize);
                            if (playAroundProb > prob) return currmana;
                            if (pap2 > prob) dontkill = true;

                            List<Minion> temp = this.ownMinions;
                            int damage = getEnemySpellDamageDamage(3);
                            foreach (Minion enemy in temp)
                            {
                                enemy.cantLowerHPbelowONE = dontkill;
                                this.minionGetDamageOrHeal(enemy, damage);
                                enemy.cantLowerHPbelowONE = false;
                            }
                        }
                        else wehaveCounterspell++;
                        currmana -= 3;
                    }
                    break;

                case CardDB.cardName.maelstromportal:
                    if (currmana >= 3)//2
                    {
                        if (wehaveCounterspell == 0)
                        {
                            bool dontkill = false;
                            int prob = Probabilitymaker.Instance.getProbOfEnemyHavingCardInHand(CardDB.cardIDEnum.KAR_073, this.enemyAnzCards, this.enemyDeckSize);
                            if (playAroundProb > prob) return currmana;
                            if (pap2 > prob) dontkill = true;

                            List<Minion> temp = this.ownMinions;
                            int damage = getEnemySpellDamageDamage(1);
                            foreach (Minion enemy in temp)
                            {
                                enemy.cantLowerHPbelowONE = dontkill;
                                this.minionGetDamageOrHeal(enemy, damage);
                                enemy.cantLowerHPbelowONE = false;
                            }
                        }
                        else wehaveCounterspell++;
                        currmana -= 2;
                    }
                    break;

                case CardDB.cardName.whirlwind:
                    if (currmana >= 3)//1
                    {
                        if (wehaveCounterspell == 0)
                        {
                            bool dontkill = false;
                            int prob = Probabilitymaker.Instance.getProbOfEnemyHavingCardInHand(CardDB.cardIDEnum.EX1_400, this.enemyAnzCards, this.enemyDeckSize);
                            if (playAroundProb > prob) return currmana;
                            if (pap2 > prob) dontkill = true;

                            List<Minion> temp = this.enemyMinions;
                            int damage = getEnemySpellDamageDamage(1);
                            foreach (Minion enemy in temp)
                            {
                                this.minionGetDamageOrHeal(enemy, damage);
                            }
                            temp = this.ownMinions;
                            foreach (Minion enemy in temp)
                            {
                                enemy.cantLowerHPbelowONE = dontkill;
                                this.minionGetDamageOrHeal(enemy, damage);
                                enemy.cantLowerHPbelowONE = false;
                            }
                        }
                        else wehaveCounterspell++;
                        currmana -= 1;
                    }
                    break;

                case CardDB.cardName.consecration:
                    if (currmana >= 4)
                    {
                        if (wehaveCounterspell == 0)
                        {
                            bool dontkill = false;
                            int prob = Probabilitymaker.Instance.getProbOfEnemyHavingCardInHand(CardDB.cardIDEnum.CS2_093, this.enemyAnzCards, this.enemyDeckSize);
                            if (playAroundProb > prob) return currmana;
                            if (pap2 > prob) dontkill = true;

                            List<Minion> temp = this.ownMinions;
                            int damage = getEnemySpellDamageDamage(2);
                            foreach (Minion enemy in temp)
                            {
                                enemy.cantLowerHPbelowONE = dontkill;
                                this.minionGetDamageOrHeal(enemy, damage);
                                enemy.cantLowerHPbelowONE = false;
                            }

                            this.minionGetDamageOrHeal(this.ownHero, damage);
                        }
                        else wehaveCounterspell++;
                        currmana -= 4;
                    }
                    break;

                case CardDB.cardName.swipe:
                    if (currmana >= 4)
                    {
                        if (wehaveCounterspell == 0)
                        {
                            bool dontkill = false;
                            int prob = Probabilitymaker.Instance.getProbOfEnemyHavingCardInHand(CardDB.cardIDEnum.CS2_012, this.enemyAnzCards, this.enemyDeckSize);
                            if (playAroundProb > prob) return currmana;
                            if (pap2 > prob) dontkill = true;

                            int damage4 = getEnemySpellDamageDamage(4);
                            // all others get 1 spelldamage
                            int damage1 = getEnemySpellDamageDamage(1);

                            List<Minion> temp = this.ownMinions;
                            Minion target = null;
                            foreach (Minion mnn in temp)
                            {
                                if (mnn.Hp <= damage4 || mnn.handcard.card.isSpecialMinion || target == null)
                                {
                                    target = mnn;
                                }
                            }
                            foreach (Minion mnn in temp.ToArray())
                            {
                                mnn.cantLowerHPbelowONE = dontkill;
                                this.minionGetDamageOrHeal(mnn, mnn.entitiyID == target.entitiyID ? damage4 : damage1);
                                mnn.cantLowerHPbelowONE = false;
                            }
                        }
                        else wehaveCounterspell++;
                        currmana -= 4;
                    }
                    break;
            }
            return currmana;
        }

        public int getNextEntity()
        {
            //i dont trust return this.nextEntity++; !!!
            int retval = this.nextEntity;
            this.nextEntity++;
            return retval;
        }


        // get all minions which are attackable
        public List<Minion> getAttackTargets(bool own, bool isLethalCheck)
        {
            List<Minion> trgts = new List<Minion>();
            List<Minion> trgts2 = new List<Minion>();

            List<Minion> temp = (own) ? this.enemyMinions : this.ownMinions;
            bool hasTaunts = false;
            foreach (Minion m in temp)
            {
                if (m.stealth) continue; // cant target stealth

                if (m.taunt)
                {
                    hasTaunts = true;
                    trgts.Add(m);
                }
                else
                {
                    trgts2.Add(m);
                }
            }
            if (hasTaunts) return trgts;

            if (isLethalCheck) trgts2.Clear(); // only target enemy hero during Lethal check!

            if (own && !(this.enemyHero.immune || this.enemyHero.stealth)) trgts2.Add(this.enemyHero);
            else if (!own && !(this.ownHero.immune || this.ownHero.stealth)) trgts2.Add(this.ownHero);
            return trgts2;
        }

        public int getBestPlace(CardDB.Card card, bool lethal)
        {
            //we return the zonepos!
            if (card.type != CardDB.cardtype.MOB) return 1;
            if (this.ownMinions.Count == 0) return 1;
            if (this.ownMinions.Count == 1)
            {
                if (this.ownMinions[0].handcard.card.name == CardDB.cardName.flametonguetotem || this.ownMinions[0].handcard.card.name == CardDB.cardName.direwolfalpha) return 1;
                else if (card.name == CardDB.cardName.tuskarrtotemic) return 1;
                else return 2;
            }

            int omCount = this.ownMinions.Count;
            int[] places = new int[omCount];
            int[] buffplaces = new int[omCount];
            int i = 0;
            int tempval = 0;
            if (lethal)
            {
                bool givesBuff = false;
                switch (card.name)
                {
                    case CardDB.cardName.grimestreetprotector: givesBuff = true; break; 
                    case CardDB.cardName.defenderofargus: givesBuff = true; break;
                    case CardDB.cardName.flametonguetotem: givesBuff = true; break;
                    case CardDB.cardName.direwolfalpha: givesBuff = true; break;
                    case CardDB.cardName.ancientmage: givesBuff = true; break;
                    case CardDB.cardName.tuskarrtotemic: givesBuff = true; break;
                }
                if (givesBuff)
                {
                    if (this.ownMinions.Count == 2) return 2;
                    i = 0;
                    foreach (Minion m in this.ownMinions)
                    {

                        places[i] = 0;
                        tempval = 0;
                        if (m.Ready)
                        {
                            tempval -= m.Angr - 1;
                            if (m.windfury) tempval -= m.Angr - 1;
                        }
                        else tempval = 1000;
                        places[i] = tempval;

                        i++;
                    }

                    i = 0;
                    int bestpl = 7;
                    int bestval = 10000;
                    foreach (Minion m in this.ownMinions)
                    {
                        int prev = 0;
                        int next = 0;
                        if (i >= 1) prev = places[i - 1];
                        next = places[i];
                        if (bestval >= prev + next)
                        {
                            bestval = prev + next;
                            bestpl = i;
                        }
                        i++;
                    }
                    return bestpl + 1;
                }
                else return this.ownMinions.Count + 1;
            }
            if (card.name == CardDB.cardName.sunfuryprotector || card.name == CardDB.cardName.defenderofargus) // bestplace, if right and left minions have no taunt + lots of hp, dont make priority-minions to taunt
            {
                if (lethal) return 1;
                if (this.ownMinions.Count == 2)
                {
                    int val1 = prozis.penman.getValueOfUsefulNeedKeepPriority(this.ownMinions[0].handcard.card.name);
                    int val2 = prozis.penman.getValueOfUsefulNeedKeepPriority(this.ownMinions[1].handcard.card.name);
                    if (val1 == 0 && val2 == 0) return 2;
                    else if (val1 > val2) return 3;
                    else return 1;
                }

                i = 0;
                foreach (Minion m in this.ownMinions)
                {

                    places[i] = 0;
                    tempval = 0;
                    if (!m.taunt)
                    {
                        tempval -= m.Hp;
                    }
                    else
                    {
                        tempval -= m.Hp - 2;
                    }

                    if (m.windfury)
                    {
                        tempval += 2;
                    }

                    tempval += prozis.penman.getValueOfUsefulNeedKeepPriority(m.handcard.card.name);
                    places[i] = tempval;
                    i++;
                }


                i = 0;
                int bestpl = 7;
                int bestval = 10000;
                foreach (Minion m in this.ownMinions)
                {
                    int prev = 0;
                    int next = 0;
                    if (i >= 1) prev = places[i - 1];
                    next = places[i];
                    if (bestval > prev + next)
                    {
                        bestval = prev + next;
                        bestpl = i;
                    }
                    i++;
                }
                return bestpl + 1;
            }

            int cardIsBuffer = 0;
            bool placebuff = false;
            if (card.name == CardDB.cardName.flametonguetotem || card.name == CardDB.cardName.direwolfalpha || card.name == CardDB.cardName.tuskarrtotemic)
            {
                placebuff = true;
                if (card.name == CardDB.cardName.flametonguetotem || card.name == CardDB.cardName.tuskarrtotemic) cardIsBuffer = 2;
                if (card.name == CardDB.cardName.direwolfalpha) cardIsBuffer = 1;
            }
            bool tundrarhino = false;
            foreach (Minion m in this.ownMinions)
            {
                if (m.handcard.card.name == CardDB.cardName.tundrarhino) tundrarhino = true;
                if (m.handcard.card.name == CardDB.cardName.flametonguetotem || m.handcard.card.name == CardDB.cardName.direwolfalpha) placebuff = true;
            }
            //max attack this turn
            if (placebuff)
            {


                int cval = 0;
                if (card.Charge || (card.race == 20 && tundrarhino))
                {
                    cval = card.Attack;
                    if (card.windfury) cval = card.Attack;
                }
                if (card.name == CardDB.cardName.nerubianegg)
                {
                    cval += 1;
                }
                i = 0;
                int[] whirlwindplaces = new int[this.ownMinions.Count];
                int gesval = 0;
                int minionsBefore = -1;
                int minionsAfter = -1;
                foreach (Minion m in this.ownMinions)
                {
                    buffplaces[i] = 0;
                    whirlwindplaces[i] = 1;
                    places[i] = 0;
                    tempval = -1;

                    if (m.Ready)
                    {
                        tempval = m.Angr;
                        if (m.windfury && m.numAttacksThisTurn == 0)
                        {
                            tempval += m.Angr;
                            whirlwindplaces[i] = 2;
                        }
                    }
                    else whirlwindplaces[i] = 0;

                    switch(m.handcard.card.name)
                    {
                        case CardDB.cardName.flametonguetotem:
                            buffplaces[i] = 2;
                            goto case CardDB.cardName.aiextra1;
                        case CardDB.cardName.direwolfalpha:
                            buffplaces[i] = 1;
                            goto case CardDB.cardName.aiextra1;
                        case CardDB.cardName.aiextra1:
                            if (minionsBefore == -1) minionsBefore = i;
                            minionsAfter = omCount - i - 1;
                            break;
                    }
                    tempval++;
                    places[i] = tempval;
                    gesval += tempval;
                    i++;
                }
                //gesval = whole possible damage
                int bplace = 0;
                int bvale = 0;
                bool needbefore = false;
                int middle = (omCount + 1) / 2;
                int middleProximity = 1000;
                int tmp = 0;
                if (minionsBefore > -1 && minionsBefore <= minionsAfter) needbefore = true;
                tempval = 0;
                for (i = 0; i <= omCount; i++)
                {
                    tempval = gesval;
                    int current = cval;
                    int prev = 0;
                    int next = 0;
                    if (i >= 1)
                    {
                        tempval -= places[i - 1];
                        prev = places[i - 1];
                        if (prev >= 0) prev += whirlwindplaces[i - 1] * cardIsBuffer;
                        if (i < omCount)
                        {
                            prev -= whirlwindplaces[i - 1] * buffplaces[i];
                        }
                        if (current > 0) current += buffplaces[i - 1];
                    }
                    if (i < omCount)
                    {
                        tempval -= places[i];
                        next = places[i];
                        if (next >= 0) next += whirlwindplaces[i] * cardIsBuffer;
                        if (i >= 1)
                        {
                            next -= whirlwindplaces[i] * buffplaces[i - 1];
                        }
                        if (current > 0) current += buffplaces[i];
                    }
                    tempval += current + prev + next;

                    bool setVal = false;
                    if (tempval > bvale) setVal = true;
                    else if (tempval == bvale)
                    {
                        if (needbefore)
                        {
                            if (i <= minionsBefore) setVal = true;
                        }
                        else
                        {
                            if (minionsBefore > -1)
                            {
                                if (i >= omCount - minionsAfter) setVal = true;
                            }
                            else
                            {
                                tmp = middle - i;
                                if (tmp < 0) tmp *= -1;
                                if (tmp <= middleProximity)
                                {
                                    middleProximity = tmp;
                                    setVal = true;
                                }
                            }
                        }
                    }
                    if (setVal)
                    {
                        bplace = i;
                        bvale = tempval;
                    }
                }
                return bplace + 1;
            }

            // normal placement
            int bestplace = 0;
            int bestvale = 0;
            if (prozis.settings.placement == 1)
            {
                int cardvalue = card.Health * 2 + card.Attack;
                if (card.Shield) cardvalue = cardvalue * 3 / 2;
                cardvalue += prozis.penman.getValueOfUsefulNeedKeepPriority(card.name);

                i = 0;
                foreach (Minion m in this.ownMinions)
                {
                    places[i] = 0;
                    tempval = m.maxHp * 2 + m.Angr;
                    if (m.divineshild) tempval = tempval * 3 / 2;
                    if (!m.silenced) tempval += prozis.penman.getValueOfUsefulNeedKeepPriority(m.handcard.card.name);
                    places[i] = tempval;
                    i++;
                }

                tempval = 0;
                for (i = 0; i <= omCount; i++)
                {
                    if (i >= omCount - i)
                    {
                        bestplace = i;
                        break;
                    }
                    if (cardvalue >= places[i])
                    {
                        if (cardvalue < places[omCount - i - 1])
                        {
                            bestplace = i;
                            break;
                        }
                        else
                        {
                            if (places[i] > places[omCount - i - 1]) bestplace = omCount - i;
                            else bestplace = i;
                            break;
                        }
                    }
                    else
                    {
                        if (cardvalue >= places[omCount - i - 1])
                        {
                            bestplace = omCount - i;
                            break;
                        }
                    }
                }
            }
            else
            {
                int cardvalue = card.Attack * 2 + card.Health;
                if (card.tank)
                {
                    cardvalue += 5;
                    cardvalue += card.Health;
                }

                cardvalue += prozis.penman.getValueOfUsefulNeedKeepPriority(card.name);
                cardvalue += 1;

                i = 0;
                foreach (Minion m in this.ownMinions)
                {
                    places[i] = 0;
                    tempval = m.Angr * 2 + m.maxHp;
                    if (m.taunt)
                    {
                        tempval += 6;
                        tempval += m.maxHp;
                    }
                    if (!m.silenced)
                    {
                        tempval += prozis.penman.getValueOfUsefulNeedKeepPriority(m.handcard.card.name);
                        if (m.stealth) tempval += 40;
                    }
                    places[i] = tempval;

                    i++;
                }

                //bigminion if >=10
                tempval = 0;
                for (i = 0; i <= omCount; i++)
                {
                    int prev = cardvalue;
                    int next = cardvalue;
                    if (i >= 1) prev = places[i - 1];
                    if (i < omCount) next = places[i];


                    if (cardvalue >= prev && cardvalue >= next)
                    {
                        tempval = 2 * cardvalue - prev - next;
                        if (tempval > bestvale)
                        {
                            bestplace = i;
                            bestvale = tempval;
                        }
                    }
                    if (cardvalue <= prev && cardvalue <= next)
                    {
                        tempval = -2 * cardvalue + prev + next;
                        if (tempval > bestvale)
                        {
                            bestplace = i;
                            bestvale = tempval;
                        }
                    }
                }

            }

            return bestplace + 1;
        }

        public int getBestAdapt(Minion m) //1-+1/+1, 2-angr, 3-hp, 4-taunt, 5-divine, 6-poison
        {
            bool ownLethal = this.ownHeroHasDirectLethal();
            bool needTaunt = false;
            if (ownLethal) needTaunt = true;
            else if (m.Ready)
            {
                if (guessEnemyHeroLethalMissing() <= 3) { this.minionGetBuffed(m, 3, 0); return 2; }
                else if (ownLethal) needTaunt = true;
                else
                {
                    if (m.Hp > 3) { this.minionGetBuffed(m, 0, 3); return 3; }
                    else { m.poisonous = true; return 6; }
                }
            }
            else { this.minionGetBuffed(m, 1, 1); return 1; }

            if (needTaunt)
            {
                if (!m.taunt)
                {
                    m.taunt = true;
                    if (m.own) this.anzOwnTaunt++;
                    else this.anzEnemyTaunt++;
                    return 4;
                }
                else if (!m.divineshild) { m.divineshild = true; return 5; }
                else if (!m.poisonous) { m.poisonous = true; return 6; }
                else { this.minionGetBuffed(m, 0, 3);  return 3; }
            }
            return 0;
        }

        public int guessEnemyHeroLethalMissing()
        {
            int lethalMissing = this.enemyHero.armor + this.enemyHero.Hp;
            if (this.anzEnemyTaunt == 0)
            {
                foreach (Minion m in this.ownMinions)
                {
                    if (m.Ready)
                    {
                        lethalMissing -= m.Angr;
                        if (m.windfury && m.numAttacksThisTurn == 0) lethalMissing -= m.Angr;
                    }
                }
            }
            return lethalMissing;
        }

        public void guessHeroDamage()
        {
            int ghd = 0;
            int ablilityDmg = 0;
            switch (this.enemyHeroAblility.card.cardIDenum)
            {
                //direct damage
                case CardDB.cardIDEnum.DS1h_292: ablilityDmg += 2; break;
                case CardDB.cardIDEnum.DS1h_292_H1: ablilityDmg += 2; break;
                case CardDB.cardIDEnum.AT_132_HUNTER: ablilityDmg += 3; break;
                case CardDB.cardIDEnum.DS1h_292_H1_AT_132: ablilityDmg += 3; break;
                case CardDB.cardIDEnum.NAX15_02: ablilityDmg += 2; break;
                case CardDB.cardIDEnum.NAX15_02H: ablilityDmg += 2; break;
                case CardDB.cardIDEnum.NAX6_02: ablilityDmg += 3; break;
                case CardDB.cardIDEnum.NAX6_02H: ablilityDmg += 3; break;
                case CardDB.cardIDEnum.CS2_034: ablilityDmg += 1; break;
                case CardDB.cardIDEnum.CS2_034_H1: ablilityDmg += 1; break;
                case CardDB.cardIDEnum.CS2_034_H2: ablilityDmg += 1; break;
                case CardDB.cardIDEnum.AT_050t: ablilityDmg += 2; break;
                case CardDB.cardIDEnum.AT_132_MAGE: ablilityDmg += 2; break;
                case CardDB.cardIDEnum.CS2_034_H1_AT_132: ablilityDmg += 2; break;
                case CardDB.cardIDEnum.CS2_034_H2_AT_132: ablilityDmg += 2; break;
                case CardDB.cardIDEnum.EX1_625t: ablilityDmg += 2; break;
                case CardDB.cardIDEnum.EX1_625t2: ablilityDmg += 3; break;
                case CardDB.cardIDEnum.TU4d_003: ablilityDmg += 1; break;
                case CardDB.cardIDEnum.NAX7_03: ablilityDmg += 3; break;
                case CardDB.cardIDEnum.NAX7_03H: ablilityDmg += 4; break;
                case CardDB.cardIDEnum.ICC_830p: ablilityDmg += 2; break;
                case CardDB.cardIDEnum.ICC_831p: ablilityDmg += 3; break;
                case CardDB.cardIDEnum.ICC_833h: ablilityDmg += 1; break;
                //condition
                case CardDB.cardIDEnum.BRMA05_2H: if (this.mana > 0) ablilityDmg += 10; break;
                case CardDB.cardIDEnum.BRMA05_2: if (this.mana > 0) ablilityDmg += 5; break;
                case CardDB.cardIDEnum.BRM_027p: if (this.ownMinions.Count < 1) ablilityDmg += 8; break;
                case CardDB.cardIDEnum.BRM_027pH: if (this.ownMinions.Count < 2) ablilityDmg += 8; break;
                case CardDB.cardIDEnum.TB_MechWar_Boss2_HeroPower: if (this.ownMinions.Count < 2) ablilityDmg += 1; break;
                //equip weapon
                case CardDB.cardIDEnum.LOEA09_2: if (this.enemyWeapon.Durability < 1 && !this.enemyHero.frozen) ghd += 2; break;
                case CardDB.cardIDEnum.LOEA09_2H: if (this.enemyWeapon.Durability < 1 && !this.enemyHero.frozen) ghd += 5; break;
                case CardDB.cardIDEnum.CS2_083b: if (this.enemyWeapon.Durability < 1 && !this.enemyHero.frozen) ghd += 1; break;
                case CardDB.cardIDEnum.CS2_083b_H1: if (this.enemyWeapon.Durability < 1 && !this.enemyHero.frozen) ghd += 1; break;
                case CardDB.cardIDEnum.AT_132_ROGUE: if (this.enemyWeapon.Durability < 1 && !this.enemyHero.frozen) ghd += 2; break;
                case CardDB.cardIDEnum.CS2_017: if (!this.enemyHero.frozen) ghd += 1; break;
                case CardDB.cardIDEnum.AT_132_DRUID: if (!this.enemyHero.frozen) ghd += 2; break;
                case CardDB.cardIDEnum.ICC_832p: if (!this.enemyHero.frozen) ghd += 3; break;
            }

            ghd += ablilityDmg;
            foreach (Minion m in this.enemyMinions)
            {
                if (m.frozen) continue;
                switch (m.name)
                {
                    case CardDB.cardName.ancientwatcher: if (!m.silenced) continue; break;
                    case CardDB.cardName.blackknight: if (!m.silenced) continue; break;
                    case CardDB.cardName.whiteknight: if (!m.silenced) continue; break;
                    case CardDB.cardName.humongousrazorleaf: if (!m.silenced) continue; break;
                }
                ghd += m.Angr;
                if (m.windfury) ghd += m.Angr;
            }

            if (this.enemyWeapon.Durability > 0 && !this.enemyHero.frozen)
            {
                ghd += this.enemyWeapon.Angr;
                if (this.enemyHero.windfury && this.enemyWeapon.Durability > 1) ghd += this.enemyWeapon.Angr;
            }

            foreach (Minion m in this.ownMinions)
            {
                if (m.taunt) ghd -= m.Hp;
                if (m.taunt && m.divineshild) ghd -= 1;
            }

            int guessingHeroDamage = Math.Max(0, ghd);
            if (this.ownHero.immune) guessingHeroDamage = 0;
            this.guessingHeroHP = this.ownHero.Hp + this.ownHero.armor - guessingHeroDamage;

            bool haveImmune = false;
            if (this.guessingHeroHP < 1 && this.ownSecretsIDList.Count > 0)
            {
                foreach (CardDB.cardIDEnum secretID in this.ownSecretsIDList)
                {
                    switch (secretID)
                    {
                        case CardDB.cardIDEnum.EX1_130: //Noble Sacrifice
                            if (this.enemyMinions.Count > 0)
                            {
                                int mAngr = 1000;
                                foreach (Minion m in this.enemyMinions)
                                {
                                    if (!m.frozen && m.Angr < mAngr && m.Angr > 0) mAngr = m.Angr; //take the weakest
                                }
                                if (mAngr != 1000) this.guessingHeroHP += mAngr;
                            }
                            continue;
                        case CardDB.cardIDEnum.EX1_533: //Misdirection
                            if (this.enemyMinions.Count > 0)
                            {
                                int mAngr = 1000;
                                foreach (Minion m in this.enemyMinions)
                                {
                                    if (!m.frozen && m.Angr < mAngr && m.Angr > 0) mAngr = m.Angr; //take the weakest
                                }
                                if (mAngr != 1000) this.guessingHeroHP += mAngr;
                            }
                            continue;
                        case CardDB.cardIDEnum.AT_060: //Bear Trap
                            if (this.enemyMinions.Count > 1) this.guessingHeroHP += 3;
                            continue;
                        case CardDB.cardIDEnum.EX1_611: //Freezing Trap
                            if (this.enemyMinions.Count > 0)
                            {
                                int mAngr = 1000;
                                int mCharge = 0;
                                foreach (Minion m in this.enemyMinions)
                                {
                                    if (!m.frozen && m.Angr < mAngr && m.Angr > 0)
                                    {
                                        mAngr = m.Angr; //take the weakest
                                        mCharge = m.charge;
                                    }
                                }
                                if (mAngr < 1000 && mCharge < 1) this.guessingHeroHP += mAngr;
                            }
                            continue;
                        case CardDB.cardIDEnum.EX1_289: //Ice Barrier
                            this.guessingHeroHP += 8;
                            continue;
                        case CardDB.cardIDEnum.EX1_295: //Ice Block
                            haveImmune = true;
                            break;
                        case CardDB.cardIDEnum.EX1_594: //Vaporize
                            if (this.enemyMinions.Count > 0)
                            {
                                int mAngr = 1000;
                                foreach (Minion m in this.enemyMinions)
                                {
                                    if (!m.frozen && m.Angr < mAngr && m.Angr > 0) mAngr = m.Angr; //take the weakest
                                }
                                if (mAngr != 1000) this.guessingHeroHP += mAngr;
                            }
                            continue;
                        case CardDB.cardIDEnum.EX1_610: //Explosive Trap
                            if (this.enemyMinions.Count > 0)
                            {
                                int losshd = 0;
                                foreach (Minion m in this.enemyMinions)
                                {
                                    if (m.frozen) continue;
                                    switch (m.name)
                                    {
                                        case CardDB.cardName.ancientwatcher: if (!m.silenced) continue; break;
                                        case CardDB.cardName.blackknight: if (!m.silenced) continue; break;
                                        case CardDB.cardName.whiteknight: if (!m.silenced) continue; break;
                                        case CardDB.cardName.humongousrazorleaf: if (!m.silenced) continue; break;
                                    }
                                    if (m.Hp < 3)
                                    {
                                        losshd += m.Angr;
                                        if (m.windfury) losshd += m.Angr;
                                    }
                                }
                                this.guessingHeroHP += losshd;
                            }
                            continue;
                    }
                }
                if (haveImmune && this.guessingHeroHP < 2) this.guessingHeroHP = 2;
            }
            if (this.ownHero.Hp + this.ownHero.armor <= ablilityDmg && !haveImmune) this.guessingHeroHP = this.ownHero.Hp + this.ownHero.armor - ablilityDmg;
        }
		


        public bool ownHeroHasDirectLethal()
        {
            //fastLethalCheck
            if (this.anzOwnTaunt != 0) return false;
            if (this.ownHero.immune) return false;
            int totalEnemyDamage = 0;
            foreach (Minion m in this.enemyMinions)
            {
                if (!m.frozen && !m.cantAttack)
                {
                    switch (m.name)
                    {
                        case CardDB.cardName.icehowl: if (!m.silenced) continue; break;
                    }
                    totalEnemyDamage += m.Angr;
                    if (m.windfury) totalEnemyDamage += m.Angr;
                }
            }

            if (this.enemyAbilityReady)
            {
                switch (this.enemyHeroAblility.card.cardIDenum)
                {
                    //direct damage
                    case CardDB.cardIDEnum.DS1h_292: totalEnemyDamage += 2; break;
                    case CardDB.cardIDEnum.DS1h_292_H1: totalEnemyDamage += 2; break;
                    case CardDB.cardIDEnum.AT_132_HUNTER: totalEnemyDamage += 3; break;
                    case CardDB.cardIDEnum.DS1h_292_H1_AT_132: totalEnemyDamage += 3; break;
                    case CardDB.cardIDEnum.NAX15_02: totalEnemyDamage += 2; break;
                    case CardDB.cardIDEnum.NAX15_02H: totalEnemyDamage += 2; break;
                    case CardDB.cardIDEnum.NAX6_02: totalEnemyDamage += 3; break;
                    case CardDB.cardIDEnum.NAX6_02H: totalEnemyDamage += 3; break;
                    case CardDB.cardIDEnum.CS2_034: totalEnemyDamage += 1; break;
                    case CardDB.cardIDEnum.CS2_034_H1: totalEnemyDamage += 1; break;
                    case CardDB.cardIDEnum.CS2_034_H2: totalEnemyDamage += 1; break;
                    case CardDB.cardIDEnum.AT_050t: totalEnemyDamage += 2; break;
                    case CardDB.cardIDEnum.AT_132_MAGE: totalEnemyDamage += 2; break;
                    case CardDB.cardIDEnum.CS2_034_H1_AT_132: totalEnemyDamage += 2; break;
                    case CardDB.cardIDEnum.CS2_034_H2_AT_132: totalEnemyDamage += 2; break;
                    case CardDB.cardIDEnum.EX1_625t: totalEnemyDamage += 2; break;
                    case CardDB.cardIDEnum.EX1_625t2: totalEnemyDamage += 3; break;
                    case CardDB.cardIDEnum.TU4d_003: totalEnemyDamage += 1; break;
                    case CardDB.cardIDEnum.NAX7_03: totalEnemyDamage += 3; break;
                    case CardDB.cardIDEnum.NAX7_03H: totalEnemyDamage += 4; break;
                    //condition
                    case CardDB.cardIDEnum.BRMA05_2H: if (this.mana > 0) totalEnemyDamage += 10; break;
                    case CardDB.cardIDEnum.BRMA05_2: if (this.mana > 0) totalEnemyDamage += 5; break;
                    case CardDB.cardIDEnum.BRM_027p: if (this.ownMinions.Count < 1) totalEnemyDamage += 8; break;
                    case CardDB.cardIDEnum.BRM_027pH: if (this.ownMinions.Count < 2) totalEnemyDamage += 8; break;
                    case CardDB.cardIDEnum.TB_MechWar_Boss2_HeroPower: if (this.ownMinions.Count < 2) totalEnemyDamage += 1; break;
                    //equip weapon
                    case CardDB.cardIDEnum.LOEA09_2: if (this.enemyWeapon.Durability < 1 && !this.enemyHero.frozen) totalEnemyDamage += 2; break;
                    case CardDB.cardIDEnum.LOEA09_2H: if (this.enemyWeapon.Durability < 1 && !this.enemyHero.frozen) totalEnemyDamage += 5; break;
                    case CardDB.cardIDEnum.CS2_017: if (this.enemyWeapon.Durability < 1 && !this.enemyHero.frozen) totalEnemyDamage += 1; break;
                    case CardDB.cardIDEnum.CS2_083b: if (this.enemyWeapon.Durability < 1 && !this.enemyHero.frozen) totalEnemyDamage += 1; break;
                    case CardDB.cardIDEnum.CS2_083b_H1: if (this.enemyWeapon.Durability < 1 && !this.enemyHero.frozen) totalEnemyDamage += 1; break;
                    case CardDB.cardIDEnum.AT_132_ROGUE: if (this.enemyWeapon.Durability < 1 && !this.enemyHero.frozen) totalEnemyDamage += 2; break;
                    case CardDB.cardIDEnum.AT_132_DRUID: if (this.enemyWeapon.Durability < 1 && !this.enemyHero.frozen) totalEnemyDamage += 2; break;
                }
            }
            if (this.enemyWeapon.Durability > 0 && this.enemyHero.Ready && !this.enemyHero.frozen)
            {
                totalEnemyDamage += this.enemyWeapon.Angr;
                if (this.enemyHero.windfury && this.enemyWeapon.Durability > 1) totalEnemyDamage += this.enemyWeapon.Angr;
            }

            if (totalEnemyDamage < this.ownHero.Hp + this.ownHero.armor) return false;
            if (this.ownSecretsIDList.Count > 0)
            {
                foreach (CardDB.cardIDEnum secretID in this.ownSecretsIDList)
                {
                    switch (secretID)
                    {
                        case CardDB.cardIDEnum.EX1_289: //Ice Barrier
                            totalEnemyDamage -= 8;
                            continue;
                        case CardDB.cardIDEnum.EX1_295: //Ice Block
                            return false;
                        case CardDB.cardIDEnum.EX1_130: //Noble Sacrifice
                            return false;
                        case CardDB.cardIDEnum.EX1_533: //Misdirection
                            return false;
                        case CardDB.cardIDEnum.EX1_594: //Vaporize
                            return false;
                        case CardDB.cardIDEnum.EX1_611: //Freezing Trap
                            return false;
                        case CardDB.cardIDEnum.EX1_610: //Explosive Trap
                            return false;
                        case CardDB.cardIDEnum.AT_060: //Bear Trap
                            return false;
                        case CardDB.cardIDEnum.EX1_132: //Eye for an Eye
                            if ((this.enemyHero.Hp + this.enemyHero.armor) <= (this.ownHero.Hp + this.ownHero.armor) && !this.enemyHero.immune) return false;
                            continue;
                        case CardDB.cardIDEnum.LOE_021: //Dart Trap
                            if ((this.enemyHero.Hp + this.enemyHero.armor) < 6 && !this.enemyHero.immune) return false;
                            continue;
                    }
                }
            }
            if (totalEnemyDamage < this.ownHero.Hp + this.ownHero.armor) return false;
            return true;
        }

        public void simulateTrapsStartEnemyTurn()
        {
            // DONT KILL ENEMY HERO (cause its only guessing)

            List<CardDB.cardIDEnum> tmpSecretsIDList = new List<CardDB.cardIDEnum>();
            List<Minion> temp;
            int pos;

            foreach (CardDB.cardIDEnum secretID in this.ownSecretsIDList)
            {
                switch (secretID)
                {
                    
                    
                    case CardDB.cardIDEnum.EX1_554: //snaketrap
                        
                        pos = this.ownMinions.Count;
                        if (pos == 0) continue;
                        CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_554t);//snake
                        callKid(kid, pos, true, false);
                        callKid(kid, pos, true);
                        callKid(kid, pos, true);
                        continue;
                    case CardDB.cardIDEnum.EX1_610: //explosive trap
                        
                        temp = new List<Minion>(this.enemyMinions);
                        int damage = getSpellDamageDamage(2);
                        foreach (Minion m in temp)
                        {
                            minionGetDamageOrHeal(m, damage);
                        }
                        attackEnemyHeroWithoutKill(damage);
                        continue;
                    case CardDB.cardIDEnum.EX1_611: //freezing trap
                        {
                            
                            int count = this.enemyMinions.Count;
                            if (count == 0) continue;
                            Minion mnn = this.enemyMinions[0];
                            for (int i = 1; i < count; i++ )
                            {
                                if (this.enemyMinions[i].Angr < mnn.Angr) mnn = this.enemyMinions[i]; //take the weakest
                            }
                            minionReturnToHand(mnn, false, 0);
                            continue;
                        }  
                    case CardDB.cardIDEnum.AT_060: //beartrap
                        
                        if (this.enemyMinions.Count == 0 && ((this.enemyWeapon.Angr == 0 && !prozis.penman.HeroPowerEquipWeapon.ContainsKey(this.enemyHeroAblility.card.name)) || this.enemyHero.frozen)) continue;
                        pos = this.ownMinions.Count;
                        callKid(CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.CS2_125), pos, true, false);
                        continue;
                    case CardDB.cardIDEnum.LOE_021: //Dart Trap
                        
                        minionGetDamageOrHeal(this.enemyHero, getSpellDamageDamage(5), true);
                        continue;
                    case CardDB.cardIDEnum.EX1_533: // misdirection
                        {
                            
                            
                            int count = this.enemyMinions.Count;
                            if (count == 0 && ((this.enemyWeapon.Angr == 0 && !prozis.penman.HeroPowerEquipWeapon.ContainsKey(this.enemyHeroAblility.card.name)) || this.enemyHero.frozen)) continue;
                            Minion mnn = this.enemyMinions[0];
                            for (int i = 1; i < count; i++ )
                            {
                                if (this.enemyMinions[i].Angr > mnn.Angr) mnn = this.enemyMinions[i]; //take the strongest
                            }
                            mnn.Angr = 0;
                            this.evaluatePenality -= this.enemyMinions.Count;// the more the enemy minions has on board, the more the posibility to destroy something other :D
                            continue;
                        }
                    case CardDB.cardIDEnum.KAR_004: //cattrick
                        
                        pos = this.ownMinions.Count;
                        callKid(CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_017), pos, true, false);
                        continue;

                    
                    case CardDB.cardIDEnum.EX1_287: //counterspell
                        
                        wehaveCounterspell++; 
                        continue;
                    case CardDB.cardIDEnum.EX1_289: //ice barrier
                        
                        if (this.enemyMinions.Count == 0 && ((this.enemyWeapon.Angr == 0 && !prozis.penman.HeroPowerEquipWeapon.ContainsKey(this.enemyHeroAblility.card.name)) || this.enemyHero.frozen)) continue;
                        this.ownHero.armor += 8;
                        continue;
                    case CardDB.cardIDEnum.EX1_295: //ice block
                        
                        guessHeroDamage();
                        if (guessingHeroHP < 11) this.ownHero.immune = true;
                        continue;
                    case CardDB.cardIDEnum.EX1_294: //mirror entity
                        
                        if (this.ownMinions.Count < 7)
                        {
                            pos = this.ownMinions.Count - 1;
                            callKid(CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.TU4f_007), pos, true, false); 
                        }
                        else goto default;
                        continue;
                    case CardDB.cardIDEnum.AT_002: //effigy
                        
                        if (this.ownMinions.Count == 0) continue;
                        pos = this.ownMinions.Count - 1;
                        callKid(CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.TU4f_007), pos, true); 
                        continue;
                    case CardDB.cardIDEnum.tt_010: //spellbender
                        
                        this.evaluatePenality -= 4;
                        continue;
                    case CardDB.cardIDEnum.EX1_594: // vaporize
                        {
                            
                            int count = this.enemyMinions.Count;
                            if (count == 0) continue;
                            Minion mnn = this.enemyMinions[0];
                            for (int i = 1; i < count; i++)
                            {
                                if (this.enemyMinions[i].Angr < mnn.Angr) mnn = this.enemyMinions[i]; //take the weakest
                            }
                            minionGetDestroyed(mnn);
                            continue;
                        }
                    case CardDB.cardIDEnum.FP1_018: // duplicate
                        {
                            
                            int count = this.ownMinions.Count;
                            if (count == 0) continue;
                            Minion mnn = this.ownMinions[0];
                            for (int i = 1; i < count; i++)
                            {
                                if (this.ownMinions[i].Angr < mnn.Angr) mnn = this.ownMinions[i]; //take the weakest
                            }
                            drawACard(mnn.name, true);
                            drawACard(mnn.name, true);
                            continue;
                        }
                    
                    
                    
                    
                    case CardDB.cardIDEnum.EX1_132: // eye for an eye
                        {
                            
                            // todo for mage and hunter
                            if (this.enemyHero.frozen && this.enemyMinions.Count == 0) continue;
                            int dmg = 0;
                            int dmgW = 0;

                            int count = this.enemyMinions.Count;
                            if (count != 0)
                            {
                                Minion mnn = this.enemyMinions[0];
                                for (int i = 1; i < count; i++)
                                {
                                    if (this.enemyMinions[i].Angr < mnn.Angr) mnn = this.enemyMinions[i]; //take the weakest
                                }
                                dmg = mnn.Angr;
                            }
                            if (this.enemyWeapon.Angr != 0) dmgW = this.enemyWeapon.Angr;
                            else if (prozis.penman.HeroPowerEquipWeapon.ContainsKey(this.enemyHeroAblility.card.name)) dmgW = prozis.penman.HeroPowerEquipWeapon[this.enemyHeroAblility.card.name];
                            if (dmgW != 0)
                            {
                                if (dmg != 0)
                                {
                                    if (dmgW < dmg) dmg = dmgW;
                                }
                                else dmg = dmgW;
                            }
                            dmg = getSpellDamageDamage(dmg);
                            if (dmg != 0) attackEnemyHeroWithoutKill(dmg);
                            continue;
                        }
                    case CardDB.cardIDEnum.EX1_130: // noble sacrifice
                        
                        if (this.enemyMinions.Count == 0 && ((this.enemyWeapon.Angr == 0 && !prozis.penman.HeroPowerEquipWeapon.ContainsKey(this.enemyHeroAblility.card.name)) || this.enemyHero.frozen)) continue;
                        if (this.ownMinions.Count == 7) continue;
                        pos = this.ownMinions.Count - 1;
                        callKid(CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.AT_097), pos, true, false); 
                        continue;
                    case CardDB.cardIDEnum.EX1_136: // redemption
                        
                        
                        if (this.ownMinions.Count == 0) continue;
                        temp = new List<Minion>(this.ownMinions);
                        temp.Sort((a, b) => a.Hp.CompareTo(b.Hp));
                        foreach (Minion m in temp)
                        {
                            if (m.divineshild) continue;
                            m.divineshild = true;
                            break;
                        }
                        continue;
                    case CardDB.cardIDEnum.FP1_020: // avenge
                        
                        
                        if (this.ownMinions.Count < 2 || (this.ownMinions.Count == 1 && !this.ownSecretsIDList.Contains(CardDB.cardIDEnum.EX1_130))) continue;
                        temp = new List<Minion>(this.ownMinions);
                        temp.Sort((a, b) => a.Hp.CompareTo(b.Hp));
                        minionGetBuffed(temp[0], 3, 2);
                        continue;
                    default:
                        tmpSecretsIDList.Add(secretID);
                        continue;
                }
            }
            this.ownSecretsIDList.Clear();
            this.ownSecretsIDList.AddRange(tmpSecretsIDList);

            this.doDmgTriggers();
        }

        public void simulateTrapsEndEnemyTurn()
        {
            // DONT KILL ENEMY HERO (cause its only guessing)

            List<CardDB.cardIDEnum> tmpSecretsIDList = new List<CardDB.cardIDEnum>();
            List<Minion> temp;
            
            bool activate = false;
            foreach (CardDB.cardIDEnum secretID in this.ownSecretsIDList)
            {
                switch (secretID)
                {
                    
                    
                    
                    
                    
                    
                    
                    
                    case CardDB.cardIDEnum.EX1_609: //snipe
                        
                        activate = false;
                        if (this.enemyMinions.Count > 0)
                        {
                            temp = new List<Minion>(this.enemyMinions);
                            int damage = getSpellDamageDamage(4);
                            foreach (Minion m in temp)
                            {
                                if (m.playedThisTurn)
                                {
                                    minionGetDamageOrHeal(m, damage);
                                    activate = true;
                                    break;
                                }
                            }
                        }
                        if (!activate) tmpSecretsIDList.Add(secretID);
                        continue;

                    
                    
                    
                    
                    
                    
                    
                    
                    

                    
                    
                    
                    
                    
                    case CardDB.cardIDEnum.EX1_379: // repentance
                        
                        activate = false;
                        if (this.enemyMinions.Count > 0)
                        {
                            temp = new List<Minion>(this.enemyMinions);
                            foreach (Minion m in temp)
                            {
                                if (m.playedThisTurn)
                                {
                                    m.Hp = 1;
                                    m.maxHp = 1;
                                    activate = true;
                                    break;
                                }
                            }
                        }
                        if (!activate) tmpSecretsIDList.Add(secretID);
                        continue;
                    case CardDB.cardIDEnum.LOE_027: // Sacred Trial
                        
                        activate = false;
                        if (this.enemyMinions.Count > 3)
                        {
                            temp = new List<Minion>(this.enemyMinions);
                            foreach (Minion m in temp)
                            {
                                if (m.playedThisTurn)
                                {
                                    this.minionGetDestroyed(m);
                                    activate = true;
                                    break;
                                }
                            }
                        }
                        if (!activate) tmpSecretsIDList.Add(secretID);
                        continue;
                    case CardDB.cardIDEnum.AT_073: // competitivespirit
                        
                        if (this.enemyMinions.Count == 0) continue;
                        foreach (Minion m in this.ownMinions)
                        {
                            minionGetBuffed(m, 1, 1);
                        }
                        continue;
                    default:
                        tmpSecretsIDList.Add(secretID);
                        continue;
                }
            }
            this.ownSecretsIDList.Clear();
            this.ownSecretsIDList.AddRange(tmpSecretsIDList);

            this.doDmgTriggers();
        }

        public void endTurn()
        {
            if (this.turnCounter == 0) this.manaTurnEnd = this.mana;
            this.turnCounter++;
            this.pIdHistory.Add(0);

            if (isOwnTurn)
            {
                this.value = int.MinValue;
                //penalty for destroying combo
                this.evaluatePenality += ComboBreaker.Instance.checkIfComboWasPlayed(this);
                if (this.complete) return;

                this.anzOwnElementalsLastTurn = this.anzOwnElementalsThisTurn;
                this.anzOwnElementalsThisTurn = 0;
            }
            else
            {
                simulateTrapsEndEnemyTurn();
            }

            this.triggerEndTurn(this.isOwnTurn);
            this.isOwnTurn = !this.isOwnTurn;
        }

        public void startTurn()
        {
            this.triggerStartTurn(this.isOwnTurn);
            if (!this.isOwnTurn)
            {
                simulateTrapsStartEnemyTurn();
                guessHeroDamage();
            }
            else
            {
				
                this.enemyHeroPowerCostLessOnce = 0;
            }
        }

        public void unlockMana()
        {
            this.ueberladung = 0;
            this.mana += lockedMana;
            this.lockedMana = 0;
        }

        //HeroPowerDamage calculation---------------------------------------------------
        public int getHeroPowerDamage(int dmg)
        {
            dmg += this.ownHeroPowerExtraDamage;
            if (this.doublepriest >= 1) dmg *= (2 * this.doublepriest);
            return dmg;
        }

        public int getEnemyHeroPowerDamage(int dmg)
        {
            dmg += this.enemyHeroPowerExtraDamage;
            if (this.enemydoublepriest >= 1) dmg *= (2 * this.enemydoublepriest);
            return dmg;
        }


        //spelldamage calculation---------------------------------------------------
        public int getSpellDamageDamage(int dmg)
        {
            int retval = dmg;
            retval += this.spellpower;
            if (this.doublepriest >= 1) retval *= (2 * this.doublepriest);
            return retval;
        }

        public int getSpellHeal(int heal)
        {
            int retval = heal;
            if (this.anzOwnAuchenaiSoulpriest > 0 || this.embracetheshadow > 0)
            {
                retval *= -1;
                retval -= this.spellpower;
            }
            if (this.doublepriest >= 1) retval *= (2 * this.doublepriest);
            return retval;
        }

        public void applySpellLifesteal(int heal, bool own)
        {
            bool minus = own ? (this.anzOwnAuchenaiSoulpriest > 0 || this.embracetheshadow > 0) : (this.anzEnemyAuchenaiSoulpriest > 0);
            this.minionGetDamageOrHeal(own ? ownHero : enemyHero, -heal * (minus ? -1 : 1));
        }

        public int getMinionHeal(int heal)
        {
            return (this.anzOwnAuchenaiSoulpriest > 0 || this.embracetheshadow > 0) ? -heal : heal;
        }

        public int getEnemySpellDamageDamage(int dmg)
        {
            int retval = dmg;
            retval += this.enemyspellpower;
            if (this.enemydoublepriest >= 1) retval *= (2 * this.enemydoublepriest);
            return retval;
        }

        public int getEnemySpellHeal(int heal)
        {
            int retval = heal;
            if (this.anzEnemyAuchenaiSoulpriest >= 1)
            {
                retval *= -1;
                retval -= this.enemyspellpower;
            }
            if (this.doublepriest >= 1) retval *= (2 * this.doublepriest);
            return retval;
        }

        public int getEnemyMinionHeal(int heal)
        {
            return (this.anzEnemyAuchenaiSoulpriest >= 1) ? -heal : heal;
        }


        // do the action--------------------------------------------------------------

        public void doAction(Action aa)
        {
            //CREATE NEW MINIONS (cant use a.target or a.own) (dont belong to this board)
            Minion trgt = null;
            Minion o = null;
            Handmanager.Handcard ha = null;
            if (aa.target != null)
            {
                if (aa.target.own)
                {
                    if (aa.target.entitiyID == this.ownHero.entitiyID) trgt = this.ownHero;
                    else
                    {
                        foreach (Minion m in this.ownMinions)
                        {
                            if (aa.target.entitiyID == m.entitiyID)
                            {
                                trgt = m;
                                break;
                            }
                        }
                    }
                }
                else
                {
                    if (aa.target.entitiyID == this.enemyHero.entitiyID) trgt = this.enemyHero;
                    else
                    {
                        foreach (Minion m in this.enemyMinions)
                        {
                            if (aa.target.entitiyID == m.entitiyID)
                            {
                                trgt = m;
                                break;
                            }
                        }
                    }
                }
                if (trgt == null)
                {
                    if (!aa.target.own)
                    {
                        if (aa.target.entitiyID == this.ownHero.entitiyID) trgt = this.ownHero;
                        else
                        {
                            foreach (Minion m in this.ownMinions)
                            {
                                if (aa.target.entitiyID == m.entitiyID)
                                {
                                    trgt = m;
                                    break;
                                }
                            }
                        }
                    }
                    else
                    {
                        if (aa.target.entitiyID == this.enemyHero.entitiyID) trgt = this.enemyHero;
                        else
                        {
                            foreach (Minion m in this.enemyMinions)
                            {
                                if (aa.target.entitiyID == m.entitiyID)
                                {
                                    trgt = m;
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            if (aa.own != null)
            {
                if (aa.own.own)
                {
                    if (aa.own.entitiyID == this.ownHero.entitiyID) o = this.ownHero;
                    else
                    {
                        foreach (Minion m in this.ownMinions)
                        {
                            if (aa.own.entitiyID == m.entitiyID)
                            {
                                o = m;
                                break;
                            }
                        }
                        if (o == null)
                        {
                            foreach (Minion m in this.enemyMinions)
                            {
                                if (aa.own.entitiyID == m.entitiyID)
                                {
                                    o = m;
                                    break;
                                }
                            }
                        }
                    }
                }
                else
                {
                    if (aa.own.entitiyID == this.enemyHero.entitiyID) o = this.enemyHero;
                    else
                    {
                        foreach (Minion m in this.enemyMinions)
                        {
                            if (aa.own.entitiyID == m.entitiyID)
                            {
                                o = m;
                                break;
                            }
                        }
                        if (o == null)
                        {
                            foreach (Minion m in this.ownMinions)
                            {
                                if (aa.own.entitiyID == m.entitiyID)
                                {
                                    o = m;
                                    break;
                                }
                            }
                        }
                    }
                }
            }

            if (aa.card != null)
            {
                foreach (Handmanager.Handcard hh in this.owncards)
                {
                    if (hh.entity == aa.card.entity)
                    {
                        ha = hh;
                        break;
                    }
                }
                if (aa.actionType == actionEnum.useHeroPower)
                {
                    ha = this.isOwnTurn ? this.ownHeroAblility : this.enemyHeroAblility;
                }
            }
            // create and execute the action------------------------------------------------------------------------
            Action a = new Action(aa.actionType, ha, o, aa.place, trgt, aa.penalty, aa.druidchoice);

            //save the action if its our first turn

            if (this.isOwnTurn) this.playactions.Add(a); //first turn is in the top level

            // its a minion attack--------------------------------
            if (a.actionType == actionEnum.attackWithMinion)
            {
                this.evaluatePenality += a.penalty;
                Minion target = a.target;
                //secret stuff
                int newTarget = this.secretTrigger_CharIsAttacked(a.own, target);

                if (newTarget >= 1)
                {
                    //search new target!
                    foreach (Minion m in this.ownMinions)
                    {
                        if (m.entitiyID == newTarget)
                        {
                            target = m;
                            break;
                        }
                    }
                    foreach (Minion m in this.enemyMinions)
                    {
                        if (m.entitiyID == newTarget)
                        {
                            target = m;
                            break;
                        }
                    }
                    if (this.ownHero.entitiyID == newTarget) target = this.ownHero;
                    if (this.enemyHero.entitiyID == newTarget) target = this.enemyHero;
                }
                if (a.own.Hp >= 1) minionAttacksMinion(a.own, target);
            }
            else
            {
                // its an hero attack--------------------------------
                if (a.actionType == actionEnum.attackWithHero)
                {
                    //secret trigger is inside
                    attackWithWeapon(a.own, a.target, a.penalty);
                }
                else
                {
                    // its an playing-card--------------------------------
                    if (a.actionType == actionEnum.playcard)
                    {
                        if (this.isOwnTurn)
                        {
                            playACard(a.card, a.target, a.place, a.druidchoice, a.penalty);
                            if (ownQuest.questProgress == ownQuest.maxProgress && ownQuest.Id != CardDB.cardIDEnum.None)
                            {
                                this.drawACard(ownQuest.Reward(), true);
                                ownQuest.Reset();
                            }
                        }
                        else
                        {
                            
                        }
                    }
                    else
                    {
                        // its using the hero power--------------------------------
                        if (a.actionType == actionEnum.useHeroPower)
                        {
                            playHeroPower(a.target, a.penalty, this.isOwnTurn, a.druidchoice);
                        }
                    }
                }
            }
            
            if (this.isOwnTurn)
            {
                this.optionsPlayedThisTurn++;
            }
            else
            {
                this.enemyOptionsDoneThisTurn++;
            }

        }

        //minion attacks a minion

        //dontcount = betrayal effect!
        public void minionAttacksMinion(Minion attacker, Minion defender, bool dontcount = false)
        {
            int oldHp = defender.Hp;
            if (attacker.isHero)
            {
                if (defender.isHero)
                {
                    int dmg = attacker.Angr;
                    switch ((attacker.own ? this.ownWeapon.name : this.enemyWeapon.name))
                    {
                        case CardDB.cardName.massiveruneblade:
                            dmg *= 2;
                            break;
                    }
                    defender.getDamageOrHeal(dmg, this, true, false);

                    switch ((attacker.own ? this.ownWeapon.name : this.enemyWeapon.name))
                    {
                        case CardDB.cardName.gravevengeance:
                            if (oldHp > defender.Hp) this.triggerAMinionDealedDmg(attacker, oldHp - defender.Hp, true);
                            break;
                    }
                }
                else
                {
                    defender.getDamageOrHeal(attacker.Angr, this, true, false);
                    if (oldHp > defender.Hp)
                    {
                        if (attacker.poisonous) minionGetDestroyed(defender);
                        else
                        {
                            switch ((attacker.own ? this.ownWeapon.name : this.enemyWeapon.name))
                            {
                                case CardDB.cardName.icebreaker:
                                    if (defender.frozen) minionGetDestroyed(defender);
                                    break;
                                case CardDB.cardName.gravevengeance:
                                    this.triggerAMinionDealedDmg(attacker, oldHp - defender.Hp, true);
                                    break;
                            }
                        }
                    }

                    int enem_attack = defender.Angr;
                    if (!this.ownHero.immuneWhileAttacking)
                    {
                        oldHp = attacker.Hp;
                        attacker.getDamageOrHeal(enem_attack, this, true, false);
                        if (!defender.silenced && oldHp > attacker.Hp)
                        {
                            switch (defender.handcard.card.name)
                            {
                                case CardDB.cardName.voodoohexxer: goto case CardDB.cardName.waterelemental;
                                case CardDB.cardName.snowchugger: goto case CardDB.cardName.waterelemental;
                                case CardDB.cardName.waterelemental: minionGetFrozen(attacker); break;
                            }
                            this.triggerAMinionDealedDmg(defender, oldHp - attacker.Hp, false);
                        }
                    }
                }
                if (defender.GotDmgValue > 0) this.triggerAMinionDealedDmg(attacker, defender.GotDmgValue, true);
                doDmgTriggers();
                return;
            }

            if (!dontcount)
            {
                attacker.numAttacksThisTurn++;
                attacker.stealth = false;
                if ((attacker.windfury && attacker.numAttacksThisTurn == 2) || !attacker.windfury)
                {
                    attacker.Ready = false;
                }

            }


            if (logging) Helpfunctions.Instance.logg(".attck with" + attacker.name + " A " + attacker.Angr + " H " + attacker.Hp);

            int attackerAngr = attacker.Angr;
            int defAngr = defender.Angr;

            //trigger attack ---------------------------
            this.triggerAMinionIsGoingToAttack(attacker, defender);
            

            //defender gets dmg
            oldHp = defender.Hp;
            defender.getDamageOrHeal(attackerAngr, this, true, false);
            bool defenderGotDmg = oldHp > defender.Hp;
            if (defenderGotDmg)
            {
                switch (attacker.handcard.card.name)
                {
                    case CardDB.cardName.voodoohexxer: goto case CardDB.cardName.waterelemental;
                    case CardDB.cardName.snowchugger: goto case CardDB.cardName.waterelemental;
                    case CardDB.cardName.waterelemental:
                        if (!attacker.silenced) minionGetFrozen(defender);
                        break;
                }
                this.triggerAMinionDealedDmg(attacker, defender.GotDmgValue, true); // attacker did dmg
            }
            if (defender.isHero)//target is enemy hero
            {
                doDmgTriggers();
                return;
            }

            //attacker gets dmg
            bool attackerGotDmg = false;
            if (!dontcount)//betrayal effect :D
            {
                oldHp = attacker.Hp;
                attacker.getDamageOrHeal(defAngr, this, true, false);
                attackerGotDmg = oldHp > attacker.Hp;
                if (attackerGotDmg)
                {
                    switch (defender.handcard.card.name)
                    {
                        case CardDB.cardName.voodoohexxer: goto case CardDB.cardName.waterelemental;
                        case CardDB.cardName.snowchugger: goto case CardDB.cardName.waterelemental;
                        case CardDB.cardName.waterelemental:
                            if (!defender.silenced) minionGetFrozen(attacker);
                            break;
                    }
                    this.triggerAMinionDealedDmg(defender, attacker.GotDmgValue, false); // defender did dmg
                }
            }


            //trigger poisonous effect of attacker + defender (even if they died due to attacking/defending)

            if (defenderGotDmg && attacker.poisonous && !defender.isHero)
            {
                minionGetDestroyed(defender);
            }

            if (attackerGotDmg && defender.poisonous && !attacker.isHero)
            {
                minionGetDestroyed(attacker);
            }

            switch (attacker.name)
            {
                case CardDB.cardName.theboogeymonster: 
                    if (!defender.isHero && defender.Hp < 1 && attacker.Hp > 0) this.minionGetBuffed(attacker, 2, 2);
                    break;
                case CardDB.cardName.windupburglebot: 
                    if (!defender.isHero && attacker.Hp > 0) this.drawACard(CardDB.cardName.unknown, attacker.own);
                    break;
                case CardDB.cardName.lotusassassin: 
                    if (!defender.isHero && defender.Hp < 1 && attacker.Hp > 0) attacker.stealth = true;
                    break;
                case CardDB.cardName.lotusillusionist: 
                    if (defender.isHero) this.minionTransform(attacker, this.getRandomCardForManaMinion(6));
                    break;
                case CardDB.cardName.viciousfledgling: 
                    if (defender.isHero) this.getBestAdapt(attacker);
                    break;
                case CardDB.cardName.knuckles: 
                    if (!defender.isHero && attacker.Hp > 0) this.minionAttacksMinion(attacker, attacker.own ? this.enemyHero : this.ownHero, true);
                    break;
                case CardDB.cardName.finjatheflyingstar: 
                    if (!defender.isHero && defender.Hp < 1)
                    {
                        if (attacker.own)
                        {
                            CardDB.Card c;
                            int count = 7 - this.ownMinions.Count; 
                            if (count > 0)
                            {
                                if (count > 2) count = 2;
                                foreach (KeyValuePair<CardDB.cardIDEnum, int> cid in this.prozis.turnDeck)
                                {
                                    c = CardDB.Instance.getCardDataFromID(cid.Key);
                                    if ((TAG_RACE)c.race == TAG_RACE.MURLOC)
                                    {
                                        for (int i = 0; i < cid.Value; i++)
                                        {
                                            this.callKid(c, this.ownMinions.Count, true);
                                            count--;
                                            if (count < 1) break;
                                        }
                                        if (count < 1) break;
                                    }
                                }
                            }
                        }
                        else
                        {
                            this.callKid(CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.CS2_168), this.enemyMinions.Count, false);
                            this.callKid(CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.CS2_168), this.enemyMinions.Count, false);
                        }
                    }
                    break;
                case CardDB.cardName.giantsandworm: 
                    if (!defender.isHero && defender.Hp < 1 && attacker.Hp > 0)
                    {
                        attacker.numAttacksThisTurn = 0; 
                        attacker.Ready = true;
                    }
                    break;
                case CardDB.cardName.drakonidslayer: goto case CardDB.cardName.foereaper4000;
                case CardDB.cardName.magnatauralpha: goto case CardDB.cardName.foereaper4000;
                case CardDB.cardName.foereaper4000:
                    if (!attacker.silenced && !dontcount)
                    {
                        List<Minion> temp = (attacker.own) ? this.enemyMinions : this.ownMinions;
                        foreach (Minion mnn in temp)
                        {
                            if (mnn.zonepos + 1 == defender.zonepos || mnn.zonepos - 1 == defender.zonepos)
                            {
                                this.minionAttacksMinion(attacker, mnn, true);
                            }
                        }
                    }
                    break;
            }

            this.doDmgTriggers();
        }

        //a hero attacks a minion
        public void attackWithWeapon(Minion hero, Minion target, int penality)
        {
            bool own = hero.own;
            Weapon weapon = own ? this.ownWeapon : this.enemyWeapon;
            this.attacked = true;
            this.evaluatePenality += penality;
            hero.numAttacksThisTurn++;

            //hero will end his readyness
            hero.updateReadyness();
            if (weapon.name == CardDB.cardName.foolsbane && !hero.frozen) hero.Ready = true;

            //heal whether truesilverchampion equipped
            switch (weapon.name)
            {
                case CardDB.cardName.truesilverchampion:
                    int heal = own ? this.getMinionHeal(2) : this.getEnemyMinionHeal(2); 
                    this.minionGetDamageOrHeal(hero, -heal);
                    doDmgTriggers();
                    break;
                case CardDB.cardName.piranhalauncher:
                    int pos = (own) ? this.ownMinions.Count : this.enemyMinions.Count;
                    this.callKid(CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.CFM_337t), pos, own); 
                    break;
                case CardDB.cardName.vinecleaver:
                    int pos2 = (own) ? this.ownMinions.Count : this.enemyMinions.Count;
                    this.callKid(CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.CS2_101t), pos2, own); 
                    this.callKid(CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.CS2_101t), pos2, own); 
                    break;
                case CardDB.cardName.foolsbane:
                    if (!hero.frozen) hero.Ready = true;
                    break;
                case CardDB.cardName.brassknuckles:
                    if (own)
                    {
                        Handmanager.Handcard hc = this.searchRandomMinionInHand(this.owncards, searchmode.searchLowestCost, GAME_TAGs.Mob);
                        if (hc != null)
                        {
                            hc.addattack++;
                            hc.addHp++;
                            this.anzOwnExtraAngrHp += 2;
                        }
                    }
                    else
                    {
                        if (this.enemyAnzCards > 0) this.anzEnemyExtraAngrHp += this.enemyAnzCards * 2 - 1;
                    }
                    break;
            }

            if (logging) Helpfunctions.Instance.logg("attck with weapon trgt: " + target.entitiyID);

            // hero attacks enemy----------------------------------------------------------------------------------

            if (target.isHero)// trigger secret and change target if necessary
            {
                int newTarget = this.secretTrigger_CharIsAttacked(hero, target);
                if (newTarget >= 1)
                {
                    //search new target!
                    foreach (Minion m in this.ownMinions)
                    {
                        if (m.entitiyID == newTarget)
                        {
                            target = m;
                            break;
                        }
                    }
                    foreach (Minion m in this.enemyMinions)
                    {
                        if (m.entitiyID == newTarget)
                        {
                            target = m;
                            break;
                        }
                    }
                    if (this.ownHero.entitiyID == newTarget) target = this.ownHero;
                    if (this.enemyHero.entitiyID == newTarget) target = this.enemyHero;
                }

            }
            this.minionAttacksMinion(hero, target);
            

            //gorehowl is not killed if he attacks minions
            if (own)
            {
                if (this.ownWeapon.name == CardDB.cardName.gorehowl && !target.isHero)
                {
                    this.ownWeapon.Angr--;
                    hero.Angr--;
                }
                else
                {
                    this.lowerWeaponDurability(1, true);
                }
            }
            else
            {
                if (enemyWeapon.card.name == CardDB.cardName.gorehowl && !target.isHero)
                {
                    this.enemyWeapon.Angr--;
                    hero.Angr--;
                }
                else
                {
                    this.lowerWeaponDurability(1, false);
                }
            }

        }

        //play a minion trigger stuff:
        // 1 whenever you play a card whatever triggers
        // 2 Auras
        // 5 whenever you summon a minion triggers (like starving buzzard)
        // 3 battlecry
        // 3.1 place minion
        // 3.2 dmg/died/dthrttl triggers
        // 4 secret: minion is played
        // 4.1 dmg/died/dthrttl triggers
        // 5 after you summon a minion triggers
        // 5.1 dmg/died/dthrttl triggers
        public void playACard(Handmanager.Handcard hc, Minion target, int position, int choice, int penality)
        {
            CardDB.Card c = hc.card;
            this.evaluatePenality += penality;
            if (this.nextSpellThisTurnCostHealth && hc.card.type == CardDB.cardtype.SPELL)
            {
                this.minionGetDamageOrHeal(this.ownHero, hc.card.getManaCost(this, hc.manacost));
                doDmgTriggers();
                this.nextSpellThisTurnCostHealth = false;
            }
            else if (this.nextMurlocThisTurnCostHealth && (TAG_RACE)hc.card.race == TAG_RACE.MURLOC)
            {
                this.minionGetDamageOrHeal(this.ownHero, hc.card.getManaCost(this, hc.manacost));
                doDmgTriggers();
                this.nextMurlocThisTurnCostHealth = false;
            }
            else this.mana = this.mana - hc.getManaCost(this);
            removeCard(hc);// remove card from hand

            this.triggerCardsChanged(true);

            if (c.type == CardDB.cardtype.SPELL)
            {
                this.playedPreparation = false;
                this.spellsplayedSinceRecalc++;
                if (target != null)
                {
                    hc.extraParam2 = choice;
                    if (target.own)
                    {
                        switch (target.name)
                        {
                            case CardDB.cardName.dragonkinsorcerer:
                                this.minionGetBuffed(target, 1, 1);
                                break;
                            case CardDB.cardName.eydisdarkbane:
                                Minion mTarget = this.getEnemyCharTargetForRandomSingleDamage(3);
                                this.minionGetDamageOrHeal(mTarget, 3, true);
                                break;
                            case CardDB.cardName.fjolalightbane:
                                target.divineshild = true;
                                break;
                            default:
                                break;
                        }
                    }
                }

                if (c.Secret)
                {
                    this.ownSecretsIDList.Add(c.cardIDenum);
                    this.nextSecretThisTurnCost0 = false;
                    this.secretsplayedSinceRecalc++;
                }
            }

            if (logging) Helpfunctions.Instance.logg("play crd " + c.name + " entitiy# " + hc.entity + " mana " + hc.getManaCost(this) + " trgt " + target);

            hc.target = target;
            this.triggerACardWillBePlayed(hc, true);
            int newTarget = secretTrigger_SpellIsPlayed(target, c);
            if (newTarget >= 1)
            {
                //search new target!
                foreach (Minion m in this.ownMinions)
                {
                    if (m.entitiyID == newTarget)
                    {
                        target = m;
                        break;
                    }
                }
                foreach (Minion m in this.enemyMinions)
                {
                    if (m.entitiyID == newTarget)
                    {
                        target = m;
                        break;
                    }
                }
                if (this.ownHero.entitiyID == newTarget) target = this.ownHero;
                if (this.enemyHero.entitiyID == newTarget) target = this.enemyHero;
                if (this.ownQuest.Id != CardDB.cardIDEnum.None && c.type == CardDB.cardtype.SPELL) this.ownQuest.trigger_SpellWasPlayed(target, hc.entity);
                hc.target = target;
            }
            if (newTarget != -2) // trigger spell-secrets!
            {

                if (c.type == CardDB.cardtype.MOB)
                {
                    if (this.ownMinions.Count < 7)
                    {
                        this.placeAmobSomewhere(hc, choice, position);
                        this.mobsplayedThisTurn++;
                    }
                    if (this.stampede > 0 && (TAG_RACE)c.race == TAG_RACE.PET)
                    {
                        for (int i = 1; i <= stampede; i++)
                        {
                            this.drawACard(CardDB.cardName.unknown, true, true);
                        }
                    }
                }
                else
                {
                    if (this.lockandload > 0 && c.type == CardDB.cardtype.SPELL)
                    {
                        for (int i = 1; i <= lockandload; i++)
                        {
                            this.drawACard(CardDB.cardName.unknown, true, true);
                        }
                    }
                    c.sim_card.onCardPlay(this, true, target, choice);
                    if (this.ownQuest.Id != CardDB.cardIDEnum.None && c.type == CardDB.cardtype.SPELL) this.ownQuest.trigger_SpellWasPlayed(target, hc.entity);
                    else if (c.type == CardDB.cardtype.WEAPON)
                    {
                        this.ownWeapon.Angr += hc.addattack;
                        this.ownWeapon.Durability += hc.addHp;
                        this.ownHero.Angr += hc.addattack;
                    }
                    this.doDmgTriggers();
                    

                }
            }
            if (newTarget != 0) //if it canBe_counterspell/spellbender
            {
                if (target != null)
                {
                    if (!target.own && (prozis.penman.attackBuffDatabase.ContainsKey(c.name) || prozis.penman.healthBuffDatabase.ContainsKey(c.name)))
                    {
                        this.evaluatePenality += 75;
                    }
                }
            }

            if (hc.target != null)
            {
                if (prozis.penman.healthBuffDatabase.ContainsKey(hc.card.name)) target.justBuffed += prozis.penman.healthBuffDatabase[hc.card.name];
            }

            
            
            this.cardsPlayedThisTurn++;

        }

        public void enemyplaysACard(CardDB.Card c, Minion target, int position, int choice, int penality)
        {

            Handmanager.Handcard hc = new Handmanager.Handcard(c);
            hc.entity = this.getNextEntity();
            if (logging) Helpfunctions.Instance.logg("enemy play crd " + c.name + " trgt " + target);

            this.enemyAnzCards--;//might be deleted if he got a real hand

            hc.target = target;
            this.triggerACardWillBePlayed(hc, false);
            this.triggerCardsChanged(false);

            int newTarget = secretTrigger_SpellIsPlayed(target, c);
            if (newTarget >= 1)
            {
                //search new target!
                foreach (Minion m in this.ownMinions)
                {
                    if (m.entitiyID == newTarget)
                    {
                        target = m;
                        break;
                    }
                }
                foreach (Minion m in this.enemyMinions)
                {
                    if (m.entitiyID == newTarget)
                    {
                        target = m;
                        break;
                    }
                }
                if (this.ownHero.entitiyID == newTarget) target = this.ownHero;
                if (this.enemyHero.entitiyID == newTarget) target = this.enemyHero;
            }
            if (newTarget != -2) // trigger spell-secrets!
            {
                if (c.type == CardDB.cardtype.MOB)
                {
                    //todo mob playing
                    //this.placeAmobSomewhere(hc, target, choice, position);

                }
                else
                {
                    c.sim_card.onCardPlay(this, false, target, choice);
                    //lockandload
                    this.doDmgTriggers();
                    


                }
            }
        }


        public void playHeroPower(Minion target, int penality, bool ownturn, int choice)
        {

            CardDB.Card c = (ownturn) ? this.ownHeroAblility.card : this.enemyHeroAblility.card;

            if (ownturn)
            {
                this.anzUsedOwnHeroPower++;
                if (this.anzUsedOwnHeroPower >= this.ownHeroPowerAllowedQuantity) this.ownAbilityReady = false;
            }
            else
            {
                this.anzUsedEnemyHeroPower++;
                if (this.anzUsedEnemyHeroPower >= this.enemyHeroPowerAllowedQuantity) this.enemyAbilityReady = false;
            }

            this.evaluatePenality += penality;
            this.mana = this.mana - this.ownHeroAblility.manacost + this.ownHeroPowerCostLessOnce;
            this.ownHeroPowerCostLessOnce = 0;

            if (logging) Helpfunctions.Instance.logg("play crd " + c.name + " trgt " + target);

            c.sim_card.onCardPlay(this, ownturn, target, choice);
            if (target != null && (ownturn ? this.ownAbilityFreezesTarget > 0 : this.enemyAbilityFreezesTarget > 0)) minionGetFrozen(target);
            this.triggerInspire(ownturn);
            this.secretTrigger_HeroPowerUsed();
            this.doDmgTriggers();
        }


        //lower durability of weapon + destroy them (deathrattle) 
        public void lowerWeaponDurability(int value, bool own)
        {
            if (own)
            {
                if (this.ownWeapon.Durability <= 0 || this.ownWeapon.immune) return;
                this.ownWeapon.Durability -= value;
                if (this.ownWeapon.Durability <= 0)
                {
                    if (this.ownWeapon.card.deathrattle)
                    {
                        Minion m = new Minion { own = true };
                        ownWeapon.card.sim_card.onDeathrattle(this, m);
                    }

                    this.ownHero.Angr = Math.Max(0, this.ownHero.Angr - this.ownWeapon.Angr);
                    this.ownWeapon = new Weapon();
                    this.ownHero.windfury = false;

                    foreach (Minion m in this.ownMinions)
                    {
                        switch (m.name)
                        {
                            case CardDB.cardName.southseadeckhand:
                                if (m.playedThisTurn)
                                {
                                    m.charge--;
                                    m.updateReadyness();
                                }
                                break;
                            case CardDB.cardName.smalltimebuccaneer:
                                this.minionGetBuffed(m, -2, 0);
                                break;
                            case CardDB.cardName.graveshambler:
                                if (!m.silenced) minionGetBuffed(m, 1, 1);
                                break;
                        }
                    }
                    this.ownHero.updateReadyness();
                }
            }
            else
            {
                if (this.enemyWeapon.Durability <= 0 || this.enemyWeapon.immune) return;
                this.enemyWeapon.Durability -= value;
                if (this.enemyWeapon.Durability <= 0)
                {
                    if (this.enemyWeapon.card.deathrattle)
                    {
                        Minion m = new Minion { own = false };
                        enemyWeapon.card.sim_card.onDeathrattle(this, m);
                    }

                    this.enemyHero.Angr = Math.Max(0, this.enemyHero.Angr - this.enemyWeapon.Angr);
                    this.enemyWeapon = new Weapon();
                    this.enemyHero.windfury = false;

                    foreach (Minion m in this.enemyMinions)
                    {
                        switch (m.name)
                        {
                            case CardDB.cardName.smalltimebuccaneer:
                                this.minionGetBuffed(m, -2, 0);
                                break;
                            case CardDB.cardName.graveshambler:
                                if (!m.silenced) minionGetBuffed(m, 1, 1);
                                break;
                        }
                    }

                    this.enemyHero.updateReadyness();
                }
            }
        }



        public void doDmgTriggers()
        {
            //we do the these trigger manualy (to less minions) (we could trigger them with m.handcard.card.sim_card.ontrigger...)
            if (this.tempTrigger.charsGotHealed >= 1)
            {
                triggerACharGotHealed();//possible effects: gain attack
            }

            if (this.tempTrigger.minionsGotHealed >= 1)
            {
                triggerAMinionGotHealed();//possible effects: draw card
            }


            if (this.tempTrigger.ownMinionsGotDmg + this.tempTrigger.enemyMinionsGotDmg >= 1)
            {
                triggerAMinionGotDmg(); //possible effects: draw card, gain armor, gain attack
            }

            if (this.tempTrigger.ownMinionsDied + this.tempTrigger.enemyMinionsDied >= 1)
            {
                triggerAMinionDied(); //possible effects: draw card, gain attack + hp, callKid.
                if (this.tempTrigger.ownMinionsDied >= 1) this.tempTrigger.ownMinionsChanged = true;
                if (this.tempTrigger.enemyMinionsDied >= 1) this.tempTrigger.enemyMininsChanged = true;
                this.tempTrigger.ownMinionsDied = 0;
                this.tempTrigger.enemyMinionsDied = 0;
                this.tempTrigger.ownBeastDied = 0;
                this.tempTrigger.enemyBeastDied = 0;
                this.tempTrigger.ownMurlocDied = 0;
                this.tempTrigger.enemyMurlocDied = 0;
                this.tempTrigger.ownMechanicDied = 0;
                this.tempTrigger.enemyMechanicDied = 0;
            }

            if (this.tempTrigger.ownMinionLosesDivineShield + this.tempTrigger.enemyMinionLosesDivineShield >= 1)
            {
                triggerAMinionLosesDivineShield(); //possible effects: draw card, gain armor, gain attack
            }

            updateBoards();
            if (this.tempTrigger.charsGotHealed + this.tempTrigger.minionsGotHealed + this.tempTrigger.ownMinionsGotDmg + this.tempTrigger.enemyMinionsGotDmg + this.tempTrigger.ownMinionsDied + this.tempTrigger.enemyMinionsDied >= 1)
            {
                doDmgTriggers();
            }
        }

        public void triggerACharGotHealed()
        {
            int anz = this.tempTrigger.charsGotHealed;
            this.tempTrigger.charsGotHealed = 0;

            foreach (Minion mnn in this.ownMinions)
            {
                if (mnn.silenced) continue;
                switch (mnn.handcard.card.name)
                {
                    case CardDB.cardName.lightwarden: goto case CardDB.cardName.aiextra1;
                    case CardDB.cardName.holychampion: goto case CardDB.cardName.aiextra1;
                    case CardDB.cardName.shadowboxer: goto case CardDB.cardName.aiextra1;
                    case CardDB.cardName.hoodedacolyte: goto case CardDB.cardName.aiextra1;
                    case CardDB.cardName.aiextra1:
                        mnn.handcard.card.sim_card.onACharGotHealed(this, mnn, anz);
                        break;
                    case CardDB.cardName.blackguard:
                        if (ownHero.GotHealedValue > 0) mnn.handcard.card.sim_card.onACharGotHealed(this, mnn, ownHero.GotHealedValue);
                        break;
                }
            }
            foreach (Minion mnn in this.enemyMinions)
            {
                if (mnn.silenced) continue;
                switch (mnn.handcard.card.name)
                {
                    case CardDB.cardName.lightwarden: goto case CardDB.cardName.aiextra1;
                    case CardDB.cardName.holychampion: goto case CardDB.cardName.aiextra1;
                    case CardDB.cardName.shadowboxer: goto case CardDB.cardName.aiextra1;
                    case CardDB.cardName.hoodedacolyte: goto case CardDB.cardName.aiextra1;
                    case CardDB.cardName.aiextra1:
                        mnn.handcard.card.sim_card.onACharGotHealed(this, mnn, anz);
                        break;
                    case CardDB.cardName.blackguard:
                        if (enemyHero.GotHealedValue > 0) mnn.handcard.card.sim_card.onACharGotHealed(this, mnn, enemyHero.GotHealedValue);
                        break;
                }
            }
        }

        public void triggerAMinionGotHealed()
        {
            //also dead minions trigger this
            int anz = this.tempTrigger.minionsGotHealed;
            this.tempTrigger.minionsGotHealed = 0;

            foreach (Minion mnn in this.ownMinions.ToArray())
            {
                if (mnn.silenced) continue;
                switch (mnn.handcard.card.name)
                {
                    case CardDB.cardName.northshirecleric: goto case CardDB.cardName.aiextra1;
                    case CardDB.cardName.manageode: goto case CardDB.cardName.aiextra1;
                    case CardDB.cardName.aiextra1:
                        mnn.handcard.card.sim_card.onAMinionGotHealedTrigger(this, mnn, anz);
                        break;
                }
            }

            foreach (Minion mnn in this.enemyMinions.ToArray())
            {
                if (mnn.silenced) continue;
                switch (mnn.handcard.card.name)
                {
                    case CardDB.cardName.northshirecleric: goto case CardDB.cardName.aiextra1;
                    case CardDB.cardName.manageode: goto case CardDB.cardName.aiextra1;
                    case CardDB.cardName.aiextra1:
                        mnn.handcard.card.sim_card.onAMinionGotHealedTrigger(this, mnn, anz);
                        break;
                }
            }
        }

        public void triggerAMinionGotDmg()
        {
            int anzOwnMinionsGotDmg = this.tempTrigger.ownMinionsGotDmg;
            int anzEnemyMinionsGotDmg = this.tempTrigger.enemyMinionsGotDmg;
            this.tempTrigger.ownMinionsGotDmg = 0;
            this.tempTrigger.enemyMinionsGotDmg = 0;

            int anzOwnHeroGotDmg = this.tempTrigger.ownHeroGotDmg;
            int anzEnemyHeroGotDmg = this.tempTrigger.enemyHeroGotDmg;
            this.tempTrigger.ownHeroGotDmg = 0;
            this.tempTrigger.enemyHeroGotDmg = 0;

            foreach (Minion m in this.ownMinions.ToArray())
            {
                if (m.silenced) { m.anzGotDmg = 0; continue; }
                m.handcard.card.sim_card.onMinionGotDmgTrigger(this, m, anzOwnMinionsGotDmg, anzEnemyMinionsGotDmg, anzOwnHeroGotDmg, anzEnemyHeroGotDmg);
                m.anzGotDmg = 0;
                m.GotDmgValue = 0;
            }

            foreach (Minion m in this.enemyMinions.ToArray())
            {
                if (m.silenced) { m.anzGotDmg = 0; continue; }
                m.handcard.card.sim_card.onMinionGotDmgTrigger(this, m, anzOwnMinionsGotDmg, anzEnemyMinionsGotDmg, anzOwnHeroGotDmg, anzEnemyHeroGotDmg);
                m.anzGotDmg = 0;
                m.GotDmgValue = 0;
            }
            this.ownHero.anzGotDmg = 0;
            this.enemyHero.anzGotDmg = 0;
        }

        public void triggerAMinionLosesDivineShield()
        {
            int anzOwn = this.tempTrigger.ownMinionLosesDivineShield;
            int anzEnemy = this.tempTrigger.enemyMinionLosesDivineShield;
            this.tempTrigger.ownMinionLosesDivineShield = 0;
            this.tempTrigger.enemyMinionLosesDivineShield = 0;
            
            if (anzOwn > 0)
            {
                foreach (Minion m in this.ownMinions.ToArray())
                {
                    if (m.silenced) continue;
                    m.handcard.card.sim_card.onMinionLosesDivineShield(this, m, anzOwn);
                }
                
                if (this.ownWeapon.name == CardDB.cardName.lightssorrow) this.ownWeapon.Angr += anzOwn;
            }
            
            if (anzEnemy > 0)
            {
                foreach (Minion m in this.enemyMinions.ToArray())
                {
                    if (m.silenced) continue;
                    m.handcard.card.sim_card.onMinionLosesDivineShield(this, m, anzEnemy);
                }
                
                if (this.enemyWeapon.name == CardDB.cardName.lightssorrow) this.enemyWeapon.Angr += anzEnemy;
            }
        }

        public void triggerAMinionDied()
        {
            this.ownMinionsDiedTurn += this.tempTrigger.ownMinionsDied;
            this.enemyMinionsDiedTurn += this.tempTrigger.enemyMinionsDied;

            foreach (Minion m in this.ownMinions.ToArray())
            {
                if (m.silenced) continue;
                if (m.Hp <= 0) continue;
                m.handcard.card.sim_card.onMinionDiedTrigger(this, m, m); 
            }
            foreach (Minion m in this.enemyMinions.ToArray())
            {
                if (m.silenced) continue;
                if (m.Hp <= 0) continue;
                m.handcard.card.sim_card.onMinionDiedTrigger(this, m, m);
            }

            foreach (Handmanager.Handcard hc in this.owncards)
            {
                if (hc.card.name == CardDB.cardName.bolvarfordragon) hc.addattack += this.tempTrigger.ownMinionsDied;
            }

            
            if (this.ownWeapon.name == CardDB.cardName.jaws)
            {
                int bonus = 0;
                foreach (Minion m in this.ownMinions) if (m.Hp < 1 && m.handcard.card.deathrattle && !m.silenced) bonus++;
                foreach (Minion m in this.enemyMinions) if (m.Hp < 1 && m.handcard.card.deathrattle && !m.silenced) bonus++;
                this.ownWeapon.Angr += bonus * 2;
            }
            if (this.enemyWeapon.name == CardDB.cardName.jaws)
            {
                int bonus = 0;
                foreach (Minion m in this.ownMinions) if (m.Hp < 1 && m.handcard.card.deathrattle && !m.silenced) bonus++;
                foreach (Minion m in this.enemyMinions) if (m.Hp < 1 && m.handcard.card.deathrattle && !m.silenced) bonus++;
                this.enemyWeapon.Angr += bonus * 2;
            }

            
            if (this.ownHeroAblility.card.name == CardDB.cardName.raisedead)
            {
                if (this.tempTrigger.enemyMinionsDied > 0)
                {
                    CardDB.Card kid = CardDB.Instance.getCardDataFromID((this.ownHeroAblility.card.cardIDenum == CardDB.cardIDEnum.NAX4_04H) ? CardDB.cardIDEnum.NAX4_03H : CardDB.cardIDEnum.NAX4_03);
                    for (int i = 0; i < this.tempTrigger.enemyMinionsDied; i++)
                    {
                        this.callKid(kid, this.ownMinions.Count, true);
                    }
                }
            }
            if (this.enemyHeroAblility.card.name == CardDB.cardName.raisedead)
            {
                if (this.tempTrigger.ownMinionsDied > 0)
                {
                    CardDB.Card kid = CardDB.Instance.getCardDataFromID((this.enemyHeroAblility.card.cardIDenum == CardDB.cardIDEnum.NAX4_04H) ? CardDB.cardIDEnum.NAX4_03H : CardDB.cardIDEnum.NAX4_03);
                    for (int i = 0; i < this.tempTrigger.ownMinionsDied; i++)
                    {
                        this.callKid(kid, this.enemyMinions.Count, false);
                    }
                }
            }
        }

        public void triggerAMinionIsGoingToAttack(Minion attacker, Minion target)
        {
            
            

            switch (attacker.name)
            {
                case CardDB.cardName.cutpurse:
                    if (target.isHero) this.drawACard(CardDB.cardName.thecoin, attacker.own, true);
                    break;
                case CardDB.cardName.wretchedtiller:
                    if (target.isHero) minionGetDamageOrHeal(attacker.own ? this.enemyHero : this.ownHero, 2);
                    break;
                case CardDB.cardName.shakuthecollector: 
                    this.drawACard(CardDB.cardName.unknown, attacker.own, true);
                    break;
                case CardDB.cardName.genzotheshark: 
                    while (this.owncards.Count < 3 && this.ownDeckSize > 0)
                    {
                        this.drawACard(CardDB.cardName.unknown, true, true);
                    }
                    while (this.enemyAnzCards < 3 && this.enemyDeckSize > 0)
                    {
                        this.drawACard(CardDB.cardName.unknown, false, true);
                    }
                    break;
            }

            if (attacker.ownBlessingOfWisdom >= 1)
            {
                for (int i = 0; i < attacker.ownBlessingOfWisdom; i++)
                {
                    this.drawACard(CardDB.cardName.unknown, true);
                }
            }
            if (attacker.enemyBlessingOfWisdom >= 1)
            {
                for (int i = 0; i < attacker.enemyBlessingOfWisdom; i++)
                {
                    this.drawACard(CardDB.cardName.unknown, false);
                }
            }

            if (attacker.ownPowerWordGlory >= 1)
            {
                int heal = this.getMinionHeal(4);
                for (int i = 0; i < attacker.ownPowerWordGlory; i++)
                {
                    this.minionGetDamageOrHeal(this.ownHero, -heal);
                }
            }
            if (attacker.enemyPowerWordGlory >= 1)
            {
                int heal = this.getEnemyMinionHeal(4);
                for (int i = 0; i < attacker.enemyPowerWordGlory; i++)
                {
                    this.minionGetDamageOrHeal(this.enemyHero, -heal);
                }
            }
        }

        public void triggerAMinionDealedDmg(Minion m, int dmgDone, bool isAttacker)
        {
            //3 cards only has such trigger
            switch (m.name)
            {
                case CardDB.cardName.alleyarmorsmith:
                    if (!m.silenced) this.minionGetArmor(m.own ? this.ownHero : this.enemyHero, m.Angr);
                    break;
            }
            if (m.lifesteal && isAttacker && dmgDone > 0)
            {
                if (m.own)
                {
                    if (this.anzOwnAuchenaiSoulpriest > 0 || this.embracetheshadow > 0) dmgDone *= -1;
                    this.minionGetDamageOrHeal(this.ownHero, -dmgDone);
                }
                else
                {
                    if (this.anzEnemyAuchenaiSoulpriest > 1) dmgDone *= -1;
                    this.minionGetDamageOrHeal(this.enemyHero, -dmgDone);
                }
            }
        }

        public void triggerACardWillBePlayed(Handmanager.Handcard hc, bool own)
        {
            if (own)
            {
                if (anzOwnDragonConsort > 0 && (TAG_RACE)hc.card.race == TAG_RACE.DRAGON) anzOwnDragonConsort = 0;
                int burly = 0;
                foreach (Minion m in this.ownMinions.ToArray())
                {
                    if (m.silenced) continue;
                    m.handcard.card.sim_card.onCardIsGoingToBePlayed(this, hc, own, m);
                }

                foreach (Minion m in this.enemyMinions)
                {
                    if (m.name == CardDB.cardName.troggzortheearthinator)
                    {
                        burly++;
                    }
                    if (m.name == CardDB.cardName.felreaver)
                    {
                        m.handcard.card.sim_card.onCardIsGoingToBePlayed(this, hc, own, m);
                    }
                }

                foreach (Handmanager.Handcard ohc in this.owncards)
                {
                    switch (ohc.card.name)
                    {
                        case CardDB.cardName.shadowreflection:
                            ohc.card.sim_card.onCardIsGoingToBePlayed(this, hc, own, ohc);
                            break;
                        case CardDB.cardName.blubberbaron:
                            ohc.card.sim_card.onCardIsGoingToBePlayed(this, hc, own, ohc);
                            break;
                    }
                }

                if (this.ownHeroAblility.card.name == CardDB.cardName.voidform) this.ownHeroAblility.card.sim_card.onCardIsGoingToBePlayed(this, hc, own, this.ownHeroAblility);

                if (this.ownWeapon.name == CardDB.cardName.atiesh)
                {
                    this.callKid(this.getRandomCardForManaMinion(hc.manacost), this.ownMinions.Count, own);
                    this.lowerWeaponDurability(1, own);
                }

                for (int i = 0; i < burly; i++)//summon for enemy !
                {
                    int pos = this.enemyMinions.Count;
                    this.callKid(CardDB.Instance.burlyrockjaw, pos, !own);
                }
            }
            else
            {
                int burly = 0;
                foreach (Minion m in this.enemyMinions.ToArray())
                {
                    if (m.silenced) continue;
                    m.handcard.card.sim_card.onCardIsGoingToBePlayed(this, hc, own, m);
                }
                foreach (Minion m in this.ownMinions)
                {
                    if (m.name == CardDB.cardName.troggzortheearthinator)
                    {
                        burly++;
                    }
                    if (m.name == CardDB.cardName.felreaver)
                    {
                        m.handcard.card.sim_card.onCardIsGoingToBePlayed(this, hc, own, m);
                    }
                }

                if (this.enemyHeroAblility.card.name == CardDB.cardName.voidform) this.enemyHeroAblility.card.sim_card.onCardIsGoingToBePlayed(this, hc, own, this.enemyHeroAblility);

                if (this.enemyWeapon.name == CardDB.cardName.atiesh)
                {
                    this.callKid(this.getRandomCardForManaMinion(hc.manacost), this.enemyMinions.Count, own);
                    this.lowerWeaponDurability(1, own);
                }

                for (int i = 0; i < burly; i++)//summon for us
                {
                    int pos = this.ownMinions.Count;
                    this.callKid(CardDB.Instance.burlyrockjaw, pos, own);
                }
            }

        }

        // public void triggerACardWasPlayed(CardDB.Card c, bool own) {        }

        public void triggerAMinionIsSummoned(Minion m)
        {
            if (m.own)
            {
                foreach (Minion mnn in this.ownMinions)
                {
                    if (mnn.silenced) continue;
                    mnn.handcard.card.sim_card.onMinionIsSummoned(this, mnn, m);
                }
            }
            else
            {
                foreach (Minion mnn in this.enemyMinions)
                {
                    if (mnn.silenced) continue;
                    mnn.handcard.card.sim_card.onMinionIsSummoned(this, mnn, m);
                }
            }
        }

        public void triggerAMinionWasSummoned(Minion mnn)
        {
            if (mnn.own)
            {
                if (this.ownQuest.Id != CardDB.cardIDEnum.None) this.ownQuest.trigger_MinionWasSummoned(mnn);
                if (mnn.taunt) anzOwnTaunt++;
                foreach (Minion m in this.ownMinions.ToArray())
                {
                    if (m.silenced || m.entitiyID == mnn.entitiyID) continue;
                    m.handcard.card.sim_card.onMinionWasSummoned(this, m, mnn);
                }
                switch (this.ownWeapon.name)
                {
                    case CardDB.cardName.swordofjustice:
                        this.minionGetBuffed(mnn, 1, 1);
                        this.lowerWeaponDurability(1, true);
                        break;
                }
            }
            else
            {
                if (this.enemyQuest.Id != CardDB.cardIDEnum.None) this.enemyQuest.trigger_MinionWasSummoned(mnn);
                if (mnn.taunt) anzEnemyTaunt++;
                foreach (Minion m in this.enemyMinions.ToArray())
                {
                    if (m.silenced || m.entitiyID == mnn.entitiyID) continue;
                    m.handcard.card.sim_card.onMinionWasSummoned(this, m, mnn);
                }
                switch (this.enemyWeapon.name)
                {
                    case CardDB.cardName.swordofjustice:
                        this.minionGetBuffed(mnn, 1, 1);
                        this.lowerWeaponDurability(1, false);
                        break;
                }
            }

        }

        public void triggerEndTurn(bool ownturn)
        {
            foreach (Minion m in this.ownMinions.ToArray())
            {
                m.cantAttackHeroes = false;
                if (!m.silenced)
                {
                    m.handcard.card.sim_card.onTurnEndsTrigger(this, m, ownturn);
                    if (this.ownTurnEndEffectsTriggerTwice > 0 && ownturn)
                    {
                        for (int i = 0; i < ownTurnEndEffectsTriggerTwice; i++)
                        {
                            m.handcard.card.sim_card.onTurnEndsTrigger(this, m, ownturn);
                        }
                    }
                }
                if (ownturn && m.destroyOnOwnTurnEnd) this.minionGetDestroyed(m);
            }
            foreach (Minion m in this.enemyMinions.ToArray())
            {
                if (!m.silenced)
                {
                    m.handcard.card.sim_card.onTurnEndsTrigger(this, m, ownturn);
                    if (this.enemyTurnEndEffectsTriggerTwice > 0 && !ownturn)
                    {
                        for (int i = 0; i < enemyTurnEndEffectsTriggerTwice; i++)
                        {
                            m.handcard.card.sim_card.onTurnEndsTrigger(this, m, ownturn);
                        }
                    }
                }
                if (!ownturn && m.destroyOnEnemyTurnEnd) this.minionGetDestroyed(m);
            }

            

            this.doDmgTriggers();

            //shadowmadness
            if (this.shadowmadnessed >= 1)
            {
                List<Minion> ownm = (ownturn) ? this.ownMinions : this.enemyMinions;
                foreach (Minion m in ownm.ToArray())
                {
                    if (m.shadowmadnessed)
                    {
                        m.shadowmadnessed = false;
                        this.minionGetControlled(m, !m.own, false);
                    }
                }
                this.shadowmadnessed = 0;
                updateBoards();
            }

            this.nextSecretThisTurnCost0 = false;
            this.nextSpellThisTurnCost0 = false;
            this.nextMurlocThisTurnCostHealth = false;
            this.nextSpellThisTurnCostHealth = false;
            this.lockandload = 0;
            this.stampede = 0;
            this.embracetheshadow = 0;
            this.playedPreparation = false;

            foreach (Minion m in this.ownMinions)
            {
                this.minionGetTempBuff(m, -m.tempAttack, 0);
                m.immune = false;
                m.cantLowerHPbelowONE = false;
            }
            foreach (Minion m in this.enemyMinions)
            {
                this.minionGetTempBuff(m, -m.tempAttack, 0);
                m.immune = false;
                m.cantLowerHPbelowONE = false;
            }
            if (this.anzOwnMalGanis < 1) this.ownHero.immune = false;
            if (this.anzEnemyMalGanis < 1) this.enemyHero.immune = false;
            this.ownWeapon.immune = false;
            this.enemyWeapon.immune = false;
        }


        public void triggerStartTurn(bool ownturn)
        {
            if (this.diedMinions != null)
            {
                this.ownMinionsDiedTurn = 0;
                this.enemyMinionsDiedTurn = 0;
                if (!this.print) this.diedMinions.Clear(); //contains only the minions that died in this turn!
            }

            List<Minion> ownm = (ownturn) ? this.ownMinions : this.enemyMinions;
            foreach (Minion m in ownm.ToArray())
            {
                m.playedPrevTurn = m.playedThisTurn;
                m.playedThisTurn = false;
                m.numAttacksThisTurn = 0;
                m.justBuffed = 0;
                m.updateReadyness();

                if (m.conceal)
                {
                    m.conceal = false;
                    m.stealth = false;
                }

                if (!m.silenced)
                {
                    m.handcard.card.sim_card.onTurnStartTrigger(this, m, ownturn);
                }
                if (ownturn && m.destroyOnOwnTurnStart) this.minionGetDestroyed(m);
                if (!ownturn && m.destroyOnEnemyTurnStart) this.minionGetDestroyed(m);
            }

            List<Minion> enemm = (ownturn) ? this.enemyMinions : this.ownMinions;
            foreach (Minion m in enemm.ToArray())
            {
                m.frozen = false;
                m.justBuffed = 0;
                if (!m.silenced)
                {
                    if (m.name == CardDB.cardName.micromachine) m.handcard.card.sim_card.onTurnStartTrigger(this, m, ownturn);
                }
                if (ownturn && m.destroyOnOwnTurnStart) this.minionGetDestroyed(m);
                if (!ownturn && m.destroyOnEnemyTurnStart) this.minionGetDestroyed(m);
                if (m.changeOwnerOnTurnStart) this.minionGetControlled(m, ownturn, true);
            }

            Minion hero;
            Handmanager.Handcard ab;
            if (ownturn)
            {
                hero = this.ownHero;
                ab = this.ownHeroAblility;
            }
            else
            {
                hero = this.enemyHero;
                ab = this.enemyHeroAblility;
            }
            if (hero.conceal)
            {
                hero.conceal = false;
                hero.stealth = false;
            }
            if (ab.card.name == CardDB.cardName.deathsshadow) ab.card.sim_card.onTurnStartTrigger(this, null, ownturn);

            this.doDmgTriggers();
            this.drawACard(CardDB.cardName.unknown, ownturn);
            this.doDmgTriggers();


            this.cardsPlayedThisTurn = 0;
            this.mobsplayedThisTurn = 0;
            this.nextSecretThisTurnCost0 = false;
            this.nextSpellThisTurnCost0 = false;
            this.nextMurlocThisTurnCostHealth = false;
            this.nextSpellThisTurnCostHealth = false;
            this.optionsPlayedThisTurn = 0;
            this.enemyOptionsDoneThisTurn = 0;
            this.anzUsedOwnHeroPower = 0;
            this.anzUsedEnemyHeroPower = 0;

            if (ownturn)
            {
                this.ownMaxMana = Math.Min(10, this.ownMaxMana + 1);
                this.mana = this.ownMaxMana - this.ueberladung;
                this.lockedMana = this.ueberladung;
                this.ueberladung = 0;

                this.enemyHero.frozen = false;
                this.ownHero.Angr = this.ownWeapon.Angr;
                this.ownHero.numAttacksThisTurn = 0;
                this.ownAbilityReady = true;
                this.ownHero.updateReadyness();
                this.owncarddraw = 0;
            }
            else
            {
                this.enemyMaxMana = Math.Min(10, this.enemyMaxMana + 1);
                this.mana = this.enemyMaxMana; 
                this.ownHero.frozen = false;
                this.enemyHero.Angr = this.enemyWeapon.Angr;
                this.enemyHero.numAttacksThisTurn = 0;
                this.enemyAbilityReady = true;
                this.enemyHero.updateReadyness();
            }


            this.complete = false;
            this.value = int.MinValue;
        }

        public void triggerAHeroGotArmor(bool ownHero)
        {
            foreach (Minion m in ((ownHero) ? this.ownMinions : this.enemyMinions))
            {
                if (m.name == CardDB.cardName.siegeengine && !m.silenced)
                {
                    this.minionGetBuffed(m, 1, 0);
                }
            }
        }

        public void triggerCardsChanged(bool own)
        {
            if (own)
            {
                if (this.tempanzOwnCards >= 6 && this.owncards.Count <= 5)
                {
                    
                    foreach (Minion m in this.enemyMinions)
                    {
                        if (m.name == CardDB.cardName.goblinsapper && !m.silenced)
                        {
                            this.minionGetBuffed(m, -4, 0);
                        }
                    }
                }
                if (this.owncards.Count >= 6 && this.tempanzOwnCards <= 5)
                {
                    
                    foreach (Minion m in this.enemyMinions)
                    {
                        if (m.name == CardDB.cardName.goblinsapper && !m.silenced)
                        {
                            this.minionGetBuffed(m, 4, 0);
                        }
                    }
                }

                this.tempanzOwnCards = this.owncards.Count;
            }
            else
            {
                if (this.tempanzEnemyCards >= 6 && this.enemyAnzCards <= 5)
                {
                    
                    foreach (Minion m in this.ownMinions)
                    {
                        if (m.name == CardDB.cardName.goblinsapper && !m.silenced)
                        {
                            this.minionGetBuffed(m, -4, 0);
                        }
                    }
                }
                if (this.enemyAnzCards >= 6 && this.tempanzEnemyCards <= 5)
                {
                    
                    foreach (Minion m in this.ownMinions)
                    {
                        if (m.name == CardDB.cardName.goblinsapper && !m.silenced)
                        {
                            this.minionGetBuffed(m, 4, 0);
                        }
                    }
                }

                this.tempanzEnemyCards = this.enemyAnzCards;
            }
        }



        public void triggerInspire(bool ownturn)
        {
            foreach (Minion m in this.ownMinions.ToArray())
            {
                if (m.silenced) continue;
                m.handcard.card.sim_card.onInspire(this, m, ownturn);
            }

            foreach (Minion m in this.enemyMinions.ToArray())
            {
                if (m.silenced) continue;
                m.handcard.card.sim_card.onInspire(this, m, ownturn);
            }
        }


        public int secretTrigger_CharIsAttacked(Minion attacker, Minion defender)
        {
            int newTarget = 0;
            int triggered = 0;
            if (this.isOwnTurn && this.enemySecretCount >= 1)
            {
                if (defender.isHero && !defender.own)
                {
                    foreach (SecretItem si in this.enemySecretList)
                    {
                        bool needDamageTrigger = false;

                        if (si.canBe_explosive)
                        {
                            triggered++;
                            foreach (SecretItem sii in this.enemySecretList)
                            {
                                sii.canBe_explosive = false;
                            }
                            CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_610).sim_card.onSecretPlay(this, false, 0);
                            needDamageTrigger = true;
                        }

                        if (si.canBe_beartrap)
                        {
                            triggered++;
                            foreach (SecretItem sii in this.enemySecretList)
                            {
                                sii.canBe_beartrap = false;
                            }
                            CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.AT_060).sim_card.onSecretPlay(this, false, 0);
                            needDamageTrigger = true;
                        }

                        if (!attacker.isHero && si.canBe_vaporize)
                        {
                            triggered++;
                            foreach (SecretItem sii in this.enemySecretList)
                            {
                                sii.canBe_vaporize = false;
                            }
                            CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_594).sim_card.onSecretPlay(this, false, attacker, 0);
                            needDamageTrigger = true;
                        }

                        if (si.canBe_missdirection)
                        {
                            if (!(attacker.isHero && this.ownMinions.Count + this.enemyMinions.Count == 0))
                            {
                                triggered++;
                                foreach (SecretItem sii in this.enemySecretList)
                                {
                                    sii.canBe_missdirection = false;
                                }
                                CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_533).sim_card.onSecretPlay(this, false, attacker, defender, out newTarget);
                                //no needDamageTrigger
                            }
                        }

                        if (si.canBe_icebarrier)
                        {
                            triggered++;
                            foreach (SecretItem sii in this.enemySecretList)
                            {
                                sii.canBe_icebarrier = false;
                            }
                            CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_289).sim_card.onSecretPlay(this, false, defender, 0);
                        }

                        if (needDamageTrigger) doDmgTriggers();
                    }
                }

                if (!defender.isHero && !defender.own)
                {
                    foreach (SecretItem si in this.enemySecretList)
                    {
                        if (si.canBe_snaketrap)
                        {
                            triggered++;
                            foreach (SecretItem sii in this.enemySecretList)
                            {
                                sii.canBe_snaketrap = false;
                            }
                            CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_554).sim_card.onSecretPlay(this, false, 0);
                            doDmgTriggers();
                        }
                    }
                }

                if (!attacker.isHero && attacker.own) // minion attacks
                {
                    foreach (SecretItem si in this.enemySecretList)
                    {
                        if (si.canBe_freezing)
                        {
                            triggered++;
                            foreach (SecretItem sii in this.enemySecretList)
                            {
                                sii.canBe_freezing = false;
                            }
                            CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_611).sim_card.onSecretPlay(this, false, attacker, 0);
                        }
                    }
                }

                foreach (SecretItem si in this.enemySecretList)
                {
                    if (si.canBe_noblesacrifice)
                    {
                        triggered++;
                        foreach (SecretItem sii in this.enemySecretList)
                        {
                            sii.canBe_noblesacrifice = false;
                        }
                        bool ishero = defender.isHero;
                        si.usedTrigger_CharIsAttacked(ishero, attacker.isHero);
                        CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_130).sim_card.onSecretPlay(this, false, attacker, defender, out newTarget);
                        //no needDamageTrigger
                    }
                }
            }

            if (turnCounter == 0)
            {
                this.evaluatePenality -= triggered * 50;
            }

            return newTarget;
        }

        public void secretTrigger_HeroGotDmg(bool own, int dmg)
        {
            int triggered = 0;
            if (own != this.isOwnTurn)
            {
                if (this.isOwnTurn && this.enemySecretCount >= 1)
                {
                    foreach (SecretItem si in this.enemySecretList)
                    {
                        if (si.canBe_eyeforaneye)
                        {
                            triggered++;
                            foreach (SecretItem sii in this.enemySecretList)
                            {
                                sii.canBe_eyeforaneye = false;
                            }
                            CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_132).sim_card.onSecretPlay(this, false, dmg);
                        }

                        if (si.canBe_iceblock && this.enemyHero.Hp <= 0)
                        {
                            triggered++;
                            foreach (SecretItem sii in this.enemySecretList)
                            {
                                sii.canBe_iceblock = false;
                            }
                            CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_295).sim_card.onSecretPlay(this, false, this.enemyHero, dmg);
                        }
                    }
                }
            }

            if (turnCounter == 0)
            {
                this.evaluatePenality -= triggered * 50;
            }

        }

        public void secretTrigger_MinionIsPlayed(Minion playedMinion)
        {
            int triggered = 0;
            if (this.isOwnTurn && playedMinion.own && this.enemySecretCount >= 1)
            {
                foreach (SecretItem si in this.enemySecretList.ToArray())
                {
                    bool needDamageTrigger = false;

                    if (si.canBe_mirrorentity)
                    {
                        triggered++;
                        foreach (SecretItem sii in this.enemySecretList)
                        {
                            sii.canBe_mirrorentity = false;
                        }
                        CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_294).sim_card.onSecretPlay(this, false, playedMinion, 0);
                        needDamageTrigger = true;
                    }

                    if (si.canBe_repentance)
                    {
                        triggered++;
                        foreach (SecretItem sii in this.enemySecretList)
                        {
                            sii.canBe_repentance = false;
                        }
                        CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_379).sim_card.onSecretPlay(this, false, playedMinion, 0);
                    }

                    if (si.canBe_sacredtrial && this.ownMinions.Count > 3)
                    {
                        triggered++;
                        foreach (SecretItem sii in this.enemySecretList)
                        {
                            sii.canBe_sacredtrial = false;
                            sii.canBe_snipe = false;
                        }
                        CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.LOE_027).sim_card.onSecretPlay(this, false, playedMinion, 0);
                        needDamageTrigger = true;
                    }
                    else if (si.canBe_snipe)
                    {
                        triggered++;
                        foreach (SecretItem sii in this.enemySecretList)
                        {
                            sii.canBe_snipe = false;
                        }
                        CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_609).sim_card.onSecretPlay(this, false, playedMinion, 0);
                        needDamageTrigger = true;
                    }

                    if (needDamageTrigger) doDmgTriggers();
                }
            }

            if (turnCounter == 0)
            {
                this.evaluatePenality -= triggered * 50;
            }

        }

        public int secretTrigger_SpellIsPlayed(Minion target, CardDB.Card c)
        {
            int triggered = 0;
            int retval = 0;
            bool isSpell = (c.type == CardDB.cardtype.SPELL);
            if (this.isOwnTurn && isSpell && this.enemySecretCount > 0) //actual secrets need a spell played!
            {
                foreach (SecretItem si in this.enemySecretList)
                {

                    if (si.canBe_counterspell)
                    {
                        triggered++;
                        // dont use spell!
                        foreach (SecretItem sii in this.enemySecretList)
                        {
                            sii.canBe_counterspell = false;
                        }

                        if (target != null && target.own && prozis.penman.maycauseharmDatabase.ContainsKey(c.name)) this.evaluatePenality += 15;

                        if (turnCounter == 0)
                        {
                            this.evaluatePenality -= triggered * 50;
                        }
                        return -2;//spellbender will NEVER trigger
                    }
                }

                foreach (SecretItem si in this.enemySecretList)
                {
                    if (si.canBe_cattrick)
                    {
                        triggered++;
                        foreach (SecretItem sii in this.enemySecretList)
                        {
                            sii.canBe_cattrick = false;
                        }
                        CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.KAR_004).sim_card.onSecretPlay(this, false, 0);
                        doDmgTriggers();
                    }

                    if (si.canBe_spellbender && target != null && !target.isHero)
                    {
                        triggered++;
                        foreach (SecretItem sii in this.enemySecretList)
                        {
                            sii.canBe_spellbender = false;
                        }
                        if (target.own && prozis.penman.maycauseharmDatabase.ContainsKey(c.name)) { }
                        else CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.tt_010).sim_card.onSecretPlay(this, false, null, target, out retval);
                    }
                }

            }

            if (turnCounter == 0)
            {
                this.evaluatePenality -= triggered * 50;
            }

            return retval; // the new target

        }

        public void secretTrigger_MinionDied(bool own)
        {
            int triggered = 0;

            if (this.isOwnTurn && !own && this.enemySecretCount >= 1)
            {

                foreach (SecretItem si in this.enemySecretList)
                {
                    if (si.canBe_duplicate)
                    {
                        triggered++;
                        foreach (SecretItem sii in this.enemySecretList)
                        {
                            sii.canBe_duplicate = false;
                        }
                        CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.FP1_018).sim_card.onSecretPlay(this, false, 0);
                    }

                    if (si.canBe_redemption)
                    {
                        triggered++;
                        foreach (SecretItem sii in this.enemySecretList)
                        {
                            sii.canBe_redemption = false;
                        }
                        CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_136).sim_card.onSecretPlay(this, false, 0);
                    }

                    if (si.canBe_avenge)
                    {
                        triggered++;
                        foreach (SecretItem sii in this.enemySecretList)
                        {
                            sii.canBe_avenge = false;
                        }
                        CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.FP1_020).sim_card.onSecretPlay(this, false, 0);
                    }
                }
            }

            if (turnCounter == 0)
            {
                this.evaluatePenality -= triggered * 50;
            }

        }

        public void secretTrigger_HeroPowerUsed()
        {
            int triggered = 0;
            if (this.isOwnTurn && this.enemySecretCount >= 1)
            {
                foreach (SecretItem si in this.enemySecretList)
                {
                    if (si.canBe_darttrap)
                    {
                        triggered++;
                        foreach (SecretItem sii in this.enemySecretList)
                        {
                            sii.canBe_darttrap = false;
                        }
                        CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.LOE_021).sim_card.onSecretPlay(this, false, 0);
                        doDmgTriggers();
                    }
                }
            }

            if (turnCounter == 0)
            {
                this.evaluatePenality -= triggered * 50;
            }
        }


        public int getSecretTriggersByType(int type, bool actedMinionOwn, bool actedMinionIsHero,  Minion target)
        {
            
            
            
            
            
            
            int triggered = 0;
            bool isSpell = false;

            switch (type)
            {
                case 0: 
                    if (this.isOwnTurn && actedMinionOwn && this.enemySecretCount >= 1)
                    {
                        bool canBe_mirrorentity = false;
                        bool canBe_repentance = false;
                        bool canBe_sacredtrial = false;
                        bool canBe_snipe = false;
                        foreach (SecretItem si in this.enemySecretList.ToArray())
                        {
                            if (si.canBe_mirrorentity && !canBe_mirrorentity) { canBe_mirrorentity = true; triggered++; }
                            if (si.canBe_repentance && !canBe_repentance) { canBe_repentance = true; triggered++; }
                            if (si.canBe_sacredtrial && this.ownMinions.Count > 3 && !canBe_sacredtrial) { canBe_sacredtrial = true; canBe_snipe = true; triggered++; }
                            else if (si.canBe_snipe && !canBe_snipe) { canBe_snipe = true; triggered++; }
                        }
                    }
                    break;

                case 1: 
                    if (this.isOwnTurn && isSpell && this.enemySecretCount >= 1)
                    {
                        bool canBe_counterspell = false;
                        bool canBe_spellbender = false;
                        bool canBe_cattrick = false;
                        foreach (SecretItem si in this.enemySecretList)
                        {
                            if (si.canBe_counterspell && !canBe_counterspell) return 1;
                            if (si.canBe_spellbender && target != null && !target.isHero && !canBe_spellbender) { canBe_spellbender = true; triggered++; }
                            if (si.canBe_cattrick && !canBe_cattrick) { canBe_cattrick = true; triggered++; }
                        }
                    }
                    break;

                case 2: 
                    if (this.isOwnTurn && this.enemySecretCount >= 1)
                    {
                        if (target.isHero && !target.own)
                        {
                            bool canBe_explosive = false;
                            bool canBe_beartrap = false;
                            bool canBe_vaporize = false;
                            bool canBe_missdirection = false;
                            bool canBe_icebarrier = false;
                            foreach (SecretItem si in this.enemySecretList)
                            {
                                if (si.canBe_explosive && !canBe_explosive) { canBe_explosive = true; triggered++; }
                                if (si.canBe_beartrap && !canBe_beartrap) { canBe_beartrap = true; triggered++; }
                                if (!actedMinionIsHero && si.canBe_vaporize && !canBe_vaporize) { canBe_vaporize = true; triggered++; }
                                if (si.canBe_missdirection && !canBe_missdirection)
                                {
                                    if (!(actedMinionIsHero && this.ownMinions.Count + this.enemyMinions.Count == 0))
                                    {
                                        canBe_missdirection = true;
                                        triggered++;
                                    }
                                }
                                if (si.canBe_icebarrier && !canBe_icebarrier) { canBe_icebarrier = true; triggered++; }
                            }
                        }

                        if (!target.isHero && !target.own)
                        {
                            bool canBe_snaketrap = false;
                            foreach (SecretItem si in this.enemySecretList)
                            {
                                if (si.canBe_snaketrap && !canBe_snaketrap) { canBe_snaketrap = true; triggered++; }
                            }
                        }

                        if (!actedMinionIsHero && actedMinionOwn) // minion attacks
                        {
                            bool canBe_freezing = false;
                            foreach (SecretItem si in this.enemySecretList)
                            {
                                if (si.canBe_freezing && !canBe_freezing) { canBe_freezing = true; triggered++; }
                            }
                        }

                        bool canBe_noblesacrifice = false;
                        foreach (SecretItem si in this.enemySecretList)
                        {
                            if (si.canBe_noblesacrifice && !canBe_noblesacrifice) { canBe_noblesacrifice = true; triggered++; }
                        }
                    }
                    break;

                case 3: 
                    if (target.own != this.isOwnTurn)
                    {
                        if (this.isOwnTurn && this.enemySecretCount >= 1)
                        {
                            bool canBe_eyeforaneye = false;
                            bool canBe_iceblock = false;
                            foreach (SecretItem si in this.enemySecretList)
                            {
                                if (si.canBe_eyeforaneye && !canBe_eyeforaneye) { canBe_eyeforaneye = true; triggered++; }
                                if (si.canBe_iceblock && this.enemyHero.Hp <= 0 && !canBe_iceblock) { canBe_iceblock = true; triggered++; }
                            }
                        }
                    }
                    break;

                case 4: 
                    if (this.isOwnTurn && !target.own && this.enemySecretCount >= 1)
                    {
                        bool canBe_duplicate = false;
                        bool canBe_redemption = false;
                        bool canBe_avenge = false;
                        foreach (SecretItem si in this.enemySecretList)
                        {
                            if (si.canBe_duplicate && !canBe_duplicate) { canBe_duplicate = true; triggered++; }
                            if (si.canBe_redemption && !canBe_redemption) { canBe_redemption = true; triggered++; }
                            if (si.canBe_avenge && !canBe_avenge) { canBe_avenge = true; triggered++; }
                        }
                    }
                    break;

                case 5: 
                    if (this.isOwnTurn && this.enemySecretCount >= 1)
                    {
                        bool canBe_darttrap = false;
                        foreach (SecretItem si in this.enemySecretList)
                        {
                            if (si.canBe_darttrap && !canBe_darttrap) { canBe_darttrap = true; triggered++; }
                        }
                    }
                    break;
            }
            return triggered;
        }

        public void doDeathrattles(List<Minion> deathrattleMinions)
        {
            //todo sort them from oldest to newest (first played, first deathrattle)
            //https://www.youtube.com/watch?v=2WrbqsOSbhc
            foreach (Minion m in deathrattleMinions)
            {
                if (!m.silenced && m.handcard.card.deathrattle) m.handcard.card.sim_card.onDeathrattle(this, m);

                if (m.explorershat > 0)
                {
                    for (int i = 0; i < m.explorershat; i++)
                    {
                        drawACard(CardDB.cardName.explorershat, m.own, true);
                    }
                }

                if (m.returnToHand > 0)
                {
                    drawACard(m.handcard.card.cardIDenum, m.own, true);
                }
                
                if (m.infest > 0)
                {
                    for (int i = 0; i < m.infest; i++)
                    {
                        drawACard(CardDB.cardName.rivercrocolisk, m.own, true);
                    }
                }

                if (m.ancestralspirit > 0)
                {
                    for (int i = 0; i < m.ancestralspirit; i++)
                    {
                        CardDB.Card kid = m.handcard.card;
                        int pos = (m.own) ? this.ownMinions.Count : this.enemyMinions.Count;
                        callKid(kid, pos, m.own, false, true);
                    }
                }

                if (m.desperatestand > 0)
                {
                    for (int i = 0; i < m.desperatestand; i++)
                    {
                        CardDB.Card kid = m.handcard.card;
                        List<Minion> tmp = (m.own) ? this.ownMinions : this.enemyMinions;
                        int pos = tmp.Count;
                        callKid(kid, pos, m.own, false, true);

                        if (tmp.Count >= 1)
                        {
                            Minion summonedMinion = tmp[pos];
                            if (summonedMinion.handcard.card.cardIDenum == kid.cardIDenum)
                            {
                                summonedMinion.Hp = 1;
                                summonedMinion.wounded = false;
                                if (summonedMinion.Hp < summonedMinion.maxHp) summonedMinion.wounded = true;
                            }
                        }
                    }
                }

                for (int i = 0; i < m.souloftheforest; i++)
                {
                    CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_158t);//Treant
                    int pos = (m.own) ? this.ownMinions.Count : this.enemyMinions.Count;
                    callKid(kid, pos, m.own, false, true);
                }
                
                for (int i = 0; i < m.stegodon; i++)
                {
                    CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.UNG_810);//Stegodon
                    int pos = (m.own) ? this.ownMinions.Count : this.enemyMinions.Count;
                    callKid(kid, pos, m.own, false, true);
                }

                for (int i = 0; i < m.livingspores; i++)
                {
                    CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.UNG_999t2t1);//Plant
                    int pos = (m.own) ? this.ownMinions.Count : this.enemyMinions.Count;
                    callKid(kid, pos, m.own, false, true);
                    callKid(kid, pos, m.own, false, true);
                }

                if (m.deathrattle2 != null) m.deathrattle2.sim_card.onDeathrattle(this, m);

                //baron rivendare ??
                if ((m.own && this.ownBaronRivendare >= 1) || (!m.own && this.enemyBaronRivendare >= 1))
                {
                    int r = (m.own) ? this.ownBaronRivendare : this.enemyBaronRivendare;
                    for (int j = 0; j < r; j++)
                    {
                        if (!m.silenced && m.handcard.card.deathrattle) m.handcard.card.sim_card.onDeathrattle(this, m);

                        if (m.explorershat > 0)
                        {
                            for (int i = 0; i < m.explorershat; i++)
                            {
                                drawACard(CardDB.cardName.explorershat, m.own, true);
                            }
                        }

                        if (m.returnToHand > 0)
                        {
                            drawACard(m.handcard.card.cardIDenum, m.own, true);
                        }

                        if (m.infest > 0)
                        {
                            for (int i = 0; i < m.infest; i++)
                            {
                                drawACard(CardDB.cardName.rivercrocolisk, m.own, true);
                            }
                        }

                        if (m.ancestralspirit > 0)
                        {
                            for (int i = 0; i < m.ancestralspirit; i++)
                            {
                                CardDB.Card kid = m.handcard.card;
                                int pos = (m.own) ? this.ownMinions.Count : this.enemyMinions.Count;
                                callKid(kid, pos, m.own); //because baron rivendare
                            }
                        }
                        
                        if (m.desperatestand > 0)
                        {
                            for (int i = 0; i < m.desperatestand; i++)
                            {
                                CardDB.Card kid = m.handcard.card;
                                List<Minion> tmp = (m.own) ? this.ownMinions : this.enemyMinions;
                                int pos = tmp.Count;
                                callKid(kid, pos, m.own, false, true);

                                if (tmp.Count >= 1)
                                {
                                    Minion summonedMinion = tmp[pos];
                                    if (summonedMinion.handcard.card.cardIDenum == kid.cardIDenum)
                                    {
                                        summonedMinion.Hp = 1;
                                        summonedMinion.wounded = false;
                                        if (summonedMinion.Hp < summonedMinion.maxHp) summonedMinion.wounded = true;
                                    }
                                }
                            }
                        }

                        for (int i = 0; i < m.souloftheforest; i++)
                        {
                            CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_158t);//Treant
                            int pos = (m.own) ? this.ownMinions.Count : this.enemyMinions.Count;
                            callKid(kid, pos, m.own); //because baron rivendare
                        }

                        for (int i = 0; i < m.stegodon; i++)
                        {
                            CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.UNG_810);//Stegodon
                            int pos = (m.own) ? this.ownMinions.Count : this.enemyMinions.Count;
                            callKid(kid, pos, m.own);  //because baron rivendare
                        }

                        for (int i = 0; i < m.livingspores; i++)
                        {
                            CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.UNG_999t2t1);//Plant
                            int pos = (m.own) ? this.ownMinions.Count : this.enemyMinions.Count;
                            callKid(kid, pos, m.own);
                            callKid(kid, pos, m.own);  //because baron rivendare
                        }

                        if (m.deathrattle2 != null) m.deathrattle2.sim_card.onDeathrattle(this, m);
                    }
                }
            }
        }


        public void updateBoards()
        {
            if (!this.tempTrigger.ownMinionsChanged && !this.tempTrigger.enemyMininsChanged) return;
            List<Minion> deathrattleMinions = new List<Minion>();

            bool minionOwnReviving = false;
            bool minionEnemyReviving = false;

            if (this.tempTrigger.ownMinionsChanged)
            {
                this.tempTrigger.ownMinionsChanged = false;
                List<Minion> temp = new List<Minion>();
                int i = 1;
                foreach (Minion m in this.ownMinions)
                {
                    //delete adjacent buffs
                    this.minionGetAdjacentBuff(m, -m.AdjacentAngr, 0);
                    m.cantBeTargetedBySpellsOrHeroPowers = false;

                    //kill it!
                    if (m.Hp <= 0)
                    {
                        this.OwnLastDiedMinion = m.handcard.card.cardIDenum;
                        if (this.revivingOwnMinion == CardDB.cardIDEnum.None)
                        {
                            this.revivingOwnMinion = m.handcard.card.cardIDenum;
                            minionOwnReviving = true;
                        }

                        if ((!m.silenced && m.handcard.card.deathrattle) || m.ancestralspirit >= 1 || m.desperatestand >= 1 || m.souloftheforest >= 1 || m.stegodon >= 1 || m.livingspores >= 1 || m.infest >= 1 || m.explorershat >= 1 || m.returnToHand >= 1 || m.deathrattle2 != null)
                        {
                            deathrattleMinions.Add(m);
                        }

                        // end aura of minion m
                        if (!m.silenced) m.handcard.card.sim_card.onAuraEnds(this, m);
                    }
                    else
                    {
                        m.zonepos = i;
                        temp.Add(m);
                        i++;
                    }

                }
                this.ownMinions = temp;
                this.updateAdjacentBuffs(true);
            }

            if (this.tempTrigger.enemyMininsChanged)
            {
                this.tempTrigger.enemyMininsChanged = false;
                List<Minion> temp = new List<Minion>();
                int i = 1;
                foreach (Minion m in this.enemyMinions)
                {
                    //delete adjacent buffs
                    this.minionGetAdjacentBuff(m, -m.AdjacentAngr, 0);
                    m.cantBeTargetedBySpellsOrHeroPowers = false;

                    //kill it!
                    if (m.Hp <= 0)
                    {
                        if (this.revivingEnemyMinion == CardDB.cardIDEnum.None)
                        {
                            this.revivingEnemyMinion = m.handcard.card.cardIDenum;
                            minionEnemyReviving = true;
                        }

                        if ((!m.silenced && m.handcard.card.deathrattle) || m.ancestralspirit >= 1 || m.desperatestand >= 1 || m.souloftheforest >= 1 || m.stegodon >= 1 || m.livingspores >= 1 || m.infest >= 1 || m.explorershat >= 1 || m.returnToHand >= 1 || m.deathrattle2 != null)
                        {
                            deathrattleMinions.Add(m);
                        }

                        // end aura of minion m
                        if (!m.silenced) m.handcard.card.sim_card.onAuraEnds(this, m);
                    }
                    else
                    {
                        m.zonepos = i;
                        temp.Add(m);
                        i++;
                    }

                }
                this.enemyMinions = temp;
                this.updateAdjacentBuffs(false);
            }

            if (this.ownWeapon.name == CardDB.cardName.spiritclaws)
            {
                int dif = 0;
                if (this.spellpower > 0) dif += 2;
                if (this.spellpowerStarted > 0) dif -=2;
                if (dif > 0)
                {
                    if (!this.ownSpiritclaws)
                    {
                        this.minionGetBuffed(this.ownHero, 2, 0);
                        this.ownWeapon.Angr += 2;
                        this.ownSpiritclaws = true;
                    }
                }
                else if (dif < 0)
                {
                    if (this.ownSpiritclaws)
                    {
                        this.minionGetBuffed(this.ownHero, -2, 0);
                        this.ownWeapon.Angr -= 2;
                        this.ownSpiritclaws = false;
                    }
                }
            }
            if (this.enemyWeapon.name == CardDB.cardName.spiritclaws)
            {
                int dif = 0;
                if (this.enemyspellpower > 0) dif += 2;
                if (this.enemyspellpowerStarted > 0) dif -= 2;
                if (dif > 0)
                {
                    if (!this.enemySpiritclaws)
                    {
                        this.minionGetBuffed(this.enemyHero, 2, 0);
                        this.enemyWeapon.Angr += 2;
                        this.enemySpiritclaws = true;
                    }
                }
                else
                {
                    if (this.enemySpiritclaws)
                    {
                        this.minionGetBuffed(this.enemyHero, -2, 0);
                        this.enemyWeapon.Angr -= 2;
                        this.enemySpiritclaws = false;
                    }
                }
            }


            if (deathrattleMinions.Count >= 1) this.doDeathrattles(deathrattleMinions);

            if (minionOwnReviving)
            {
                this.secretTrigger_MinionDied(true);
                this.revivingOwnMinion = CardDB.cardIDEnum.None;
            }

            if (minionEnemyReviving)
            {
                this.secretTrigger_MinionDied(false);
                this.revivingEnemyMinion = CardDB.cardIDEnum.None;
            }
            //update buffs
        }

        public void minionGetOrEraseAllAreaBuffs(Minion m, bool get)
        {
            if (m.isHero) return;
            int angr = 0;
            int vert = 0;

            if (!m.silenced) // if they are not silenced, these minions will give a buff, but cant buff themselfes
            {
                switch (m.name)
                {
                    case CardDB.cardName.raidleader: angr--; break;
                    case CardDB.cardName.leokk: angr--; break;
                    case CardDB.cardName.timberwolf: angr--; break;
                    case CardDB.cardName.stormwindchampion:
                        angr--;
                        vert--;
                        break;
                    case CardDB.cardName.southseacaptain:
                        angr--;
                        vert--;
                        break;
                    case CardDB.cardName.grimscaleoracle:
                        angr--;
                        break;
                    case CardDB.cardName.murlocwarleader:
                        if (get)
                        {
                            angr -= 2;
                        }
                        break;
                }
            }

            if (m.handcard.card.race == 14)
            {
                if (m.own)
                {
                    angr += 2 * anzOwnMurlocWarleader + anzOwnGrimscaleOracle;
                }
                else
                {
                    angr += 2 * anzEnemyMurlocWarleader + anzEnemyGrimscaleOracle;
                }
            }
            if (m.own)
            {
                angr += anzOwnRaidleader;
                angr += anzOwnStormwindChamps;
                vert += anzOwnStormwindChamps;
                if (m.name == CardDB.cardName.silverhandrecruit) angr += anzOwnWarhorseTrainer;
                if (m.handcard.card.race == 20)
                {
                    angr += anzOwnTimberWolfs;
                    if (get) m.charge += anzOwnTundrarhino;
                    else m.charge -= anzOwnTundrarhino;
                }
                if (m.handcard.card.race == 23)
                {
                    angr += anzOwnSouthseacaptain;
                    vert += anzOwnSouthseacaptain;

                }
                if (m.handcard.card.race == 15)
                {
                    angr += anzOwnMalGanis * 2;
                    vert += anzOwnMalGanis * 2;

                }

            }
            else
            {
                angr += anzEnemyRaidleader;
                angr += anzEnemyStormwindChamps;
                vert += anzEnemyStormwindChamps;

                if (m.name == CardDB.cardName.silverhandrecruit) angr += anzEnemyWarhorseTrainer;
                if (m.handcard.card.race == 20)
                {
                    angr += anzEnemyTimberWolfs;
                    if (get) m.charge += anzEnemyTundrarhino;
                    else m.charge -= anzEnemyTundrarhino;
                }
                if (m.handcard.card.race == 23)
                {
                    angr += anzEnemySouthseacaptain;
                    vert += anzEnemySouthseacaptain;
                }
                if (m.handcard.card.race == 15)
                {
                    angr += anzEnemyMalGanis * 2;
                    vert += anzEnemyMalGanis * 2;

                }
            }

            if (get) this.minionGetBuffed(m, angr, vert);
            else this.minionGetBuffed(m, -angr, -vert);

        }

        public void updateAdjacentBuffs(bool own)
        {
            //only call this after update board
            List<Minion> temp = own ? this.ownMinions : this.enemyMinions;

            int anz = temp.Count;
            for (int i = 0; i < anz; i++)
            {
                Minion m = temp[i];
                if (!m.silenced)
                {
                    switch (m.name)
                    {
                        case CardDB.cardName.faeriedragon: m.cantBeTargetedBySpellsOrHeroPowers = true; continue;
                        case CardDB.cardName.spectralknight: m.cantBeTargetedBySpellsOrHeroPowers = true; continue;
                        case CardDB.cardName.laughingsister: m.cantBeTargetedBySpellsOrHeroPowers = true; continue;
                        case CardDB.cardName.soggoththeslitherer: m.cantBeTargetedBySpellsOrHeroPowers = true; continue;
                        case CardDB.cardName.arcanenullifierx21: m.cantBeTargetedBySpellsOrHeroPowers = true; continue;
                        case CardDB.cardName.weespellstopper:
                            if (i > 0) temp[i - 1].cantBeTargetedBySpellsOrHeroPowers = true;
                            if (i < anz - 1) temp[i + 1].cantBeTargetedBySpellsOrHeroPowers = true;
                            continue;
                        case CardDB.cardName.direwolfalpha:
                            if (i > 0) this.minionGetAdjacentBuff(temp[i - 1], 1, 0);
                            if (i < anz - 1) this.minionGetAdjacentBuff(temp[i + 1], 1, 0);
                            continue;
                        case CardDB.cardName.flametonguetotem:
                            if (i > 0) this.minionGetAdjacentBuff(temp[i - 1], 2, 0);
                            if (i < anz - 1) this.minionGetAdjacentBuff(temp[i + 1], 2, 0);
                            continue;
                    }
                }
            }
        }

        public Minion createNewMinion(Handmanager.Handcard hc, int zonepos, bool own)
        {
            Minion m = new Minion();
            Handmanager.Handcard handc = new Handmanager.Handcard(hc);
            m.handcard = handc;
            m.own = own;
            m.isHero = false;
            m.entitiyID = hc.entity;
            if (this.ownCrystalCore > 0)
            {
                m.Angr = ownCrystalCore;
                m.Hp = ownCrystalCore;
                m.maxHp = ownCrystalCore;
            }
            else
            {
                m.Angr = hc.card.Attack + hc.addattack;
                m.Hp = hc.card.Health + hc.addHp;
                m.maxHp = hc.card.Health;
            }

            hc.addattack = 0;
            hc.addHp = 0;

            m.name = hc.card.name;
            m.playedThisTurn = true;
            m.numAttacksThisTurn = 0;
            m.zonepos = zonepos;
            m.windfury = hc.card.windfury;
            m.taunt = hc.card.tank;
            m.charge = (hc.card.Charge) ? 1 : 0;
            m.divineshild = hc.card.Shield;
            m.poisonous = hc.card.poisonous;
            m.lifesteal = hc.card.lifesteal;
            if (this.prozis.ownElementalsHaveLifesteal > 0 && (TAG_RACE)m.handcard.card.race == TAG_RACE.ELEMENTAL) m.lifesteal = true;
            m.stealth = hc.card.Stealth;
            m.untouchable = hc.card.untouchable;

            switch (m.name)
            {
                case CardDB.cardName.lightspawn:
                    m.Angr = m.Hp;
                    break;
            }
            m.updateReadyness();

            if (m.name == CardDB.cardName.lightspawn)
            {
                m.Angr = m.Hp;
            }

            if (own) m.synergy = prozis.penman.getClassRacePriorityPenality(this.ownHeroStartClass, (TAG_RACE)m.handcard.card.race);
            else m.synergy = prozis.penman.getClassRacePriorityPenality(this.enemyHeroStartClass, (TAG_RACE)m.handcard.card.race);
            if (m.synergy > 0 && hc.card.Stealth) m.synergy++;

            //trigger on summon effect!
            this.triggerAMinionIsSummoned(m);
            //activate onAura effect
            m.handcard.card.sim_card.onAuraStarts(this, m);
            //buffs minion
            this.minionGetOrEraseAllAreaBuffs(m, true);
            return m;
        }

        public void placeAmobSomewhere(Handmanager.Handcard hc, int choice, int zonepos)
        {
            int mobplace = zonepos;

            
            Minion m = createNewMinion(hc, mobplace, true);
            m.playedFromHand = true;

            
            addMinionToBattlefield(m);

            //trigger the battlecry!
            m.handcard.card.sim_card.getBattlecryEffect(this, m, hc.target, choice);
            if (this.ownBrannBronzebeard > 0)
            {
                for (int i = 0; i < this.ownBrannBronzebeard; i++)
                {
                    m.handcard.card.sim_card.getBattlecryEffect(this, m, hc.target, choice);
                }
            }
            doDmgTriggers();

            secretTrigger_MinionIsPlayed(m);
            if (this.ownQuest.Id != CardDB.cardIDEnum.None) ownQuest.trigger_MinionWasPlayed(m);

            if (logging) Helpfunctions.Instance.logg("added " + m.handcard.card.name);
        }

        public void addMinionToBattlefield(Minion m, bool isSummon = true)
        {
            List<Minion> temp = (m.own) ? this.ownMinions : this.enemyMinions;
            if (temp.Count >= m.zonepos && m.zonepos >= 1)
            {
                temp.Insert(m.zonepos - 1, m);
            }
            else
            {
                temp.Add(m);
            }
            if (m.own)
            {
                this.tempTrigger.ownMinionsChanged = true;
                if (m.handcard.card.race == 20) this.tempTrigger.ownBeastSummoned++;
            }
            else this.tempTrigger.enemyMininsChanged = true;

            //minion was played secrets? trigger here---- (+ do triggers)

            //trigger a minion was summoned
            triggerAMinionWasSummoned(m);
            doDmgTriggers();

            m.updateReadyness();
        }

        public void equipWeapon(CardDB.Card c, bool own)
        {
            Minion hero = (own) ? this.ownHero : this.enemyHero;
            if (own)
            {
                if (this.ownWeapon.Durability > 0)
                {
                    bool calcLostWeaponDamage = true;
                    switch (c.name)
                    {
                        case CardDB.cardName.poisoneddagger: goto case CardDB.cardName.wickedknife;
                        case CardDB.cardName.wickedknife:
                            if (this.ownWeapon.Angr == c.Attack && this.ownWeapon.Durability < c.Durability) calcLostWeaponDamage = false;
                            break;
                    }
                    if (calcLostWeaponDamage)
                    {
                        this.lostWeaponDamage += this.ownWeapon.Durability * this.ownWeapon.Angr;
                        if (this.ownWeapon.Angr >= c.Attack) this.lostWeaponDamage += 30;
                    }
                    this.lowerWeaponDurability(1000, true);
                }
                this.ownWeapon.equip(c);
            }
            else
            {
                this.lowerWeaponDurability(1000, false);
                this.enemyWeapon.equip(c);
            }

            hero.Angr += c.Attack;
            hero.windfury = c.windfury;
            hero.updateReadyness();
            hero.immuneWhileAttacking = (c.name == CardDB.cardName.gladiatorslongbow);

            List<Minion> temp = (own) ? this.ownMinions : this.enemyMinions;
            foreach (Minion m in temp)
            {
                switch (m.name)
                {
                    case CardDB.cardName.southseadeckhand:
                        if (m.playedThisTurn) minionGetCharge(m);
                        break;
                    case CardDB.cardName.buccaneer:
                        if (own) this.ownWeapon.Angr++;
                        else this.enemyWeapon.Angr++;
                        break;
                    case CardDB.cardName.smalltimebuccaneer:
                        this.minionGetBuffed(m, 2, 0);
                        break;
                }
            }

        }


        
        public void callKid(CardDB.Card c, int zonepos, bool own, bool spawnKid = true, bool oneMoreIsAllowed = false)
        {
            
            int allowed = 7;
            allowed += (oneMoreIsAllowed) ? 1 : 0;

            if (own)
            {
                if (this.ownMinions.Count >= allowed)
                {
                    if (spawnKid) this.evaluatePenality += 10;
                    else this.evaluatePenality += 20;
                    return;
                }
            }
            else
            {
                if (this.enemyMinions.Count >= allowed)
                {
                    if (spawnKid) this.evaluatePenality -= 10;
                    else this.evaluatePenality -= 20;
                    return;
                }
            }
            int mobplace = zonepos + 1;

            //create minion (+triggers)
            Handmanager.Handcard hc = new Handmanager.Handcard(c) { entity = this.getNextEntity() };
            Minion m = createNewMinion(hc, mobplace, own);
            //put it on battle field (+triggers)
            addMinionToBattlefield(m);

        }
        
        public void minionGetFrozen(Minion target)
        {
            target.frozen = true;
            if (target.isHero) return;
            if (this.anzMoorabi > 1)
            {
                foreach (Minion m in this.ownMinions)
                {
                    switch (m.name)
                    {
                        case CardDB.cardName.moorabi:
                            if (m.silenced) continue;
                            this.drawACard(target.handcard.card.name, m.own, true);
                            break;
                    }
                }
                foreach (Minion m in this.enemyMinions)
                {
                    switch (m.name)
                    {
                        case CardDB.cardName.moorabi:
                            if (m.silenced) continue;
                            this.drawACard(target.handcard.card.name, m.own, true);
                            break;
                    }
                }
            }
        }

        public void minionGetSilenced(Minion m)
        {
            //minion cant die due to silencing!
            m.becomeSilence(this);

        }

        public void allMinionsGetSilenced(bool own)
        {
            List<Minion> temp = (own) ? this.ownMinions : this.enemyMinions;
            foreach (Minion m in temp)
            {
                m.becomeSilence(this);
            }
        }

        public void drawACard(CardDB.cardName ss, bool own, bool nopen = false)
        {
            CardDB.cardName s = ss;

            // cant hold more than 10 cards
            if (own)
            {

                if (s == CardDB.cardName.unknown && !nopen) 
                {
                    if (ownDeckSize == 0)
                    {
                        this.ownHeroFatigue++;
                        this.ownHero.getDamageOrHeal(this.ownHeroFatigue, this, false, true);
                        return;
                    }
                    else
                    {
                        this.ownDeckSize--;
                        if (this.owncards.Count >= 10)
                        {
                            this.evaluatePenality += 15;
                            return;
                        }
                        this.owncarddraw++;
                    }

                }
                else
                {
                    if (this.owncards.Count >= 10)
                    {
                        this.evaluatePenality += 5;
                        return;
                    }
                    this.owncarddraw++;

                }


            }
            else
            {
                if (s == CardDB.cardName.unknown && !nopen) 
                {
                    if (enemyDeckSize == 0)
                    {
                        this.enemyHeroFatigue++;
                        this.enemyHero.getDamageOrHeal(this.enemyHeroFatigue, this, false, true);
                        return;
                    }
                    else
                    {
                        this.enemyDeckSize--;
                        if (this.enemyAnzCards >= 10)
                        {
                            this.evaluatePenality -= (this.turnCounter > 2) ? 20 : 50;
                            return;
                        }
                        this.enemycarddraw++;
                        this.enemyAnzCards++;
                    }

                }
                else
                {
                    if (this.enemyAnzCards >= 10)
                    {
                        this.evaluatePenality -= (this.turnCounter > 2) ? 20 : 50;
                        return;
                    }
                    this.enemycarddraw++;
                    this.enemyAnzCards++;
                }
                this.triggerCardsChanged(false);

                if (anzEnemyChromaggus > 0 && s == CardDB.cardName.unknown && !nopen)
                {
                    for (int i = 1; i <= anzEnemyChromaggus; i++)
                    {
                        if (this.enemyAnzCards >= 10)
                        {
                            this.evaluatePenality -= (this.turnCounter > 2) ? 20 : 50;
                            return;
                        }
                        this.enemycarddraw++;
                        this.enemyAnzCards++;
                        this.triggerCardsChanged(false);

                    }
                }
                return;
            }

            if (s == CardDB.cardName.unknown)
            {
                CardDB.Card c = CardDB.Instance.getCardData(s);
                Handmanager.Handcard hc = new Handmanager.Handcard { card = c, position = this.owncards.Count + 1, manacost = 1000, entity = this.getNextEntity() };
                this.owncards.Add(hc);
                this.triggerCardsChanged(true);
            }
            else
            {
                CardDB.Card c = CardDB.Instance.getCardData(s);
                Handmanager.Handcard hc = new Handmanager.Handcard { card = c, position = this.owncards.Count + 1, manacost = c.calculateManaCost(this), entity = this.getNextEntity() };
                this.owncards.Add(hc);
                this.triggerCardsChanged(true);
            }

            if (anzOwnChromaggus > 0 && s == CardDB.cardName.unknown && !nopen) 
            {
                CardDB.Card c = CardDB.Instance.getCardData(s);
                for (int i = 1; i <= anzOwnChromaggus; i++)
                {
                    if (this.owncards.Count >= 10)
                    {
                        this.evaluatePenality += 15;
                        return;
                    }
                    this.owncarddraw++;

                    Handmanager.Handcard hc = new Handmanager.Handcard { card = c, position = this.owncards.Count + 1, manacost = 1000, entity = this.getNextEntity() };
                    this.owncards.Add(hc);
                    this.triggerCardsChanged(true);
                }
            }

        }

        public void drawACard(CardDB.cardIDEnum ss, bool own, bool nopen = false)
        {
            CardDB.cardIDEnum s = ss;

            // cant hold more than 10 cards

            if (own)
            {
                if (s == CardDB.cardIDEnum.None && !nopen) 
                {
                    if (ownDeckSize == 0)
                    {
                        this.ownHeroFatigue++;
                        this.ownHero.getDamageOrHeal(this.ownHeroFatigue, this, false, true);
                        return;
                    }
                    else
                    {
                        this.ownDeckSize--;
                        if (this.owncards.Count >= 10)
                        {
                            this.evaluatePenality += 15;
                            return;
                        }
                        this.owncarddraw++;
                    }

                }
                else
                {
                    if (this.owncards.Count >= 10)
                    {
                        this.evaluatePenality += 5;
                        return;
                    }
                    this.owncarddraw++;
                }
            }
            else
            {
                if (s == CardDB.cardIDEnum.None && !nopen) 
                {
                    if (enemyDeckSize == 0)
                    {
                        this.enemyHeroFatigue++;
                        this.enemyHero.getDamageOrHeal(this.enemyHeroFatigue, this, false, true);
                        return;
                    }
                    else
                    {
                        this.enemyDeckSize--;
                        if (this.enemyAnzCards >= 10)
                        {
                            this.evaluatePenality -= (this.turnCounter > 2) ? 20 : 50;
                            return;
                        }
                        this.enemycarddraw++;
                        this.enemyAnzCards++;
                    }
                }
                else
                {
                    if (this.enemyAnzCards >= 10)
                    {
                        this.evaluatePenality -= (this.turnCounter > 2) ? 20 : 50;
                        return;
                    }
                    this.enemycarddraw++;
                    this.enemyAnzCards++;

                }
                this.triggerCardsChanged(false);

                if (anzEnemyChromaggus > 0 && s == CardDB.cardIDEnum.None && !nopen)
                {
                    for (int i = 1; i <= anzEnemyChromaggus; i++)
                    {
                        if (this.enemyAnzCards >= 10)
                        {
                            this.evaluatePenality -= (this.turnCounter > 2) ? 20 : 50;
                            return;
                        }
                        this.enemycarddraw++;
                        this.enemyAnzCards++;
                        this.triggerCardsChanged(false);
                    }
                }
                return;
            }

            if (s == CardDB.cardIDEnum.None)
            {
                CardDB.Card c = CardDB.Instance.getCardDataFromID(s);
                Handmanager.Handcard hc = new Handmanager.Handcard { card = c, position = this.owncards.Count + 1, manacost = 1000, entity = this.getNextEntity() };
                this.owncards.Add(hc);
                this.triggerCardsChanged(true);
            }
            else
            {
                CardDB.Card c = CardDB.Instance.getCardDataFromID(s);
                Handmanager.Handcard hc = new Handmanager.Handcard { card = c, position = this.owncards.Count + 1, manacost = c.calculateManaCost(this), entity = this.getNextEntity() };
                this.owncards.Add(hc);
                this.triggerCardsChanged(true);
            }

            if (anzOwnChromaggus > 0 && s == CardDB.cardIDEnum.None && !nopen) 
            {
                CardDB.Card c = CardDB.Instance.getCardDataFromID(s);
                for (int i = 1; i <= anzOwnChromaggus; i++)
                {
                    if (this.owncards.Count >= 10)
                    {
                        this.evaluatePenality += 15;
                        return;
                    }
                    this.owncarddraw++;

                    Handmanager.Handcard hc = new Handmanager.Handcard { card = c, position = this.owncards.Count + 1, manacost = 1000, entity = this.getNextEntity() };
                    this.owncards.Add(hc);
                    this.triggerCardsChanged(true);
                }
            }

        }


        public void removeCard(Handmanager.Handcard hcc)
        {
            int cardPos = 1;
            int cardNum = 0;
            Handmanager.Handcard hcTmp = null;
            foreach (Handmanager.Handcard hc in this.owncards)
            {
                if (hc.entity == hcc.entity)
                {
                    hcTmp = hc;
                    cardNum++;
                    continue;
                }
                this.owncards[cardNum].position = cardPos;
                cardNum++;
                cardPos++;
            }
            if (hcTmp != null) this.owncards.Remove(hcTmp);
        }

        public void renumHandCards(List<Handmanager.Handcard> list)
        {
            int count = list.Count;
            for (int i = 0; i < count; i++) list[0].position = i + 1;
        }


        public void attackEnemyHeroWithoutKill(int dmg)
        {
            this.enemyHero.cantLowerHPbelowONE = true;
            this.minionGetDamageOrHeal(this.enemyHero, dmg);
            this.enemyHero.cantLowerHPbelowONE = false;
        }

        public void minionGetDestroyed(Minion m)
        {
            if (m.own)
            {
                if (m.playedThisTurn && m.charge == 0) this.lostDamage += m.Hp * 2 + m.Angr * 2 + (m.windfury ? m.Angr : 0) + ((m.handcard.card.isSpecialMinion && !m.taunt) ? 20 : 0);
            }

            if (m.Hp > 0)
            {
                m.Hp = 0;
                m.minionDied(this);
            }

        }

        public void allMinionsGetDestroyed()
        {
            foreach (Minion m in this.ownMinions)
            {
                minionGetDestroyed(m);
            }
            foreach (Minion m in this.enemyMinions)
            {
                minionGetDestroyed(m);
            }
        }


        public void minionGetArmor(Minion m, int armor)
        {
            m.armor += armor;
            this.triggerAHeroGotArmor(m.own);
        }

        public void minionReturnToHand(Minion m, bool own, int manachange)
        {
            List<Minion> temp = (m.own) ? this.ownMinions : this.enemyMinions;
            m.handcard.card.sim_card.onAuraEnds(this, m);
            temp.Remove(m);

            if (own)
            {
                CardDB.Card c = m.handcard.card;
                Handmanager.Handcard hc = new Handmanager.Handcard { card = c, position = this.owncards.Count + 1, entity = m.entitiyID, manacost = c.calculateManaCost(this) + manachange };
                if (this.owncards.Count < 10)
                {
                    this.owncards.Add(hc);
                    this.triggerCardsChanged(true);
                }
                else this.drawACard(CardDB.cardName.unknown, true);
            }
            else this.drawACard(CardDB.cardName.unknown, false);

            if (m.own) this.tempTrigger.ownMinionsChanged = true;
            else this.tempTrigger.enemyMininsChanged = true;
        }

        public void minionReturnToDeck(Minion m, bool own)
        {
            List<Minion> temp = (m.own) ? this.ownMinions : this.enemyMinions;
            m.handcard.card.sim_card.onAuraEnds(this, m);
            temp.Remove(m);

            if (m.own) this.tempTrigger.ownMinionsChanged = true;
            else this.tempTrigger.enemyMininsChanged = true;

            if (own) this.ownDeckSize++;
            else this.enemyDeckSize++;
        }

        public void minionTransform(Minion m, CardDB.Card c)
        {
            m.handcard.card.sim_card.onAuraEnds(this, m);//end aura of the minion

            Handmanager.Handcard hc = new Handmanager.Handcard(c) { entity = m.entitiyID };
            if ((m.ancestralspirit >= 1 || m.desperatestand >= 1) && !m.own) 
            {
                this.evaluatePenality -= Ai.Instance.botBase.getEnemyMinionValue(m, this) - 1;
            }
            
            if (m.taunt)
            {
                if (m.own) this.anzOwnTaunt--;
                else this.anzEnemyTaunt--;
            }
            m.setMinionToMinion(createNewMinion(hc, m.zonepos, m.own));
            if (m.taunt)
            {
                if (m.own) this.anzOwnTaunt++;
                else this.anzEnemyTaunt++;
            }

            m.handcard.card.sim_card.onAuraStarts(this, m);
            this.minionGetOrEraseAllAreaBuffs(m, true);

            if (m.own)
            {
                this.tempTrigger.ownMinionsChanged = true;
            }
            else
            {
                this.tempTrigger.enemyMininsChanged = true;
            }

            if (logging) Helpfunctions.Instance.logg("minion got sheep" + m.name + " " + m.Angr);
        }

        public CardDB.Card getRandomCardForManaMinion(int manaCost)
        {
            CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.CS2_231); 
            if (manaCost > 0)
            {
                if (manaCost > 10) manaCost = 10;
                switch (manaCost)
                {
                    case 1: kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_011); break; 
                    case 2: kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_131); break; 
                    case 3: kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_134); break; 
                    case 4: kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.GVG_074); break; 
                    case 5: kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.DS1_055); break; 
                    case 6: kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_283); break; 
                    case 7: kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.CS2_088); break; 
                    case 8: kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.NEW1_038); break; 
                    case 9: kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_573); break; 
                    case 10: kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.AT_120); break; 
                }
            }
            return kid;
        }

        public Minion getEnemyCharTargetForRandomSingleDamage(int damage, bool onlyMinions = false)
        {
            Minion target = null;
            int tmp = this.guessingHeroHP;
            this.guessHeroDamage();
            if (this.guessingHeroHP < 0)
            {
                target = this.searchRandomMinionByMaxHP(this.enemyMinions, searchmode.searchHighestAttack, damage); //the last chance (optimistic)
                if ((target == null || this.enemyHero.Hp <= damage) && !onlyMinions) target = this.enemyHero;
            }
            else
            {
                target = this.searchRandomMinion(this.enemyMinions, damage > 3 ? searchmode.searchLowestHP : searchmode.searchHighestHP); //damage the lowest (pessimistic)
                if (target == null && !onlyMinions) target = this.enemyHero;
            }
            this.guessingHeroHP = tmp;
            return target;
        }

        public void minionGetControlled(Minion m, bool newOwner, bool canAttack, bool forced = false)
        {
            List<Minion> newOwnerList = (newOwner) ? this.ownMinions : this.enemyMinions;
            List<Minion> oldOwnerList = (newOwner) ? this.enemyMinions : this.ownMinions;
            bool isFreeSpace = true;

            if (newOwnerList.Count >= 7)
            {
                if (!forced) return;
                else isFreeSpace = false;
            }

            this.tempTrigger.ownMinionsChanged = true;
            this.tempTrigger.enemyMininsChanged = true;
            if (m.taunt)
            {
                if (newOwner)
                {
                    this.anzEnemyTaunt--;
                    if (isFreeSpace) this.anzOwnTaunt++;
                }
                else
                {
                    if (isFreeSpace) this.anzEnemyTaunt++;
                    this.anzOwnTaunt--;
                }
            }

            //end buffs/aura
            m.handcard.card.sim_card.onAuraEnds(this, m);
            this.minionGetOrEraseAllAreaBuffs(m, false);

            //remove minion from list
            oldOwnerList.Remove(m);

            if (isFreeSpace)
            {
                //change site (and minion is played in this turn)
                m.playedThisTurn = true;
                m.own = !m.own;

                // add minion to new list + new buffs
                newOwnerList.Add(m);
                m.handcard.card.sim_card.onAuraStarts(this, m);
                this.minionGetOrEraseAllAreaBuffs(m, true);

                if (m.charge >= 1 || canAttack) // minion can attack if its shadowmadnessed (canAttack = true) or it has charge
                {
                    this.minionGetCharge(m);
                }
                else m.updateReadyness();
            }

        }



        public void minionGetWindfurry(Minion m)
        {
            if (m.windfury) return;
            m.windfury = true;
            m.updateReadyness();
        }

        public void minionGetCharge(Minion m)
        {
            m.charge++;
            m.updateReadyness();
        }

        public void minionLostCharge(Minion m)
        {
            m.charge--;
            m.updateReadyness();
        }



        public void minionGetTempBuff(Minion m, int tempAttack, int tempHp)
        {
            if (!m.silenced && m.name == CardDB.cardName.lightspawn) return;
            if (tempAttack < 0 && -tempAttack > m.Angr)
            {
                tempAttack = -m.Angr;
            }
            m.tempAttack += tempAttack;
            m.Angr += tempAttack;
        }

        public void minionGetAdjacentBuff(Minion m, int angr, int vert)
        {
            if (!m.silenced && m.name == CardDB.cardName.lightspawn) return;
            m.Angr += angr;
            m.AdjacentAngr += angr;
        }

        public void allMinionOfASideGetBuffed(bool own, int attackbuff, int hpbuff)
        {
            List<Minion> temp = (own) ? this.ownMinions : this.enemyMinions;
            foreach (Minion m in temp)
            {
                minionGetBuffed(m, attackbuff, hpbuff);
            }
        }

        public void minionGetBuffed(Minion m, int attackbuff, int hpbuff)
        {
            if (attackbuff != 0) m.Angr = Math.Max(0, m.Angr + attackbuff);

            if (hpbuff != 0)
            {
                if (hpbuff >= 1)
                {
                    m.Hp = m.Hp + hpbuff;
                    m.maxHp = m.maxHp + hpbuff;
                }
                else
                {
                    //debuffing hp, lower only maxhp (unless maxhp < hp)
                    m.maxHp = m.maxHp + hpbuff;
                    if (m.maxHp < m.Hp)
                    {
                        m.Hp = m.maxHp;
                    }
                }
                m.wounded = (m.maxHp != m.Hp);
            }

            if (m.name == CardDB.cardName.lightspawn && !m.silenced)
            {
                m.Angr = m.Hp;
            }
        }
        
        public void cthunGetBuffed(int attackbuff, int hpbuff, int tauntbuff)
        {
            this.anzOgOwnCThunAngrBonus += attackbuff;
            this.anzOgOwnCThunHpBonus += hpbuff;
            this.anzOgOwnCThunTaunt += tauntbuff;

            bool cthunonboard = false;
            foreach (Minion m in this.ownMinions)
            {
                if (m.name == CardDB.cardName.cthun)
                {
                    this.minionGetBuffed(m, attackbuff, hpbuff);
                    if (tauntbuff > 0)
                    {
                        m.taunt = true;
                        this.anzOwnTaunt++;
                    }
                }
            }
        }

        public void minionLosesDivineShield(Minion m)
        {
            m.divineshild = false;
            if (m.own) this.tempTrigger.ownMinionLosesDivineShield++;
            else this.tempTrigger.enemyMinionLosesDivineShield++;
        }

        public void discardCards(int num, bool own)
        {
            if (own)
            {
                int anz = Math.Min(num, this.owncards.Count);
                if (anz < 1) return;
                int numDiscardedCards = anz;

                int cardValue = 0;
                int bestCardValue = -1;
                int bestCardPos = -1;
                int bestSecondCardValue = -1;
                int bestSecondCardPos = -1;
                int ratio = 100;
                List<Handmanager.Handcard> discardedCardsBonusList = new List<Handmanager.Handcard>();
                Handmanager.Handcard hc;
                CardDB.Card c;
                Dictionary<int, int> cardsValDict = new Dictionary<int,int>();
                for (int i = 0; i < this.owncards.Count; i++)
                {
                    hc = this.owncards[i];
                    c = hc.card;
                    switch (c.type)
                    {
                        case CardDB.cardtype.MOB:
                            cardValue = (c.Health + hc.addHp) * 2 + (c.Attack + hc.addattack) * 2 + c.rarity + hc.elemPoweredUp * 2;
                            if (c.windfury) cardValue += c.Attack + hc.addattack;
                            if (c.tank) cardValue += 2;
                            if (c.Shield) cardValue += 2;
                            if (c.Charge) cardValue += 3;
                            if (c.Stealth) cardValue += 1;
                            if (c.isSpecialMinion) cardValue += 10;
                            switch (c.name)
                            {
                                case CardDB.cardName.direwolfalpha: if (this.ownMinions.Count > 2) cardValue += 10; break;
                                case CardDB.cardName.flametonguetotem: if (this.ownMinions.Count > 2) cardValue += 10; break;
                                case CardDB.cardName.stormwindchampion: if (this.ownMinions.Count > 2) cardValue += 10; break;
                                case CardDB.cardName.raidleader: if (this.ownMinions.Count > 2) cardValue += 10; break;
                                case CardDB.cardName.silverwaregolem: cardValue = (c.Health + hc.addHp) * 2 + c.rarity; break;
                                case CardDB.cardName.clutchmotherzavas: cardValue = (c.Health + hc.addHp) * 2 + c.rarity; break;
                            }
                            break;
                        case CardDB.cardtype.WEAPON:
                            cardValue = c.Attack * c.Durability * 2;
                            if (c.battlecry || c.deathrattle) cardValue += 7;
                            break;
                        case CardDB.cardtype.SPELL:
                            cardValue = 15;
                            break;
                    }
                    if (hc.manacost > 1)
                    {
                        if (hc.manacost == this.mana) ratio = 80;
                        else ratio = 60;
                    }
                    cardsValDict.Add(hc.entity, cardValue * ratio / 100);
                    if (bestCardValue <= cardValue)
                    {
                        bestSecondCardValue = bestCardValue;
                        bestSecondCardPos = bestCardPos;
                        bestCardValue = cardValue;
                        bestCardPos = i;
                    }
                    else if (bestSecondCardValue <= cardValue)
                    {
                        bestSecondCardValue = cardValue;
                        bestSecondCardPos = i;
                    }
                }

                Handmanager.Handcard removedhc;
                int first = bestCardPos;
                int firstVal = bestCardValue;
                int second = bestSecondCardPos;
                int secondVal = bestSecondCardValue;
                int summPen = 0;
                if (bestSecondCardPos > first)
                {
                    first = bestSecondCardPos;
                    firstVal = bestSecondCardValue;
                    second = bestCardPos;
                    secondVal = bestCardValue;
                }
                for (int i = 0; i < numDiscardedCards; i++)
                {
                    if (i > 1) break;
                    int cPos = first;
                    int cVal = firstVal;
                    if (i > 0)
                    {
                        cPos = second;
                        cVal = secondVal;
                    }
                    removedhc = this.owncards[cPos];
                    this.owncards.RemoveAt(cPos);
                    anz--;

                    if (removedhc.card.sim_card.onCardDicscard(this, removedhc, null, 0, true)) 
                    {
                        discardedCardsBonusList.Add(removedhc);
                        cVal = -6;
                    }
                    else this.owncarddraw--;
                    if (prozis.penman.cardDiscardDatabase.ContainsKey(removedhc.card.name)) cVal = 0;
                    summPen += cVal;
                }

                if (anz > 0)
                {
                    for (int i = 0; i < anz; i++)
                    {
                        removedhc = this.owncards[i];
                        bestCardValue = cardsValDict[this.owncards[i].entity];
                        if (removedhc.card.sim_card.onCardDicscard(this, removedhc, null, 0, true))
                        {
                            discardedCardsBonusList.Add(removedhc);
                            bestCardValue = 0;
                        }
                        else this.owncarddraw--;
                        summPen += bestCardValue;
                    }
                    this.owncards.RemoveRange(0, anz);
                }
                
                if (this.ownQuest.Id != CardDB.cardIDEnum.None) this.ownQuest.trigger_WasDiscard(numDiscardedCards);

                
                int malchezaarsimpCount = 0;
                foreach (Minion m in this.ownMinions)
                {
                    if (m.Hp > 0 && !m.silenced)
                    {
                        if (m.name == CardDB.cardName.malchezaarsimp) malchezaarsimpCount++;
                        m.handcard.card.sim_card.onCardDicscard(this, m.handcard, m, numDiscardedCards); 
                    }
                }
                if (malchezaarsimpCount > 0) summPen = summPen / 6;
                this.evaluatePenality += summPen;

                
                foreach (Handmanager.Handcard dc in discardedCardsBonusList)
                {
                    dc.card.sim_card.onCardDicscard(this, dc, null, 0); 
                }
            }
            else
            {
                int anz = Math.Min(num, this.enemyAnzCards);
                if (anz < 1) return;
                this.enemycarddraw -= anz;
                this.enemyAnzCards -= anz;
            }
            this.triggerCardsChanged(own);
        }

        public int lethalMissing()
        {
            if (this.lethlMissing < 1000) return lethlMissing;
            lethlMissing = Ai.Instance.lethalMissing;
            if (lethlMissing > 5) return lethlMissing;
            int dmg = 0;
            if (this.anzEnemyTaunt == 0)
            {
                foreach (Minion m in this.ownMinions)
                {
                    if (!m.Ready || m.frozen) continue;
                    dmg += m.Angr;
                    if (m.windfury) dmg += m.Angr;
                }
            }
            else
            {
                List<Minion> om = new List<Minion>(this.ownMinions);
                List<Minion> omn = new List<Minion>();
                Minion bm = null;
                int tmp = 0;
                foreach (Minion d in this.enemyMinions)
                {
                    if (!d.taunt) continue;
                    bm = null;
                    foreach (Minion m in om)
                    {
                        if (!m.Ready || m.frozen) continue;
                        if (m.Angr < d.Hp)
                        {
                            omn.Add(m);
                            continue;
                        }
                        else
                        {
                            if (bm == null)
                            {
                                bm = m;
                                continue;
                            }
                            else
                            {
                                if (m.Angr < bm.Angr)
                                {
                                    omn.Add(bm);
                                    bm = m;
                                    continue;
                                }
                                else
                                {
                                    omn.Add(m);
                                    continue;
                                }
                            }
                        }
                    }
                    if (bm == null)
                    {
                        dmg = 0;
                        tmp = 0;
                        break;
                    }
                    tmp++;
                    om.Clear();
                    om.AddRange(omn);
                    omn.Clear();
                }
                if (tmp >= this.anzEnemyTaunt)
                {
                    foreach (Minion m in om)
                    {
                        dmg += m.Angr;
                        if (m.windfury) dmg += m.Angr;
                    }
                }
            }
            lethlMissing = this.enemyHero.Hp - dmg;
            return lethlMissing;
        }

        public bool nextTurnWin()
        {
            if (this.anzEnemyTaunt > 0) return false;

            int dmg = 0;
            foreach (Minion m in this.ownMinions)
            {
                if (m.frozen) continue;
                dmg += m.Angr;
                if (m.windfury) dmg += m.Angr;
            }
            if (this.enemyHero.Hp > dmg) return false;
            else return true;
        }

        public void minionSetAngrToX(Minion m, int newAngr)
        {
            if (!m.silenced && m.name == CardDB.cardName.lightspawn) return;
            m.Angr = newAngr;
            m.tempAttack = 0;
            this.minionGetOrEraseAllAreaBuffs(m, true);
        }

        public void minionSetLifetoX(Minion m, int newHp)
        {
            minionGetOrEraseAllAreaBuffs(m, false);
            m.Hp = newHp;
            m.maxHp = newHp;
            if (m.wounded && !m.silenced) m.handcard.card.sim_card.onEnrageStop(this, m);
            m.wounded = false;
            minionGetOrEraseAllAreaBuffs(m, true);
        }

        public void minionSetAngrToHP(Minion m)
        {
            m.Angr = m.Hp;
            m.tempAttack = 0;
            this.minionGetOrEraseAllAreaBuffs(m, true);

        }

        public void minionSwapAngrAndHP(Minion m)
        {
            
            bool woundedbef = m.wounded;
            int temp = m.Angr;
            m.Angr = m.Hp;
            m.Hp = temp;
            m.maxHp = temp;
            m.wounded = false;
            if (woundedbef) m.handcard.card.sim_card.onEnrageStop(this, m);
            if (m.Hp <= 0)
            {
                if (m.own) this.tempTrigger.ownMinionsDied++;
                else this.tempTrigger.enemyMinionsDied++;
            }

            this.minionGetOrEraseAllAreaBuffs(m, true);
        }

        public void minionGetDamageOrHeal(Minion m, int dmgOrHeal, bool dontDmgLoss = false)
        {
            if (m.Hp > 0) m.getDamageOrHeal(dmgOrHeal, this, false, dontDmgLoss);
        }



        public void allMinionOfASideGetDamage(bool own, int damages, bool frozen = false)
        {
            List<Minion> temp = (own) ? this.ownMinions : this.enemyMinions;
            foreach (Minion m in temp)
            {
                if (frozen) minionGetFrozen(m);
                minionGetDamageOrHeal(m, damages, true);
            }
        }

        public void allCharsOfASideGetDamage(bool own, int damages)
        {
            //ALL CHARS get same dmg
            List<Minion> temp = (own) ? this.ownMinions : this.enemyMinions;
            foreach (Minion m in temp)
            {
                minionGetDamageOrHeal(m, damages, true);
            }

            this.minionGetDamageOrHeal(own ? this.ownHero : this.enemyHero, damages);
        }

        public void allCharsOfASideGetRandomDamage(bool ownSide, int times) 
        {
            //Deal damage randomly split among all enemies.

            if ((!ownSide && this.enemyHero.Hp + this.enemyHero.armor <= times) || (ownSide && this.ownHero.Hp + this.ownHero.armor <= times))
            {
                if (!ownSide)
                {
                    int dmg = this.enemyHero.Hp + this.enemyHero.armor;  //optimistic
                    if (this.enemyMinions.Count > 2) dmg--;
                    times = times - dmg;
                    if (this.anzEnemyAnimatedArmor > 0)
                    {
                        for (; dmg > 0; dmg--) this.minionGetDamageOrHeal(this.enemyHero, 1);
                    }
                    else this.minionGetDamageOrHeal(this.enemyHero, dmg);
                }
                else
                {
                    int dmg = this.ownHero.Hp + this.ownHero.armor - 1;
                    times = times - dmg;
                    if (this.anzOwnAnimatedArmor > 0)
                    {
                        for (; dmg > 0; dmg--) this.minionGetDamageOrHeal(this.ownHero, 1);
                    }
                    else this.minionGetDamageOrHeal(this.ownHero, dmg);
                }
            }

            List<Minion> temp = (ownSide) ? new List<Minion>(this.ownMinions) : new List<Minion>(this.enemyMinions);
            temp.Sort((a, b) => { int tmp = a.Hp.CompareTo(b.Hp); return tmp == 0 ? a.Angr - b.Angr : tmp; }); 

            int border = 1;
            for (int pos = 0; pos < temp.Count; pos++)
            {
                Minion m = temp[pos];
                if (m.divineshild)
                {
                    m.divineshild = false;
                    times--;
                    if (times < 1) break;
                }
                if (m.Hp > border)
                {
                    int dmg = Math.Min(m.Hp - border, times);
                    times -= dmg;
                    this.minionGetDamageOrHeal(m, dmg);
                }
                if (times < 1) break;
            }
            if (times > 0)
            {
                int dmg = times;
                if (!ownSide)
                {
                    if (this.anzEnemyAnimatedArmor > 0)
                    {
                        for (; dmg > 0; dmg--) this.minionGetDamageOrHeal(this.enemyHero, 1);
                    }
                    else this.minionGetDamageOrHeal(this.enemyHero, dmg);
                }
                else
                {
                    if (this.anzOwnAnimatedArmor > 0)
                    {
                        for (; dmg > 0; dmg--) this.minionGetDamageOrHeal(this.ownHero, 1);
                    }
                    else this.minionGetDamageOrHeal(this.ownHero, dmg);
                }
            }
        }

        public void allCharsGetDamage(int damages, int exceptID = -1)
        {
            foreach (Minion m in this.ownMinions)
            {
                if (m.entitiyID != exceptID) minionGetDamageOrHeal(m, damages, true);
            }
            foreach (Minion m in this.enemyMinions)
            {
                if (m.entitiyID != exceptID) minionGetDamageOrHeal(m, damages, true);
            }
            minionGetDamageOrHeal(this.ownHero, damages);
            minionGetDamageOrHeal(this.enemyHero, damages);
        }

        public void allMinionsGetDamage(int damages, int exceptID = -1)
        {
            foreach (Minion m in this.ownMinions)
            {
                if (m.entitiyID != exceptID) minionGetDamageOrHeal(m, damages, true);
            }
            foreach (Minion m in this.enemyMinions)
            {
                if (m.entitiyID != exceptID) minionGetDamageOrHeal(m, damages, true);
            }
        }


        public void setNewHeroPower(CardDB.cardIDEnum newHeroPower, bool own)
        {
            if (own)
            {
                this.ownHeroAblility.card = CardDB.Instance.getCardDataFromID(newHeroPower);
                this.ownAbilityReady = true;
            }
            else
            {
                this.enemyHeroAblility.card = CardDB.Instance.getCardDataFromID(newHeroPower);
                this.enemyAbilityReady = true;
            }
        }


        private void getHandcardsByType(List<Handmanager.Handcard> cards, GAME_TAGs tag, TAG_RACE race = TAG_RACE.INVALID)
        {
            switch (tag)
            {
                case GAME_TAGs.None:
                    foreach (Handmanager.Handcard hc in cards) hc.extraParam3 = true;
                    break;
                case GAME_TAGs.Spell:
                    foreach (Handmanager.Handcard hc in cards) if (hc.card.type == CardDB.cardtype.SPELL) hc.extraParam3 = true;
                    break;
                case GAME_TAGs.SECRET:
                    foreach (Handmanager.Handcard hc in cards) if (hc.card.Secret) hc.extraParam3 = true;
                    break;
                case GAME_TAGs.Mob:
                    foreach (Handmanager.Handcard hc in cards) if (hc.card.type == CardDB.cardtype.MOB) hc.extraParam3 = true;
                    break;
                case GAME_TAGs.CARDRACE:
                    foreach (Handmanager.Handcard hc in cards)
                    {
                        if (hc.card.type == CardDB.cardtype.MOB)
                        {
                            if (race == TAG_RACE.INVALID) hc.extraParam3 = true;
                            else if (hc.card.race == (int)race) hc.extraParam3 = true;
                        }
                    }
                    break;
                case GAME_TAGs.TAUNT:
                    foreach (Handmanager.Handcard hc in cards) if (hc.card.tank) hc.extraParam3 = true;
                    break;
                case GAME_TAGs.COMBO:
                    foreach (Handmanager.Handcard hc in cards) if (hc.card.Combo) hc.extraParam3 = true;
                    break;
                case GAME_TAGs.DIVINE_SHIELD:
                    foreach (Handmanager.Handcard hc in cards) if (hc.card.Shield) hc.extraParam3 = true;
                    break;
                case GAME_TAGs.ENRAGED:
                    foreach (Handmanager.Handcard hc in cards) if (hc.card.Enrage) hc.extraParam3 = true;
                    break;
                case GAME_TAGs.LIFESTEAL:
                    foreach (Handmanager.Handcard hc in cards) if (hc.card.lifesteal) hc.extraParam3 = true;
                    break;
                case GAME_TAGs.OVERLOAD:
                    foreach (Handmanager.Handcard hc in cards) if (hc.card.overload > 0) hc.extraParam3 = true;
                    break;
                case GAME_TAGs.CLASS:
                    foreach (Handmanager.Handcard hc in cards) if (hc.card.Class == (int)ownHeroStartClass) hc.extraParam3 = true;
                    break;
                case GAME_TAGs.Weapon:
                    foreach (Handmanager.Handcard hc in cards) if (hc.card.type == CardDB.cardtype.WEAPON) hc.extraParam3 = true;
                    break;
            }
        }

        public Handmanager.Handcard searchRandomMinionInHand(List<Handmanager.Handcard> cards, searchmode mode, GAME_TAGs tag = GAME_TAGs.None, TAG_RACE race = TAG_RACE.INVALID)
        {
            Handmanager.Handcard ret = null;
            double value = 0;
            switch (mode)
            {
                case searchmode.searchLowestHP: value = 1000; break;
                case searchmode.searchHighestHP: value = -1; break;
                case searchmode.searchLowestAttack: value = 1000; break;
                case searchmode.searchHighestAttack: value = -1; break;
                case searchmode.searchHighAttackLowHP: value = -1; break;
                case searchmode.searchHighHPLowAttack: value = -1; break;
                case searchmode.searchLowestCost: value = 1000;  break;
                case searchmode.searchHighesCost: value = -1; break;
            }

            getHandcardsByType(cards, tag, race);
            foreach (Handmanager.Handcard hc in cards)
            {
                if (!hc.extraParam3) continue;
                hc.extraParam3 = false;

                switch (mode)
                {
                    case searchmode.searchLowestHP:
                        if ((hc.card.Health + hc.addHp) < value)
                        {
                            ret = hc;
                            value = (hc.card.Health + hc.addHp);
                        }
                        break;
                    case searchmode.searchHighestHP:
                        if ((hc.card.Health + hc.addHp) > value)
                        {
                            ret = hc;
                            value = (hc.card.Health + hc.addHp);
                        }
                        break;
                    case searchmode.searchLowestAttack:
                        if ((hc.card.Attack + hc.addattack) < value)
                        {
                            ret = hc;
                            value = (hc.card.Attack + hc.addattack);
                        }
                        break;
                    case searchmode.searchHighestAttack:
                        if ((hc.card.Attack + hc.addattack) > value)
                        {
                            ret = hc;
                            value = (hc.card.Attack + hc.addattack);
                        }
                        break;
                    case searchmode.searchHighAttackLowHP:
                        if ((hc.card.Attack + hc.addattack) / (hc.card.Health + hc.addHp) > value)
                        {
                            ret = hc;
                            value = (hc.card.Attack + hc.addattack) / (hc.card.Health + hc.addHp);
                        }
                        break;
                    case searchmode.searchHighHPLowAttack:
                        if ((hc.card.Health + hc.addHp) / (hc.card.Attack + hc.addattack) > value)
                        {
                            ret = hc;
                            value = (hc.card.Health + hc.addHp) / (hc.card.Attack + hc.addattack);
                        }
                        break;
                    case searchmode.searchLowestCost:
                        if (hc.manacost < value)
                        {
                            ret = hc;
                            value = hc.manacost;
                        }
                        break;
                    case searchmode.searchHighesCost:
                        if (hc.manacost > value)
                        {
                            ret = hc;
                            value = hc.manacost;
                        }
                        break;
                }
            }
            return ret;
        }

        public Minion searchRandomMinion(List<Minion> minions, searchmode mode)
        {
            if (minions.Count == 0) return null;
            Minion ret = null;
            double value = 0;
            switch (mode)
            {
                case searchmode.searchLowestHP: value = 1000; break;
                case searchmode.searchHighestHP: value = -1; break;
                case searchmode.searchLowestAttack: value = 1000; break;
                case searchmode.searchHighestAttack: value = -1; break;
                case searchmode.searchHighAttackLowHP: value = -1; break;
                case searchmode.searchHighHPLowAttack: value = -1; break;
                case searchmode.searchLowestCost: value = 1000; break;
                case searchmode.searchHighesCost: value = -1; break;
            }

            foreach (Minion m in minions)
            {
                if (m.Hp <= 0) continue;

                switch (mode)
                {
                    case searchmode.searchLowestHP:
                        if (m.Hp < value)
                        {
                            ret = m;
                            value = m.Hp;
                        }
                        continue;
                    case searchmode.searchHighestHP:
                        if (m.Hp > value)
                        {
                            ret = m;
                            value = m.Hp;
                        }
                        continue;
                    case searchmode.searchLowestAttack:
                        if (m.Angr < value)
                        {
                            ret = m;
                            value = m.Angr;
                        }
                        continue;
                    case searchmode.searchHighestAttack:
                        if (m.Angr > value)
                        {
                            ret = m;
                            value = m.Angr;
                        }
                        continue;
                    case searchmode.searchHighAttackLowHP:
                        if (m.Angr / m.Hp > value)
                        {
                            ret = m;
                            value = m.Angr / m.Hp;
                        }
                        continue;
                    case searchmode.searchHighHPLowAttack:
                        if (m.Angr == 0)
                        {
                            if (ret == null) ret = m;
                            continue;
                        }
                        if (m.Hp / m.Angr > value)
                        {
                            ret = m;
                            value = m.Hp / m.Angr;
                        }
                        continue;
                    case searchmode.searchLowestCost:
                        if (m.handcard.card.cost < value)
                        {
                            ret = m;
                            value = m.handcard.card.cost;
                        }
                        continue;
                    case searchmode.searchHighesCost:
                        if (m.handcard.card.cost > value)
                        {
                            ret = m;
                            value = m.handcard.card.cost;
                        }
                        continue;
                }
            }
            return ret;
        }

        public Minion searchRandomMinionByMaxHP(List<Minion> minions, searchmode mode, int maxHP)
        {
            //optimistic search

            if (maxHP < 1) return null;
            if (minions.Count == 0) return null;

            Minion ret = null;

            double value = 0;
            int retVal = 0;
            foreach (Minion m in minions)
            {
                if (m.Hp > maxHP) continue;

                switch (mode)
                {
                    case searchmode.searchHighestHP:
                        if (m.Hp > value)
                        {
                            ret = m;
                            value = m.Hp;
                            retVal = m.Angr;
                        }
                        else if (m.Hp == value && retVal < m.Angr) ret = m;
                        continue;
                    case searchmode.searchLowestAttack:
                        if (m.Angr < value)
                        {
                            ret = m;
                            value = m.Angr;
                            retVal = m.Hp;
                        }
                        else if (m.Angr == value && retVal < m.Hp) ret = m;
                        continue;
                    case searchmode.searchHighestAttack:
                        if (m.Angr > value)
                        {
                            ret = m;
                            value = m.Angr;
                            retVal = m.Hp;
                        }
                        else if (m.Angr == value && retVal < m.Hp) ret = m;
                        continue;
                    case searchmode.searchHighAttackLowHP:
                        if (m.Angr / m.Hp > value)
                        {
                            ret = m;
                            value = m.Angr / m.Hp;
                            retVal = m.Hp;
                        }
                        else if (m.Angr / m.Hp == value && retVal < m.Hp) ret = m;
                        continue;
                    case searchmode.searchHighHPLowAttack:
                        if (m.Angr == 0)
                        {
                            if (ret == null) ret = m;
                            continue;
                        }
                        if (m.Hp / m.Angr > value)
                        {
                            ret = m;
                            value = m.Hp / m.Angr;
                            retVal = m.Hp;
                        }
                        else if (m.Angr / m.Hp == value && retVal < m.Hp) ret = m;
                        continue;
                    default: //==searchHighestHP
                        if (m.Hp > value)
                        {
                            ret = m;
                            value = m.Hp;
                            retVal = m.Angr;
                        }
                        else if (m.Hp == value && retVal < m.Angr) ret = m;
                        continue;
                }
            }
            if (ret != null && ret.Hp <= 0) return null;
            return ret;
        }

        public CardDB.Card getNextJadeGolem(bool own)
        {
            int tmp = 0;            
            if (own)
            {
                tmp = 1 + anzOwnJadeGolem;
                anzOwnJadeGolem++;
            }
            else
            {
                tmp = 1 + anzEnemyJadeGolem;
                anzEnemyJadeGolem++;
            }
            switch (tmp)
            {
                case 1: return CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.CFM_712_t01);
                case 2: return CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.CFM_712_t02);
                case 3: return CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.CFM_712_t03);
                case 4: return CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.CFM_712_t04);
                case 5: return CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.CFM_712_t05);
                case 6: return CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.CFM_712_t06);
                case 7: return CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.CFM_712_t07);
                case 8: return CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.CFM_712_t08);
                case 9: return CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.CFM_712_t09);
                case 10: return CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.CFM_712_t10);
                case 11: return CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.CFM_712_t11);
                case 12: return CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.CFM_712_t12);
                case 13: return CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.CFM_712_t13);
                case 14: return CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.CFM_712_t14);
                case 15: return CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.CFM_712_t15);
                case 16: return CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.CFM_712_t16);
                case 17: return CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.CFM_712_t17);
                case 18: return CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.CFM_712_t18);
                case 19: return CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.CFM_712_t19);
                case 20: return CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.CFM_712_t20);
                case 21: return CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.CFM_712_t21);
                case 22: return CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.CFM_712_t22);
                case 23: return CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.CFM_712_t23);
                case 24: return CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.CFM_712_t24);
                case 25: return CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.CFM_712_t25);
                case 26: return CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.CFM_712_t26);
                case 27: return CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.CFM_712_t27);
                case 28: return CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.CFM_712_t28);
                case 29: return CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.CFM_712_t29);
                case 30: return CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.CFM_712_t30);
            }
            return CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.CFM_712_t01);
        }

        public void debugMinions()
        {
            Helpfunctions.Instance.logg("OWN MINIONS################");

            foreach (Minion m in this.ownMinions)
            {
                Helpfunctions.Instance.logg("name,ang, hp, maxhp: " + m.name + ", " + m.Angr + ", " + m.Hp + ", " + m.maxHp);
            }

            Helpfunctions.Instance.logg("ENEMY MINIONS############");
            foreach (Minion m in this.enemyMinions)
            {
                Helpfunctions.Instance.logg("name,ang, hp: " + m.name + ", " + m.Angr + ", " + m.Hp);
            }
        }

        public void printBoard()
        {
            Helpfunctions.Instance.logg("board/hash/turn: " + value + "  /  " + this.hashcode + "  /  " + this.turnCounter + " ++++++++++++++++++++++");
            Helpfunctions.Instance.logg("pen " + this.evaluatePenality);
            Helpfunctions.Instance.logg("mana " + this.mana + "/" + this.ownMaxMana);
            Helpfunctions.Instance.logg("cardsplayed: " + this.cardsPlayedThisTurn + " handsize: " + this.owncards.Count + " enemyhand: " + this.enemyAnzCards);

            Helpfunctions.Instance.logg("ownhero: ");
            Helpfunctions.Instance.logg("ownherohp: " + this.ownHero.Hp + " + " + this.ownHero.armor);
            Helpfunctions.Instance.logg("ownheroattac: " + this.ownHero.Angr);
            Helpfunctions.Instance.logg("ownheroweapon: " + this.ownWeapon.Angr + " " + this.ownWeapon.Durability + " " + this.ownWeapon.name + " " + this.ownWeapon.card.cardIDenum + " " + (this.ownWeapon.poisonous ? 1 : 0) + " " + (this.ownWeapon.lifesteal ? 1 : 0));
            Helpfunctions.Instance.logg("ownherostatus: frozen" + this.ownHero.frozen + " ");
            Helpfunctions.Instance.logg("enemyherohp: " + this.enemyHero.Hp + " + " + this.enemyHero.armor + ((this.enemyHero.immune) ? " immune" : ""));

            if (this.enemySecretCount >= 1) Helpfunctions.Instance.logg("enemySecrets: " + Probabilitymaker.Instance.getEnemySecretData(this.enemySecretList));
            foreach (Action a in this.playactions)
            {
                a.print();
            }
            Helpfunctions.Instance.logg("OWN MINIONS################ " + this.ownMinions.Count);

            foreach (Minion m in this.ownMinions)
            {
                Helpfunctions.Instance.logg("deckpos, name,ang, hp: " + m.zonepos + ", " + m.name + ", " + m.Angr + ", " + m.Hp + " " + m.entitiyID);
            }

            if (this.enemyMinions.Count > 0)
            {
                Helpfunctions.Instance.logg("ENEMY MINIONS############ " + this.enemyMinions.Count);
                foreach (Minion m in this.enemyMinions)
                {
                    Helpfunctions.Instance.logg("deckpos, name,ang, hp: " + m.zonepos + ", " + m.name + ", " + m.Angr + ", " + m.Hp + " " + m.entitiyID);
                }
            }

            if (this.diedMinions.Count > 0)
            {
                Helpfunctions.Instance.logg("DIED MINIONS############");
                foreach (GraveYardItem m in this.diedMinions)
                {
                    Helpfunctions.Instance.logg("own, entity, cardid: " + m.own + ", " + m.entity + ", " + m.cardid);
                }
            }

            Helpfunctions.Instance.logg("Own Handcards: ");
            foreach (Handmanager.Handcard hc in this.owncards)
            {
                Helpfunctions.Instance.logg("pos " + hc.position + " " + hc.card.name + " " + hc.manacost + " entity " + hc.entity + " " + hc.card.cardIDenum + " " + hc.addattack + " " + hc.addHp + " " + hc.elemPoweredUp);
            }
            Helpfunctions.Instance.logg("+++++++ printBoard end +++++++++");

            Helpfunctions.Instance.logg("");
        }


        public string printBoardString()
        {
            string retval = "Turn : board\t" + this.turnCounter + ":" + ((this.value < -2000000) ? "." : this.value.ToString());
            retval += "\r\n" + "pIdHistory\t";
            foreach (int pId in this.pIdHistory) retval += pId + " ";
            retval += "\r\n" + ("pen\t" + this.evaluatePenality);
            retval += "\r\n" + ("mana\t" + this.mana + "/" + this.ownMaxMana);
            retval += "\r\n" + ("cardsplayed : handsize : enemyhand\t" + this.cardsPlayedThisTurn + ":" + this.owncards.Count + ":" + this.enemyAnzCards);
            retval += "\r\n" + ("Hp : armor : Atk ownhero\t" + this.ownHero.Hp + ":" + this.ownHero.armor + ":" + this.ownHero.Angr + ((this.ownHero.immune) ? ":immune" : ""));
            retval += "\r\n" + ("Atk : Dur : Name : IDe : poison ownWeapon\t" + this.ownWeapon.Angr + " " + this.ownWeapon.Durability + " " + this.ownWeapon.name + " " + this.ownWeapon.card.cardIDenum + " " + (this.ownWeapon.poisonous ? 1 : 0) + " " + (this.ownWeapon.lifesteal ? 1 : 0));
            retval += "\r\n" + ("ownHero.frozen\t" + this.ownHero.frozen);
            retval += "\r\n" + ("Hp : armor enemyhero\t" + this.enemyHero.Hp + ":" + this.enemyHero.armor + ((this.enemyHero.immune) ? ":immune" : ""));
            retval += "\r\n" + ("Atk : Dur : Name : IDe : poison enemyWeapon\t" + this.enemyWeapon.Angr + " " + this.enemyWeapon.Durability + " " + this.enemyWeapon.name + " " + this.enemyWeapon.card.cardIDenum + " " + (this.enemyWeapon.poisonous ? 1 : 0) + " " + (this.enemyWeapon.lifesteal ? 1 : 0));
            retval += "\r\n" + ("carddraw own:enemy\t" + this.owncarddraw + ":" + this.enemycarddraw);

            if (this.enemySecretCount > 0) retval += "\r\n" + ("enemySecrets\t" + Probabilitymaker.Instance.getEnemySecretData(this.enemySecretList));
            if (this.ownSecretsIDList.Count > 0)
            {
                retval += "\r\n" + ("ownSecrets\t" );
                foreach (CardDB.cardIDEnum s in this.ownSecretsIDList)
                {
                    retval += " " + CardDB.Instance.getCardDataFromID(s).name;
                }
            }

            for (int i = 0; i < this.playactions.Count; i++) retval += "\r\n" + i + " action\t" + this.playactions[i].printString();
            retval += "\r\n" + ("OWN MINIONS################\t" + this.ownMinions.Count);

            for (int i = 0; i < this.ownMinions.Count; i++)
            {
                Minion m = this.ownMinions[i];
                retval += "\r\n" + (i + 1) + " OWN MINION\t" + m.zonepos + " " + m.entitiyID + ":" + m.name + " " + m.Angr + " " + m.Hp;
            }

            if (this.enemyMinions.Count > 0)
            {
                retval += "\r\n" + ("ENEMY MINIONS############\t" + this.enemyMinions.Count);
                for (int i = 0; i < this.enemyMinions.Count; i++)
                {
                    Minion m = this.enemyMinions[i];
                    retval += "\r\n" + (i + 1) + " ENEMY MINION\t" + m.zonepos + " " + m.entitiyID + ":" + m.name + " " + m.Angr + " " + m.Hp;
                }
            }

            if (this.diedMinions.Count > 0)
            {
                retval += "\r\n" + ("DIED MINIONS############\t");
                for (int i = 0; i < this.diedMinions.Count; i++)
                {
                    GraveYardItem m = this.diedMinions[i];
                    retval += "\r\n" + i + (" own : entity : cardid\t" + (m.own ? "own" : "en") + " " + m.entity + " " + m.cardid);
                }
            }

            retval += "\r\nOwn Handcards\t\r\n";
            for (int i = 0; i < this.owncards.Count; i++)
            {
                Handmanager.Handcard hc = this.owncards[i];
                retval += "\r\n" + (i + 1) + " CARD\t" + (hc.position + " " + hc.entity + ":" + hc.card.name + " " + hc.manacost + " " + hc.card.cardIDenum + " " + hc.addattack + " " + hc.addHp + " " + hc.elemPoweredUp + "\r\n");
            }
            retval += ("Enemy Handcards count\t" + this.enemyAnzCards + "\r\n");

            return retval;
        }

        public void printBoardDebug()
        {
            Helpfunctions.Instance.logg("hero " + this.ownHero.Hp + " " + this.ownHero.armor + " " + this.ownHero.entitiyID);
            Helpfunctions.Instance.logg("ehero " + this.enemyHero.Hp + " " + this.enemyHero.armor + " " + this.enemyHero.entitiyID);
            foreach (Minion m in ownMinions)
            {
                Helpfunctions.Instance.logg(m.name + " " + m.entitiyID);
            }
            Helpfunctions.Instance.logg("-");
            foreach (Minion m in enemyMinions)
            {
                Helpfunctions.Instance.logg(m.name + " " + m.entitiyID);
            }
            Helpfunctions.Instance.logg("-");
            foreach (Handmanager.Handcard hc in this.owncards)
            {
                Helpfunctions.Instance.logg(hc.position + " " + hc.card.name + " " + hc.entity);
            }
        }

        public Action getNextAction()
        {
            if (this.playactions.Count >= 1) return this.playactions[0];
            return null;
        }

        public void printActions(bool toBuffer = false)
        {
            foreach (Action a in this.playactions)
            {
                a.print(toBuffer);
                Helpfunctions.Instance.logg("");
            }
        }

        public void printActionforDummies(Action a)
        {
            if (a.actionType == actionEnum.playcard)
            {
                Helpfunctions.Instance.ErrorLog("play " + a.card.card.name);
                if (a.druidchoice >= 1)
                {
                    string choose = (a.druidchoice == 1) ? "left card" : "right card";
                    Helpfunctions.Instance.ErrorLog("choose the " + choose);
                }
                if (a.place >= 1)
                {
                    Helpfunctions.Instance.ErrorLog("on position " + a.place);
                }
                if (a.target != null)
                {
                    if (!a.target.own && !a.target.isHero)
                    {
                        string ename = "" + a.target.name;
                        Helpfunctions.Instance.ErrorLog("and target to the enemy " + ename);
                    }

                    if (a.target.own && !a.target.isHero)
                    {
                        string ename = "" + a.target.name;
                        Helpfunctions.Instance.ErrorLog("and target to your own" + ename);
                    }

                    if (a.target.own && a.target.isHero)
                    {
                        Helpfunctions.Instance.ErrorLog("and target your own hero");
                    }

                    if (!a.target.own && a.target.isHero)
                    {
                        Helpfunctions.Instance.ErrorLog("and target to the enemy hero");
                    }
                }

            }
            if (a.actionType == actionEnum.attackWithMinion)
            {
                string name = "" + a.own.name;
                if (a.target.isHero)
                {
                    Helpfunctions.Instance.ErrorLog("attack with: " + name + " the enemy hero");
                }
                else
                {
                    string ename = "" + a.target.name;
                    Helpfunctions.Instance.ErrorLog("attack with: " + name + " the enemy: " + ename);
                }

            }

            if (a.actionType == actionEnum.attackWithHero)
            {
                if (a.target.isHero)
                {
                    Helpfunctions.Instance.ErrorLog("attack with your hero the enemy hero!");
                }
                else
                {
                    string ename = "" + a.target.name;
                    Helpfunctions.Instance.ErrorLog("attack with the hero, and choose the enemy: " + ename);
                }
            }
            if (a.actionType == actionEnum.useHeroPower)
            {
                Helpfunctions.Instance.ErrorLog("use your Heropower ");
                if (a.target != null)
                {
                    if (!a.target.own && !a.target.isHero)
                    {
                        string ename = "" + a.target.name;
                        Helpfunctions.Instance.ErrorLog("on enemy: " + ename);
                    }

                    if (a.target.own && !a.target.isHero)
                    {
                        string ename = "" + a.target.name;
                        Helpfunctions.Instance.ErrorLog("on your own: " + ename);
                    }

                    if (a.target.own && a.target.isHero)
                    {
                        Helpfunctions.Instance.ErrorLog("on your own hero");
                    }

                    if (!a.target.own && a.target.isHero)
                    {
                        Helpfunctions.Instance.ErrorLog("on your the enemy hero");
                    }

                }
            }
            Helpfunctions.Instance.ErrorLog("");

        }


    }



}
