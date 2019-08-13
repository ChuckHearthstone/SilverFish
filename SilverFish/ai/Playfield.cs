using System.ComponentModel;

namespace HREngine.Bots
{
    using System;
    using System.Collections.Generic;

    public struct triggerCounter
    {
        public int minionsGotHealed;
        public int ownMinionsGotHealed;

        public int charsGotHealed;
        public int owncharsGotHealed;

        public int ownMinionsGotDmg;
        public int enemyMinionsGotDmg;

        public int ownHeroGotDmg;
        public int enemyHeroGotDmg;

        public int ownMinionsDied;
        public int enemyMinionsDied;
        public int ownTotemSummoned;
        public int ownBeastSummoned;
        public int ownBeastDied;
        public int enemyBeastDied;
        public int ownMechanicDied;
        public int enemyMechanicDied;
        public int ownMurlocDied;
        public int enemyMurlocDied;

        public bool ownMinionsChanged;
        public bool enemyMininsChanged;
    }

    //todo save "started" variables outside (they doesnt change)

    public class Playfield
    {
        //Todo: delete all new list<minion>
        //TODO: graveyard change (list <card,owner>)
        //Todo: vanish clear all auras/buffs (NEW1_004)

        public bool logging;
        public bool complete;

        //dont have to be copied! (server doesnt copy)
        public List<Handmanager.Handcard> myDeck ;
        public List<Handmanager.Handcard> enemyDeck ;
        public List<Handmanager.Handcard> EnemyCards ;
        public List<CardDB.cardIDEnum> EnemySecretsIDList ;
        //------------

        public int nextEntity;

        public triggerCounter tempTrigger;
        private Hrtprozis prozis = Hrtprozis.Instance;

        //Entity=PLAYER tag=HEROPOWER_ACTIVATIONS_THIS_TURN
        //Entity=PLAYER tag=NUM_TIMES_HERO_POWER_USED_THIS_GAME

        //aura minions##########################
        //todo reduce buffing vars
        public int anzOwnRaidleader;
        public int anzEnemyRaidleader;
        public int anzOwnStormwindChamps;
        public int anzEnemyStormwindChamps;
        public int anzOwnWarhorseTrainer;
        public int anzEnemyWarhorseTrainer;
        public int anzOwnTundrarhino;
        public int anzEnemyTundrarhino;
        public int anzOwnTimberWolfs;
        public int anzEnemyTimberWolfs;
        public int anzOwnMurlocWarleader;
        public int anzEnemyMurlocWarleader;
        public int anzAcidmaw;
        public int anzOwnGrimscaleOracle;
        public int anzEnemyGrimscaleOracle;
        public int anzOwnShadowfiends;
        public int anzEnemyShadowfiends;
        public int anzOwnAuchenaiSoulpriest;
        public int anzEnemyAuchenaiSoulpriest;
        public int anzOwnSorcerersApprentice;
        public int anzOwnsorcerersapprenticeStarted;
        public int anzEnemysorcerersapprentice;
        public int anzEnemysorcerersapprenticeStarted;
        public int anzOwnSouthseacaptain;
        public int anzEnemySouthseacaptain;
        public int anzOwnMalGanis;
        public int anzEnemyMalGanis;
        public int anzOwnPiratesStarted;
        public int anzOwnMurlocStarted;
        public int anzOwnChromaggus;
        public int anzEnemyChromaggus;
        public int anzOwnBolfRamshield;
        public int anzEnemyBolfRamshield;
        public int anzOwnHorsemen;
        public int anzEnemyHorsemen;
        //new ones TGT##########################

        public int anzOwnSaboteur;
        public int anzEnemySaboteur;
        public int anzOwnFencingCoach;
        public int anzEnemyFencingCoach;
        
        public int ownHeroPowerExtraDamage;
        public int enemyHeroPowerExtraDamage;
        public int ownHeroPowerAllowedQuantity;
        public int enemyHeroPowerAllowedQuantity;
        public int anzUsedOwnHeroPower;
        public int anzOwnExtraAngrHp;
        public int anzEnemyExtraAngrHp;

        public int anzOwnGarrisonCommander;//also used for ColdarraDrake
        public int anzEnemyGarrisonCommander;//also used for ColdarraDrake
        public int anzOwnFallenHeros;
        public int anzEnemyFallenHeros;
        public int anzOwnFizzlebang;
        public int anzEnemyFizzlebang;
        public int anzOwnBuccaneer;
        public int anzEnemyBuccaneer;
        public int anzOwnAviana;
        public int anzEnemyAviana;
        public int anzOwnMaidenOfTheLake;
        public int anzEnemyMaidenOfTheLake;

        public int anzOwnWarsongCommanders;
        public int anzEnemyWarsongCommanders;

        //new ones LOE##########################

        public int anzOwnBranns;
        public int anzEnemyBranns;
        public int anzOwnFandralStaghelm;

        //##########################

        public int anzOwnMechwarper;
        public int anzOwnMechwarperStarted;
        public int anzEnemyMechwarper;
        public int anzEnemyMechwarperStarted;
        
        public int anzOgOwnCThunHpBonus;
        public int anzOgOwnCThunAngrBonus;
        public int anzOgOwnCThunTaunt;
        public int anzOwnJadeGolem;
        public int anzEnemyJadeGolem;

        public int ownVioletIllusionist;
        public int enemyVioletIllusionist;
        public int anzOwnCloakedHuntress;

        public int anzBlackwaterPirate;
        public int blackwaterpirateStarted;
        public int embracetheshadow;

        public int anzEnemyTaunt;
        public int anzOwnTaunt;
        public int ownMinionsDiedTurn;
        public int enemyMinionsDiedTurn;

        public bool feugenDead;
        public bool stalaggDead;

        public bool anzOwnMillhouseManastorm;
        public bool anzEnemyMillhouseManastorm;

        public bool weHaveSteamwheedleSniper;
        public bool enemyHaveSteamwheedleSniper;
        
        public bool ownSpiritclaws;
        public bool enemySpiritclaws;

        public bool needGraveyard;


        public int doublepriest;
        public int enemydoublepriest;
        public int ownMistcaller;

        public int lockandload;
        public int anzOwnDragonConsort;
        public int anzEnemyDragonConsort;

        public int ownBaronRivendare;
        public int enemyBaronRivendare;
        //#########################################
        //new variables LOE
        public int selectedChoice;
        public int anzOwnNagaSeaWitch;
        public int anzEnemyNagaSeaWitch;
        public int anzOwnAnimatedArmor;
        public int anzEnemyAnimatedArmor;
        public int anzEnemyCursed;
        //############################

        public int tempanzOwnCards; // for Goblin Sapper
        public int tempanzEnemyCards;// for Goblin Sapper

        public bool isOwnTurn; // its your turn?
        public int turnCounter;
        public bool sEnemTurn;//should the enemy turn be simulated?

        public bool attacked;
        public int attackFaceHP;

        public int evaluatePenality;
        public int ownController;

        //public int ownHeroEntity = -1;
        //public int enemyHeroEntity = -1;

        public int hashcode;
        public float value;
        public int guessingHeroHP = 30;

        public int mana;
        public int manaTurnEnd;
        public int numEnemySecretsTurnEnd;



        public List<CardDB.cardIDEnum> ownSecretsIDList;
        public List<SecretItem> enemySecretList;

        public int enemySecretCount;

        public Minion ownHero;
        public Minion enemyHero;
        public HeroEnum ownHeroName;
        public HeroEnum enemyHeroName;
        public TAG_CLASS ownHeroStartClass;
        public TAG_CLASS enemyHeroStartClass;

        public CardDB.cardName ownWeaponName;
        public CardDB.Card ownWeaponCard;
        public int ownWeaponAttack;
        public int ownWeaponDurability;

        public CardDB.cardName enemyWeaponName;
        public CardDB.Card enemyWeaponCard;
        public int enemyWeaponAttack;
        public int enemyWeaponDurability;

        public List<Minion> ownMinions;
        public List<Minion> enemyMinions;
        public List<GraveYardItem> diedMinions;
        public int anzMinionsDiedThisTurn;

        public int numPlayerMinionsAtTurnStart;
        public int loathebLastTurn;  // only checked for turn 2 bonus

        public List<Handmanager.Handcard> owncards;
        public int owncarddraw;

        public List<Action> playactions;

        public int enemycarddraw;
        public int enemyAnzCards;

        public int spellpower;
        public int enemyspellpower;
        public int wehaveCounterspell;

        public bool nextSecretThisTurnCost0;
        public bool playedPreparation;
        public bool nextSpellThisTurnCost0;
        public bool nextMurlocThisTurnCostHealth;
        public bool nextSpellThisTurnCostHealth;

        public int anzOwnLoatheb;
        public int anzEnemyLoatheb;

        public int anzPintSizedSummoner;
        public int anzManaWraith;
        public int anzVentureCoMercenary;
        public int anzSummoningPortal;
        public int myCardsCostLess;
        public int allSpellCostLess;
        public int anzNerubarWeblord;

        public bool startedWithDamagedMinions; // needed for manacalculation of the spell "Crush"

        public int ownWeaponAttackStarted;
        public int ownMobsCountStarted;
        public int ownCardsCountStarted;
        public int enemyCardsCountStarted;
        public int enemyMobsCountStarted;
        public int ownHeroHpStarted;
        public int enemyHeroHpStarted;

        public int mobsPlayedThisTurn;
        public int startedWithMobsPlayedThisTurn;
        public int spellsplayedSinceRecalc;
        public int secretsplayedSinceRecalc;


        public int optionsPlayedThisTurn;
        public int cardsPlayedThisTurn;
        public int owedRecall; //=overload
        public int currentRecall;
        public int enemyRecall;
        public int enemyCurrentRecall;//only needed for enemys turn sim.

        public int enemyOptionsDoneThisTurn;

        public int ownMaxMana;
        public int enemyMaxMana;

        public int lostDamage;
        public int lostHeal;
        public int lostWeaponDamage;

        public int ownDeckSize;
        public int enemyDeckSize;
        public int ownHeroFatigue;
        public int enemyHeroFatigue;

        public int heroPowerActivationsThisTurn;//new----------
        public int lockAndLoads;//new------------

        public bool ownAbilityReady;
        public Handmanager.Handcard ownHeroAblility;
        public int ownHeroPowerUses;//new----------

        public bool enemyAbilityReady;
        public Handmanager.Handcard enemyHeroAblility;
        public int enemyHeroPowerUses;//new----------

        // just for saving which minion to revive with secrets (=the first one that died);
        public CardDB.cardIDEnum revivingOwnMinion;
        public CardDB.cardIDEnum revivingEnemyMinion;
        public CardDB.cardIDEnum OwnLastDiedMinion;

        public int shadowmadnessed; //minions has switched controllers this turn.
        public int ownSpellsPlayedThisGame; //todo sepefeets - finish this in hrtprozis for yogg/arcanegolem and check cthun stuff too
        //todo sepefeets - a lot of these vars could be triggers in sims? only invisible things need to be tracked


        //Helpfunctions help = Helpfunctions.Instance;

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
            shadowmadnessed = 0;
            OwnLastDiedMinion = CardDB.cardIDEnum.None;
            revivingEnemyMinion = CardDB.cardIDEnum.None;
            revivingOwnMinion = CardDB.cardIDEnum.None;
            enemyDeckSize = 30;
            ownDeckSize = 30;
            enemyHeroHpStarted = 30;
            ownHeroHpStarted = 30;
            enemyCardsCountStarted = 0;
            ownCardsCountStarted = 0;
            ownWeaponAttackStarted = 0;
            startedWithDamagedMinions = false;
            allSpellCostLess = 0;
            myCardsCostLess = 0;
            wehaveCounterspell = 0;
            playactions = new List<Action>();
            owncards = new List<Handmanager.Handcard>();
            enemyMinions = new List<Minion>();
            ownMinions = new List<Minion>();
            enemyWeaponCard = new CardDB.Card();
            enemyWeaponName = CardDB.cardName.unknown;
            ownWeaponCard = new CardDB.Card();
            ownWeaponName = CardDB.cardName.unknown;
            enemyHeroStartClass = TAG_CLASS.INVALID;
            ownHeroStartClass = TAG_CLASS.INVALID;
            enemyHeroName = HeroEnum.None;
            ownHeroName = HeroEnum.None;
            enemySecretList = new List<SecretItem>();
            ownSecretsIDList = new List<CardDB.cardIDEnum>();
            value = Int32.MinValue;
            hashcode = 0;
            attackFaceHP = 15;
            isOwnTurn = true;
            selectedChoice = -1;
            lockandload = 0;
            ownMistcaller = 0;
            enemyMinionsDiedTurn = 0;
            ownMinionsDiedTurn = 0;
            anzOwnTaunt = 0;
            anzEnemyTaunt = 0;
            embracetheshadow = 0;
            blackwaterpirateStarted = 0;
            anzBlackwaterPirate = 0;
            anzUsedOwnHeroPower = 0;
            enemyHeroPowerAllowedQuantity = 1;
            ownHeroPowerAllowedQuantity = 1;
            enemyHeroPowerExtraDamage = 0;
            ownHeroPowerExtraDamage = 0;
            anzEnemyHorsemen = 0;
            anzOwnHorsemen = 0;
            anzEnemyBolfRamshield = 0;
            anzOwnBolfRamshield = 0;
            anzEnemyChromaggus = 0;
            anzOwnChromaggus = 0;
            anzOwnMurlocStarted = 0;
            anzOwnPiratesStarted = 0;
            anzEnemysorcerersapprenticeStarted = 0;
            anzOwnsorcerersapprenticeStarted = 0;
            nextEntity = 70;
            logging = false;
            this.nextEntity = 1000;
            //this.simulateEnemyTurn = Ai.Instance.simulateEnemyTurn;
            this.ownController = prozis.getOwnController();

            //this.ownHeroEntity = Hrtprozis.Instance.ownHeroEntity;
            //this.enemyHeroEntity = Hrtprozis.Instance.enemyHeroEntitiy;

            this.mana = prozis.currentMana;
            this.manaTurnEnd = this.mana;
            this.numEnemySecretsTurnEnd = 0;
            this.ownMaxMana = prozis.ownMaxMana;
            this.enemyMaxMana = prozis.enemyMaxMana;
            this.evaluatePenality = 0;
            this.ownSecretsIDList.AddRange(prozis.ownSecretList);
            this.enemySecretCount = prozis.enemySecretCount;

            this.anzOgOwnCThunAngrBonus = prozis.anzOgOwnCThunAngrBonus;
            this.anzOgOwnCThunHpBonus = prozis.anzOgOwnCThunHpBonus;
            this.anzOgOwnCThunTaunt = prozis.anzOgOwnCThunTaunt;
            this.anzOwnJadeGolem = prozis.anzOwnJadeGolem;
            this.anzEnemyJadeGolem = prozis.anzEnemyJadeGolem;

            this.ownVioletIllusionist = 0;
            this.enemyVioletIllusionist = 0;
            this.anzOwnCloakedHuntress = 0;

            this.attackFaceHP = prozis.attackFaceHp;

            this.complete = false;

            addMinionsReal(prozis.ownMinions, ownMinions);
            addMinionsReal(prozis.enemyMinions, enemyMinions);
            this.ownHero = new Minion(prozis.ownHero);
            this.enemyHero = new Minion(prozis.enemyHero);
            addCardsReal(Handmanager.Instance.handCards);

            this.enemySecretList.Clear();
            if (Settings.Instance.useSecretsPlayArround)
            {
                foreach (SecretItem si in Probabilitymaker.Instance.enemySecrets)
                {
                    this.enemySecretList.Add(new SecretItem(si));
                }
            }

            this.ownHeroName = prozis.heroname;
            this.enemyHeroName = prozis.enemyHeroname;


            //####buffs#############################

            this.anzOwnExtraAngrHp = 0;
            this.anzEnemyExtraAngrHp = 0;
            this.anzOwnRaidleader = 0;
            this.anzEnemyRaidleader = 0;
            this.anzOwnStormwindChamps = 0;
            this.anzEnemyStormwindChamps = 0;
            this.anzOwnTundrarhino = 0;
            this.anzEnemyTundrarhino = 0;
            this.anzOwnTimberWolfs = 0;
            this.anzEnemyTimberWolfs = 0;
            this.anzOwnMurlocWarleader = 0;
            this.anzEnemyMurlocWarleader = 0;
            this.anzOwnGrimscaleOracle = 0;
            this.anzEnemyGrimscaleOracle = 0;
            this.anzOwnAuchenaiSoulpriest = 0;
            this.anzEnemyAuchenaiSoulpriest = 0;
            this.anzOwnSorcerersApprentice = 0;
            this.anzEnemysorcerersapprentice = 0;
            this.anzOwnSouthseacaptain = 0;
            this.anzEnemySouthseacaptain = 0;
            this.anzOwnWarsongCommanders = 0;
            this.anzEnemyWarsongCommanders = 0;
            this.anzOwnNagaSeaWitch = 0;
            this.anzEnemyNagaSeaWitch = 0;

            this.feugenDead = Probabilitymaker.Instance.feugenDead;
            this.stalaggDead = Probabilitymaker.Instance.stalaggDead;

            this.ownSpiritclaws = false;
            this.enemySpiritclaws = false;

            this.doublepriest = 0;
            this.enemydoublepriest = 0;

            this.anzOwnDragonConsort = prozis.ownDragonConsort;
            this.anzEnemyDragonConsort = prozis.enemyDragonConsort;

            //tgt---new
            this.anzOwnMillhouseManastorm = (prozis.ownMillhouse >= 1) ? true : false;//CHANGED!!!
            this.anzEnemyMillhouseManastorm = (prozis.enemyMillhouse >= 1) ? true : false; //CHANGED!!!
            this.anzOwnLoatheb = prozis.ownLoatheb;//CHANGED!!!
            this.anzEnemyLoatheb = prozis.enemyLoatheb;//CHANGED!!!
            this.anzOwnSaboteur = prozis.ownSaboteur;
            this.anzEnemySaboteur = prozis.enemySaboteur;
            this.anzOwnFencingCoach = prozis.ownFenciCoaches;
            this.anzEnemyFencingCoach = 0; // dont needed yet. D:

            this.ownMobsCountStarted = this.ownMinions.Count;
            this.enemyMobsCountStarted = this.enemyMinions.Count;

            this.nextSecretThisTurnCost0 = (prozis.nextSecretThisTurnCost0>=1)? true:false;
            this.playedPreparation = (prozis.ownPreparation >= 1) ? true : false;
            this.nextSpellThisTurnCost0 = false;
            this.nextMurlocThisTurnCostHealth = false;
            this.nextSpellThisTurnCostHealth = false;

            this.ownBaronRivendare = 0;
            this.enemyBaronRivendare = 0;
            //#########################################

            this.ownWeaponDurability = prozis.heroWeaponDurability;
            this.ownWeaponAttack = prozis.heroWeaponAttack;
            this.ownWeaponName = prozis.ownHeroWeapon;
            this.owncarddraw = 0;


            this.enemyWeaponAttack = prozis.enemyWeaponAttack;//dont know jet
            this.enemyWeaponName = prozis.enemyHeroWeapon;
            this.enemyWeaponDurability = prozis.enemyWeaponDurability;
            this.enemycarddraw = 0;

            this.enemyAnzCards = Handmanager.Instance.enemyAnzCards;

            this.ownAbilityReady = prozis.ownAbilityisReady;
            this.ownHeroAblility = new Handmanager.Handcard(prozis.heroAbility);
            this.enemyHeroAblility = new Handmanager.Handcard(prozis.enemyAbility);
            this.enemyAbilityReady = false;

            this.ownHeroPowerUses = prozis.ownHeroPowerUsesThisGame;
            this.enemyHeroPowerUses = prozis.enemyHeroPowerUsesThisGame;
            this.heroPowerActivationsThisTurn = prozis.heroPowerUsesThisTurn;
            this.lockAndLoads = prozis.lockAndLoads;


            this.mobsPlayedThisTurn = prozis.numMinionsPlayedThisTurn;
            this.cardsPlayedThisTurn = prozis.cardsPlayedThisTurn;
            this.spellsplayedSinceRecalc = 0;
            this.secretsplayedSinceRecalc = 0;
            //todo:
            this.optionsPlayedThisTurn = prozis.numOptionsPlayedThisTurn;

            this.owedRecall = prozis.owedRecall;
            this.currentRecall = prozis.ownCurrentRecall;
            this.enemyRecall = prozis.enemyRecall;
            this.enemyCurrentRecall = 0;

            this.ownHeroFatigue = prozis.ownHeroFatigue;
            this.enemyHeroFatigue = prozis.enemyHeroFatigue;
            this.ownDeckSize = prozis.ownDeckSize;
            this.enemyDeckSize = prozis.enemyDeckSize;

            this.anzEnemyCursed = prozis.enemyCursedCardsinHand;


            this.selectedChoice = -1;

            this.anzPintSizedSummoner = 0;
            this.anzManaWraith = 0;
            this.anzVentureCoMercenary = 0;
            this.anzSummoningPortal = 0;
            this.anzNerubarWeblord = 0;

            this.ownBaronRivendare = 0;
            this.enemyBaronRivendare = 0;

            needGraveyard = false;

            anzOwnGarrisonCommander = 0;
            anzEnemyGarrisonCommander = 0;
            anzOwnFallenHeros = 0;
            anzEnemyFallenHeros = 0;
            anzOwnShadowfiends = 0;
            anzEnemyShadowfiends = 0;
            anzOwnFizzlebang = 0;
            anzEnemyFizzlebang = 0;
            anzOwnBuccaneer = 0;
            anzEnemyBuccaneer = 0;
            anzEnemyAviana = 0;
            anzAcidmaw = 0;
            anzOwnWarhorseTrainer = 0;
            anzEnemyWarhorseTrainer = 0;
            anzOwnMaidenOfTheLake = 0;
            anzEnemyMaidenOfTheLake = 0;
            anzOwnBranns = 0;
            anzEnemyBranns = 0;
            anzOwnFandralStaghelm = 0;

            anzOwnAnimatedArmor = 0;
            anzEnemyAnimatedArmor = 0;

            this.spellpower = 0;
            this.enemyspellpower = 0;

            int i = -1;
            int anz = this.ownMinions.Count;
            foreach (Minion m in this.ownMinions)
            {
                //todo sepefeets - convert this to a switch
                i++;
                if (m.playedThisTurn && m.name == CardDB.cardName.loatheb) this.anzOwnLoatheb ++;

                spellpower = spellpower + m.spellpower;
                if (m.silenced) continue;
                //spellpower += m.handcard.card.spellpowervalue; // its allready in m.spellpower! (if you are updating it in silverfish.getMinions() :P)

                switch (m.name) //todo sepefeets - add all these
                {/*
                    case CardDB.cardName.blackwaterpirate:
                        this.blackwaterpirate++;
                        this.blackwaterpirateStarted++;
                        continue;
                    case CardDB.cardName.chogall:
                        if (m.playedThisTurn && this.cardsPlayedThisTurn == this.mobsplayedThisTurn) this.nextSpellThisTurnCostHealth = true;
                        continue;
                    case CardDB.cardName.seadevilstinger:
                        if (m.playedThisTurn && this.cardsPlayedThisTurn == this.mobsplayedThisTurn) this.nextMurlocThisTurnCostHealth = true;
                        continue;*/
                    case CardDB.cardName.prophetvelen:
                        this.doublepriest++;
                        continue;
                    case CardDB.cardName.weespellstopper:
                        if (i > 0) this.ownMinions[i - 1].cantBeTargetedBySpellsOrHeroPowers = true;
                        if (i < anz - 1) this.ownMinions[i + 1].cantBeTargetedBySpellsOrHeroPowers = true;
                        continue;
                    case CardDB.cardName.faeriedragon:
                    case CardDB.cardName.laughingsister:
                    case CardDB.cardName.spectralknight:
                    case CardDB.cardName.arcanenullifierx21:
                    case CardDB.cardName.soggoththeslitherer:
                        m.cantBeTargetedBySpellsOrHeroPowers = true;
                        continue;
                    case CardDB.cardName.pintsizedsummoner:
                        this.anzPintSizedSummoner++;
                        continue;
                    case CardDB.cardName.manawraith:
                        this.anzManaWraith++;
                        continue;
                    case CardDB.cardName.nerubarweblord:
                        this.anzNerubarWeblord++;
                        continue;
                    case CardDB.cardName.venturecomercenary:
                        this.anzVentureCoMercenary++;
                        continue;
                    case CardDB.cardName.summoningportal:
                        this.anzSummoningPortal++;
                        continue;
                    case CardDB.cardName.baronrivendare:
                        this.ownBaronRivendare++;
                        continue;
                    case CardDB.cardName.kelthuzad:
                        this.needGraveyard = true;
                        continue;
                    case CardDB.cardName.coldarradrake:
                        this.anzOwnGarrisonCommander += 1000;
                        continue;
                    case CardDB.cardName.garrisoncommander:
                        this.anzOwnGarrisonCommander++;
                        continue;
                    case CardDB.cardName.fallenhero:
                        this.anzOwnFallenHeros++;
                        continue;
                    case CardDB.cardName.shadowfiend:
                        this.anzOwnShadowfiends++;
                        continue;
                    case CardDB.cardName.wilfredfizzlebang:
                        this.anzOwnFizzlebang++;
                        continue;
                    case CardDB.cardName.buccaneer:
                        this.anzOwnBuccaneer++;
                        continue;
                    case CardDB.cardName.aviana:
                        this.anzOwnAviana++;
                        continue;
                    case CardDB.cardName.acidmaw:
                        this.anzAcidmaw++;
                        continue;
                    case CardDB.cardName.warhorsetrainer:
                        this.anzOwnWarhorseTrainer++;
                        continue;
                    case CardDB.cardName.maidenofthelake:
                        this.anzOwnMaidenOfTheLake++;
                        continue;
                    case CardDB.cardName.warsongcommander:
                        this.anzOwnWarsongCommanders++;
                        continue;
                    case CardDB.cardName.raidleader:
                    case CardDB.cardName.leokk:
                        this.anzOwnRaidleader++;
                        continue;
                    case CardDB.cardName.malganis:
                        this.anzOwnMalGanis++;
                        continue;
                    case CardDB.cardName.stormwindchampion:
                        this.anzOwnStormwindChamps++;
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
                    case CardDB.cardName.grimscaleoracle:
                        this.anzOwnGrimscaleOracle++;
                        continue;
                    case CardDB.cardName.auchenaisoulpriest:
                        anzOwnAuchenaiSoulpriest++;
                        continue;
                    case CardDB.cardName.nagaseawitch:
                        this.anzOwnNagaSeaWitch++;
                        continue;
                    case CardDB.cardName.brannbronzebeard:
                        this.anzOwnBranns++;
                        continue;
                    case CardDB.cardName.fandralstaghelm:
                        this.anzOwnFandralStaghelm++;
                        continue;
                    case CardDB.cardName.animatedarmor:
                        this.anzOwnAnimatedArmor++;
                        continue;
                    case CardDB.cardName.sorcerersapprentice:
                        this.anzOwnSorcerersApprentice++;
                        continue;
                    case CardDB.cardName.southseacaptain:
                        this.anzOwnSouthseacaptain++;
                        continue;
                    case CardDB.cardName.mechwarper:
                        this.anzOwnMechwarper++;
                        this.anzOwnMechwarperStarted++;
                        continue;
                    case CardDB.cardName.steamwheedlesniper:
                        if (this.ownHeroAblility.card.name == CardDB.cardName.steadyshot || this.ownHeroAblility.card.name == CardDB.cardName.ballistashot)
                        {
                            this.weHaveSteamwheedleSniper = true;
                        }
                        continue;
                    case CardDB.cardName.cloakedhuntress:
                        this.anzOwnCloakedHuntress++;
                        continue;
                    case CardDB.cardName.violetillusionist:
                        this.ownVioletIllusionist++;
                        continue;
                }

            }

            foreach (Handmanager.Handcard hc in this.owncards)
            {
                if (hc.card.name == CardDB.cardName.kelthuzad)
                {
                    this.needGraveyard = true;
                }
            }

            i = - 1;
            anz = this.enemyMinions.Count;
            foreach (Minion m in this.enemyMinions)
            {
                i++;
                this.enemyspellpower = this.enemyspellpower + m.spellpower;
                //enemyspellpower += m.handcard.card.spellpowervalue;//its allready in m.spellpower!!!
                
                if (m.silenced) continue;

                switch (m.name)
                {
                    case CardDB.cardName.prophetvelen:
                        this.enemydoublepriest++;
                        continue;
                    case CardDB.cardName.weespellstopper:
                        if (i > 0) this.ownMinions[i - 1].cantBeTargetedBySpellsOrHeroPowers = true;
                        if (i < anz - 1) this.ownMinions[i + 1].cantBeTargetedBySpellsOrHeroPowers = true;
                        continue;
                    case CardDB.cardName.faeriedragon:
                    case CardDB.cardName.laughingsister:
                    case CardDB.cardName.spectralknight:
                    case CardDB.cardName.arcanenullifierx21:
                    case CardDB.cardName.soggoththeslitherer:
                        m.cantBeTargetedBySpellsOrHeroPowers = true;
                        continue;
                    case CardDB.cardName.manawraith:
                        this.anzManaWraith++;
                        continue;
                    case CardDB.cardName.nerubarweblord:
                        this.anzNerubarWeblord++;
                        continue;
                    case CardDB.cardName.baronrivendare:
                        this.enemyBaronRivendare++;
                        continue;
                    case CardDB.cardName.kelthuzad:
                        this.needGraveyard = true;
                        continue;
                    case CardDB.cardName.coldarradrake:
                        this.anzEnemyGarrisonCommander += 1000;
                        continue;
                    case CardDB.cardName.garrisoncommander:
                        this.anzEnemyGarrisonCommander++;
                        continue;
                    case CardDB.cardName.fallenhero:
                        this.anzEnemyFallenHeros++;
                        continue;
                    case CardDB.cardName.shadowfiend:
                        this.anzEnemyShadowfiends++;
                        continue;
                    case CardDB.cardName.wilfredfizzlebang:
                        this.anzEnemyFizzlebang++;
                        continue;
                    case CardDB.cardName.buccaneer:
                        this.anzEnemyBuccaneer++;
                        continue;
                    case CardDB.cardName.aviana:
                        this.anzEnemyAviana++;
                        continue;
                    case CardDB.cardName.acidmaw:
                        this.anzAcidmaw++;
                        continue;
                    case CardDB.cardName.warhorsetrainer:
                        this.anzEnemyWarhorseTrainer++;
                        continue;
                    case CardDB.cardName.maidenofthelake:
                        this.anzEnemyMaidenOfTheLake++;
                        continue;
                    case CardDB.cardName.warsongcommander:
                        this.anzEnemyWarsongCommanders++;
                        continue;
                    case CardDB.cardName.raidleader:
                    case CardDB.cardName.leokk:
                        this.anzEnemyRaidleader++;
                        continue;
                    case CardDB.cardName.malganis:
                        this.anzEnemyMalGanis++;
                        continue;
                    case CardDB.cardName.stormwindchampion:
                        this.anzEnemyStormwindChamps++;
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
                    case CardDB.cardName.grimscaleoracle:
                        this.anzEnemyGrimscaleOracle++;
                        continue;
                    case CardDB.cardName.auchenaisoulpriest:
                        anzEnemyAuchenaiSoulpriest++;
                        continue;
                    case CardDB.cardName.nagaseawitch:
                        this.anzEnemyNagaSeaWitch++;
                        continue;
                    case CardDB.cardName.brannbronzebeard:
                        this.anzEnemyBranns++;
                        continue;
                    case CardDB.cardName.animatedarmor:
                        this.anzEnemyAnimatedArmor++;
                        continue;
                    case CardDB.cardName.sorcerersapprentice:
                        this.anzEnemysorcerersapprentice++;
                        continue;
                    case CardDB.cardName.southseacaptain:
                        this.anzEnemySouthseacaptain++;
                        continue;
                    case CardDB.cardName.mechwarper:
                        this.anzEnemyMechwarper++;
                        this.anzEnemyMechwarperStarted++;
                        continue;
                    case CardDB.cardName.steamwheedlesniper:
                        if (this.ownHeroAblility.card.name == CardDB.cardName.steadyshot || this.ownHeroAblility.card.name == CardDB.cardName.ballistashot)
                        {
                            this.enemyHaveSteamwheedleSniper = true;
                        }
                        continue;
                    case CardDB.cardName.violetillusionist:
                        this.enemyVioletIllusionist++;
                        continue;
                }

            }

            if (this.spellpower > 0 && this.ownWeaponName == CardDB.cardName.spiritclaws) this.ownSpiritclaws = true;
            if (this.enemyspellpower > 0 && this.enemyWeaponName == CardDB.cardName.spiritclaws) this.enemySpiritclaws = true;

            if (this.enemySecretCount >= 1) this.needGraveyard = true;
            if (this.needGraveyard) this.diedMinions = new List<GraveYardItem>(Probabilitymaker.Instance.turngraveyard);
            this.anzMinionsDiedThisTurn = prozis.numberMinionsDiedThisTurn;

            this.tempanzOwnCards = this.owncards.Count;
            this.tempanzEnemyCards = this.enemyAnzCards;

            //calculate the "real"-manacosts of a card
            foreach (Handmanager.Handcard hm in this.owncards)
            {
                hm.manacost = hm.card.getStartManaCosts(this, hm.manacost);
            }


        }

        public Playfield(Playfield p)
        {
            revivingEnemyMinion = CardDB.cardIDEnum.None;
            revivingOwnMinion = CardDB.cardIDEnum.None;
            enemyDeckSize = 30;
            ownDeckSize = 30;
            allSpellCostLess = 0;
            myCardsCostLess = 0;
            wehaveCounterspell = 0;
            playactions = new List<Action>();
            owncards = new List<Handmanager.Handcard>();
            enemyMinions = new List<Minion>();
            ownMinions = new List<Minion>();
            enemyWeaponCard = new CardDB.Card();
            enemyWeaponName = CardDB.cardName.unknown;
            ownWeaponCard = new CardDB.Card();
            ownWeaponName = CardDB.cardName.unknown;
            enemyHeroStartClass = TAG_CLASS.INVALID;
            ownHeroStartClass = TAG_CLASS.INVALID;
            enemyHeroName = HeroEnum.None;
            ownHeroName = HeroEnum.None;
            enemySecretList = new List<SecretItem>();
            ownSecretsIDList = new List<CardDB.cardIDEnum>();
            value = Int32.MinValue;
            hashcode = 0;
            attackFaceHP = 15;
            isOwnTurn = true;
            selectedChoice = -1;
            enemyMinionsDiedTurn = 0;
            ownMinionsDiedTurn = 0;
            anzEnemyTaunt = 0;
            anzBlackwaterPirate = 0;
            anzUsedOwnHeroPower = 0;
            enemyHeroPowerExtraDamage = 0;
            ownHeroPowerExtraDamage = 0;
            anzEnemyBolfRamshield = 0;
            anzOwnBolfRamshield = 0;
            anzEnemyChromaggus = 0;
            anzOwnChromaggus = 0;
            nextEntity = 70;
            logging = false;
            this.nextEntity = p.nextEntity;

            this.isOwnTurn = p.isOwnTurn;
            this.turnCounter = p.turnCounter;

            this.anzOgOwnCThunAngrBonus = p.anzOgOwnCThunAngrBonus;
            this.anzOgOwnCThunHpBonus = p.anzOgOwnCThunHpBonus;
            this.anzOgOwnCThunTaunt = p.anzOgOwnCThunTaunt;
            this.anzOwnJadeGolem = p.anzOwnJadeGolem;
            this.anzEnemyJadeGolem = p.anzEnemyJadeGolem;

            this.attacked = p.attacked;
            this.sEnemTurn = p.sEnemTurn;
            this.ownController = p.ownController;
            //this.ownHeroEntity = p.ownHeroEntity;
            //this.enemyHeroEntity = p.enemyHeroEntity;

            this.evaluatePenality = p.evaluatePenality;
            this.ownSecretsIDList.AddRange(p.ownSecretsIDList);

            this.enemySecretCount = p.enemySecretCount;

            this.enemySecretList.Clear();
            if (Settings.Instance.useSecretsPlayArround)
            {
                foreach (SecretItem si in p.enemySecretList)
                {
                    this.enemySecretList.Add(new SecretItem(si));
                }
            }

            this.mana = p.mana;
            this.manaTurnEnd = p.manaTurnEnd;
            this.numEnemySecretsTurnEnd = p.numEnemySecretsTurnEnd;
            this.ownMaxMana = p.ownMaxMana;
            this.enemyMaxMana = p.enemyMaxMana;
            addMinionsReal(p.ownMinions, ownMinions);
            addMinionsReal(p.enemyMinions, enemyMinions);
            this.ownHero = new Minion(p.ownHero);
            this.enemyHero = new Minion(p.enemyHero);
            addCardsReal(p.owncards);

            this.ownHeroName = p.ownHeroName;
            this.enemyHeroName = p.enemyHeroName;

            this.playactions.AddRange(p.playactions);
            this.complete = false;

            this.attackFaceHP = p.attackFaceHP;

            this.owncarddraw = p.owncarddraw;

            this.enemyWeaponAttack = p.enemyWeaponAttack;
            this.enemyWeaponDurability = p.enemyWeaponDurability;
            this.enemyWeaponName = p.enemyWeaponName;
            this.enemycarddraw = p.enemycarddraw;
            this.enemyAnzCards = p.enemyAnzCards;

            this.ownWeaponDurability = p.ownWeaponDurability;
            this.ownWeaponAttack = p.ownWeaponAttack;
            this.ownWeaponName = p.ownWeaponName;

            this.lostDamage = p.lostDamage;
            this.lostWeaponDamage = p.lostWeaponDamage;
            this.lostHeal = p.lostHeal;

            this.ownAbilityReady = p.ownAbilityReady;
            this.enemyAbilityReady = p.enemyAbilityReady;
            this.ownHeroAblility = new Handmanager.Handcard(p.ownHeroAblility);
            this.enemyHeroAblility = new Handmanager.Handcard(p.enemyHeroAblility);

            //tgt new
            this.ownHeroPowerUses = p.ownHeroPowerUses;
            this.enemyHeroPowerUses = p.enemyHeroPowerUses;
            this.heroPowerActivationsThisTurn = p.heroPowerActivationsThisTurn;
            this.lockAndLoads = p.lockAndLoads;
            this.anzOwnSaboteur = p.anzOwnSaboteur;//dont ask...
            this.anzEnemySaboteur = p.anzEnemySaboteur;//dont ask... :D
            this.anzOwnFencingCoach = p.anzOwnFencingCoach;
            this.anzEnemyFencingCoach = p.anzEnemyFencingCoach; // dont needed yet. D:
            //---

            this.spellpower = 0;
            this.mobsPlayedThisTurn = p.mobsPlayedThisTurn;
            this.startedWithMobsPlayedThisTurn = p.startedWithMobsPlayedThisTurn;
            this.spellsplayedSinceRecalc = p.spellsplayedSinceRecalc;
            this.secretsplayedSinceRecalc = p.secretsplayedSinceRecalc;
            this.optionsPlayedThisTurn = p.optionsPlayedThisTurn;
            this.cardsPlayedThisTurn = p.cardsPlayedThisTurn;
            this.owedRecall = p.owedRecall;
            this.currentRecall = p.currentRecall;
            this.enemyRecall = p.enemyRecall;
            this.enemyCurrentRecall = p.enemyCurrentRecall;

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
            this.nextSpellThisTurnCostHealth = p.nextSpellThisTurnCostHealth;


            this.anzNerubarWeblord = p.anzNerubarWeblord;
            this.anzPintSizedSummoner = p.anzPintSizedSummoner;
            this.anzManaWraith = p.anzManaWraith;
            this.anzVentureCoMercenary = p.anzVentureCoMercenary;
            this.anzOwnLoatheb = p.anzOwnLoatheb;
            this.anzEnemyLoatheb = p.anzEnemyLoatheb;

            this.spellpower = p.spellpower;
            this.enemyspellpower = p.enemyspellpower;

            this.needGraveyard = p.needGraveyard;
            if (p.needGraveyard) this.diedMinions = new List<GraveYardItem>(p.diedMinions);

            this.anzEnemyCursed = p.anzEnemyCursed;

            //####buffs#############################

            this.anzOwnRaidleader = p.anzOwnRaidleader;
            this.anzEnemyRaidleader = p.anzEnemyRaidleader;
            this.anzOwnMalGanis = p.anzOwnMalGanis;
            this.anzEnemyMalGanis = p.anzEnemyMalGanis;
            this.anzOwnStormwindChamps = p.anzOwnStormwindChamps;
            this.anzEnemyStormwindChamps = p.anzEnemyStormwindChamps;
            this.anzOwnTundrarhino = p.anzOwnTundrarhino;
            this.anzEnemyTundrarhino = p.anzEnemyTundrarhino;
            this.anzOwnTimberWolfs = p.anzOwnTimberWolfs;
            this.anzEnemyTimberWolfs = p.anzEnemyTimberWolfs;
            this.anzOwnMurlocWarleader = p.anzOwnMurlocWarleader;
            this.anzOwnGrimscaleOracle = p.anzOwnGrimscaleOracle;
            this.anzOwnAuchenaiSoulpriest = p.anzOwnAuchenaiSoulpriest;
            this.anzEnemyAuchenaiSoulpriest = p.anzEnemyAuchenaiSoulpriest;
            this.anzOwnSorcerersApprentice = p.anzOwnSorcerersApprentice;
            this.anzEnemysorcerersapprentice = p.anzEnemysorcerersapprentice;
            this.anzOwnSouthseacaptain = p.anzOwnSouthseacaptain;
            this.anzEnemySouthseacaptain = p.anzEnemySouthseacaptain;
            this.anzOwnMechwarper = p.anzOwnMechwarper;
            this.anzOwnMechwarperStarted = p.anzOwnMechwarperStarted;
            this.anzEnemyMechwarper = p.anzEnemyMechwarper;
            this.anzEnemyMechwarperStarted = p.anzEnemyMechwarperStarted;
            this.anzOwnWarsongCommanders = p.anzOwnWarsongCommanders;
            this.anzEnemyWarsongCommanders = p.anzEnemyWarsongCommanders;
            this.anzOwnExtraAngrHp = p.anzOwnExtraAngrHp;
            this.anzEnemyExtraAngrHp = p.anzEnemyExtraAngrHp;

            this.feugenDead = p.feugenDead;
            this.stalaggDead = p.stalaggDead;

            this.anzOwnMillhouseManastorm = p.anzOwnMillhouseManastorm;
            this.anzEnemyMillhouseManastorm = p.anzEnemyMillhouseManastorm;
            
            this.ownSpiritclaws = p.ownSpiritclaws;
            this.enemySpiritclaws = p.enemySpiritclaws;
            if (this.spellpower > 0 && this.ownWeaponName == CardDB.cardName.spiritclaws) this.ownSpiritclaws = true;
            if (this.enemyspellpower > 0 && this.enemyWeaponName == CardDB.cardName.spiritclaws) this.enemySpiritclaws = true;

            this.doublepriest = p.doublepriest;
            this.enemydoublepriest = p.enemydoublepriest;

            this.anzOwnDragonConsort = p.anzOwnDragonConsort;
            this.anzEnemyDragonConsort = p.anzEnemyDragonConsort;

            this.ownBaronRivendare = p.ownBaronRivendare;
            this.enemyBaronRivendare = p.enemyBaronRivendare;

            this.weHaveSteamwheedleSniper = p.weHaveSteamwheedleSniper;
            this.enemyHaveSteamwheedleSniper = p.enemyHaveSteamwheedleSniper;



            anzOwnGarrisonCommander = p.anzOwnGarrisonCommander;
            anzEnemyGarrisonCommander = p.anzEnemyGarrisonCommander;
            anzOwnFallenHeros = p.anzOwnFallenHeros;
            anzEnemyFallenHeros = p.anzEnemyFallenHeros;

            anzOwnShadowfiends = p.anzOwnShadowfiends;
            anzEnemyShadowfiends = p.anzEnemyShadowfiends;

            //tgt new-----
            anzOwnFizzlebang = p.anzOwnFizzlebang;
            anzEnemyFizzlebang = p.anzEnemyFizzlebang;
            anzOwnBuccaneer = p.anzOwnBuccaneer;
            anzEnemyBuccaneer = p.anzEnemyBuccaneer;
            anzOwnAviana = p.anzOwnAviana;
            anzEnemyAviana = p.anzEnemyAviana;
            anzAcidmaw = p.anzAcidmaw;
            anzOwnWarhorseTrainer = p.anzOwnWarhorseTrainer;
            anzEnemyWarhorseTrainer = p.anzEnemyWarhorseTrainer;
            anzOwnMaidenOfTheLake = p.anzOwnMaidenOfTheLake;
            anzEnemyMaidenOfTheLake = p.anzEnemyMaidenOfTheLake;

            //loe new---
            anzOwnBranns = p.anzOwnBranns;
            anzEnemyBranns = p.anzEnemyBranns;

            this.anzOwnNagaSeaWitch = p.anzOwnNagaSeaWitch;
            this.anzEnemyNagaSeaWitch = p.anzEnemyNagaSeaWitch;
            this.anzOwnAnimatedArmor = p.anzOwnAnimatedArmor ;
            this.anzEnemyAnimatedArmor = p.anzEnemyAnimatedArmor;
            //#########################################

            this.selectedChoice = p.selectedChoice;

            this.anzMinionsDiedThisTurn = p.anzMinionsDiedThisTurn;

            this.tempanzOwnCards = this.owncards.Count;
            this.tempanzEnemyCards = this.enemyAnzCards;

            this.ownSpellsPlayedThisGame = p.ownSpellsPlayedThisGame;

            this.ownVioletIllusionist = p.ownVioletIllusionist;
            this.enemyVioletIllusionist = p.enemyVioletIllusionist;
            this.anzOwnCloakedHuntress = p.anzOwnCloakedHuntress;
        }

        public void swapAll()
        {
            ////copied form dfreelan (thx :D)

            // minion counters----------------------------------------------------------------------

            Swap(ref anzOwnRaidleader, ref anzEnemyRaidleader);
            Swap(ref anzOwnStormwindChamps, ref anzEnemyStormwindChamps);
            Swap(ref anzOwnTundrarhino, ref anzEnemyTundrarhino);
            Swap(ref anzOwnTimberWolfs, ref anzEnemyTimberWolfs);
            //Swap(ref anzOwnMurlocWarleader, ref anzOwnMurlocWarleader);//dont need to swapped, we have one int for both players
            //Swap(ref anzOwnGrimscaleOracle, ref anzOwnGrimscaleOracle);//dont need to swapped, we have one int for both players
            Swap(ref anzOwnAuchenaiSoulpriest, ref anzEnemyAuchenaiSoulpriest);
            Swap(ref anzOwnSorcerersApprentice, ref anzEnemysorcerersapprentice);
            Swap(ref anzOwnSouthseacaptain, ref anzEnemySouthseacaptain);
            Swap(ref anzOwnMalGanis, ref anzEnemyMalGanis);
            Swap(ref anzOwnMechwarper, ref anzEnemyMechwarper);
            Swap(ref anzOwnMechwarperStarted, ref anzEnemyMechwarperStarted);
            Swap(ref anzOwnMillhouseManastorm, ref anzEnemyMillhouseManastorm);
            Swap(ref weHaveSteamwheedleSniper, ref enemyHaveSteamwheedleSniper);
            Swap(ref doublepriest, ref enemydoublepriest);
            Swap(ref anzOwnDragonConsort, ref anzEnemyDragonConsort);
            Swap(ref ownBaronRivendare, ref enemyBaronRivendare);

             //tgt new
             Swap(ref anzOwnGarrisonCommander, ref anzEnemyGarrisonCommander);
             Swap(ref anzOwnFallenHeros, ref anzEnemyFallenHeros);
             Swap(ref anzOwnShadowfiends, ref anzEnemyShadowfiends);
             Swap(ref anzOwnFizzlebang, ref anzEnemyFizzlebang);
             Swap(ref anzOwnBuccaneer, ref anzEnemyBuccaneer);
             Swap(ref anzOwnAviana, ref anzEnemyAviana);
             //Swap(ref anzOwnmaw, ref anzEnemymaw);//dont need to swapped, we have one int for both players
             Swap(ref anzOwnWarhorseTrainer, ref anzEnemyWarhorseTrainer);
             Swap(ref anzOwnMaidenOfTheLake, ref anzEnemyMaidenOfTheLake);





            Swap(ref tempanzOwnCards, ref tempanzEnemyCards);// for Goblin Sapper NEEDED?
            Swap(ref this.ownSecretsIDList, ref EnemySecretsIDList);
            enemySecretList.Clear();
            enemySecretCount = this.EnemySecretsIDList.Count;

            

            //TODO: feugenDead = false;
            //TODO: stalaggDead = false;

            //TODO: public bool needGraveyard = false;

            if(ownController == 1) 
            {
                ownController = 2;
            }
            else
            {
                ownController = 1;
            }

            Swap(ref enemyDeck, ref myDeck);
            //swap mana
            
             Swap(ref ownHero, ref enemyHero);
            Swap(ref ownHeroName, ref enemyHeroName);
            swapReferences(ownWeaponName, enemyWeaponName);
            Swap(ref ownWeaponAttack, ref enemyWeaponAttack);
            Swap(ref ownWeaponDurability, ref enemyWeaponDurability);

            // swap minions
            Swap(ref ownMinions, ref enemyMinions);

            if (diedMinions != null) diedMinions.Clear();
            Swap(ref owncards, ref EnemyCards);

            Swap(ref spellpower, ref enemyspellpower);
            Swap(ref anzOwnLoatheb, ref anzEnemyLoatheb);

            anzOwnLoatheb = 0;
            Swap(ref ownMaxMana, ref enemyMaxMana);

            anzMinionsDiedThisTurn = 0;
            owncarddraw = 0;
            enemycarddraw = 0;
            playactions.Clear();
            enemyAnzCards = owncards.Count;

            nextSecretThisTurnCost0 = false;
            playedPreparation = false;
            anzPintSizedSummoner = 0;

            //managespenst = 0;
            

        mobsPlayedThisTurn = 0;
        optionsPlayedThisTurn = 0;
        cardsPlayedThisTurn = 0;

        /*public int owedRecall = 0; //=recall
        public int currentRecall = 0;
        public int enemyRecall = 0;
        public int enemyCurrentRecall = 0;//only needed for enemys turn sim.
            */

            heroPowerActivationsThisTurn = 0;

        lostDamage = 0;
        lostHeal = 0;
        lostWeaponDamage = 0;
        Swap(ref ownDeckSize, ref enemyDeckSize);
        
            
        Swap(ref ownHeroFatigue, ref enemyHeroFatigue);

        ownAbilityReady = true;
        enemyAbilityReady = true;

        //tgt---
        Swap(ref ownHeroAblility, ref enemyHeroAblility);
        Swap(ref ownHeroPowerUses, ref enemyHeroPowerUses);
        Swap(ref anzOwnSaboteur, ref anzEnemySaboteur);
        Swap(ref anzOwnFencingCoach, ref anzEnemyFencingCoach);
        //---

        // just for saving which minion to revive with secrets (=the first one that died);
        swapReferences(revivingOwnMinion, revivingEnemyMinion);


            //count...
            anzVentureCoMercenary = 0;
            anzSummoningPortal = 0;
            anzNerubarWeblord = 0;


            foreach(Minion m in this.ownMinions)
            {
                m.own = true;
                if (m.silenced) continue;
                if (m.name == CardDB.cardName.nerubarweblord) anzNerubarWeblord++;
                if (m.name == CardDB.cardName.summoningportal) anzSummoningPortal++;
                if (m.name == CardDB.cardName.venturecomercenary) anzVentureCoMercenary++;
            }

            foreach (Minion m in this.enemyMinions)
            {
                m.own = false;
            }
        }
        static void Swap<T>(ref T lhs, ref T rhs)
        {
            T temp;
            temp = lhs;
            lhs = rhs;
            rhs = temp;
        }
        public void swapReferences(Object obj1, Object obj2)
        {
            Object temp = obj1;
            obj1 = obj2;
            obj2 = temp;
        }
        
        public void setDecksAndHands(List<Handmanager.Handcard> ownDeck, List<Handmanager.Handcard> oppDeck, List<Handmanager.Handcard> oppCards)
        {
            this.myDeck = new List<Handmanager.Handcard>(ownDeck);
            this.enemyDeck = new List<Handmanager.Handcard>(oppDeck);
            this.EnemyCards = new List<Handmanager.Handcard>(oppCards);
            this.EnemySecretsIDList = new List<CardDB.cardIDEnum>();
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

            if (this.cardsPlayedThisTurn != p.cardsPlayedThisTurn || this.mobsPlayedThisTurn != p.mobsPlayedThisTurn || this.owedRecall != p.owedRecall || this.ownAbilityReady != p.ownAbilityReady)
            {
                if (logg) Helpfunctions.Instance.logg("stuff changed " + this.cardsPlayedThisTurn + " " + p.cardsPlayedThisTurn + " " + this.mobsPlayedThisTurn + " " + p.mobsPlayedThisTurn + " " + this.owedRecall + " " + p.owedRecall + " " + this.ownAbilityReady + " " + p.ownAbilityReady);
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
            if (this.ownHero.Ready != p.ownHero.Ready || this.ownWeaponAttack != p.ownWeaponAttack || this.ownWeaponDurability != p.ownWeaponDurability || this.ownHero.numAttacksThisTurn != p.ownHero.numAttacksThisTurn || this.ownHero.windfury != p.ownHero.windfury)
            {
                if (logg) Helpfunctions.Instance.logg("weapon changed " + this.ownHero.Ready + " " + p.ownHero.Ready + " " + this.ownWeaponAttack + " " + p.ownWeaponAttack + " " + this.ownWeaponDurability + " " + p.ownWeaponDurability + " " + this.ownHero.numAttacksThisTurn + " " + p.ownHero.numAttacksThisTurn + " " + this.ownHero.windfury + " " + p.ownHero.windfury);
                return false;
            }
            if (this.enemyHero.Hp != p.enemyHero.Hp || this.enemyWeaponAttack != p.enemyWeaponAttack || this.enemyHero.armor != p.enemyHero.armor || this.enemyWeaponDurability != p.enemyWeaponDurability || this.enemyHero.frozen != p.enemyHero.frozen || this.enemyHero.immune != p.enemyHero.immune)
            {
                if (logg) Helpfunctions.Instance.logg("enemyhero changed " + this.enemyHero.Hp + " " + p.enemyHero.Hp + " " + this.enemyWeaponAttack + " " + p.enemyWeaponAttack + " " + this.enemyHero.armor + " " + p.enemyHero.armor + " " + this.enemyWeaponDurability + " " + p.enemyWeaponDurability + " " + this.enemyHero.frozen + " " + p.enemyHero.frozen + " " + this.enemyHero.immune + " " + p.enemyHero.immune);
                return false;
            }

            /*if (this.auchenaiseelenpriesterin != p.auchenaiseelenpriesterin || this.winzigebeschwoererin != p.winzigebeschwoererin || this.zauberlehrling != p.zauberlehrling || this.managespenst != p.managespenst || this.soeldnerDerVenture != p.soeldnerDerVenture || this.beschwoerungsportal != p.beschwoerungsportal || this.doublepriest != p.doublepriest)
            {
                Helpfunctions.Instance.logg("special minions changed " + this.auchenaiseelenpriesterin + " " + p.auchenaiseelenpriesterin + " " + this.winzigebeschwoererin + " " + p.winzigebeschwoererin + " " + this.zauberlehrling + " " + p.zauberlehrling + " " + this.managespenst + " " + p.managespenst + " " + this.soeldnerDerVenture + " " + p.soeldnerDerVenture + " " + this.beschwoerungsportal + " " + p.beschwoerungsportal + " " + this.doublepriest + " " + p.doublepriest);
                return false;
            }*/

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
                //if (dis.entitiyID == 0) dis.entitiyID = pis.entitiyID;
                //if (pis.entitiyID == 0) pis.entitiyID = dis.entitiyID;
                if (dis.entityID != pis.entityID) minionbool = false;
                if (dis.name != pis.name) minionbool = false;
                if (dis.Angr != pis.Angr || dis.Hp != pis.Hp || dis.maxHp != pis.maxHp || dis.numAttacksThisTurn != pis.numAttacksThisTurn) minionbool = false;
                if (dis.Ready != pis.Ready) minionbool = false; // includes frozen, exhaunted
                if (dis.playedThisTurn != pis.playedThisTurn) minionbool = false;
                if (dis.silenced != pis.silenced || dis.stealth != pis.stealth || dis.taunt != pis.taunt || dis.windfury != pis.windfury || dis.zonepos != pis.zonepos) minionbool = false;
                if (dis.divineshild != pis.divineshild || dis.cantLowerHPbelowONE != pis.cantLowerHPbelowONE || dis.immune != pis.immune) minionbool = false;
                if (dis.ownBlessingOfWisdom != pis.ownBlessingOfWisdom || dis.enemyBlessingOfWisdom != pis.enemyBlessingOfWisdom) minionbool = false;
                if (dis.ownPowerWordGlory != pis.ownPowerWordGlory || dis.enemyPowerWordGlory != pis.enemyPowerWordGlory) minionbool = false;
                if (dis.destroyOnEnemyTurnStart != pis.destroyOnEnemyTurnStart || dis.destroyOnEnemyTurnEnd != pis.destroyOnEnemyTurnEnd || dis.destroyOnOwnTurnEnd != pis.destroyOnOwnTurnEnd || dis.destroyOnOwnTurnStart != pis.destroyOnOwnTurnStart) minionbool = false;
                if (dis.ancestralspirit != pis.ancestralspirit || dis.souloftheforest != pis.souloftheforest) minionbool = false;

            }
            if (minionbool == false)
            {
                if (logg) Helpfunctions.Instance.logg("ownminions changed");
                return false;
            }

            for (int i = 0; i < this.enemyMinions.Count; i++)
            {
                Minion dis = this.enemyMinions[i]; Minion pis = p.enemyMinions[i];
                //if (dis.entitiyID == 0) dis.entitiyID = pis.entitiyID;
                //if (pis.entitiyID == 0) pis.entitiyID = dis.entitiyID;
                if (dis.entityID != pis.entityID) minionbool = false;
                if (dis.name != pis.name) minionbool = false;
                if (dis.Angr != pis.Angr || dis.Hp != pis.Hp || dis.maxHp != pis.maxHp || dis.numAttacksThisTurn != pis.numAttacksThisTurn) minionbool = false;
                if (dis.Ready != pis.Ready) minionbool = false; // includes frozen, exhaunted
                if (dis.playedThisTurn != pis.playedThisTurn) minionbool = false;
                if (dis.silenced != pis.silenced || dis.stealth != pis.stealth || dis.taunt != pis.taunt || dis.windfury != pis.windfury || dis.zonepos != pis.zonepos) minionbool = false;
                if (dis.divineshild != pis.divineshild || dis.cantLowerHPbelowONE != pis.cantLowerHPbelowONE || dis.immune != pis.immune) minionbool = false;
                if (dis.ownBlessingOfWisdom != pis.ownBlessingOfWisdom || dis.enemyBlessingOfWisdom != pis.enemyBlessingOfWisdom) minionbool = false;
                if (dis.ownPowerWordGlory != pis.ownPowerWordGlory || dis.enemyPowerWordGlory != pis.enemyPowerWordGlory) minionbool = false;
                if (dis.destroyOnEnemyTurnStart != pis.destroyOnEnemyTurnStart || dis.destroyOnEnemyTurnEnd != pis.destroyOnEnemyTurnEnd || dis.destroyOnOwnTurnEnd != pis.destroyOnOwnTurnEnd || dis.destroyOnOwnTurnStart != pis.destroyOnOwnTurnStart) minionbool = false;
                if (dis.ancestralspirit != pis.ancestralspirit || dis.souloftheforest != pis.souloftheforest) minionbool = false;
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

            // now we're sure the boards are equal, we are just updating entitys (for spawned stuff etc)

            for (int i = 0; i < this.ownMinions.Count; i++)
            {
                Minion dis = this.ownMinions[i]; Minion pis = p.ownMinions[i];
                if (dis.entityID != pis.entityID) Ai.Instance.updateEntitiy(pis.entityID, dis.entityID);

            }

            for (int i = 0; i < this.enemyMinions.Count; i++)
            {
                Minion dis = this.enemyMinions[i]; Minion pis = p.enemyMinions[i];
                if (dis.entityID != pis.entityID) Ai.Instance.updateEntitiy(pis.entityID, dis.entityID);

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
            if (Math.Abs(this.value - p.value) > 0) return false;

            if (this.ownMinions.Count != p.ownMinions.Count || this.enemyMinions.Count != p.enemyMinions.Count || this.owncards.Count != p.owncards.Count) return false;

            if (this.cardsPlayedThisTurn != p.cardsPlayedThisTurn || this.mobsPlayedThisTurn != p.mobsPlayedThisTurn || this.owedRecall != p.owedRecall || this.ownAbilityReady != p.ownAbilityReady) return false;

            if (this.mana != p.mana || this.enemyMaxMana != p.enemyMaxMana || this.ownMaxMana != p.ownMaxMana) return false;

            if (this.ownHeroName != p.ownHeroName || this.enemyHeroName != p.enemyHeroName || this.enemySecretCount != p.enemySecretCount) return false;

            if (this.ownHero.Hp != p.ownHero.Hp || this.ownHero.Angr != p.ownHero.Angr || this.ownHero.armor != p.ownHero.armor || this.ownHero.frozen != p.ownHero.frozen || this.ownHero.immuneWhileAttacking != p.ownHero.immuneWhileAttacking || this.ownHero.immune != p.ownHero.immune) return false;

            if (this.ownHero.Ready != p.ownHero.Ready || this.ownWeaponAttack != p.ownWeaponAttack || this.ownWeaponDurability != p.ownWeaponDurability || this.ownHero.numAttacksThisTurn != p.ownHero.numAttacksThisTurn || this.ownHero.windfury != p.ownHero.windfury) return false;

            if (this.enemyHero.Hp != p.enemyHero.Hp || this.enemyWeaponAttack != p.enemyWeaponAttack || this.enemyHero.armor != p.enemyHero.armor || this.enemyWeaponDurability != p.enemyWeaponDurability || this.enemyHero.frozen != p.enemyHero.frozen || this.enemyHero.immune != p.enemyHero.immune) return false;

            if (this.ownHeroAblility.card.name != p.ownHeroAblility.card.name || this.spellpower != p.spellpower) return false;

            bool minionbool = true;
            for (int i = 0; i < this.ownMinions.Count; i++)
            {
                Minion dis = this.ownMinions[i]; Minion pis = p.ownMinions[i];
                //if (dis.entitiyID == 0) dis.entitiyID = pis.entitiyID;
                //if (pis.entitiyID == 0) pis.entitiyID = dis.entitiyID;
                if (dis.entityID != pis.entityID && pis.entityID < 1000) minionbool = false;
                if (dis.Angr != pis.Angr || dis.Hp != pis.Hp || dis.maxHp != pis.maxHp || dis.numAttacksThisTurn != pis.numAttacksThisTurn) minionbool = false;
                if (dis.Ready != pis.Ready) minionbool = false; // includes frozen, exhaunted
                if (dis.playedThisTurn != pis.playedThisTurn) minionbool = false;
                if (dis.silenced != pis.silenced || dis.stealth != pis.stealth || dis.taunt != pis.taunt || dis.windfury != pis.windfury || dis.zonepos != pis.zonepos) minionbool = false;
                if (dis.divineshild != pis.divineshild || dis.cantLowerHPbelowONE != pis.cantLowerHPbelowONE || dis.immune != pis.immune) minionbool = false;
                if (dis.ownBlessingOfWisdom != pis.ownBlessingOfWisdom || dis.enemyBlessingOfWisdom != pis.enemyBlessingOfWisdom) minionbool = false;
                if (dis.ownPowerWordGlory != pis.ownPowerWordGlory || dis.enemyPowerWordGlory != pis.enemyPowerWordGlory) minionbool = false;
                if (dis.destroyOnEnemyTurnStart != pis.destroyOnEnemyTurnStart || dis.destroyOnEnemyTurnEnd != pis.destroyOnEnemyTurnEnd || dis.destroyOnOwnTurnEnd != pis.destroyOnOwnTurnEnd || dis.destroyOnOwnTurnStart != pis.destroyOnOwnTurnStart) minionbool = false;
                if (dis.ancestralspirit != pis.ancestralspirit || dis.souloftheforest != pis.souloftheforest) minionbool = false;
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
                if (dis.entityID != pis.entityID && pis.entityID < 1000) minionbool = false;
                if (dis.Angr != pis.Angr || dis.Hp != pis.Hp || dis.maxHp != pis.maxHp || dis.numAttacksThisTurn != pis.numAttacksThisTurn) minionbool = false;
                if (dis.Ready != pis.Ready) minionbool = false; // includes frozen, exhaunted
                if (dis.playedThisTurn != pis.playedThisTurn) minionbool = false;
                if (dis.silenced != pis.silenced || dis.stealth != pis.stealth || dis.taunt != pis.taunt || dis.windfury != pis.windfury || dis.zonepos != pis.zonepos) minionbool = false;
                if (dis.divineshild != pis.divineshild || dis.cantLowerHPbelowONE != pis.cantLowerHPbelowONE || dis.immune != pis.immune) minionbool = false;
                if (dis.ownBlessingOfWisdom != pis.ownBlessingOfWisdom || dis.enemyBlessingOfWisdom != pis.enemyBlessingOfWisdom) minionbool = false;
                if (dis.ownPowerWordGlory != pis.ownPowerWordGlory || dis.enemyPowerWordGlory != pis.enemyPowerWordGlory) minionbool = false;
                if (dis.destroyOnEnemyTurnStart != pis.destroyOnEnemyTurnStart || dis.destroyOnEnemyTurnEnd != pis.destroyOnEnemyTurnEnd || dis.destroyOnOwnTurnEnd != pis.destroyOnOwnTurnEnd || dis.destroyOnOwnTurnStart != pis.destroyOnOwnTurnStart) minionbool = false;
                if (dis.ancestralspirit != pis.ancestralspirit || dis.souloftheforest != pis.souloftheforest) minionbool = false;
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

        // get hand cards that came from the deck
        public List<Handmanager.Handcard> getNewHandCards(Playfield p)
        {
            //todo sepefeets - p needs to be the last board instead of the expected one
            List<Handmanager.Handcard> list = new List<Handmanager.Handcard>();

            foreach (var tcard in this.owncards)
            {
                bool match = false;
                foreach (var pcard in p.owncards)
                {
                    if (tcard.entity == pcard.entity) match = true;
                }
                foreach (var pmnn in p.ownMinions) // don't count minions that were returned to hand
                {
                    if (tcard.entity == pmnn.entityID) match = true;
                }
                if (!match) list.Add(tcard);
            }
            return list;
        }

        //todo sepefeets - we probably shouldn't override, move to new function like HB
        public override int GetHashCode()
        {
            int retval = 0;
            retval += 10000 * this.ownMinions.Count + 100 * this.enemyMinions.Count + 1000 * this.mana + 100000 * (this.ownHero.Hp + this.enemyHero.Hp);
            retval += this.owncards.Count + this.enemycarddraw + this.cardsPlayedThisTurn + this.mobsPlayedThisTurn + this.ownHero.Angr + this.ownHero.armor;
            retval += this.ownWeaponAttack + this.enemyWeaponDurability + this.anzOgOwnCThunAngrBonus;
            return retval;
        }
        public Int64 GetPHash()
        {
            Int64 retval = 0;
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
                                retval += a.target.entityID;
                            }
                            continue;
                        case actionEnum.attackWithMinion:
                            retval += a.own.entityID + a.target.entityID;
                            continue;
                        case actionEnum.attackWithHero:
                            retval += a.target.entityID;
                            continue;
                        case actionEnum.useHeroPower:
                            retval += 100;
                            if (a.target != null)
                            {
                                retval += a.target.entityID;
                            }
                            continue;
                    }
                }
                if (this.playactions[this.playactions.Count - 1].card != null && this.playactions[this.playactions.Count - 1].card.card.type == CardDB.cardtype.MOB) retval++;
                retval += this.manaTurnEnd;
            }
            retval += this.anzOgOwnCThunAngrBonus + this.anzOwnJadeGolem;
            retval *= 1000;

            foreach (Minion m in this.ownMinions)
            {
                retval += m.entityID + m.Angr + m.Hp + (m.taunt ? 1 : 0) + (m.divineshild ? 1 : 0) + (m.wounded ? 0 : 1);
            }
            retval *= 10000000;

            retval += 10000 * this.ownMinions.Count + 100 * this.enemyMinions.Count + 1000 * this.mana + 100000 * (this.ownHero.Hp + this.enemyHero.Hp) + this.owncards.Count + this.enemycarddraw + this.cardsPlayedThisTurn + this.mobsPlayedThisTurn + this.ownHero.Angr + this.ownHero.armor + this.ownWeaponAttack + this.enemyWeaponDurability + this.spellpower + this.enemyspellpower;
            return retval;
        }


        //stuff for playing around enemy aoes
        public void enemyPlaysAoe(int pprob, int pprob2)
        {
            if (this.anzEnemyLoatheb == 0)
            {
                Playfield p = new Playfield(this);
                float oldval = Ai.Instance.botBase.getPlayfieldValue(p);
                p.value = int.MinValue;
                p.EnemyCardPlaying(p.enemyHeroName, p.mana, p.enemyAnzCards, pprob, pprob2);
                float newval = Ai.Instance.botBase.getPlayfieldValue(p);
                p.value = int.MinValue;
                if (oldval > newval) // new board is better for enemy (value is smaller)
                {
                    this.copyValuesFrom(p);
                }
            }
        }

        public int EnemyCardPlaying(HeroEnum enemyHeroNamee, int currmana, int cardcount, int playAroundProb, int pap2)
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

            if (enemyHeroNamee == HeroEnum.warrior)
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

            switch (enemyHeroNamee)
            {
                case HeroEnum.mage:
                    mana = EnemyPlaysACard(CardDB.cardName.flamestrike, mana, playAroundProb, pap2);
                    mana = EnemyPlaysACard(CardDB.cardName.blizzard, mana, playAroundProb, pap2);
                    break;
                case HeroEnum.hunter:
                    mana = EnemyPlaysACard(CardDB.cardName.unleashthehounds, mana, playAroundProb, pap2);
                    break;
                case HeroEnum.priest:
                    mana = EnemyPlaysACard(CardDB.cardName.holynova, mana, playAroundProb, pap2);
                    break;
                case HeroEnum.shaman:
                    mana = EnemyPlaysACard(CardDB.cardName.lightningstorm, mana, playAroundProb, pap2);
                    mana = EnemyPlaysACard(CardDB.cardName.maelstromportal, mana, playAroundProb, pap2);
                    break;
                case HeroEnum.pala:
                    mana = EnemyPlaysACard(CardDB.cardName.consecration, mana, playAroundProb, pap2);
                    break;
                case HeroEnum.druid:
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
                                enemy.frozen = true;
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
                                this.minionGetDamageOrHeal(mnn, target != null && mnn.entityID == target.entityID ? damage4 : damage1);
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
        public List<Minion> getAttackTargets(bool own)
        {
            List<Minion> trgts = new List<Minion>();
            List<Minion> trgts2 = new List<Minion>();
            bool hasTaunts = false;
            if (own)
            {
                if (!this.enemyHero.immune) trgts2.Add(this.enemyHero);
                foreach (Minion m in this.enemyMinions)
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
            }
            else
            {

                foreach (Minion m in this.ownMinions)
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

                if (!this.ownHero.immune) trgts2.Add(this.ownHero);
                //if (trgts2.Count == 0 && !this.ownHero.immune) trgts2.Add(this.ownHero);
            }

            if (hasTaunts) return trgts;

            return trgts2;


        }

        public int getBestPlace(CardDB.Card card, bool lethal) //todo sepefeets - this function really sucks!!! consider total rewrite.
        {
            //we return the zonepos!
            if (card.type != CardDB.cardtype.MOB) return 1;
            int omCount = this.ownMinions.Count;

            if (omCount == 0) return 1;
            if (omCount == 1)
            {
                if (this.ownMinions[0].handcard.card.name == CardDB.cardName.flametonguetotem || this.ownMinions[0].handcard.card.name == CardDB.cardName.direwolfalpha) return 1;
                if (card.name == CardDB.cardName.impgangboss) return 1;
                return 2;
            }

            int[] places = new int[omCount]; //lower values = better places
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
                }
                if (givesBuff)
                {
                    if (omCount == 2) return 2;
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
                else return omCount + 1;
            }

            if (card.name == CardDB.cardName.sunfuryprotector || card.name == CardDB.cardName.defenderofargus) // bestplace, if right and left minions have no taunt + lots of hp, dont make priority-minions to taunt
            {
                if (omCount == 2)
                {
                    int val1 = 0;
                    int val2 = 0;
                    if (PenalityManager.Instance.priorityDatabase.ContainsKey(this.ownMinions[0].handcard.card.name)) val1 = PenalityManager.Instance.priorityDatabase[this.ownMinions[0].handcard.card.name];
                    if (PenalityManager.Instance.priorityDatabase.ContainsKey(this.ownMinions[1].handcard.card.name)) val2 = PenalityManager.Instance.priorityDatabase[this.ownMinions[1].handcard.card.name];

                    //don't taunt priority minions IF they are high enough priority
                    if (val1 > val2 + 5) return 3;
                    else if (val1 + 5 < val2) return 1;
                    return 2;
                }
                
                i = 0;
                foreach (Minion m in this.ownMinions)
                {

                    places[i] = 0;
                    tempval = 0;
                    if (m.taunt)
                    {
                        tempval += -m.Hp + 2;
                    }
                    else
                    {
                        tempval += -m.Hp;
                    }

                    if (m.windfury)
                    {
                        tempval += 2;
                    }
                    
                    if (m.handcard.card.name == CardDB.cardName.flametonguetotem) tempval += 50;
                    if (m.handcard.card.name == CardDB.cardName.direwolfalpha) tempval += 50;

                    if (PenalityManager.Instance.priorityDatabase.ContainsKey(m.handcard.card.name)) tempval += 2 * PenalityManager.Instance.priorityDatabase[m.handcard.card.name];

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
            if (card.name == CardDB.cardName.flametonguetotem || card.name == CardDB.cardName.direwolfalpha)
            {
                placebuff = true;
                if (card.name == CardDB.cardName.flametonguetotem) cardIsBuffer = 2;
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
                if (card.Charge || (card.race == TAG_RACE.PET && tundrarhino))
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

                    if (m.handcard.card.name == CardDB.cardName.flametonguetotem)
                    {
                        buffplaces[i] = 2;
                        if (minionsBefore == -1) minionsBefore = i;
                        minionsAfter = omCount - i - 1;
                    }
                    if (m.handcard.card.name == CardDB.cardName.direwolfalpha)
                    {
                        buffplaces[i] = 1;
                        if (minionsBefore == -1) minionsBefore = i;
                        minionsAfter = omCount - i - 1;
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
                if (minionsBefore > -1 && minionsBefore <= minionsAfter) needbefore = true;

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
                                int tmp = middle - i;
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
            if (Settings.Instance.simulatePlacement == true)
            {
                int cardvalue = card.Health * 2 + card.Attack;
                if (card.Shield) cardvalue = cardvalue * 3 / 2;
                if (PenalityManager.Instance.priorityDatabase.ContainsKey(card.name)) cardvalue += 2 * PenalityManager.Instance.priorityDatabase[card.name];

                i = 0;
                foreach (Minion m in this.ownMinions)
                {
                    places[i] = 0;
                    tempval = m.maxHp * 2 + m.Angr;
                    if (m.divineshild) tempval = tempval * 3 / 2;
                    if (PenalityManager.Instance.priorityDatabase.ContainsKey(m.handcard.card.name) && !m.silenced) tempval += 2 * PenalityManager.Instance.priorityDatabase[m.handcard.card.name];
                    places[i] = tempval;
                    i++;
                }
                
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


                if (PenalityManager.Instance.priorityDatabase.ContainsKey(card.name)) cardvalue += 2 * PenalityManager.Instance.priorityDatabase[card.name];
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
                        if (PenalityManager.Instance.priorityDatabase.ContainsKey(m.handcard.card.name)) tempval += 2 * PenalityManager.Instance.priorityDatabase[m.handcard.card.name];
                        if (m.stealth) tempval += 40;
                    }
                    places[i] = tempval;

                    i++;
                }
                
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

        public int guessHeroDamage(bool own = false)
        {
            List<Minion> attackingMinions = (own ? this.ownMinions : this.enemyMinions);
            Minion attackingHero = (own ? this.ownHero : this.enemyHero);
            HeroEnum attackingHeroName = (own ? this.ownHeroName : this.enemyHeroName);
            int weaponAttack = (own ? this.ownWeaponAttack : this.enemyWeaponAttack);
            int weaponDurability = (own ? this.ownWeaponDurability : this.enemyWeaponDurability);
            CardDB.cardName weaponName = (own ? this.ownWeaponName : this.enemyWeaponName);
            List<Minion> targetMinions = (own ? this.enemyMinions : this.ownMinions);
            Minion targetHero = (own ? this.enemyHero : this.ownHero);
            Handmanager.Handcard attackingHeroAbilility = (own ? this.ownHeroAblility : this.enemyHeroAblility);
            int attackingHeroMana = (own) ? mana : enemyMaxMana;

            int ghd = 0;
            foreach (Minion m in attackingMinions)
            {
                if (m.frozen) continue;
                if (m.name == CardDB.cardName.ancientwatcher && !m.silenced)
                {
                    continue;
                }
                ghd += m.Angr;
                if (m.windfury) ghd += m.Angr;
            }

            switch (attackingHeroAbilility.card.cardIDenum)
            {
                //direct damage
                case CardDB.cardIDEnum.DS1h_292: ghd += 2; break;
                case CardDB.cardIDEnum.DS1h_292_H1: ghd += 2; break;
                case CardDB.cardIDEnum.AT_132_HUNTER: ghd += 3; break;
                case CardDB.cardIDEnum.DS1h_292_H1_AT_132: ghd += 3; break;
                case CardDB.cardIDEnum.NAX15_02: ghd += 2; break;
                case CardDB.cardIDEnum.NAX15_02H: ghd += 2; break;
                case CardDB.cardIDEnum.NAX6_02: ghd += 3; break;
                case CardDB.cardIDEnum.NAX6_02H: ghd += 3; break;
                case CardDB.cardIDEnum.CS2_034: ghd += 1; break;
                case CardDB.cardIDEnum.CS2_034_H1: ghd += 1; break;
                case CardDB.cardIDEnum.CS2_034_H2: ghd += 1; break;
                case CardDB.cardIDEnum.AT_050t: ghd += 2; break;
                case CardDB.cardIDEnum.AT_132_MAGE: ghd += 2; break;
                case CardDB.cardIDEnum.CS2_034_H1_AT_132: ghd += 2; break;
                case CardDB.cardIDEnum.CS2_034_H2_AT_132: ghd += 2; break;
                case CardDB.cardIDEnum.EX1_625t: ghd += 2; break;
                case CardDB.cardIDEnum.EX1_625t2: ghd += 3; break;
                case CardDB.cardIDEnum.TU4d_003: ghd += 1; break;
                case CardDB.cardIDEnum.NAX7_03: ghd += 3; break;
                case CardDB.cardIDEnum.NAX7_03H: ghd += 4; break;
                //condition
                case CardDB.cardIDEnum.BRMA05_2H: if (attackingHeroMana > 0) ghd += 10; break;
                case CardDB.cardIDEnum.BRMA05_2: if (attackingHeroMana > 0) ghd += 5; break;
                case CardDB.cardIDEnum.BRM_027p: if (attackingMinions.Count < 1) ghd += 8; break;
                case CardDB.cardIDEnum.BRM_027pH: if (attackingMinions.Count < 2) ghd += 8; break;
                case CardDB.cardIDEnum.TB_MechWar_Boss2_HeroPower: if (attackingMinions.Count < 2) ghd += 1; break;
                //equip weapon
                case CardDB.cardIDEnum.LOEA09_2: if (weaponDurability < 1 && !attackingHero.frozen) ghd += 2; break;
                case CardDB.cardIDEnum.LOEA09_2H: if (weaponDurability < 1 && !attackingHero.frozen) ghd += 5; break;
                case CardDB.cardIDEnum.CS2_017: if (weaponDurability < 1 && !attackingHero.frozen) ghd += 1; break;
                case CardDB.cardIDEnum.CS2_083b: if (weaponDurability < 1 && !attackingHero.frozen) ghd += 1; break;
                case CardDB.cardIDEnum.AT_132_ROGUE: if (weaponDurability < 1 && !attackingHero.frozen) ghd += 2; break;
                case CardDB.cardIDEnum.AT_132_DRUID: if (weaponDurability < 1 && !attackingHero.frozen) ghd += 2; break;
            }

            if (!attackingHero.frozen && weaponAttack >= 1)
            {
                if (weaponName != CardDB.cardName.foolsbane) ghd += weaponAttack;
                if ((attackingHero.windfury || weaponName == CardDB.cardName.doomhammer) && weaponDurability > 1) ghd += weaponAttack;
            }

            foreach (Minion m in targetMinions)
            {
                if (m.taunt) ghd -= m.Hp;
                if (m.taunt && m.divineshild) ghd -= 1;
            }

            int guessingHeroDamage = Math.Max(0, ghd);
            if (targetHero.immune) guessingHeroDamage = 0;
            this.guessingHeroHP = this.ownHero.Hp + this.ownHero.armor - guessingHeroDamage;
            //todo sepefeets - rebase secret code from HB

            return guessingHeroDamage;
        }

        public void simulateTraps()
        {
            //todo rework this
            // DONT KILL ENEMY HERO (cause its only guessing)
            int pos;
            foreach (CardDB.cardIDEnum secretID in this.ownSecretsIDList)
            {
                //hunter secrets############

                if (secretID == CardDB.cardIDEnum.AT_060) //beartrap
                {

                    //call 3 snakes (if possible)
                    int posi = this.ownMinions.Count;
                    CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.CS2_125);//bear
                    callKid(kid, posi, true);
                }

                if (secretID == CardDB.cardIDEnum.EX1_554) //snaketrap
                {

                    //call 3 snakes (if possible)
                    int posi = this.ownMinions.Count;
                    CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_554t);//snake
                    callKid(kid, posi, true);
                    callKid(kid, posi, true);
                    callKid(kid, posi, true);
                }
                if (secretID == CardDB.cardIDEnum.EX1_609) //snipe
                {
                    //kill weakest minion of enemy
                    List<Minion> temp = new List<Minion>(this.enemyMinions);
                    temp.Sort((a, b) => a.Angr.CompareTo(b.Angr));//take the weakest
                    if (temp.Count == 0) continue;
                    Minion m = temp[0];
                    minionGetDamageOrHeal(m, 4);
                }
                if (secretID == CardDB.cardIDEnum.EX1_610) //explosive trap
                {
                    //take 2 damage to each enemy
                    List<Minion> temp = this.enemyMinions;
                    foreach (Minion m in temp)
                    {
                        minionGetDamageOrHeal(m, 2);
                    }
                    attackEnemyHeroWithoutKill(2);
                }
                if (secretID == CardDB.cardIDEnum.EX1_611) //freezing trap
                {
                    //return weakest enemy minion to hand
                    List<Minion> temp = new List<Minion>(this.enemyMinions);
                    temp.Sort((a, b) => a.Angr.CompareTo(b.Angr));//take the weakest
                    if (temp.Count == 0) continue;
                    Minion m = temp[0];
                    minionReturnToHand(m, false, 0);
                }
                if (secretID == CardDB.cardIDEnum.EX1_533) // missdirection
                {
                    // first damage to your hero is nulled -> lower guessingHeroDamage
                    List<Minion> temp = new List<Minion>(this.enemyMinions);
                    temp.Sort((a, b) => a.Angr.CompareTo(b.Angr));//take the weakest
                    if (temp.Count == 0) continue;
                    Minion m = temp[0];
                    m.Angr = 0;
                    this.evaluatePenality -= this.enemyMinions.Count;// the more the enemy minions has on board, the more the posibility to destroy something other :D
                }

                //mage secrets############
                if (secretID == CardDB.cardIDEnum.EX1_287) //counterspell
                {
                    // what should we do?
                    this.evaluatePenality -= 8;
                }

                if (secretID == CardDB.cardIDEnum.EX1_289) //ice barrier
                {
                    this.ownHero.armor += 8;
                }

                if (secretID == CardDB.cardIDEnum.EX1_295) //ice block
                {
                    //set the guessed Damage to zero
                    this.ownHero.immune = true;
                }

                if (secretID == CardDB.cardIDEnum.EX1_294) //mirror entity
                {
                    // summon a weak minion (thx to xytrix)
                    int posi = this.ownMinions.Count;
                    CardDB.Card kid;
                    switch ((this.ownMaxMana + 2) / 3)  // conservative, but scales a little as the game progresses
                    {
                        case 1:
                        default: kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_554t); break;  // 1/1 snake turns 1-3
                        case 2: kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_158t); break; // 2/2 treant turns 4-6
                        case 3: kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.CS2_172); break; // 3/2 bloodfen raptor turns 7-9
                        case 4: kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.AT_036t); break; // 4/4 nerubian turn 10
                    }
                    callKid(kid, posi, true);
                }
                if (secretID == CardDB.cardIDEnum.tt_010) //spellbender
                {
                    //whut???
                    // add 2 to your defence (most attack-buffs give +2, lots of damage spells too)
                    this.evaluatePenality -= 4;
                }
                if (secretID == CardDB.cardIDEnum.EX1_594) // vaporize
                {
                    // first damage to your hero is nulled -> lower guessingHeroDamage and destroy weakest minion
                    List<Minion> temp = new List<Minion>(this.enemyMinions);
                    temp.Sort((a, b) => a.Angr.CompareTo(b.Angr));//take the weakest
                    if (temp.Count == 0) continue;
                    Minion m = temp[0];
                    minionGetDestroyed(m);
                }
                if (secretID == CardDB.cardIDEnum.FP1_018) // duplicate
                {
                    // first damage to your hero is nulled -> lower guessingHeroDamage and destroy weakest minion
                    List<Minion> temp = new List<Minion>(this.ownMinions);
                    temp.Sort((a, b) => a.Angr.CompareTo(b.Angr));//take the weakest
                    if (temp.Count == 0) continue;
                    Minion m = temp[0];
                    drawACard(m.handcard.card.cardIDenum, true);
                    drawACard(m.handcard.card.cardIDenum, true);
                }
                if (secretID == CardDB.cardIDEnum.AT_002) // effigy
                {
                    if (this.ownMinions.Count == 0) continue;

                    // assume enemy kills our lowest mana cost minion, and we get a vanilla drop of manacost-1
                    List<Minion> temp = new List<Minion>(this.ownMinions);
                    temp.Sort((a, b) => a.handcard.card.cost.CompareTo(b.handcard.card.cost));

                    int cardCost = Math.Min(8, Math.Max(temp[0].handcard.card.cost - 1, 0));  // min cost 0 (wisp), max cost 8 (giants, etc)
                    this.evaluatePenality -= cardCost * 3;  // value as if we played a vanilla minion of the same cost (i.e. 2*atk + hp, but atk==hp)
                }

                //pala secrets############
                if (secretID == CardDB.cardIDEnum.EX1_132) // eye for an eye
                {
                    // enemy takes one damage
                    List<Minion> temp = new List<Minion>(this.enemyMinions);
                    temp.Sort((a, b) => a.Angr.CompareTo(b.Angr));//take the weakest
                    if (temp.Count == 0) continue;
                    Minion m = temp[0];
                    attackEnemyHeroWithoutKill(m.Angr);
                }
                if (secretID == CardDB.cardIDEnum.EX1_130) // noble sacrifice
                {
                    //spawn a 2/1 taunt!
                    int posi = this.ownMinions.Count;
                    CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_130a);
                    callKid(kid, posi, true);

                }

                if (secretID == CardDB.cardIDEnum.EX1_136) // redemption
                {
                    // we give our weakest minion a divine shield :D
                    List<Minion> temp = new List<Minion>(this.ownMinions);
                    temp.Sort((a, b) => a.Hp.CompareTo(b.Hp));//take the weakest
                    if (temp.Count == 0) continue;

                    bool buffed = false;
                    foreach (Minion m in temp)
                    {
                        if (m.divineshild) continue;
                        m.divineshild = true;
                        buffed = true;
                        break;
                    }

                    // all our minions have divine shield? redemption really shines here, so give weakest minion more hp.
                    if (!buffed) temp[0].Hp += temp[0].handcard.card.Health;  // don't count already buffed hp
                }

                if (secretID == CardDB.cardIDEnum.EX1_379) // repentance
                {
                    // set his current lowest hp minion to x/1
                    List<Minion> temp = new List<Minion>(this.enemyMinions);
                    temp.Sort((a, b) => a.Hp.CompareTo(b.Hp));//take the weakest
                    if (temp.Count == 0) continue;
                    Minion m = temp[0];
                    m.Hp = 1;
                    m.maxHp = 1;
                }

                if (secretID == CardDB.cardIDEnum.FP1_020) // avenge
                {
                    if (this.numPlayerMinionsAtTurnStart < 2) continue;

                    // we give our weakest minion +3/+2 :D
                    List<Minion> temp = new List<Minion>(this.ownMinions);
                    temp.Sort((a, b) => a.Hp.CompareTo(b.Hp));//take the weakest
                    if (temp.Count == 0)
                    {
                        // even though there's no minions to buff because the board was cleared, we still got value for the secret
                        this.evaluatePenality -= 8;
                        continue;
                    }
                    foreach (Minion m in temp)
                    {
                        minionGetBuffed(m, 3, 2);
                        break;
                    }
                }

                switch (secretID)
                {
                    case CardDB.cardIDEnum.KAR_004: //cattrick
                        pos = this.ownMinions.Count;
                        callKid(CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.KAR_004a), pos, true, false);
                        continue;
                }
            }

            this.doDmgTriggers();
        }



        //old one, will be replaced soon
        public void endTurn(bool simulateTwoTurns, bool playaround, bool print = false, int pprob = 0, int pprob2 = 0)
        {
                this.value = int.MinValue;
                if (!this.enemyHero.immune && this.turnCounter == 0)
                {
                    this.manaTurnEnd = this.mana;
                    this.numEnemySecretsTurnEnd = this.enemySecretCount;
                    bool eHasTaunt = false;
                    
                    foreach (Minion m in this.enemyMinions)
                    {
                        if (m.taunt) eHasTaunt = true;
                    }

                    eHasTaunt = true;

                    int hasReady = 0;
                    foreach (Minion m in this.ownMinions)
                    {
                        if (!m.stealth && m.Ready && m.Angr>=1) hasReady++;
                    }

                    if (!eHasTaunt && !this.enemyHero.immune)
                    {


                        this.evaluatePenality += 100 * hasReady;
                    }
                    else
                    {
                        if (!simulateTwoTurns)
                        {
                            if (this.enemySecretCount >= 1)
                            {
                                this.evaluatePenality += 2 * hasReady;
                            }

                            this.evaluatePenality += 40 * hasReady;
                        }
                    }

                }

                if (!this.enemyHero.immune && this.turnCounter == 2)//own next turn
                {
                    bool eHasTaunt = false;
                    foreach (Minion m in this.enemyMinions)
                    {
                        if (m.taunt) eHasTaunt = true;
                    }
                    if (!eHasTaunt && this.enemySecretCount == 0)
                    {
                        int attack = 0;
                        foreach (Minion m in this.ownMinions)
                        {
                            if (m.Ready) attack += m.Angr;
                            if (m.Ready && m.windfury && m.numAttacksThisTurn == 0) attack += m.Angr;
                        }
                        if (this.enemyHero.armor == 0)
                        {
                            this.enemyHero.Hp -= attack;
                        }
                        else
                        {
                            if (this.enemyHero.armor >= attack)
                            {
                                this.enemyHero.armor -= attack;
                            }
                            else 
                            {
                                this.enemyHero.Hp += this.enemyHero.armor - attack;
                                this.enemyHero.armor = 0;
                            }
                        }
                    }

                }
            //this.turnCounter++;
            //penalty for destroying combo


                this.evaluatePenality += ComboBreaker.Instance.checkIfComboWasPlayed(this.playactions, this.ownWeaponName, this.ownHeroName);
                if (this.complete) return;



            this.triggerEndTurn(this.isOwnTurn);
            this.isOwnTurn = !this.isOwnTurn;
            this.triggerStartTurn(this.isOwnTurn);
            this.optionsPlayedThisTurn = 0;
                if (!this.isOwnTurn) simulateTraps();

                if (!sEnemTurn && !this.isOwnTurn) // it was at the biginning our turn -> now its enems
                {
                    //guessHeroDamage();
                    this.triggerEndTurn(false);
                    this.triggerStartTurn(true);
                    this.complete = true;
                }
                else
                {
                    //guessHeroDamage();
                    /*
                    if (this.guessingHeroHP >= 1)
                    {
                        //simulateEnemysTurn(simulateTwoTurns, playaround, print, pprob, pprob2);
                        this.prepareNextTurn(this.isOwnTurn);

                        if (this.turnCounter >= 2)
                            Ai.Instance.enemySecondTurnSim.simulateEnemysTurn(this, simulateTwoTurns, playaround, print, pprob, pprob2);
                        else
                            Ai.Instance.enemyTurnSim.simulateEnemysTurn(this, simulateTwoTurns, playaround, print, pprob, pprob2);
                    }
                    this.complete = true;*/
                }
        }

        //prepares the turn for the next player
        public void prepareNextTurn(bool own)
        {
            //call this after start turn trigger!

            if (own)
            {
                this.ownMaxMana = Math.Min(10, this.ownMaxMana + 1);
                this.mana = this.ownMaxMana - this.owedRecall;
                this.currentRecall = this.owedRecall;
                this.owedRecall = 0;
                foreach (Minion m in ownMinions)
                {
                    m.numAttacksThisTurn = 0;
                    m.playedThisTurn = false;
                    m.updateReadyness(this);
                    m.canAttackNormal = false;
                    if (m.concedal)
                    {
                        m.concedal = false;
                        m.stealth = false;
                    }

                }
                //unfreeze the enemy minions
                foreach (Minion m in enemyMinions)
                {
                    m.frozen = false;
                    m.canAttackNormal = false;
                    //m.immune = false;
                }
                this.enemyHero.frozen = false;


                this.ownHero.Angr = this.ownWeaponAttack;
                this.ownHero.numAttacksThisTurn = 0;
                this.ownAbilityReady = true;
                this.ownHero.updateReadyness();
                this.playedPreparation = false;
                this.nextSecretThisTurnCost0 = false;

                this.anzOwnMillhouseManastorm = false;
                loathebLastTurn = this.anzOwnLoatheb;
                this.anzOwnLoatheb = 0;
                this.anzOwnSaboteur = 0;
                
                this.owncarddraw = 0;//todo: realy?
                this.sEnemTurn = false;

            }
            else
            {

                this.enemyMaxMana = Math.Min(10, this.enemyMaxMana + 1);
                this.mana = this.enemyMaxMana - this.enemyRecall ;
                this.enemyCurrentRecall = this.enemyRecall;
                this.enemyRecall = 0;
                foreach (Minion m in enemyMinions)
                {
                    //m.immune = true;
                    m.numAttacksThisTurn = 0;
                    m.playedThisTurn = false;
                    m.updateReadyness(this);
                    m.canAttackNormal = false;
                    if (m.concedal)
                    {
                        m.concedal = false;
                        m.stealth = false;
                    }
                }
                //unfreeze the own minions
                foreach (Minion m in ownMinions)
                {
                    m.frozen = false;
                }
                this.ownHero.frozen = false;

                this.enemyHero.Angr = this.enemyWeaponAttack;
                this.enemyHero.numAttacksThisTurn = 0;
                this.enemyAbilityReady = true;
                this.enemyHero.updateReadyness();
                this.heroPowerActivationsThisTurn = 0;

                this.anzEnemyMillhouseManastorm = false;
                this.anzEnemyLoatheb = 0;
                this.anzEnemySaboteur = 0;
                
                this.playedPreparation = false;
                this.nextSecretThisTurnCost0 = false;

                this.sEnemTurn = false;
                
            }
            this.turnCounter++;
            this.attacked = false;
            this.optionsPlayedThisTurn = 0;
            this.cardsPlayedThisTurn = 0;
            this.mobsPlayedThisTurn = 0;

            this.heroPowerActivationsThisTurn = 0;
            this.lockAndLoads = 0;

            this.anzMinionsDiedThisTurn = 0;

            this.complete = false;

            this.value = int.MinValue;
            if (this.diedMinions != null) this.diedMinions.Clear();//contains only the minions that died in this turn!
        }

        public void endEnemyTurn() //
        {

            //do face-attack:

            if (!this.ownHero.immune && (this.turnCounter == 1 || this.turnCounter == 3))// enemys turn ends -> attack with all minions face (if there is no taunt)
            {
                //Helpfunctions.Instance.ErrorLog(turnCounter + " bef " + this.ownHero.Hp + " " + this.ownHero.armor);
                bool oHasTaunt = false;
                foreach (Minion m in this.ownMinions)
                {
                    if (m.taunt) oHasTaunt = true;
                }
                if (!oHasTaunt && this.ownSecretsIDList.Count == 0)
                {
                    int attack = 0;
                    foreach (Minion m in this.enemyMinions)
                    {
                        if (m.Ready) attack += m.Angr;
                        if (m.Ready && m.windfury && m.numAttacksThisTurn == 0) attack += m.Angr;
                        m.Ready = false;
                    }

                    if (this.ownHero.armor == 0)
                    {
                        this.ownHero.Hp -= attack;
                    }
                    else
                    {
                        if (this.ownHero.armor >= attack)
                        {
                            this.ownHero.armor -= attack;
                        }
                        else
                        {
                            this.ownHero.Hp += this.ownHero.armor - attack;
                            this.ownHero.armor = 0;
                        }
                    }
                }

                if (this.turnCounter == 3)// enemys turn ends -> attack with all minions face (if there is no taunt)
                {
                    if (this.ownHero.Hp <= 0) this.ownHero.Hp = 0;
                }
                //Helpfunctions.Instance.ErrorLog("aft " + this.ownHero.Hp + " " + this.ownHero.armor);

            }

            this.triggerEndTurn(false);
            //this.turnCounter++;
            this.isOwnTurn = true;
            this.triggerStartTurn(true);
            this.complete = true;
            //Ai.Instance.botBase.getPlayfieldValue(this);

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
            if (this.anzOwnAuchenaiSoulpriest >= 1)
            {
                retval *= -1;
                retval -= this.spellpower;
            }
            if (this.doublepriest >= 1) retval *= (2 * this.doublepriest);
            return retval;
        }

        public int getMinionHeal(int heal)
        {
            return (this.anzOwnAuchenaiSoulpriest >= 1) ? -heal : heal;
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
            if (this.anzOwnAuchenaiSoulpriest >= 1)
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
                foreach (Minion m in this.ownMinions)
                {
                    if (aa.target.entityID == m.entityID)
                    {
                        trgt = m;
                        break;
                    }
                }
                foreach (Minion m in this.enemyMinions)
                {
                    if (aa.target.entityID == m.entityID)
                    {
                        trgt = m;
                        break;
                    }
                }
                if (aa.target.entityID == this.ownHero.entityID) trgt = this.ownHero;
                if (aa.target.entityID == this.enemyHero.entityID) trgt = this.enemyHero;
            }
            if (aa.own != null)
            {
                foreach (Minion m in this.ownMinions)
                {
                    if (aa.own.entityID == m.entityID)
                    {
                        o = m;
                        break;
                    }
                }
                foreach (Minion m in this.enemyMinions)
                {
                    if (aa.own.entityID == m.entityID)
                    {
                        o = m;
                        break;
                    }
                }
                if (aa.own.entityID == this.ownHero.entityID) o = this.ownHero;
                if (aa.own.entityID == this.enemyHero.entityID) o = this.enemyHero;
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
                if (aa.tracking >= 1 )
                {
                    ha = Handmanager.Instance.getCardChoice(aa.tracking - 1);
                }
                if (aa.actionType == actionEnum.useHeroPower)
                {
                    ha = this.isOwnTurn ? this.ownHeroAblility : this.enemyHeroAblility;
                }
            }
            // create and execute the action------------------------------------------------------------------------
            Action a = new Action(aa.actionType, ha, o, aa.place, trgt, aa.penalty, aa.druidchoice, aa.tracking);

            //druidchoice correction, and save tracking-choice
            if (a.tracking >= 1)
            {
                int codedchoice = a.druidchoice;
                this.selectedChoice = a.tracking;

            }

            //save the action if its our first turn
            if (this.turnCounter == 0) this.playactions.Add(a);
            //if (this.isOwnTurn) this.playactions.Add(a);

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
                        if (m.entityID == newTarget)
                        {
                            target = m;
                            break;
                        }
                    }
                    foreach (Minion m in this.enemyMinions)
                    {
                        if (m.entityID == newTarget)
                        {
                            target = m;
                            break;
                        }
                    }
                    if (this.ownHero.entityID == newTarget) target = this.ownHero;
                    if (this.enemyHero.entityID == newTarget) target = this.enemyHero;
                    //Helpfunctions.Instance.ErrorLog("missdirection target = " + target.entitiyID);
                }
                if (a.own.Hp >= 1) minionAttacksMinion(a.own, target);
            }
            else
            {
                // its an hero attack--------------------------------
                if (a.actionType == actionEnum.attackWithHero)
                {
                    //secret trigger is inside
                    //Console.WriteLine("HERO ATTACK:::::::::::::###################################");
                    attackWithWeapon(a.own, a.target, a.penalty);
                    //Console.WriteLine("HERO ATTACK:::::::::::::###################################");
                }
                else
                {
                    // its an playing-card--------------------------------
                    if (a.actionType == actionEnum.playcard)
                    {
                        if (this.isOwnTurn)
                        {
                            playACard(a.card, a.target, a.place, a.druidchoice, a.penalty);
                        }
                        else
                        {
                            //enemyplaysACard();
                        }
                    }
                    else
                    {
                        // its using the hero power--------------------------------
                        if (a.actionType == actionEnum.useHeroPower)
                        {
                            playHeroPower(a.target, a.penalty, this.isOwnTurn);
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

            if (attacker.isHero)
            {
                if (defender.isHero)
                {

                    defender.getDamageOrHeal(attacker.Angr, this, true, false);
                }
                else
                {

                    int enem_attack = defender.Angr;

                    defender.getDamageOrHeal(attacker.Angr, this, true, false);

                    if (!this.ownHero.immuneWhileAttacking)
                    {
                        int oldhp = attacker.Hp;
                        attacker.getDamageOrHeal(enem_attack, this, true, false);
                        if (!defender.silenced && oldhp > attacker.Hp)
                        {
                            if (defender.handcard.card.name == CardDB.cardName.waterelemental || defender.handcard.card.name == CardDB.cardName.snowchugger)
                            {
                                attacker.frozen = true;
                            }

                            this.triggerAMinionDealedDmg(defender, oldhp - attacker.Hp, enem_attack);
                        }
                    }
                }
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
            this.triggerAMinionIsGoingToAttack(attacker,defender);
            //------------------------------------------

            if (defender.isHero)//target is enemy hero
            {

                int oldhp = defender.Hp;
                defender.getDamageOrHeal(attacker.Angr, this, true, false);
                if (!attacker.silenced && oldhp > defender.Hp) // attacker did dmg
                {

                    if (attacker.handcard.card.name == CardDB.cardName.waterelemental || attacker.handcard.card.name == CardDB.cardName.snowchugger) defender.frozen = true;

                    this.triggerAMinionDealedDmg(attacker, oldhp - defender.Hp, attackerAngr);
                }
                doDmgTriggers();
                return;
            }



            //defender gets dmg
            int oldHP = defender.Hp;
            defender.getDamageOrHeal(attackerAngr, this, true, false);
            if (!attacker.silenced && oldHP > defender.Hp && (attacker.handcard.card.name == CardDB.cardName.waterelemental || attacker.handcard.card.name == CardDB.cardName.snowchugger)) defender.frozen = true;
            bool defenderGotDmg = oldHP > defender.Hp;

            bool attackerGotDmg = false;

            //attacker gets dmg
            if (!dontcount)//betrayal effect :D
            {
                oldHP = attacker.Hp;
                attacker.getDamageOrHeal(defAngr, this, true, false);

                if (!defender.silenced && oldHP > attacker.Hp)
                {
                   if(defender.handcard.card.name == CardDB.cardName.waterelemental || defender.handcard.card.name == CardDB.cardName.snowchugger) attacker.frozen = true;

                   this.triggerAMinionDealedDmg(defender, oldHP - attacker.Hp, defAngr);
                }
                attackerGotDmg = oldHP > attacker.Hp;
            }


            //trigger poisonous effect of attacker + defender (even if they died due to attacking/defending)

            if (defenderGotDmg && !attacker.silenced && attacker.handcard.card.poisionous && !defender.isHero)
            {
                minionGetDestroyed(defender);
            }

            if (attackerGotDmg && !defender.silenced && defender.handcard.card.poisionous && !attacker.isHero)
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
                case CardDB.cardName.knuckles:
                    if (!defender.isHero && attacker.Hp > 0) this.minionAttacksMinion(attacker, attacker.own ? this.enemyHero : this.ownHero, true);
                    break;
                case CardDB.cardName.finjatheflyingstar:
                    if (!defender.isHero && defender.Hp < 1)
                    {
                        if (attacker.own)
                        {
                            CardDB.Card c;
                            int count = 0;
                            foreach (KeyValuePair<CardDB.cardIDEnum, int> cid in this.prozis.turnDeck)
                            {
                                c = CardDB.Instance.getCardDataFromID(cid.Key);
                                if ((TAG_RACE)c.race == TAG_RACE.MURLOC)
                                {
                                    for (int i = 0; i < cid.Value; i++)
                                    {
                                        this.callKid(c, this.ownMinions.Count, true);
                                        count++;
                                        if (count > 2) break;
                                    }
                                    if (count > 2) break;
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
            CardDB.Card weapon = own ? this.ownWeaponCard : this.enemyWeaponCard;
            this.attacked = true;
            this.evaluatePenality += penality;
            hero.numAttacksThisTurn++;

            //hero will end his readyness
            hero.updateReadyness();
            if (weapon.name == CardDB.cardName.foolsbane && !hero.frozen) hero.Ready = true;

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
                case CardDB.cardName.foolsbane:
                    if (!hero.frozen) hero.Ready = true;
                    break;
                case CardDB.cardName.brassknuckles:
                    if (own)
                    {
                        Handmanager.Handcard hc = this.searchRandomMinionInHand(this.owncards, searchmode.searchLowestCost, cardsProperty.Mob);
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

            if (logging) Helpfunctions.Instance.logg("attck with weapon trgt: " + target.entityID);

            // hero attacks enemy----------------------------------------------------------------------------------

            if (target.isHero)// trigger secret and change target if necessary
            {
                int newTarget = this.secretTrigger_CharIsAttacked(hero, target);
                if (newTarget >= 1)
                {
                    //search new target!
                    foreach (Minion m in this.ownMinions)
                    {
                        if (m.entityID == newTarget)
                        {
                            target = m;
                            break;
                        }
                    }
                    foreach (Minion m in this.enemyMinions)
                    {
                        if (m.entityID == newTarget)
                        {
                            target = m;
                            break;
                        }
                    }
                    if (this.ownHero.entityID == newTarget) target = this.ownHero;
                    if (this.enemyHero.entityID == newTarget) target = this.enemyHero;
                }

            }
            this.minionAttacksMinion(hero, target);
            //-----------------------------------------------------------------------------------------------------

            //gorehowl is not killed if he attacks minions
            if (own)
            {
                if (ownWeaponName == CardDB.cardName.gorehowl && !target.isHero)
                {
                    this.ownWeaponAttack--;
                    hero.Angr--;
                }
                else
                {
                    this.lowerWeaponDurability(1, true);
                }
            }
            else
            {
                if (enemyWeaponName == CardDB.cardName.gorehowl && !target.isHero)
                {
                    this.enemyWeaponAttack--;
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
        // 3.5 place minion
        // 3.75 dmg/died/dthrttl triggers
        // 4 secret: minion is played
        // 4.5 dmg/died/dthrttl triggers
        // 5 after you summon a minion triggers
        // 5.5 dmg/died/dthrttl triggers
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
                this.ownSpellsPlayedThisGame++;
            }
            if (c.race == TAG_RACE.DRAGON) //dragon
            {
                this.anzOwnDragonConsort = 0;
            }
            if (c.Secret)
            {
                this.ownSecretsIDList.Add(c.cardIDenum);
                this.nextSecretThisTurnCost0 = false;
                this.secretsplayedSinceRecalc++;
            }


            //Helpfunctions.Instance.logg("play crd " + c.name + " entitiy# " + cardEntity + " mana " + hc.getManaCost(this) + " trgt " + target);
            if (logging) Helpfunctions.Instance.logg("play crd " + c.name + " entitiy# " + hc.entity + " mana " + hc.getManaCost(this) + " trgt " + target);


            this.triggerACardWillBePlayed(hc, true, target, choice);
            int newTarget = secretTrigger_SpellIsPlayed(target, c.type == CardDB.cardtype.SPELL);
            if (newTarget >= 1)
            {
                //search new target!
                foreach (Minion m in this.ownMinions)
                {
                    if (m.entityID == newTarget)
                    {
                        target = m;
                        break;
                    }
                }
                foreach (Minion m in this.enemyMinions)
                {
                    if (m.entityID == newTarget)
                    {
                        target = m;
                        break;
                    }
                }
                if (this.ownHero.entityID == newTarget) target = this.ownHero;
                if (this.enemyHero.entityID == newTarget) target = this.enemyHero;
            }
            if (newTarget != -2) // trigger spell-secrets!
            {

                if (c.type == CardDB.cardtype.MOB)
                {
                    if (this.ownMinions.Count < 7)
                    {
                        this.placeAmobSomewhere(hc, target, choice, position);
                        this.mobsPlayedThisTurn++;
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
                    if (c.type == CardDB.cardtype.WEAPON)
                    {
                        this.ownWeaponAttack += hc.addattack;
                        this.ownWeaponDurability += hc.addHp;
                        this.ownHero.Angr += hc.addattack;
                    }
                    this.doDmgTriggers();


                }
            }


            this.cardsPlayedThisTurn++;

        }

        public void enemyplaysACard(CardDB.Card c, Minion target, int position, int choice, int penality)
        {

            Handmanager.Handcard hc = new Handmanager.Handcard(c) {entity = this.getNextEntity()};
            //Helpfunctions.Instance.logg("play crd " + c.name + " entitiy# " + cardEntity + " mana " + hc.getManaCost(this) + " trgt " + target);
            if (logging) Helpfunctions.Instance.logg("enemy play crd " + c.name + " trgt " + target);

            if (c.race == TAG_RACE.DRAGON) //dragon
            {
                this.anzEnemyDragonConsort = 0;
            }

            this.enemyAnzCards--;//might be deleted if he got a real hand

            this.triggerACardWillBePlayed(hc, false, target, choice);
            this.triggerCardsChanged(false);

            int newTarget = secretTrigger_SpellIsPlayed(target, c.type == CardDB.cardtype.SPELL);
            if (newTarget >= 1)
            {
                //search new target!
                foreach (Minion m in this.ownMinions)
                {
                    if (m.entityID == newTarget)
                    {
                        target = m;
                        break;
                    }
                }
                foreach (Minion m in this.enemyMinions)
                {
                    if (m.entityID == newTarget)
                    {
                        target = m;
                        break;
                    }
                }
                if (this.ownHero.entityID == newTarget) target = this.ownHero;
                if (this.enemyHero.entityID == newTarget) target = this.enemyHero;
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
                    this.doDmgTriggers();
                    //secret trigger? do here


                }
            }

            //atm only 2 cards trigger this
            if (c.type == CardDB.cardtype.SPELL)
            {
                this.triggerACardWasPlayed(c, false);
                this.doDmgTriggers();
            }

        }


        public void playHeroPower(Minion target, int penality, bool ownturn)
        {

            CardDB.Card c = (ownturn) ? this.ownHeroAblility.card : this.enemyHeroAblility.card;
            this.heroPowerActivationsThisTurn++;
            if (ownturn)
            {
                this.ownHeroPowerUses++;
                int allowedUses = 1;
                if (this.anzOwnGarrisonCommander >= 1)
                {
                    if (this.anzOwnGarrisonCommander < 1000) allowedUses = 2;
                    if (this.anzOwnGarrisonCommander >= 1000) allowedUses = 1000;
                }
                if (this.heroPowerActivationsThisTurn >= allowedUses)
                {
                    this.ownAbilityReady = false;
                }

            }
            else
            {
                this.enemyHeroPowerUses++;
                int allowedUses = 1;
                if (this.anzEnemyGarrisonCommander >= 1)
                {
                    if (this.anzEnemyGarrisonCommander < 1000) allowedUses = 2;
                    if (this.anzEnemyGarrisonCommander >= 1000) allowedUses = 1000;
                }
                if (this.heroPowerActivationsThisTurn >= allowedUses)
                {
                    this.enemyAbilityReady = false;
                }
                
            }
            int cost = c.getManaCost(this,2);

            
            this.evaluatePenality += penality;
            this.mana = this.mana - cost;
            this.anzOwnFencingCoach = 0;

            this.secretTrigger_HeroPowerUsed(ownturn);

            //Helpfunctions.Instance.logg("play crd " + c.name + " entitiy# " + cardEntity + " mana " + hc.getManaCost(this) + " trgt " + target);
            if (logging) Helpfunctions.Instance.logg("play crd " + c.name + " trgt " + target);

            c.sim_card.onCardPlay(this, ownturn, target, 0);
            this.doDmgTriggers();

            foreach (Minion m in (ownturn) ? this.ownMinions.ToArray() : this.enemyMinions.ToArray())
            {
                if (!m.silenced) m.handcard.card.sim_card.onInspire(this, m);
            }
            this.doDmgTriggers();
        }


        //lower durability of weapon + destroy them (deathrattle) 
        //todo: test death's bite's dearthrattle
        public void lowerWeaponDurability(int value, bool own)
        {

            if (own)
            {
                if (this.ownWeaponDurability <= 0) return;
                this.ownWeaponDurability -= value;
                if (this.ownWeaponDurability <= 0)
                {
                    //todo deathrattle deathsbite

                    if (this.ownWeaponName == CardDB.cardName.powermace && this.ownMinions.Count>=1)
                    {
                        int sum = 1000;
                        Minion t = null;

                        foreach (Minion m in ownMinions)
                        {
                            if ((TAG_RACE)m.handcard.card.race == TAG_RACE.MECHANICAL)
                            {
                                int s = m.maxHp + m.Angr;
                                if (s < sum)
                                {
                                    t = m;
                                    sum = s;
                                }
                            }

                        }

                        if (t != null && sum < 999)
                        {
                            this.minionGetBuffed(t, 2, 2);
                        }
                    }

                    if (this.ownWeaponName == CardDB.cardName.deathsbite)
                    {
                        int anz = 1;
                        if (this.ownBaronRivendare >= 1) anz = 2;
                        int dmg = getSpellDamageDamage(1);
                        foreach (Minion m in this.ownMinions)
                        {
                            this.minionGetDamageOrHeal(m, anz * dmg);
                        }
                        foreach (Minion m in this.enemyMinions)
                        {
                            this.minionGetDamageOrHeal(m, anz * dmg);
                        }
                        this.doDmgTriggers();

                    }

                    if (this.ownWeaponName == CardDB.cardName.chargedhammer)
                    {
                        this.ownHeroAblility = new Handmanager.Handcard(CardDB.Instance.ligthningJolt);
                        if(this.isOwnTurn) this.heroPowerActivationsThisTurn = 0;

                    }


                    this.ownHero.Angr -= this.ownWeaponAttack;
                    this.ownWeaponDurability = 0;
                    this.ownWeaponAttack = 0;
                    this.ownWeaponName = CardDB.cardName.unknown;
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
                        }
                    }
                    this.ownHero.updateReadyness();
                }
            }
            else
            {
                if (this.enemyWeaponDurability <= 0) return;
                this.enemyWeaponDurability -= value;
                if (this.enemyWeaponDurability <= 0)
                {
                    //deathrattle deathsbite

                    if (this.ownWeaponName == CardDB.cardName.powermace && this.enemyMinions.Count >= 1)
                    {
                        int sum = 1000;
                        Minion t = null;

                        foreach (Minion m in enemyMinions)
                        {
                            if ((TAG_RACE)m.handcard.card.race == TAG_RACE.MECHANICAL)
                            {
                                int s = m.maxHp + m.Angr;
                                if (s < sum)
                                {
                                    t = m;
                                    sum = s;
                                }
                            }

                        }

                        if (t != null && sum < 999)
                        {
                            this.minionGetBuffed(t, 2, 2);
                        }
                    }

                    if (this.enemyWeaponName == CardDB.cardName.deathsbite)
                    {
                        int anz = 1;
                        if (this.enemyBaronRivendare >= 1) anz = 2;
                        int dmg = getEnemySpellDamageDamage(1);
                        foreach (Minion m in this.ownMinions)
                        {
                            this.minionGetDamageOrHeal(m, anz * dmg);
                        }
                        foreach (Minion m in this.enemyMinions)
                        {
                            this.minionGetDamageOrHeal(m, anz * dmg);
                        }
                        this.doDmgTriggers();
                    }

                    if (this.enemyWeaponName == CardDB.cardName.chargedhammer)
                    {
                        this.enemyHeroAblility = new Handmanager.Handcard(CardDB.Instance.ligthningJolt);
                        if (!this.isOwnTurn) this.heroPowerActivationsThisTurn = 0;

                    }

                    this.enemyHero.Angr -= this.enemyWeaponAttack;
                    this.enemyWeaponDurability = 0;
                    this.enemyWeaponAttack = 0;
                    this.enemyWeaponName = CardDB.cardName.unknown;
                    this.enemyHero.windfury = false;

                    foreach (Minion m in this.enemyMinions)
                    {
                        switch (m.name)
                        {
                            case CardDB.cardName.smalltimebuccaneer:
                                this.minionGetBuffed(m, -2, 0);
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
                this.tempTrigger.charsGotHealed = 0;
                this.tempTrigger.owncharsGotHealed = 0;
            }

            if (this.tempTrigger.minionsGotHealed >= 1)
            {
                triggerAMinionGotHealed();//possible effects: draw card
                this.tempTrigger.minionsGotHealed = 0;
                this.tempTrigger.ownMinionsGotHealed = 0;
            }


            if (this.tempTrigger.ownMinionsGotDmg + this.tempTrigger.enemyMinionsGotDmg + this.tempTrigger.ownHeroGotDmg + this.tempTrigger.enemyHeroGotDmg>= 1)
            {
                triggerAMinionGotDmg(); //possible effects: draw card, gain armor, gain attack
                this.tempTrigger.ownMinionsGotDmg = 0;
                this.tempTrigger.enemyMinionsGotDmg = 0;
                this.tempTrigger.ownHeroGotDmg = 0;
                this.tempTrigger.enemyHeroGotDmg = 0;
            }

            if (this.tempTrigger.ownMinionsDied + this.tempTrigger.enemyMinionsDied >= 1)
            {
                triggerAMinionDied(); //possible effects: draw card, gain attack + hp
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

            updateBoards();
            if (this.tempTrigger.charsGotHealed + this.tempTrigger.minionsGotHealed + this.tempTrigger.ownMinionsGotDmg + this.tempTrigger.enemyMinionsGotDmg + this.tempTrigger.ownMinionsDied + this.tempTrigger.enemyMinionsDied >= 1)
            {
                doDmgTriggers();
            }
        }

        //todo sepefeets - update char heal triggers to be simpler and support mana geode
        public void triggerACharGotHealed()
        {
            foreach (Minion mnn in this.ownMinions)
            {
                if (mnn.silenced) continue;
                if (mnn.handcard.card.name == CardDB.cardName.lightwarden || mnn.handcard.card.name == CardDB.cardName.holychampion || mnn.handcard.card.name == CardDB.cardName.hoodedacolyte)
                {
                    if (turnCounter == 0)
                    {
                        for (int i = 0; i < this.tempTrigger.charsGotHealed; i++)
                        {
                            mnn.handcard.card.sim_card.onAHeroGotHealedTrigger(this, mnn);
                        }
                    }
                    else
                    {
                        //we are doing this, because we dont do a "real" search on enemys turn
                        for (int i = 0; i < this.tempTrigger.owncharsGotHealed; i++)
                        {
                            mnn.handcard.card.sim_card.onAHeroGotHealedTrigger(this, mnn);
                        }
                    }

                }

                if (mnn.handcard.card.name == CardDB.cardName.shadowboxer)
                {
                    for (int i = 0; i < this.tempTrigger.charsGotHealed; i++)
                    {
                        mnn.handcard.card.sim_card.onAHeroGotHealedTrigger(this, mnn);
                    }
                }
            }
            foreach (Minion mnn in this.enemyMinions)
            {
                if (mnn.silenced) continue;
                if (mnn.handcard.card.name == CardDB.cardName.lightwarden || mnn.handcard.card.name == CardDB.cardName.holychampion || mnn.handcard.card.name == CardDB.cardName.shadowboxer || mnn.handcard.card.name == CardDB.cardName.hoodedacolyte)
                {
                    for (int i = 0; i < this.tempTrigger.charsGotHealed; i++)
                    {
                        mnn.handcard.card.sim_card.onAHeroGotHealedTrigger(this, mnn);
                    }

                }
            }
        }

        public void triggerAMinionGotHealed()
        {
            //also dead minions trigger this
            foreach (Minion mnn in this.ownMinions)
            {
                if (mnn.silenced) continue;
                if (mnn.handcard.card.name == CardDB.cardName.northshirecleric)
                {
                    for (int i = 0; i < this.tempTrigger.minionsGotHealed; i++)
                    {
                        this.drawACard(CardDB.cardIDEnum.None, true);
                    }
                }
            }

            foreach (Minion mnn in this.enemyMinions)
            {
                if (mnn.silenced) continue;
                if (mnn.handcard.card.name == CardDB.cardName.northshirecleric)
                {
                    for (int i = 0; i < this.tempTrigger.minionsGotHealed; i++)
                    {
                        this.drawACard(CardDB.cardIDEnum.None, false);
                    }
                }
            }
        }

        public void triggerAMinionGotDmg()
        {
            /*
            int anz = this.tempTrigger.ownMinionsGotDmg + this.tempTrigger.enemyMinionsGotDmg;
            for (int i = 0; i < anz; i++)
            {
                foreach (Minion m in this.ownMinions)
                {
                    m.handcard.card.sim_card.onMinionGotDmgTrigger(this, m, i < this.tempTrigger.ownMinionsGotDmg);
                }

                foreach (Minion m in this.enemyMinions)
                {
                    m.handcard.card.sim_card.onMinionGotDmgTrigger(this, m, i < this.tempTrigger.ownMinionsGotDmg);
                }
            }*/

            // only 4 minions.. we do this manually :D
            //allso dead minion trigger this!

            if (this.anzAcidmaw == 1)
            {
                int anzam = this.anzAcidmaw;
                foreach (Minion m in this.ownMinions)
                {
                    if (m.anzGotDmg >= 1)
                    {
                        if (!m.silenced && m.name == CardDB.cardName.acidmaw && anzam == 1) continue;
                        this.minionGetDestroyed(m);
                    }
                }

                foreach (Minion m in this.enemyMinions)
                {
                    if (m.anzGotDmg >= 1)
                    {
                        if (!m.silenced && m.name == CardDB.cardName.acidmaw && anzam == 1) continue;
                        this.minionGetDestroyed(m);
                    }
                }
            }

            int grimpatrons = 0;
            int eggs = 0;
            int imps = 0;
            foreach (Minion m in this.ownMinions)
            {
                if (m.silenced)
                {
                    m.anzGotDmg = 0;
                    m.gotDmgRaw = 0;

                    continue;
                }

                if (m.name == CardDB.cardName.frothingberserker && (tempTrigger.ownMinionsGotDmg + tempTrigger.enemyMinionsGotDmg) > 1)
                {
                    this.minionGetBuffed(m, this.tempTrigger.ownMinionsGotDmg + this.tempTrigger.enemyMinionsGotDmg, 0);
                }

                if (m.name == CardDB.cardName.gurubashiberserker && m.anzGotDmg >= 1)
                {
                    this.minionGetBuffed(m, 3 * m.anzGotDmg, 0);
                }

                if (m.name == CardDB.cardName.acolyteofpain && m.anzGotDmg >= 1)
                {
                    for (int i = 0; i < m.anzGotDmg; i++)
                    {
                        this.drawACard(CardDB.cardIDEnum.None, true);
                    }
                }

                if (m.name == CardDB.cardName.armorsmith)
                {
                    for(int i = 0;i< this.tempTrigger.ownMinionsGotDmg;i++)
                    {
                    this.minionGetArmor(this.ownHero,1);
                    }
                }

                if (m.name == CardDB.cardName.gahzrilla && m.anzGotDmg >= 1)
                {
                    int attackbuff = m.Angr * (int)Math.Pow(2, m.anzGotDmg) - m.Angr;
                    this.minionGetBuffed(m, attackbuff, 0);
                }

                if (this.isOwnTurn && m.name == CardDB.cardName.floatingwatcher && this.ownHero.anzGotDmg>=1)
                {
                    this.minionGetBuffed(m, 2 * this.ownHero.anzGotDmg, 2 * this.ownHero.anzGotDmg);
                }

                if (m.name == CardDB.cardName.mechbearcat && m.anzGotDmg>=1)
                {
                    for (int i = 0; i < m.anzGotDmg; i++)
                    {
                        this.drawACard(CardDB.cardIDEnum.PART_001, true, true);
                    }
                }

                if (m.name == CardDB.cardName.grimpatron && m.Hp>=1 && m.anzGotDmg >= 1)
                {
                    grimpatrons+= m.anzGotDmg;
                }

                if (m.name == CardDB.cardName.dragonegg && m.anzGotDmg >= 1)//todo: maybe only if it survives?
                {
                    eggs += m.anzGotDmg;
                }

                if (m.name == CardDB.cardName.impgangboss && m.anzGotDmg >= 1)
                {
                    imps += m.anzGotDmg;
                }

                if (m.name == CardDB.cardName.axeflinger && m.anzGotDmg >= 1)
                {
                    this.minionGetDamageOrHeal(this.enemyHero, 2 * m.anzGotDmg, true);
                }

                if (m.name == CardDB.cardName.wrathguard && m.anzGotDmg >= 1)
                {
                    m.handcard.card.sim_card.onMinionGotDmgTrigger(this, m, m.own);
                }

                m.anzGotDmg = 0;
                m.gotDmgRaw = 0;


            }

            //summon grimpatrons and eggs and imps
            for (int i = 0; i < grimpatrons; i++)
            {
                int pos = this.ownMinions.Count;
                this.callKid(CardDB.Instance.grimpatron, pos, true);
            }
            for (int i = 0; i < eggs; i++)
            {
                int pos = this.ownMinions.Count;
                this.callKid(CardDB.Instance.whelp2a1h, pos, true);
            }
            for (int i = 0; i < imps; i++)
            {
                int pos = this.ownMinions.Count;
                this.callKid(CardDB.Instance.imp, pos, true);
            }

            //enemys minions
            grimpatrons = 0;
            eggs = 0;
            imps = 0;
            foreach (Minion m in this.enemyMinions)
            {
                if (m.silenced)
                {
                    m.anzGotDmg = 0;
                    m.gotDmgRaw = 0;
                    continue;
                }

                if (m.name == CardDB.cardName.frothingberserker && (tempTrigger.ownMinionsGotDmg + tempTrigger.enemyMinionsGotDmg) > 1)
                {
                    this.minionGetBuffed(m, this.tempTrigger.ownMinionsGotDmg + this.tempTrigger.enemyMinionsGotDmg, 0);
                }

                if (m.name == CardDB.cardName.gurubashiberserker && m.anzGotDmg >= 1)
                {
                    this.minionGetBuffed(m, 3 * m.anzGotDmg, 0);
                }

                if (m.name == CardDB.cardName.acolyteofpain && m.anzGotDmg >= 1)
                {
                    for (int i = 0; i < m.anzGotDmg; i++)
                    {
                        this.drawACard(CardDB.cardIDEnum.None, false);
                    }
                }

                if (m.name == CardDB.cardName.armorsmith)
                {
                    for (int i = 0; i < this.tempTrigger.enemyMinionsGotDmg; i++)
                    {
                        this.minionGetArmor(this.enemyHero, 1);
                    }
                }

                if (m.name == CardDB.cardName.gahzrilla && m.anzGotDmg >= 1)
                {

                    int attackbuff = m.Angr * (int)Math.Pow(2, m.anzGotDmg) - m.Angr;
                    this.minionGetBuffed(m, attackbuff, 0);
                }

                if (!this.isOwnTurn && m.name == CardDB.cardName.floatingwatcher && this.enemyHero.anzGotDmg >= 1)
                {
                    this.minionGetBuffed(m, 2 * this.enemyHero.anzGotDmg, 2 * this.enemyHero.anzGotDmg);
                }

                if (m.name == CardDB.cardName.mechbearcat && m.anzGotDmg >= 1)
                {
                    for (int i = 0; i < m.anzGotDmg; i++)
                    {
                        this.drawACard(CardDB.cardIDEnum.PART_001, false, true);
                    }
                }


                if (m.name == CardDB.cardName.grimpatron && m.Hp >= 1 && m.anzGotDmg >= 1)
                {
                    grimpatrons += m.anzGotDmg;
                }

                if (m.name == CardDB.cardName.dragonegg && m.anzGotDmg >= 1)//todo: maybe only if it survives?
                {
                    eggs += m.anzGotDmg;
                }

                if (m.name == CardDB.cardName.impgangboss && m.anzGotDmg >= 1)
                {
                    imps += m.anzGotDmg;
                }

                if (m.name == CardDB.cardName.axeflinger && m.anzGotDmg >= 1)
                {
                    this.minionGetDamageOrHeal(this.ownHero, 2 * m.anzGotDmg, true);
                }

                if (m.name == CardDB.cardName.wrathguard && m.anzGotDmg >= 1)
                {
                    m.handcard.card.sim_card.onMinionGotDmgTrigger(this, m, m.own);
                }

                m.anzGotDmg = 0;
                m.gotDmgRaw = 0;
            }

            //summon grimpatrons
            for (int i = 0; i < grimpatrons; i++)
            {
                int pos = this.enemyMinions.Count;
                this.callKid(CardDB.Instance.grimpatron, pos, false);
            }
            for (int i = 0; i < eggs; i++)
            {
                int pos = this.enemyMinions.Count;
                this.callKid(CardDB.Instance.whelp2a1h, pos, false);
            }
            for (int i = 0; i < imps; i++)
            {
                int pos = this.enemyMinions.Count;
                this.callKid(CardDB.Instance.imp, pos, false);
            }

            this.ownHero.anzGotDmg = 0;
            this.enemyHero.anzGotDmg = 0;
        }

        public void triggerAMinionDied()
        {
            int summonOwn = 0;
            int summonEnemy = 0;
            foreach (Minion mnn in this.ownMinions)
            {
                if (mnn.silenced) continue;
                if (mnn.Hp <= 0) continue;

                if (mnn.handcard.card.name == CardDB.cardName.cultmaster)
                {
                    int anz = this.tempTrigger.ownMinionsDied;
                    if (mnn.Hp <= 0) anz--;//only other minions

                    for (int i = 0; i < anz; i++)
                    {
                        this.drawACard(CardDB.cardIDEnum.None, true);
                    }
                }

                if (mnn.handcard.card.name == CardDB.cardName.flesheatingghoul)
                {
                    this.minionGetBuffed(mnn, this.tempTrigger.ownMinionsDied + this.tempTrigger.enemyMinionsDied, 0);
                }

                if (mnn.handcard.card.name == CardDB.cardName.scavenginghyena)
                {
                    this.minionGetBuffed(mnn, 2 * this.tempTrigger.ownBeastDied, this.tempTrigger.ownBeastDied);
                }

                if (mnn.handcard.card.name == CardDB.cardName.oldmurkeye)
                {
                    this.minionGetBuffed(mnn, -1 * (this.tempTrigger.ownMurlocDied + this.tempTrigger.enemyMurlocDied), 0);
                }

                if (mnn.handcard.card.name == CardDB.cardName.siltfinspiritwalker)
                {
                    for (int i = 0; i < this.tempTrigger.ownMurlocDied; i++)
                    {
                        this.drawACard(CardDB.cardIDEnum.None, true);
                    }
                }

                if (mnn.handcard.card.name == CardDB.cardName.cogmaster )
                {
                    if (this.tempTrigger.ownMechanicDied >= 1)
                    {
                        //check if we have more mechanics, or debuff him
                        bool hasmechanics = false;
                        foreach (Minion m in this.ownMinions)
                        {
                            if (m.Hp >=1 && (TAG_RACE)m.handcard.card.race == TAG_RACE.MECHANICAL) hasmechanics = true;
                        }

                        if (!hasmechanics)
                        {
                            //we have no living mechanics -> debuff cogmaster
                            this.minionGetBuffed(mnn, -2, 0);
                        }
                    }
                }

                if (mnn.handcard.card.name == CardDB.cardName.cogmasterswrench)
                {
                    if (this.tempTrigger.ownMechanicDied >= 1)
                    {
                        //check if we have more mechanics, or debuff him
                        bool hasmechanics = false;
                        foreach (Minion m in this.ownMinions)
                        {
                            if (m.Hp >= 1 && (TAG_RACE)m.handcard.card.race == TAG_RACE.MECHANICAL) hasmechanics = true;
                        }

                        if (!hasmechanics)
                        {
                            this.ownWeaponAttack -= 2;
                            this.minionGetBuffed(this.ownHero, -2, 0);
                        }
                    }
                }


                if (mnn.handcard.card.name == CardDB.cardName.junkbot)
                {
                    this.minionGetBuffed(mnn, 2 * this.tempTrigger.ownMechanicDied, 2*this.tempTrigger.ownMechanicDied);
                }

                if (mnn.handcard.card.name == CardDB.cardName.mekgineerthermaplugg)
                {
                    summonOwn += this.tempTrigger.enemyMinionsDied;
                }

                if (mnn.handcard.card.name == CardDB.cardName.eeriestatue)
                {
                    mnn.updateReadyness(this);
                }
            }
            
            foreach (Minion mnn in this.enemyMinions)
            {
                if (mnn.silenced) continue;
                if (mnn.Hp <= 0) continue;
                if (mnn.handcard.card.name == CardDB.cardName.cultmaster)
                {
                    int anz = this.tempTrigger.enemyMinionsDied;
                    if (mnn.Hp <= 0) anz--;//only other minions

                    for (int i = 0; i < anz; i++)
                    {
                        this.drawACard(CardDB.cardIDEnum.None, false);
                    }
                }

                if (mnn.handcard.card.name == CardDB.cardName.flesheatingghoul)
                {
                    this.minionGetBuffed(mnn, this.tempTrigger.ownMinionsDied + this.tempTrigger.enemyMinionsDied, 0);
                }

                if (mnn.handcard.card.name == CardDB.cardName.scavenginghyena)
                {
                    this.minionGetBuffed(mnn, 2 * this.tempTrigger.enemyBeastDied, this.tempTrigger.enemyBeastDied);
                }

                if (mnn.handcard.card.name == CardDB.cardName.oldmurkeye)
                {
                    this.minionGetBuffed(mnn, -1 * (this.tempTrigger.ownMurlocDied + this.tempTrigger.enemyMurlocDied), 0);
                }

                if (mnn.handcard.card.name == CardDB.cardName.siltfinspiritwalker)
                {
                    for (int i = 0; i < this.tempTrigger.enemyMurlocDied; i++)
                    {
                        this.drawACard(CardDB.cardIDEnum.None, false);
                    }
                }

                if (mnn.handcard.card.name == CardDB.cardName.cogmaster)
                {
                    if (this.tempTrigger.enemyMechanicDied >= 1)
                    {
                        //check if we have more mechanics, or debuff him
                        bool hasmechanics = false;
                        foreach (Minion m in this.enemyMinions)
                        {
                            if (m.Hp >= 1 && (TAG_RACE)m.handcard.card.race == TAG_RACE.MECHANICAL) hasmechanics = true;
                        }

                        if (!hasmechanics)
                        {
                            //we have no living mechanics -> debuff cogmaster
                            this.minionGetBuffed(mnn, -2, 0);
                        }
                    }
                }

                if (mnn.handcard.card.name == CardDB.cardName.cogmasterswrench)
                {
                    if (this.tempTrigger.ownMechanicDied >= 1)
                    {
                        //check if enemy has more mechanics, or debuff him
                        bool hasmechanics = false;
                        foreach (Minion m in this.ownMinions)
                        {
                            if (m.Hp >= 1 && (TAG_RACE)m.handcard.card.race == TAG_RACE.MECHANICAL) hasmechanics = true;
                        }

                        if (!hasmechanics)
                        {
                            this.enemyWeaponAttack -= 2;
                            this.minionGetBuffed(this.enemyHero, -2, 0);
                        }
                    }
                }
                
                if (mnn.handcard.card.name == CardDB.cardName.junkbot)
                {
                    this.minionGetBuffed(mnn, 2 * this.tempTrigger.enemyMechanicDied, 2 * this.tempTrigger.enemyMechanicDied);
                }

                if (mnn.handcard.card.name == CardDB.cardName.mekgineerthermaplugg)
                {
                    summonEnemy += this.tempTrigger.ownMinionsDied;
                }

                if (mnn.handcard.card.name == CardDB.cardName.eeriestatue)
                {
                    mnn.updateReadyness(this);
                }
            }

            foreach (Handmanager.Handcard hc in this.owncards)
            {
                if (hc.card.name == CardDB.cardName.bolvarfordragon) hc.addattack += this.tempTrigger.ownMinionsDied;
            }

            if (summonOwn >= 1)
            {
                for (int i = 0; i < summonOwn; i++)
                {
                    int pos = this.ownMinions.Count ;
                    this.callKid(CardDB.Instance.lepergnome, pos, true);
                }
            }
            if (summonEnemy >= 1)
            {
                for (int i = 0; i < summonEnemy; i++)
                {
                    int pos = this.enemyMinions.Count;
                    this.callKid(CardDB.Instance.lepergnome, pos, false);
                }
            }
        }

        public void triggerAMinionIsGoingToAttack(Minion attacker, Minion defender)
        {
            //todo trigger secret her too

            switch (attacker.name)
            {
                case CardDB.cardName.cutpurse:
                    if (defender.isHero) this.drawACard(CardDB.cardName.thecoin, !defender.own, true);
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

            //blessing of wisdom (truesilver is located in attackWithWeapon(...))
            if (attacker.ownBlessingOfWisdom >= 1)
            {
                for (int i = 0; i < attacker.ownBlessingOfWisdom; i++)
                {
                    this.drawACard(CardDB.cardIDEnum.None, true);
                }
            }
            if (attacker.enemyBlessingOfWisdom >= 1)
            {
                for (int i = 0; i < attacker.enemyBlessingOfWisdom; i++)
                {
                    this.drawACard(CardDB.cardIDEnum.None, false);
                }
            }

            if (attacker.ownPowerWordGlory >= 1)
            {
                for (int i = 0; i < attacker.ownPowerWordGlory; i++)
                {
                    int heal = this.getMinionHeal(4);
                    this.minionGetDamageOrHeal(this.ownHero, -heal, true);
                }
            }

            if (attacker.enemyPowerWordGlory >= 1)
            {
                for (int i = 0; i < attacker.enemyPowerWordGlory; i++)
                {
                    int heal = this.getEnemyMinionHeal(4);
                    this.minionGetDamageOrHeal(this.enemyHero, -heal, true);
                }
            }

            if (defender.isHero && attacker.name == CardDB.cardName.cutpurse)
            {
                this.drawACard(CardDB.cardIDEnum.GAME_005, attacker.own);
            }

        }

        public void triggerAMinionDealedDmg(Minion m, int dmgDone, int attackvalue)
        {
            //only 3 cards have this trigger
            switch (m.name)
            {
                case CardDB.cardName.alleyarmorsmith:
                    this.minionGetArmor(m.own ? this.ownHero : this.enemyHero, m.Angr);
                    break;
                case CardDB.cardName.mistressofpain:
                case CardDB.cardName.wickerflameburnbristle:
                    if (dmgDone > 0)
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
                    break;
            }

        }

        public void triggerACardWillBePlayed(Handmanager.Handcard hc, bool own, Minion target, int choice)
        {
            if (this.isOwnTurn == own && this.lockAndLoads>=1 && hc.card.type == CardDB.cardtype.SPELL)
            {
                for (int i = 0; i < this.lockAndLoads; i++)
                {
                        this.drawACard(CardDB.cardIDEnum.None, own, true);
                }
            }

            if (own)
            {
                int violetteacher = 0; //we count violetteacher to avoid copying ownminions
                int illidan = 0;
                int burly = 0;

                if (target!=null && target.name == CardDB.cardName.dragonkinsorcerer && target.own == own && hc.card.type == CardDB.cardtype.SPELL)
                {
                    this.minionGetBuffed(target, 1, 1);
                }

                int summonstones = 0;
                Minion summoningStone = null;

                foreach (Minion m in this.ownMinions.ToArray())
                {
                    if (m.silenced) continue;

                    if (m.name == CardDB.cardName.illidanstormrage)
                    {
                        illidan++;
                        continue;
                    }

                    if (m.name == CardDB.cardName.violetteacher)
                    {
                        if (hc.card.type == CardDB.cardtype.SPELL)
                        {
                            violetteacher++;
                        }
                        continue;
                    }
                    if (m.name == CardDB.cardName.hobgoblin)
                    {
                        if (hc.card.type == CardDB.cardtype.MOB && hc.card.Attack == 1 )
                        {
                            hc.addattack += 2;
                            hc.addHp += 2;
                        }
                        continue;
                    }

                    if (m.name == CardDB.cardName.summoningstone)
                    {
                        summonstones++;
                        summoningStone = m;
                        continue;
                    }

                    m.handcard.card.sim_card.onCardIsGoingToBePlayed(this, hc.card, own, m, target, choice);
                }

                for (int i = 0; i < summonstones; i++)
                {
                    if (summoningStone != null) summoningStone.handcard.card.sim_card.onCardIsGoingToBePlayed(this, hc.card, own, summoningStone, target, choice);
                }

                foreach (Minion m in this.enemyMinions)
                {
                    if (m.name == CardDB.cardName.troggzortheearthinator)
                    {
                        burly++;
                    }
                    if (m.name == CardDB.cardName.felreaver)
                    {
                        m.handcard.card.sim_card.onCardIsGoingToBePlayed(this, hc.card, own, m, target, choice);
                    }
                }

                if (this.ownWeaponCard.name == CardDB.cardName.atiesh)
                {
                    this.callKid(this.getRandomCardForManaMinion(hc.manacost), this.ownMinions.Count, own);
                    this.lowerWeaponDurability(1, own);
                }

                for (int i = 0; i < violetteacher; i++)
                {
                    int pos = this.ownMinions.Count;
                    this.callKid(CardDB.Instance.teacherminion, pos, own);
                }

                for (int i = 0; i < illidan; i++)
                {
                    int pos = this.ownMinions.Count;
                    this.callKid(CardDB.Instance.illidanminion, pos, own);
                }

                for (int i = 0; i < burly; i++)//summon for enemy !
                {
                    int pos = this.enemyMinions.Count;
                    this.callKid(CardDB.Instance.burlyrockjaw, pos, !own);
                }

                foreach (Handmanager.Handcard hc2 in this.owncards)
                {
                    if (hc2.card.name == CardDB.cardName.blubberbaron)
                    {
                        hc2.addattack += this.tempTrigger.ownMinionsDied;
                        hc2.addHp += this.tempTrigger.ownMinionsDied;
                    }
                }


            }
            else
            {
                int violetteacher = 0; //we count violetteacher to avoid copying ownminions
                int illidan = 0;
                int burly = 0;

                if (target!=null && target.name == CardDB.cardName.dragonkinsorcerer && target.own == own && hc.card.type == CardDB.cardtype.SPELL)
                {
                    this.minionGetBuffed(target, 1, 1);
                }

                int summonstones = 0;
                Minion summoningStone = null;

                foreach (Minion m in this.enemyMinions)
                {
                    if (m.silenced) continue;
                    if (m.name == CardDB.cardName.illidanstormrage)
                    {
                        illidan++;
                        continue;
                    }
                    if (m.name == CardDB.cardName.violetteacher)
                    {
                        if (hc.card.type == CardDB.cardtype.SPELL)
                        {
                            violetteacher++;
                        }
                        continue;
                    }
                    if (m.name == CardDB.cardName.hobgoblin)
                    {
                        if (hc.card.type == CardDB.cardtype.MOB && hc.card.Attack == 1)
                        {
                            hc.addattack += 2;
                            hc.addHp += 2;
                        }
                        continue;
                    }

                    if (m.name == CardDB.cardName.summoningstone)
                    {
                        summonstones++;
                        summoningStone = m;
                        continue;
                    }


                    m.handcard.card.sim_card.onCardIsGoingToBePlayed(this, hc.card, own, m, target, choice);
                }

                for (int i = 0; i < summonstones; i++)
                {
                    if (summoningStone.handcard != null) summoningStone.handcard.card.sim_card.onCardIsGoingToBePlayed(this, hc.card, own, summoningStone, target, choice);
                }

                foreach (Minion m in this.ownMinions)
                {
                    if (m.name == CardDB.cardName.troggzortheearthinator)
                    {
                        burly++;
                    }
                    if (m.name == CardDB.cardName.felreaver)
                    {
                        m.handcard.card.sim_card.onCardIsGoingToBePlayed(this, hc.card, own, m, target, choice);
                    }
                }

                if (this.enemyWeaponCard.name == CardDB.cardName.atiesh)
                {
                    this.callKid(this.getRandomCardForManaMinion(hc.manacost), this.enemyMinions.Count, own);
                    this.lowerWeaponDurability(1, own);
                }
                for (int i = 0; i < violetteacher; i++)
                {
                    int pos = this.enemyMinions.Count;
                    this.callKid(CardDB.Instance.teacherminion, pos, own);
                }
                for (int i = 0; i < illidan; i++)
                {
                    int pos = this.enemyMinions.Count;
                    this.callKid(CardDB.Instance.illidanminion, pos, own);
                }

                for (int i = 0; i < burly; i++)//summon for us
                {
                    int pos = this.ownMinions.Count;
                    this.callKid(CardDB.Instance.burlyrockjaw, pos, own);
                }
            }

        }

        public void triggerACardWasPlayed(CardDB.Card c, bool own)
        {
            //we do the effects manually :D (just 2 minions)
            foreach (Minion m in this.ownMinions)
            {
                if (m.silenced || m.Hp <= 0) continue;

                if (own && m.name == CardDB.cardName.flamewaker && c.type == CardDB.cardtype.SPELL)
                {
                    m.handcard.card.sim_card.onCardWasPlayed(this, c, own, m);
                }

                if (m.name == CardDB.cardName.secretkeeper && c.Secret)
                {
                    this.minionGetBuffed(m, 1, 1);
                }
                if (own && m.name == CardDB.cardName.wildpyromancer && c.type == CardDB.cardtype.SPELL)
                {
                    this.allMinionsGetDamage(1);
                }
                if (own && m.name == CardDB.cardName.rumblingelemental && c.type == CardDB.cardtype.MOB && c.battlecry==true)
                {
                    this.doDmgToRandomEnemyCLIENT2(2, true, own);
                }
            }

            foreach (Minion m in this.enemyMinions)
            {
                if (m.silenced || m.Hp <= 0) continue;

                if (!own && m.name == CardDB.cardName.flamewaker && c.type == CardDB.cardtype.SPELL)
                {
                    m.handcard.card.sim_card.onCardWasPlayed(this, c, own, m);
                }

                if (m.name == CardDB.cardName.secretkeeper && c.Secret)
                {
                    this.minionGetBuffed(m, 1, 1);
                }
                if (!own && m.name == CardDB.cardName.wildpyromancer && c.type == CardDB.cardtype.SPELL)
                {
                    this.allMinionsGetDamage(1);
                }
                if (!own && m.name == CardDB.cardName.rumblingelemental && c.type == CardDB.cardtype.MOB && c.battlecry == true)
                {
                    this.doDmgToRandomEnemyCLIENT2(2, true, own);
                }
            }

        }

        public void triggerAMinionIsSummoned(Minion m)
        {
            if (m.own)
            {
                foreach (Minion mnn in this.ownMinions)
                {
                    if (mnn.silenced) continue;
                    mnn.handcard.card.sim_card.onMinionIsSummoned(this, mnn, m);
                }

                if (this.ownWeaponName == CardDB.cardName.spiritclaws && !this.ownSpiritclaws)
                {
                    if (this.spellpower > 0 || m.handcard.card.Spellpower)
                    {
                        this.ownWeaponAttack += 2;
                        this.minionGetBuffed(this.ownHero, 2, 0);
                        this.ownSpiritclaws = true;
                    }
                }

                if (this.ownWeaponName == CardDB.cardName.swordofjustice)
                {
                    this.minionGetBuffed(m, 1, 1);
                    this.lowerWeaponDurability(1, true);
                }

                if(m.handcard.card.race == TAG_RACE.PET) 
                {
                    foreach (Handmanager.Handcard hc in this.owncards)
                    {
                        if (hc.card.cardIDenum == CardDB.cardIDEnum.AT_041)
                        {
                            if (hc.manacost >= 1) hc.manacost--;
                        }
                    }

                }
            }
            else
            {
                foreach (Minion mnn in this.enemyMinions)
                {
                    if (mnn.silenced) continue;
                    mnn.handcard.card.sim_card.onMinionIsSummoned(this, mnn, m);
                }

                foreach (Minion mnn in this.ownMinions)
                {
                    if (mnn.silenced) continue;
                    if (mnn.name == CardDB.cardName.murloctidecaller) mnn.handcard.card.sim_card.onMinionIsSummoned(this, mnn, m);
                }
                if (this.enemyWeaponName == CardDB.cardName.swordofjustice)
                {
                    this.minionGetBuffed(m, 1, 1);
                    this.lowerWeaponDurability(1, false);
                }
            }
        }

        public void triggerAMinionWasSummoned(Minion mnn)
        {
            if (mnn.own)
            {
                foreach (Minion m in this.ownMinions)
                {
                    if (m.silenced) continue;
                    m.handcard.card.sim_card.onMinionWasSummoned(this, m, mnn);

                    if (m.handcard.card.name == CardDB.cardName.eeriestatue)
                    {
                        m.updateReadyness(this);
                    }

                }
            }
            else
            {
                foreach (Minion m in this.enemyMinions)
                {
                    if (m.silenced) continue;
                    m.handcard.card.sim_card.onMinionWasSummoned(this, m, mnn);

                    if (m.handcard.card.name == CardDB.cardName.eeriestatue)
                    {
                        m.updateReadyness(this);
                    }
                }
            }

        }

        public void triggerEndTurn(bool ownturn)
        {
            //todo sepefeets - add all the missing turn end trigger minions
            //todo sort them
            //List<Minion> temp = (ownturn)? this.ownMinions : this.enemyMinions;

            List<Minion> ownm = (ownturn) ? this.ownMinions : this.enemyMinions;
            foreach (Minion m in ownm.ToArray())
            {
                if (!m.silenced)
                {
                    m.handcard.card.sim_card.onTurnEndsTrigger(this, m, ownturn);
                }
                if (ownturn == m.own && m.destroyOnOwnTurnEnd) this.minionGetDestroyed(m);
                if (ownturn != m.own && m.destroyOnEnemyTurnEnd) this.minionGetDestroyed(m);
            }
            List<Minion> enemm = (ownturn) ? this.enemyMinions : this.ownMinions;
            foreach (Minion m in enemm.ToArray())
            {
                //only gruul + kelthuzad
                if (!m.silenced && (m.name == CardDB.cardName.gruul || m.name == CardDB.cardName.kelthuzad || m.name == CardDB.cardName.animagolem || m.name == CardDB.cardName.jeeves))
                {
                    m.handcard.card.sim_card.onTurnEndsTrigger(this, m, ownturn);
                }
                if (ownturn == m.own && m.destroyOnOwnTurnEnd) this.minionGetDestroyed(m);
                if (ownturn != m.own && m.destroyOnEnemyTurnEnd) this.minionGetDestroyed(m);
            }

            this.doDmgTriggers();

            //shadowmadness
            foreach (Minion m in ownm.ToArray())
            {

                if (m.shadowmadnessed)
                {
                    m.shadowmadnessed = false;
                    this.minionGetControlled(m, !m.own, false);
                }

            }

            this.doDmgTriggers();

            this.nextSecretThisTurnCost0 = false;
            this.nextSpellThisTurnCost0 = false;
            this.nextMurlocThisTurnCostHealth = false;
            this.nextSpellThisTurnCostHealth = false;
            this.lockandload = 0;
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

        }

        public void triggerStartTurn(bool ownturn)
        {
            this.numPlayerMinionsAtTurnStart = this.ownMinions.Count;
            this.cardsPlayedThisTurn = 0;
            this.mobsPlayedThisTurn = 0;
            this.nextSecretThisTurnCost0 = false;
            this.nextSpellThisTurnCost0 = false;
            this.nextMurlocThisTurnCostHealth = false;
            this.nextSpellThisTurnCostHealth = false;
            this.optionsPlayedThisTurn = 0;
            this.enemyOptionsDoneThisTurn = 0;

            if (ownturn)
            {
                int at073 = 0;
                foreach (CardDB.cardIDEnum cie in this.ownSecretsIDList)
                {
                    if (cie == CardDB.cardIDEnum.AT_073)
                    {
                        at073++;
                    }
                }
                if (at073 >= 1)
                {
                    foreach (Minion m in this.ownMinions)
                    {
                        this.minionGetBuffed(m, at073, at073);
                    }
                    this.ownSecretsIDList.RemoveAll(x => x == CardDB.cardIDEnum.AT_073);
                }
            }
            else
            {
                    int triggered = 0;
                    foreach (SecretItem si in this.enemySecretList)
                    {
                        if (si.canBe_competivespirit)
                        {
                            triggered++;
                            CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_132).sim_card.onSecretPlay(this, false, 0);
                            si.usedTrigger_EndTurn();
                            foreach (SecretItem sii in this.enemySecretList)
                            {
                                sii.canBe_competivespirit = false;
                            }
                        }
                    }
            }
            List<Minion> ownm = (ownturn) ? this.ownMinions : this.enemyMinions;
            int summonbigone = -1;
            foreach (Minion m in ownm)
            {
                m.playedThisTurn = false;
                m.numAttacksThisTurn = 0;
                m.updateReadyness(this);
                if (!m.silenced)
                {
                    if (m.name == CardDB.cardName.mimironshead)
                    {
                        summonbigone = m.zonepos - 1;
                    }
                    else
                    {
                        m.handcard.card.sim_card.onTurnStartTrigger(this, m, ownturn);
                    }
                }
                if (ownturn == m.own && m.destroyOnOwnTurnStart) this.minionGetDestroyed(m);
                if (ownturn != m.own && m.destroyOnEnemyTurnStart) this.minionGetDestroyed(m);
            }

            if (summonbigone >= 0)
            {
                if (summonbigone >= ownm.Count) summonbigone = ownm.Count - 1; //todo - figure out how summonbigone is exceeding the minion count
                ownm[summonbigone].handcard.card.sim_card.onTurnStartTrigger(this, ownm[summonbigone], ownturn);
            }

            List<Minion> enemm = (ownturn) ? this.enemyMinions : this.ownMinions;
            foreach (Minion m in enemm)
            {
                if (!m.silenced)
                {
                    if (m.name == CardDB.cardName.micromachine) m.handcard.card.sim_card.onTurnStartTrigger(this, m, ownturn);
                }
                if (ownturn == m.own && m.destroyOnOwnTurnStart) this.minionGetDestroyed(m);
                if (ownturn != m.own && m.destroyOnEnemyTurnStart) this.minionGetDestroyed(m);
            }

            //cursed-card effect
            if (ownturn)
            {
                foreach (Handmanager.Handcard hc in this.owncards)
                {
                    if (hc.card.cardIDenum == CardDB.cardIDEnum.LOE_007t)
                    {
                        this.minionGetDamageOrHeal(this.ownHero, 2, true);
                    }
                }
            }
            else
            {
                if(this.anzEnemyCursed>=1)this.minionGetDamageOrHeal(this.enemyHero, 2 * this.anzEnemyCursed, true);
            }

            this.doDmgTriggers();

            this.drawACard(CardDB.cardIDEnum.None, ownturn);
            this.doDmgTriggers();
        }

        public void triggerAHeroGotArmor(bool ownHero)
        {
            foreach (Minion m in ((ownHero) ? this.ownMinions : this.enemyMinions))
            {
                if (m.name == CardDB.cardName.siegeengine)
                {
                    this.minionGetBuffed(m, 1, 0);
                }
            }
        }

        public void changeRecall(bool own, int value)
        {
            int oldrecall = 0;
            int newrecall = 0;
            List<Minion> tempminions = this.ownMinions;
            if (own)
            {
                oldrecall = this.owedRecall;
                this.owedRecall = Math.Min(10,this.owedRecall+value);
                newrecall = this.owedRecall;
            }
            else
            {
                oldrecall = this.enemyRecall;
                this.enemyRecall = Math.Min(10, this.enemyRecall + value);
                newrecall = this.enemyRecall;
                tempminions = this.enemyMinions;
            };

            if (oldrecall < newrecall)
            {
                foreach (Minion m in tempminions)
                {
                    if (!m.silenced && m.name == CardDB.cardName.tunneltrogg)
                    {
                        this.minionGetBuffed(m, newrecall - oldrecall, 0);
                    }
                }
            }
        }

        public void triggerACardWasDiscarded(bool own)
        {
            if (own)
            {
                foreach (Minion m in this.ownMinions)
                {
                    if (m.name == CardDB.cardName.tinyknightofevil && !m.silenced)
                    {
                        m.handcard.card.sim_card.onCardWasDiscarded(this, own, m);
                    }
                }
            }
            else
            {
                foreach (Minion m in this.enemyMinions)
                {
                    if (m.name == CardDB.cardName.tinyknightofevil && !m.silenced)
                    {
                        m.handcard.card.sim_card.onCardWasDiscarded(this, own, m);
                    }
                }
            }

            this.triggerCardsChanged(own);
        }

        public void triggerCardsChanged(bool own)
        {
            if (own)
            {
                if (this.tempanzOwnCards >= 6 && this.owncards.Count <= 5)
                {
                    //delete effect of enemy Goblin Sapper
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
                    //add effect of enemy Goblin Sapper
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
                    //delete effect of own Goblin Sapper
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
                    //add effect of own Goblin Sapper
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


        public void secretTrigger_HeroPowerUsed(bool own)
        {
            int triggered = 0;
            if (own != this.isOwnTurn)
            {
                if (this.isOwnTurn && this.enemySecretCount >= 1)
                {
                    foreach (SecretItem si in this.enemySecretList)
                    {
                        if (si.canBe_Dart)
                        {
                            triggered++;
                            CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.LOE_021).sim_card.onSecretPlay(this, false, 0);
                            si.usedTrigger_HeroGotDmg();
                            foreach (SecretItem sii in this.enemySecretList)
                            {
                                sii.canBe_Dart = false;
                            }
                        }
                    }
                }
            }

            if (turnCounter == 0)
            {
                this.evaluatePenality -= triggered * 50;
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
                    foreach (SecretItem si in this.enemySecretList.ToArray())
                    {
                        if (si.canBe_explosive)
                        {
                            triggered++;
                            CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_610).sim_card.onSecretPlay(this, false, 0);
                            doDmgTriggers();
                            //Helpfunctions.Instance.ErrorLog("trigger explosive" + attacker.Hp);
                            si.usedTrigger_CharIsAttacked(true, attacker.isHero);
                            foreach (SecretItem sii in this.enemySecretList)
                            {
                                sii.canBe_explosive = false;
                            }
                        }

                        if (!attacker.isHero && si.canBe_vaporize)
                        {
                            triggered++;
                            CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_594).sim_card.onSecretPlay(this, false, attacker, 0);
                            doDmgTriggers();

                            si.usedTrigger_CharIsAttacked(true, attacker.isHero);
                            foreach (SecretItem sii in this.enemySecretList)
                            {
                                sii.canBe_vaporize = false;
                            }
                        }

                        if (si.canBe_missdirection)
                        {
                            if (!(attacker.isHero && this.ownMinions.Count + this.enemyMinions.Count == 0))
                            {
                                triggered++;
                                CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_533).sim_card.onSecretPlay(this, false, attacker, defender, out newTarget);
                                si.usedTrigger_CharIsAttacked(true, attacker.isHero);
                                //Helpfunctions.Instance.ErrorLog("trigger miss " + attacker.Hp);
                                foreach (SecretItem sii in this.enemySecretList)
                                {
                                    sii.canBe_missdirection = false;
                                }
                            }
                        }

                        if (si.canBe_icebarrier)
                        {
                            triggered++;
                            CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_289).sim_card.onSecretPlay(this, false, defender, 0);
                            si.usedTrigger_CharIsAttacked(true, attacker.isHero);
                            foreach (SecretItem sii in this.enemySecretList)
                            {
                                sii.canBe_icebarrier = false;
                            }
                        }

                        if (si.canBe_beartrap)
                        {
                            triggered++;
                            CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.AT_060).sim_card.onSecretPlay(this, false, 0);
                            si.usedTrigger_CharIsAttacked(true, attacker.isHero);
                            foreach (SecretItem sii in this.enemySecretList)
                            {
                                sii.canBe_beartrap = false;
                            }

                        }

                    }

                }

                if (!defender.isHero && !defender.own)
                {
                    foreach (SecretItem si in this.enemySecretList)
                    {

                        if (si.canBe_snaketrap)
                        {
                            triggered++;
                            CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_554).sim_card.onSecretPlay(this, false, 0);
                            si.usedTrigger_CharIsAttacked(false, attacker.isHero);
                            foreach (SecretItem sii in this.enemySecretList)
                            {
                                sii.canBe_snaketrap = false;
                            }
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
                            CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_611).sim_card.onSecretPlay(this, false, attacker, 0);
                            si.usedTrigger_CharIsAttacked(defender.isHero, attacker.isHero);
                            //Helpfunctions.Instance.ErrorLog("trigger freeze " + attacker.Hp);
                            foreach (SecretItem sii in this.enemySecretList)
                            {
                                sii.canBe_freezing = false;
                            }
                        }
                    }
                }

                foreach (SecretItem si in this.enemySecretList)
                {

                    if (si.canBe_noblesacrifice)
                    {
                        //triggered++;
                        bool ishero = defender.isHero;
                        //CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_130).sim_card.onSecretPlay(this, false, attacker, defender, out newTarget);
                        si.usedTrigger_CharIsAttacked(ishero, attacker.isHero);
                        foreach (SecretItem sii in this.enemySecretList)
                        {
                            sii.canBe_noblesacrifice = false;
                        }
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
                            CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_132).sim_card.onSecretPlay(this, false, dmg);
                            si.usedTrigger_HeroGotDmg();
                            foreach (SecretItem sii in this.enemySecretList)
                            {
                                sii.canBe_eyeforaneye = false;
                            }
                        }

                        if (si.canBe_iceblock && this.enemyHero.Hp <= 0)
                        {
                            triggered++;
                            CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_295).sim_card.onSecretPlay(this, false, this.enemyHero, dmg);
                            si.usedTrigger_HeroGotDmg(true);
                            foreach (SecretItem sii in this.enemySecretList)
                            {
                                sii.canBe_iceblock = false;
                            }

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
                int minionCount = this.ownMinions.Count -1; //played minion is allready placed
                foreach (SecretItem si in this.enemySecretList.ToArray())
                {
                    if (si.canBe_snipe)
                    {
                        triggered++;
                        CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_609).sim_card.onSecretPlay(this, false, playedMinion, 0);
                        doDmgTriggers();
                        si.usedTrigger_MinionIsPlayed(minionCount);
                        foreach (SecretItem sii in this.enemySecretList)
                        {
                            sii.canBe_snipe = false;
                        }
                    }

                    if (si.canBe_Trial && minionCount >= 3)
                    {
                        triggered++;
                        CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.LOE_027).sim_card.onSecretPlay(this, false, playedMinion, 0);
                        doDmgTriggers();
                        si.usedTrigger_MinionIsPlayed(minionCount);
                        foreach (SecretItem sii in this.enemySecretList)
                        {
                            sii.canBe_Trial = false;
                        }
                    }

                    if (si.canBe_mirrorentity)
                    {
                        triggered++;
                        CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_294).sim_card.onSecretPlay(this, false, playedMinion, 0);
                        si.usedTrigger_MinionIsPlayed(minionCount);
                        foreach (SecretItem sii in this.enemySecretList)
                        {
                            sii.canBe_mirrorentity = false;
                        }

                    }

                    if (si.canBe_repentance)
                    {
                        //triggered++;
                        //CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_379).sim_card.onSecretPlay(this, false, playedMinion, 0);
                        si.usedTrigger_MinionIsPlayed(minionCount);
                        foreach (SecretItem sii in this.enemySecretList)
                        {
                            sii.canBe_repentance = false;
                        }
                    }
                }
            }

            if (turnCounter == 0)
            {
                this.evaluatePenality -= triggered * 50;
            }

        }

        public int secretTrigger_SpellIsPlayed(Minion target, bool isSpell)
        {
            int triggered = 0;
            int retval = 0;
            if (this.isOwnTurn && isSpell && this.enemySecretCount > 0) //actual secrets need a spell played!
            {
                foreach (SecretItem si in this.enemySecretList)
                {
                    if (si.canBe_counterspell)
                    {
                        triggered++;
                        // dont use spell!
                        si.usedTrigger_SpellIsPlayed(false);
                        foreach (SecretItem sii in this.enemySecretList)
                        {
                            sii.canBe_counterspell = false;
                        }

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
                        CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.tt_010).sim_card.onSecretPlay(this, false, null, target, out retval);
                        si.usedTrigger_SpellIsPlayed(true);
                        foreach (SecretItem sii in this.enemySecretList)
                        {
                            sii.canBe_spellbender = false;
                        }
                    }
                }
            }

            if (turnCounter == 0)
            {
                this.evaluatePenality -= triggered * 50;
            }

            return retval;
        }

        public void secretTrigger_MinionDied(bool own)
        {
            int triggered = 0;

            if (this.isOwnTurn && !own && this.enemySecretCount >= 1)
            {
                List<SecretItem> templist = new List<SecretItem>(this.enemySecretList);
                foreach (SecretItem si in templist)
                {
                    if (si.canBe_duplicate)
                    {
                        triggered++;
                        CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.FP1_018).sim_card.onSecretPlay(this, false, 0);
                        si.usedTrigger_MinionDied();
                        foreach (SecretItem sii in this.enemySecretList)
                        {
                            sii.canBe_duplicate = false;
                        }
                    }

                    if (si.canBe_redemption)
                    {
                        //triggered++;
                        //CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_136).sim_card.onSecretPlay(this, false, 0);
                        si.usedTrigger_MinionDied();
                        foreach (SecretItem sii in this.enemySecretList)
                        {
                            sii.canBe_redemption = false;
                        }
                    }

                    if (si.canBe_effigy)
                    {
                        //triggered++;
                        CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.AT_002).sim_card.onSecretPlay(this, false, 0);
                        si.usedTrigger_MinionDied();
                        foreach (SecretItem sii in this.enemySecretList)
                        {
                            sii.canBe_effigy = false;
                        }
                    }

                    if (si.canBe_avenge)
                    {
                        //triggered++;
                        //CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.FP1_020).sim_card.onSecretPlay(this, false, 0);
                        si.usedTrigger_MinionDied();
                        foreach (SecretItem sii in this.enemySecretList)
                        {
                            sii.canBe_avenge = false;
                        }
                    }


                }
            }

            if (turnCounter == 0)
            {
                this.evaluatePenality -= triggered * 50;
            }

        }



        public void doDeathrattles(List<Minion> deathrattles)
        {
            //todo sort them from oldest to newest (first played, first deathrattle)
            //https://www.youtube.com/watch?v=2WrbqsOSbhc
            foreach (Minion m in deathrattles)
            {
                if (!m.silenced && m.handcard.card.deathrattle) m.handcard.card.sim_card.onDeathrattle(this, m);

                for (int i = 0; i < m.souloftheforest; i++)
                {
                    CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_158t);//Treant
                    int pos = (m.own) ? this.ownMinions.Count : this.enemyMinions.Count; //these guys actually do spawn at the right
                    callKid(kid, pos, m.own);
                }

                for (int i = 0; i < m.ancestralspirit; i++)
                {
                    CardDB.Card kid = m.handcard.card;
                    int pos = (m.own) ? this.ownMinions.Count : this.enemyMinions.Count;
                    callKid(kid, pos, m.own);
                }

                for (int i = 0; i < m.explorershat; i++)
                {
                    this.drawACard(CardDB.cardIDEnum.LOE_105, m.own, true);
                }

                //baron rivendare ??
                if ((m.own && this.ownBaronRivendare >= 1) || (!m.own && this.enemyBaronRivendare >= 1))
                {
                    if (!m.silenced && m.handcard.card.deathrattle) m.handcard.card.sim_card.onDeathrattle(this, m);

                    for (int i = 0; i < m.souloftheforest; i++)
                    {
                        CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_158t);//Treant
                        int pos = (m.own) ? this.ownMinions.Count : this.enemyMinions.Count;
                        callKid(kid, pos, m.own);
                    }

                    for (int i = 0; i < m.ancestralspirit; i++)
                    {
                        CardDB.Card kid = m.handcard.card;
                        int pos = (m.own) ? this.ownMinions.Count : this.enemyMinions.Count;
                        callKid(kid, pos, m.own);
                    }

                    for (int i = 0; i < m.explorershat; i++)
                    {
                        this.drawACard(CardDB.cardIDEnum.LOE_105, m.own, true);
                    }

                }
            }


        }


        public void updateBoards()
        {
            if (!this.tempTrigger.ownMinionsChanged && !this.tempTrigger.enemyMininsChanged) return;
            List<Minion> deathrattles = new List<Minion>();

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
                    if ((m.name == CardDB.cardName.faeriedragon || m.name == CardDB.cardName.spectralknight || m.name == CardDB.cardName.laughingsister || m.name == CardDB.cardName.arcanenullifierx21 || m.name == CardDB.cardName.soggoththeslitherer) && !m.silenced)
                    {
                        m.cantBeTargetedBySpellsOrHeroPowers = true;
                    }

                    //kill it!
                    if (m.Hp <= 0)
                    {
                        if (this.revivingOwnMinion == CardDB.cardIDEnum.None)
                        {
                            this.revivingOwnMinion = m.handcard.card.cardIDenum;
                            minionOwnReviving = true;
                        }

                        if ((!m.silenced && m.handcard.card.deathrattle) || m.ancestralspirit >= 1 || m.souloftheforest >= 1 || m.explorershat >= 1)
                        {
                            deathrattles.Add(m);
                        }
                        // end aura of minion m
                        m.endAura(this);

                        /*if (m.handcard.card.name == CardDB.cardName.cairnebloodhoof || m.handcard.card.name == CardDB.cardName.harvestgolem || m.ancestralspirit>=1)
                        {
                            this.evaluatePenality -= Ai.Instance.botBase.getEnemyMinionValue(m, this) - 1;
                        }*/

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
                    if ((m.name == CardDB.cardName.faeriedragon || m.name == CardDB.cardName.spectralknight || m.name == CardDB.cardName.laughingsister || m.name == CardDB.cardName.arcanenullifierx21 || m.name == CardDB.cardName.soggoththeslitherer) && !m.silenced)
                    {
                        m.cantBeTargetedBySpellsOrHeroPowers = true;
                    }

                    //kill it!
                    if (m.Hp <= 0)
                    {
                        if (this.revivingEnemyMinion == CardDB.cardIDEnum.None)
                        {
                            this.revivingEnemyMinion = m.handcard.card.cardIDenum;
                            minionEnemyReviving = true;
                        }

                        if ((!m.silenced && m.handcard.card.deathrattle) || m.ancestralspirit >= 1 || m.souloftheforest >= 1 || m.explorershat>=1)
                        {
                            deathrattles.Add(m);
                        }

                        m.endAura(this);

                        if ((!m.silenced && (m.handcard.card.name == CardDB.cardName.cairnebloodhoof || m.handcard.card.name == CardDB.cardName.harvestgolem)) || m.ancestralspirit >= 1)
                        {
                            if (Ai.Instance.botBase != null) this.evaluatePenality -= Ai.Instance.botBase.getEnemyMinionValue(m, this) - 1;
                        }
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

            if (this.ownWeaponName == CardDB.cardName.spiritclaws)
            {
                if (this.spellpower > 0 && !this.ownSpiritclaws)
                {
                        this.minionGetBuffed(this.ownHero, 2, 0);
                        this.ownWeaponAttack += 2;
                        this.ownSpiritclaws = true;
                }
                else if (this.spellpower < 1 && this.ownSpiritclaws)
                {
                        this.minionGetBuffed(this.ownHero, -2, 0);
                        this.ownWeaponAttack += -2;
                        this.ownSpiritclaws = false;
                }
            }
            if (this.enemyWeaponName == CardDB.cardName.spiritclaws)
            {
                if (this.enemyspellpower > 0 && !this.enemySpiritclaws)
                {
                    this.minionGetBuffed(this.enemyHero, 2, 0);
                    this.enemyWeaponAttack += 2;
                    this.enemySpiritclaws = true;
                }
                else if (this.enemyspellpower < 1 && this.enemySpiritclaws)
                {
                    this.minionGetBuffed(this.enemyHero, -2, 0);
                    this.enemyWeaponAttack += -2;
                    this.enemySpiritclaws = false;
                }
            }


            if (deathrattles.Count >= 1) this.doDeathrattles(deathrattles);

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

            if (m.handcard.card.race == TAG_RACE.MURLOC)
            {
                if (m.own)
                {
                    angr += 2 * anzOwnMurlocWarleader + anzOwnGrimscaleOracle;
                    vert += anzOwnMurlocWarleader;
                }
                else
                {
                    angr += 2 * anzEnemyMurlocWarleader + anzEnemyGrimscaleOracle;
                    vert += anzEnemyMurlocWarleader;
                }
            }

            if (!m.silenced) // if they are not silenced, these minions will give a buff, but cant buff themselfes
            {
                switch (m.name)
                {
                    case CardDB.cardName.raidleader:
                    case CardDB.cardName.leokk:
                    case CardDB.cardName.timberwolf:
                    case CardDB.cardName.grimscaleoracle:
                        angr--;
                        break;
                    case CardDB.cardName.stormwindchampion:
                    case CardDB.cardName.southseacaptain:
                        angr--;
                        vert--;
                        break;
                    case CardDB.cardName.murlocwarleader:
                        if (get)
                        {
                            angr -= 2;
                            vert--;
                        }
                        break;
                }
            }


            if (m.own)
            {
                // todo charge:  m.charge -= anzOwnTundrarhino;
                if (get) m.charge += anzOwnTundrarhino;
                else m.charge -= anzOwnTundrarhino;
                angr += anzOwnRaidleader;
                angr += anzOwnStormwindChamps;
                vert += anzOwnStormwindChamps;
                if (m.handcard.card.race == TAG_RACE.PET)
                {
                    angr += anzOwnTimberWolfs;
                }
                if (m.handcard.card.race == TAG_RACE.PIRATE)
                {
                    angr += anzOwnSouthseacaptain;
                    vert += anzOwnSouthseacaptain;

                }
                if (m.handcard.card.race == TAG_RACE.DEMON)
                {
                    angr += anzOwnMalGanis *2;
                    vert += anzOwnMalGanis * 2;

                }

                if (m.charge >= 1)
                {
                    angr += this.anzOwnWarsongCommanders;
                }

                if (m.name == CardDB.cardName.silverhandrecruit)
                {
                    angr += anzOwnWarhorseTrainer;
                }

            }
            else
            {
                if (get) m.charge += anzEnemyTundrarhino;
                else m.charge -= anzEnemyTundrarhino;
                angr += anzEnemyRaidleader;
                angr += anzEnemyStormwindChamps;
                vert += anzEnemyStormwindChamps;

                if (m.handcard.card.race == TAG_RACE.PET)
                {
                    angr += anzEnemyTimberWolfs;
                }
                if (m.handcard.card.race == TAG_RACE.PIRATE)
                {
                    angr += anzEnemySouthseacaptain;
                    vert += anzEnemySouthseacaptain;
                }
                if (m.handcard.card.race == TAG_RACE.DEMON)
                {
                    angr += anzEnemyMalGanis * 2;
                    vert += anzEnemyMalGanis * 2;

                }

                if (m.charge >= 1)
                {
                    angr += this.anzEnemyWarsongCommanders;
                }

                if (m.name == CardDB.cardName.silverhandrecruit)
                {
                    angr += anzEnemyWarhorseTrainer;
                }
            }

            if (get)
            {
                this.minionGetBuffed(m, angr, vert);
            }
            else
            {
                this.minionGetBuffed(m, -angr, -vert);
            }

        }

        public void updateAdjacentBuffs(bool own)
        {
            //todo sepefeets - more updates need to call this?
            //only call this after update board
            if (own)
            {
                int anz = this.ownMinions.Count;
                for (int i = 0; i < anz; i++)
                {
                    Minion m = this.ownMinions[i];
                    if (!m.silenced)
                    {
                        if (m.name == CardDB.cardName.direwolfalpha)
                        {
                            if (i > 0) this.minionGetAdjacentBuff(this.ownMinions[i - 1], 1, 0);
                            if (i < anz - 1) this.minionGetAdjacentBuff(this.ownMinions[i + 1], 1, 0);
                        }

                        if (m.name == CardDB.cardName.flametonguetotem)
                        {
                            if (i > 0) this.minionGetAdjacentBuff(this.ownMinions[i - 1], 2, 0);
                            if (i < anz - 1) this.minionGetAdjacentBuff(this.ownMinions[i + 1], 2, 0);
                        }

                        if (m.name == CardDB.cardName.weespellstopper)
                        {
                            if (i > 0) this.ownMinions[i - 1].cantBeTargetedBySpellsOrHeroPowers = true;
                            if (i < anz - 1) this.ownMinions[i + 1].cantBeTargetedBySpellsOrHeroPowers = true;
                        }
                    }
                }
            }
            else
            {
                int anz = this.enemyMinions.Count;
                for (int i = 0; i < anz; i++)
                {
                    Minion m = this.enemyMinions[i];
                    if (!m.silenced)
                    {
                        if (m.name == CardDB.cardName.direwolfalpha)
                        {
                            if (i > 0) this.minionGetAdjacentBuff(this.enemyMinions[i - 1], 1, 0);
                            if (i < anz - 1) this.minionGetAdjacentBuff(this.enemyMinions[i + 1], 1, 0);
                        }

                        if (m.name == CardDB.cardName.flametonguetotem)
                        {
                            if (i > 0) this.minionGetAdjacentBuff(this.enemyMinions[i - 1], 2, 0);
                            if (i < anz - 1) this.minionGetAdjacentBuff(this.enemyMinions[i + 1], 2, 0);
                        }

                        if (m.name == CardDB.cardName.weespellstopper)
                        {
                            if (i > 0) this.enemyMinions[i - 1].cantBeTargetedBySpellsOrHeroPowers = true;
                            if (i < anz - 1) this.enemyMinions[i + 1].cantBeTargetedBySpellsOrHeroPowers = true;
                        }
                    }
                }
            }
        }

        public Minion createNewMinion(Handmanager.Handcard hc, int zonepos, bool own)
        {
            Minion m = new Minion();
            Handmanager.Handcard handc = new Handmanager.Handcard(hc);
            //Handmanager.Handcard handc = hc; // new Handcard(hc)?
            m.handcard = handc;
            m.own = own;
            m.isHero = false;
            m.entityID = hc.entity;
            m.Angr = hc.card.Attack + hc.addattack;
            m.Hp = hc.card.Health + hc.addHp;

            hc.addattack = 0;
            hc.addHp = 0;

            m.maxHp = hc.card.Health;
            m.name = hc.card.name;
            m.playedThisTurn = true;
            m.numAttacksThisTurn = 0;
            m.zonepos = zonepos;
            m.windfury = hc.card.windfury;
            m.taunt = hc.card.tank;
            m.charge = (hc.card.Charge) ? 1 : 0;
            m.divineshild = hc.card.Shield;
            m.poisonous = hc.card.poisionous;
            m.stealth = hc.card.Stealth;
            m.spellpower = 0; //we set this value in onAuraStarts!

            m.updateReadyness(this);

            if (m.name == CardDB.cardName.lightspawn)
            {
                m.Angr = m.Hp;
            }


            //trigger on summon effect!
            this.triggerAMinionIsSummoned(m);
            //activate onAura effect
            m.handcard.card.sim_card.onAuraStarts(this, m);
            //buffs minion
            this.minionGetOrEraseAllAreaBuffs(m, true);
            return m;
        }

        public void placeAmobSomewhere(Handmanager.Handcard hc, Minion target, int choice, int zonepos)
        {
            int mobplace = zonepos;

            //create the new minion + trigger Summon effects + buffs it
            Minion m = createNewMinion(hc, mobplace, true);


            //trigger the battlecry!
            m.handcard.card.sim_card.getBattlecryEffect(this, m, target, choice);
            if (m.own)
            {
                if (this.anzOwnBranns >= 1)
                {
                    m.handcard.card.sim_card.getBattlecryEffect(this, m, target, choice);
                }
            }
            else
            {
                if (this.anzEnemyBranns >= 1)
                {
                    m.handcard.card.sim_card.getBattlecryEffect(this, m, target, choice);
                }
            }

            

            //add minion to list + do triggers + do secret trigger +  minion was played trigger
            addMinionToBattlefield(m);

            secretTrigger_MinionIsPlayed(m);


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
                if (m.handcard.card.race == TAG_RACE.TOTEM) this.tempTrigger.ownTotemSummoned++;
                if (m.handcard.card.race == TAG_RACE.PET) this.tempTrigger.ownBeastSummoned++;
            }
            else this.tempTrigger.enemyMininsChanged = true;
            doDmgTriggers();


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
                if (this.ownWeaponDurability >= 1)
                {
                    this.lostWeaponDamage += this.ownWeaponDurability * this.ownWeaponAttack;
                    this.lowerWeaponDurability(1000, true);
                    hero.Angr -= this.ownWeaponAttack;
                }
                this.ownWeaponAttack = c.Attack + this.anzOwnBuccaneer;
                this.ownWeaponDurability = c.Durability;
                this.ownWeaponName = c.name;
            }
            else
            {
                if (this.enemyWeaponDurability >= 1)
                {
                    hero.Angr -= this.enemyWeaponAttack;
                }
                this.enemyWeaponAttack = c.Attack + this.anzEnemyBuccaneer;
                this.enemyWeaponDurability = c.Durability;
                this.enemyWeaponName = c.name;
            }



            hero.Angr += c.Attack;

            hero.windfury = (c.name == CardDB.cardName.doomhammer || c.name == CardDB.cardName.foolsbane); // foolsbane has unlimited attacks but use windfury for simplicity unless it becomes a problem

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
                        if (own) this.ownWeaponAttack++;
                        else this.enemyWeaponAttack++;
                        break;
                    case CardDB.cardName.smalltimebuccaneer:
                        this.minionGetBuffed(m, 2, 0);
                        break;
                }
            }

        }


        public void callKid(CardDB.Card c, int zonepos, bool own, bool spawnKid = false, bool oneMoreIsAllowed = false)
        {
            //spawnKid = true if its a minion spawned with another one (battlecry)
            int allowed = 7;
            allowed += (oneMoreIsAllowed) ? 1 : 0;
            allowed -= (spawnKid) ? 1 : 0;

            if (own)
            {
                if (this.ownMinions.Count >= allowed)
                {
                    if(spawnKid) this.evaluatePenality += 20;
                    return;
                }
            }
            else
            {
                if (this.enemyMinions.Count >= allowed)
                {
                    if (spawnKid) this.evaluatePenality -= 20;
                    return;
                }
            }
            //int mobplace = zonepos + 1;//todo check this?
            int mobplace = (spawnKid ? zonepos : zonepos + 1);
            //create minion (+triggers)
            Handmanager.Handcard hc = new Handmanager.Handcard(c) { entity = this.getNextEntity() };
            Minion m = createNewMinion(hc, mobplace, own);
            //put it on battle field (+triggers)
            addMinionToBattlefield(m);

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
                CardDB.Card plchldr = new CardDB.Card { name = CardDB.cardName.unknown };
                Handmanager.Handcard hc = new Handmanager.Handcard { card = plchldr, position = this.owncards.Count + 1, manacost = 1000, entity = this.getNextEntity() };
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
                CardDB.Card plchldr = new CardDB.Card { name = CardDB.cardName.unknown };
                for (int i = 1; i <= anzOwnChromaggus; i++)
                {
                    if (this.owncards.Count >= 10)
                    {
                        this.evaluatePenality += 15;
                        return;
                    }
                    this.owncarddraw++;

                    Handmanager.Handcard hc = new Handmanager.Handcard { card = plchldr, position = this.owncards.Count + 1, manacost = 1000, entity = this.getNextEntity() };
                    this.owncards.Add(hc);
                    this.triggerCardsChanged(true);
                }
            }

        }

        public void drawACard(CardDB.cardIDEnum ss, bool own, bool no_pen = false, bool reduceManaToZero = false)
        {
            CardDB.cardIDEnum s = ss;

            // cant hold more than 10 cards
            int draw = 1;//number of card drawn!
            if (!no_pen)
            {
                List<Minion> temp = (own) ? this.ownMinions : this.enemyMinions;
                foreach (Minion m in temp)
                {
                    if (m.name == CardDB.cardName.chromaggus && !m.silenced) draw++;
                }
            }
            int oldenemyanz = this.enemyAnzCards;

            if (own)
            {
                oldenemyanz = this.owncards.Count;

                if (s == CardDB.cardIDEnum.None && !no_pen) // draw a card from deck :D
                {
                    if (ownDeckSize == 0)
                    {
                        this.ownHeroFatigue++;
                        this.ownHero.getDamageOrHeal(this.ownHeroFatigue, this, false, true);
                    }
                    else
                    {
                        this.ownDeckSize--;
                        if (this.owncards.Count >= 10)
                        {
                            this.evaluatePenality += 15 * draw;
                            //return;
                        }
                        else
                        {
                            this.owncarddraw += draw;
                        }
                    }

                }
                else
                {
                    if (this.owncards.Count >= 10)
                    {
                        this.evaluatePenality += 5;
                        //return;
                    }
                    else
                    {
                        this.owncarddraw++;
                    }

                }


            }
            else
            {
                
                if (s == CardDB.cardIDEnum.None && !no_pen) // draw a card from deck :D
                {
                    if (enemyDeckSize == 0)
                    {
                        this.enemyHeroFatigue++;
                        this.enemyHero.getDamageOrHeal(this.enemyHeroFatigue, this, false, true);
                    }
                    else
                    {
                        this.enemyDeckSize--;
                        if (this.enemyAnzCards >= 10)
                        {
                            this.evaluatePenality = (this.enemycarddraw >= 0) ? 10 : 25;
                            //return;
                        }
                        else
                        {
                            this.enemycarddraw += draw;
                            this.enemyAnzCards += draw;
                        }
                    }

                }
                else
                {
                    if (this.enemyAnzCards >= 10)
                    {
                        this.evaluatePenality -= 50;
                        //return;
                    }
                    else
                    {
                        this.enemycarddraw++;
                        this.enemyAnzCards++;
                    }

                }
                //if (this.enemyAnzCards != oldenemyanz) this.triggerCardsChanged(false);
                //return;
            }

            //simulated draw:
            if (own)
            {
                if (s == CardDB.cardIDEnum.None)
                {
                    CardDB.Card plchldr = CardDB.Instance.unknownCard;

                    for (int i = 0; i < draw; i++)
                    {
                        Handmanager.Handcard hc = new Handmanager.Handcard { card = plchldr, position = this.owncards.Count + 1, manacost = 1000, entity = this.getNextEntity() };
                        if (i == 0 && reduceManaToZero) hc.manacost = 0;
                        this.owncards.Add(hc);
                    }
                }
                else
                {
                    CardDB.Card c = CardDB.Instance.getCardDataFromID(s);
                    int manac = Math.Max(0, c.cost - this.anzOwnShadowfiends);
                    Handmanager.Handcard hc = new Handmanager.Handcard { card = c, position = this.owncards.Count + 1, manacost = manac, entity = this.getNextEntity() };
                    this.owncards.Add(hc);
                }
            }

            if (own)
            {
                if (this.owncards.Count != oldenemyanz) this.triggerCardsChanged(true);
            }
            else
            {
                if (this.enemyAnzCards != oldenemyanz) this.triggerCardsChanged(false);
            }

        }
        

        public void removeCard(Handmanager.Handcard hcc)
        {
            //todo test this and remove toarray()
            //this.owncards.RemoveAll(x => x.entity == hcc.entity);

            int i = 1;
            foreach (Handmanager.Handcard hc in this.owncards.ToArray())
            {
                if (hc.entity == hcc.entity)
                {
                    this.owncards.Remove(hc);
                    continue;
                }
                this.owncards[i - 1].position = i;
                //hc.position = i;
                i++;
            }

        }

        


        // some helpfunctions 


        public void attackEnemyHeroWithoutKill(int dmg)
        {
            this.enemyHero.cantLowerHPbelowONE = true;
            this.minionGetDamageOrHeal(this.enemyHero, dmg);
            this.enemyHero.cantLowerHPbelowONE = false;
        }

        public void minionGetDestroyed(Minion m)
        {
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
            List<Minion> temp = (own) ? this.ownMinions : this.enemyMinions;

            m.endAura(this);

            temp.Remove(m);

            if (own)
            {
                CardDB.Card c = m.handcard.card;
                Handmanager.Handcard hc = new Handmanager.Handcard { card = c, position = this.owncards.Count + 1, entity = m.entityID, manacost = c.cost + manachange };
                if (this.owncards.Count < 10)
                {
                    this.owncards.Add(hc);
                    this.triggerCardsChanged(true);
                }
                else
                {
                    this.drawACard(CardDB.cardIDEnum.None, true);
                }
                this.tempTrigger.ownMinionsChanged = true;
            }
            else
            {
                this.drawACard(CardDB.cardIDEnum.None, false);
                this.tempTrigger.enemyMininsChanged = true;
            }
        }

        public void minionTransform(Minion m, CardDB.Card c)
        {
            m.endAura(this);

            Handmanager.Handcard hc = new Handmanager.Handcard(c){ entity = this.getNextEntity() }; // m.entityID;
            int ancestral = m.ancestralspirit;
            if (m.handcard.card.name == CardDB.cardName.cairnebloodhoof || m.handcard.card.name == CardDB.cardName.harvestgolem || ancestral >= 1)
            {
                if (Ai.Instance.botBase != null) this.evaluatePenality -= Ai.Instance.botBase.getEnemyMinionValue(m, this) - 1;
            }

            //necessary???
            /*Minion tranform = createNewMinion(hc, m.zonepos, m.own);
            Minion temp = new Minion();
            temp.setMinionTominion(m);
            m.setMinionTominion(tranform);*/

            m.setMinionTominion(createNewMinion(hc, m.zonepos, m.own));

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
            return kid;
        }

        public Minion getEnemyCharTargetForRandomSingleDamage(int damage)
        {
            Minion target = new Minion();
            int tmp = this.guessingHeroHP;
            this.guessHeroDamage();
            if (this.guessingHeroHP < 0)
            {
                target = this.searchRandomMinionByMaxHP(this.enemyMinions, searchmode.searchHighestAttack, damage); //the last chance (optimistic)
                if (target == null || this.enemyHero.Hp <= damage) target = this.enemyHero;
            }
            else
            {
                target = this.searchRandomMinion(this.enemyMinions, damage > 3 ? searchmode.searchLowestHP : searchmode.searchHighestHP); //damage the lowest (pessimistic)
                if (target == null) target = this.enemyHero;
            }
            this.guessingHeroHP = tmp;
            return target;
        }

        public void minionGetControlled(Minion m, bool newOwner, bool canAttack)
        {
            List<Minion> newOwnerList = (newOwner) ? this.ownMinions : this.enemyMinions;
            List<Minion> oldOwnerList = (newOwner) ? this.enemyMinions : this.ownMinions;



            if (newOwnerList.Count >= 7) return;

            this.tempTrigger.ownMinionsChanged = true;
            this.tempTrigger.enemyMininsChanged = true;

            //end buffs/aura
            m.endAura(this);

            this.minionGetOrEraseAllAreaBuffs(m, false);

            //remove minion from list
            oldOwnerList.Remove(m);

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
            m.updateReadyness(this);

        }



        public void minionGetWindfurry(Minion m)
        {
            if (m.windfury) return;
            m.windfury = true;
            m.updateReadyness(this);
        }

        public void minionGetCharge(Minion m)
        {
            this.minionGetOrEraseAllAreaBuffs(m, false);//because of warsong commander
            m.charge++;
            m.updateReadyness(this);
            this.minionGetOrEraseAllAreaBuffs(m, true);
        }

        public void minionLostCharge(Minion m)
        {
            this.minionGetOrEraseAllAreaBuffs(m, false);//because of warsong commander
            m.charge--;
            m.updateReadyness(this);
            this.minionGetOrEraseAllAreaBuffs(m, true);
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
            m.Angr = Math.Max(0, m.Angr + attackbuff);

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

            if (m.name == CardDB.cardName.lightspawn && !m.silenced)
            {
                m.Angr = m.Hp;
            }

        }

        public void minionSetAngrToOne(Minion m)
        {
            if (!m.silenced && m.name == CardDB.cardName.lightspawn) return;
            m.Angr = 1;
            m.tempAttack = 0;
            this.minionGetOrEraseAllAreaBuffs(m, true);
        }

        public void minionSetLifetoOne(Minion m)
        {
            minionGetOrEraseAllAreaBuffs(m, false);
            m.Hp = 1;
            m.maxHp = 1;
            if (m.wounded && !m.silenced) m.handcard.card.sim_card.onEnrageStop(this, m);
            m.wounded = false;
            minionGetOrEraseAllAreaBuffs(m, true);
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
            m.getDamageOrHeal(dmgOrHeal, this, false, dontDmgLoss);
        }



        public void allMinionOfASideGetDamage(bool own, int damages, bool frozen = false)
        {
            List<Minion> temp = (own) ? this.ownMinions : this.enemyMinions;
            foreach (Minion m in temp)
            {
                if (frozen) m.frozen = true;
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
            foreach (Minion m in temp)
            {
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

        public void allCharsGetDamage(int damages)
        {
            foreach (Minion m in this.ownMinions)
            {
                minionGetDamageOrHeal(m, damages, true);
            }
            foreach (Minion m in this.enemyMinions)
            {
                minionGetDamageOrHeal(m, damages, true);
            }
            minionGetDamageOrHeal(this.ownHero, damages);
            minionGetDamageOrHeal(this.enemyHero, damages);
        }

        public void allMinionsGetDamage(int damages)
        {
            foreach (Minion m in this.ownMinions)
            {
                minionGetDamageOrHeal(m, damages, true);
            }
            foreach (Minion m in this.enemyMinions)
            {
                minionGetDamageOrHeal(m, damages, true);
            }
        }

        public enum searchmode
        {
            searchLowestHP,
            searchHighestHP,
            searchLowestAttack,
            searchHighestAttack,
            searchHighAttackLowHP, //get max attack/hp ratio
            searchHighHPLowAttack, //get max hp/attack ratio
            searchLowestCost,
            searchHighesCost,
        }

        public enum cardsProperty
        {
            None,
            Spell,
            Secret,
            Mob,
            Race,
            Taunt,
            Combo,
            Shield,
            Enrage,
            Overload,
            ClassCard,
            Weapon
        }


        private void getHandcardsByType(List<Handmanager.Handcard> cards, cardsProperty prop, TAG_RACE race = TAG_RACE.INVALID)
        {
            switch (prop)
            {
                case cardsProperty.None:
                    foreach (Handmanager.Handcard hc in cards) hc.extraParam3 = true;
                    break;
                case cardsProperty.Spell:
                    foreach (Handmanager.Handcard hc in cards) if (hc.card.type == CardDB.cardtype.SPELL) hc.extraParam3 = true;
                    break;
                case cardsProperty.Secret:
                    foreach (Handmanager.Handcard hc in cards) if (hc.card.Secret) hc.extraParam3 = true;
                    break;
                case cardsProperty.Mob:
                    foreach (Handmanager.Handcard hc in cards) if (hc.card.type == CardDB.cardtype.MOB) hc.extraParam3 = true;
                    break;
                case cardsProperty.Race:
                    foreach (Handmanager.Handcard hc in cards)
                    {
                        if (hc.card.type == CardDB.cardtype.MOB)
                        {
                            if (race == TAG_RACE.INVALID) hc.extraParam3 = true;
                            else if (hc.card.race == race) hc.extraParam3 = true;
                        }
                    }
                    break;
                case cardsProperty.Taunt:
                    foreach (Handmanager.Handcard hc in cards) if (hc.card.tank) hc.extraParam3 = true;
                    break;
                case cardsProperty.Combo:
                    foreach (Handmanager.Handcard hc in cards) if (hc.card.Combo) hc.extraParam3 = true;
                    break;
                case cardsProperty.Shield:
                    foreach (Handmanager.Handcard hc in cards) if (hc.card.Shield) hc.extraParam3 = true;
                    break;
                case cardsProperty.Enrage:
                    foreach (Handmanager.Handcard hc in cards) if (hc.card.Enrage) hc.extraParam3 = true;
                    break;
                case cardsProperty.Overload:
                    foreach (Handmanager.Handcard hc in cards) if (hc.card.overload > 0) hc.extraParam3 = true;
                    break;
                case cardsProperty.ClassCard:
                    foreach (Handmanager.Handcard hc in cards) if (hc.card.Class == (int)ownHeroStartClass) hc.extraParam3 = true;
                    break;
                case cardsProperty.Weapon:
                    foreach (Handmanager.Handcard hc in cards) if (hc.card.type == CardDB.cardtype.WEAPON) hc.extraParam3 = true;
                    break;
            }
        }

        public Handmanager.Handcard searchRandomMinionInHand(List<Handmanager.Handcard> cards, searchmode mode, cardsProperty cardsProp = cardsProperty.None, TAG_RACE race = TAG_RACE.INVALID)
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
                case searchmode.searchLowestCost: value = 1000; break;
                case searchmode.searchHighesCost: value = -1; break;
            }

            getHandcardsByType(cards, cardsProp, race);
            foreach (Handmanager.Handcard hc in cards)
            {
                if (!hc.extraParam3) continue;

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
            Minion ret = minions[0];
            int value = 0;
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
                        break;
                    case searchmode.searchHighestHP:
                        if (m.Hp > value)
                        {
                            ret = m;
                            value = m.Hp;
                        }
                        break;
                    case searchmode.searchLowestAttack:
                        if (m.Angr < value)
                        {
                            ret = m;
                            value = m.Angr;
                        }
                        break;
                    case searchmode.searchHighestAttack:
                        if (m.Angr > value)
                        {
                            ret = m;
                            value = m.Angr;
                        }
                        break;
                    case searchmode.searchHighAttackLowHP:
                        if (m.Angr / m.Hp > value)
                        {
                            ret = m;
                            value = m.Angr / m.Hp;
                        }
                        break;
                    case searchmode.searchHighHPLowAttack:
                        if (m.Hp / m.Angr > value)
                        {
                            ret = m;
                            value = m.Hp / m.Angr;
                        }
                        break;
                    case searchmode.searchLowestCost:
                        if (m.handcard.card.cost < value)
                        {
                            ret = m;
                            value = m.handcard.card.cost;
                        }
                        break;
                    case searchmode.searchHighesCost:
                        if (m.handcard.card.cost > value)
                        {
                            ret = m;
                            value = m.handcard.card.cost;
                        }
                        break;
                }
            }
            return ret;
        }

        public Minion searchRandomMinionByMaxHP(List<Minion> minions, searchmode mode, int maxHP)
        {
            //optimistic search

            if (maxHP < 1) return null;
            if (minions.Count == 0) return null;

            Minion ret = minions[0];

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
                        break;
                    case searchmode.searchLowestAttack:
                        if (m.Angr < value)
                        {
                            ret = m;
                            value = m.Angr;
                            retVal = m.Hp;
                        }
                        else if (m.Angr == value && retVal < m.Hp) ret = m;
                        break;
                    case searchmode.searchHighestAttack:
                        if (m.Angr > value)
                        {
                            ret = m;
                            value = m.Angr;
                            retVal = m.Hp;
                        }
                        else if (m.Angr == value && retVal < m.Hp) ret = m;
                        break;
                    case searchmode.searchHighAttackLowHP:
                        if (m.Angr / m.Hp > value)
                        {
                            ret = m;
                            value = m.Angr / m.Hp;
                            retVal = m.Hp;
                        }
                        else if (m.Angr / m.Hp == value && retVal < m.Hp) ret = m;
                        break;
                    case searchmode.searchHighHPLowAttack:
                        if (m.Hp / m.Angr > value)
                        {
                            ret = m;
                            value = m.Hp / m.Angr;
                            retVal = m.Hp;
                        }
                        else if (m.Angr / m.Hp == value && retVal < m.Hp) ret = m;
                        break;
                    default: //==searchHighestHP
                        if (m.Hp > value)
                        {
                            ret = m;
                            value = m.Hp;
                            retVal = m.Angr;
                        }
                        else if (m.Hp == value && retVal < m.Angr) ret = m;
                        break;
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
                default: return CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.CFM_712_t30);
            }
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

        public void printBoard(bool justactions = false, int boardnumber = -1)
        {
            if (boardnumber >= 0)
            {
                Helpfunctions.Instance.logg("index: "+boardnumber + " board: " + value + " ++++++++++++++++++++++");
            }
            else
            {
                Helpfunctions.Instance.logg("board: " + value + " ++++++++++++++++++++++");
            }

            if (justactions)
            {
                foreach (Action a in this.playactions)
                {
                    a.print();
                }
            }
            else
            {
                Helpfunctions.Instance.logg("pen " + this.evaluatePenality);
                if (this.selectedChoice >= 1) Helpfunctions.Instance.logg("tracking " + this.selectedChoice);
                Helpfunctions.Instance.logg("mana " + this.mana + "/" + this.ownMaxMana + " turnEndMana " + this.manaTurnEnd);
                Helpfunctions.Instance.logg("cardsplayed: " + this.cardsPlayedThisTurn + " handsize: " + this.owncards.Count + " eh " + this.enemyAnzCards + " " + this.enemycarddraw);

                Helpfunctions.Instance.logg("ownhero: ");
                Helpfunctions.Instance.logg("ownherohp: " + this.ownHero.Hp + " + " + this.ownHero.armor);
                Helpfunctions.Instance.logg("ownheroattack: " + this.ownHero.Angr);
                Helpfunctions.Instance.logg("ownheroweapon: " + this.ownWeaponAttack + " " + this.ownWeaponDurability + " " + this.ownWeaponName);
                Helpfunctions.Instance.logg("ownherostatus: frozen" + this.ownHero.frozen + " ");
                Helpfunctions.Instance.logg("enemyherohp: " + this.enemyHero.Hp + " + " + this.enemyHero.armor + ((this.enemyHero.immune) ? " immune" : ""));

                if (this.enemySecretCount >= 1) Helpfunctions.Instance.logg("enemySecrets: " + this.enemySecretCount + " " + Probabilitymaker.Instance.getEnemySecretData(this.enemySecretList));
                Helpfunctions.Instance.logg("OWN MINIONS################");

                foreach (Minion m in this.ownMinions)
                {
                    String attrib = this.getMinionString(m);
                    Helpfunctions.Instance.logg(attrib);
                }

                Helpfunctions.Instance.logg("ENEMY MINIONS############");
                foreach (Minion m in this.enemyMinions)
                {
                    String attrib = this.getMinionString(m);
                    Helpfunctions.Instance.logg(attrib);
                }
            }

            Helpfunctions.Instance.logg("");
        }

        public void printBoardDebug()
        {
            Helpfunctions.Instance.logg("hero " + this.ownHero.Hp + " " + this.ownHero.armor + " " + this.ownHero.entityID);
            Helpfunctions.Instance.logg("ehero " + this.enemyHero.Hp + " " + this.enemyHero.armor + " " + this.enemyHero.entityID);
            foreach (Minion m in ownMinions)
            {
                Helpfunctions.Instance.logg(m.name + " " + m.entityID);
            }
            Helpfunctions.Instance.logg("-");
            foreach (Minion m in enemyMinions)
            {
                Helpfunctions.Instance.logg(m.name + " " + m.entityID);
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
            if (a.actionType == actionEnum.attackWithMinion && a.target != null)
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

            if (a.actionType == actionEnum.attackWithHero && a.target != null)
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

        public string getCompleteBoardForSimulating(String settings, String version, String time)
        {
            //returns same string as: 
            /*
            string dtimes = DateTime.Now.ToString("HH:mm:ss:ffff");
            hpf.writeToBuffer("#######################################################################");
            hpf.writeToBuffer("#######################################################################");
            hpf.writeToBuffer("start calculations, current time: " + dtimes + " V" + "115.55" + " " + p.settings);
            hpf.writeToBuffer("#######################################################################");
            hpf.writeToBuffer("mana " + p.curMana + "/" + p.maxMana);
            hpf.writeToBuffer("emana " + opponent.maxMana);
            hpf.writeToBuffer("own secretsCount: " + ownsecretcount);
            hpf.writeToBuffer("enemy secretsCount: " + enemySecretCount + " ;" + enemysecretIds);

            Hrtprozis.Instance.printHero(runEx);
            Hrtprozis.Instance.printOwnMinions(runEx);
            Hrtprozis.Instance.printEnemyMinions(runEx);
            
            Handmanager.Instance.printcards(runEx);
            
            Probabilitymaker.Instance.printTurnGraveYard(runEx);
            Probabilitymaker.Instance.printGraveyards(runEx);
            */

            string choice = Handmanager.Instance.getCardChoiceString();
            Probabilitymaker probm = Probabilitymaker.Instance;
            String data = "#######################################################################"+"\r\n";
            data += "start calculations, current time: " + time + " V" + version + " " + settings + "\r\n";
            data += "#######################################################################" + "\r\n";
            if (choice != "") data += choice + "\r\n"; 
            data +="mana " + this.mana + "/" + this.ownMaxMana+"\r\n";
            data +="emana " + this.enemyMaxMana+"\r\n";
            data +="own secretsCount: " + this.ownSecretsIDList.Count+"\r\n";
            data += "enemy secretsCount: " + this.enemySecretCount + " ;" + probm.getEnemySecretData() + "\r\n";

            //print hero:-------------------------------------------------------------------------------
            data += "player:" + "\r\n";
            
            int ownPlayerController= this.ownController;

            int ownmillhouse = (this.anzOwnMillhouseManastorm)? 1:0;
            int enemymillhouse = (this.anzEnemyMillhouseManastorm)? 1:0;
            int ownKirinTorEffect = (this.nextSecretThisTurnCost0) ? 1:0;
            int ownPreparation = (this.playedPreparation) ? 1:0;

            data += this.mobsPlayedThisTurn + " " + this.cardsPlayedThisTurn + " " + this.owedRecall + " " + ownPlayerController + " " + this.anzMinionsDiedThisTurn + " " + this.currentRecall + " " + this.enemyRecall + " " + this.heroPowerActivationsThisTurn +  " " +  this.lockAndLoads +"\r\n";
            data += this.anzOwnDragonConsort + " " + this.anzEnemyDragonConsort + " " + this.anzOwnLoatheb + " " + this.anzEnemyLoatheb + " " + ownmillhouse + " " + enemymillhouse + " " + ownKirinTorEffect + " " + ownPreparation+  " " + this.anzOwnSaboteur + " " + this.anzEnemySaboteur + " " +  this.anzOwnFencingCoach + "\r\n";
            data += "ownhero:" + "\r\n";
            data += Hrtprozis.heroEnumtoName(this.ownHeroName)+ " " + this.ownHero.Hp + " " + this.ownHero.maxHp + " " + this.ownHero.armor + " " + this.ownHero.immuneWhileAttacking + " " + this.ownHero.immune + " " + this.ownHero.entityID + " " + this.ownHero.Ready + " " + this.ownHero.numAttacksThisTurn + " " + this.ownHero.frozen + " " + this.ownHero.Angr + " " + this.ownHero.tempAttack+ "\r\n";
            data += "weapon: " + this.ownWeaponAttack + " " + this.ownWeaponDurability  + " " + this.ownWeaponName + "\r\n";
            data += "ability: " + this.ownAbilityReady + " " + this.ownHeroAblility.card.cardIDenum + " " +  this.ownHeroPowerUses + "\r\n";
            string secs = "";
            foreach (CardDB.cardIDEnum sec in this.ownSecretsIDList)
            {
                secs += sec + " ";
            }
            data += "osecrets: " + secs + "\r\n";
            data += "cthunbonus: " + this.anzOgOwnCThunAngrBonus + " " + this.anzOgOwnCThunHpBonus + " " + this.anzOgOwnCThunTaunt + "\r\n";
            data += "jadegolems: " + this.anzOwnJadeGolem + " " + this.anzEnemyJadeGolem + "\r\n";
            data += "enemyhero:"+ "\r\n";
            data += Hrtprozis.heroEnumtoName(this.enemyHeroName) + " " + this.enemyHero.Hp + " " + this.enemyHero.maxHp + " " + this.enemyHero.armor + " " + this.enemyHero.frozen + " " + this.enemyHero.immune + " " + this.enemyHero.entityID+ "\r\n";
            data += "weapon: " + this.enemyWeaponAttack + " " + this.enemyWeaponDurability + " " + this.enemyWeaponName + "\r\n";
            data += "ability: " + "True" + " " + this.enemyHeroAblility.card.cardIDenum+ " " + this.enemyHeroPowerUses + "\r\n";
            data += "fatigue: " + this.ownDeckSize + " " + this.ownHeroFatigue + " " + this.enemyDeckSize + " " + this.enemyHeroFatigue + "\r\n";

            //print own Minions

            data += "OwnMinions:" + "\r\n";
            foreach (Minion m in this.ownMinions)
            {
                String mini = this.getMinionString(m);
                data += mini + "\r\n";

            }

            //print enemy Minions
            data += "EnemyMinions:" + "\r\n";
            foreach (Minion m in this.enemyMinions)
            {
                String mini = this.getMinionString(m);
                data += mini + "\r\n";

            }

            //print cards!

            data +="Own Handcards: "+ "\r\n";
            foreach (Handmanager.Handcard c in this.owncards)
            {
                if (c.isChoiceTemp) continue;  // don't print fake 'discover' card
                data +="pos " + c.position + " " + c.card.name + " " + c.getManaCost(this) + " entity " + c.entity + " " + c.card.cardIDenum + " " + c.addattack+ " " + c.addHp + "\r\n";
            }
            data += "Enemy cards: " + this.enemyAnzCards + "\r\n";

            //Probabilitymaker.Instance.printTurnGraveYard(runEx)
            data += Probabilitymaker.Instance.printTurnGraveYard(false, true); //dont need \r\n

            //Probabilitymaker.Instance.printGraveyards(runEx);
            data += Probabilitymaker.Instance.printGraveyards(false, true); //dont need \r\n

            int tdc = 0;
            data += "td: ";
            foreach (KeyValuePair<CardDB.cardIDEnum, int> card in Hrtprozis.Instance.turnDeck)
            {
                data += card.Key;
                if (card.Value > 1) data += "," + card.Value;
                data += ";";
                tdc += card.Value;
            }
            data += "\r\n";

            data += "tdc: " + tdc;
            if (tdc != this.ownDeckSize) data += " tdc mismatch " + this.ownDeckSize;
            
            return data;
        }

        public string getMinionString(Minion m)
        {
            string mini = m.name + " " + m.handcard.card.cardIDenum + " zp:" + m.zonepos + " e:" + m.entityID + " A:" + m.Angr + " H:" + m.Hp + " mH:" + m.maxHp + " rdy:" + m.Ready + " natt:" + m.numAttacksThisTurn;
            if (m.exhausted) mini += " ex";
            if (m.taunt) mini += " tnt";
            if (m.frozen) mini += " frz";
            if (m.silenced) mini += " silenced";
            if (m.divineshild) mini += " divshield";
            if (m.playedThisTurn) mini += " ptt";
            if (m.windfury) mini += " wndfr";
            if (m.stealth) mini += " stlth";
            if (m.poisonous) mini += " poi";
            if (m.immune) mini += " imm";
            if (m.concedal) mini += " cncdl";
            if (m.destroyOnOwnTurnStart) mini += " dstrOwnTrnStrt";
            if (m.destroyOnOwnTurnEnd) mini += " dstrOwnTrnnd";
            if (m.destroyOnEnemyTurnStart) mini += " dstrEnmTrnStrt";
            if (m.destroyOnEnemyTurnEnd) mini += " dstrEnmTrnnd";
            if (m.shadowmadnessed) mini += " shdwmdnssd";
            if (m.cantLowerHPbelowONE) mini += " cantLowerHpBelowOne";
            if (m.cantBeTargetedBySpellsOrHeroPowers) mini += " canttarget";

            if (m.charge >= 1) mini += " chrg(" + m.charge + ")";
            if (m.AdjacentAngr >= 1) mini += " adjaattk(" + m.AdjacentAngr + ")";
            if (m.tempAttack != 0) mini += " tmpattck(" + m.tempAttack + ")";
            if (m.spellpower != 0) mini += " spllpwr(" + m.spellpower + ")";

            if (m.ancestralspirit >= 1) mini += " ancstrl(" + m.ancestralspirit + ")";
            if (m.ownBlessingOfWisdom >= 1) mini += " ownBlssng(" + m.ownBlessingOfWisdom + ")";
            if (m.enemyBlessingOfWisdom >= 1) mini += " enemyBlssng(" + m.enemyBlessingOfWisdom + ")";
            if (m.souloftheforest >= 1) mini += " souloffrst(" + m.souloftheforest + ")";

            if (m.ownPowerWordGlory >= 1) mini += " ownPWG(" + m.ownPowerWordGlory + ")";
            if (m.enemyPowerWordGlory >= 1) mini += " enemyPWG(" + m.enemyPowerWordGlory + ")";

            if (m.explorershat >= 1) mini += " explht(" + m.explorershat + ")";


            return mini;
        }

        public void discardACard(bool own, bool all = false)
        {
            //TODO ... (guess random effect :D)
            if (!all)
            {
                if (own)
                {
                    if (this.owncards.Count >= 1)
                    {
                        this.owncarddraw -= 1;
                        Handmanager.Handcard removedCard = this.owncards[0];
                        if (removedCard.card.cardIDenum == CardDB.cardIDEnum.AT_022 || removedCard.card.cardIDenum == CardDB.cardIDEnum.KAR_205)
                        {
                            removedCard.card.sim_card.onCardIsDiscarded(this, removedCard.card, true);
                        }
                        this.owncards.RemoveAt(0);
                        this.triggerACardWasDiscarded(true);
                    }


                }
                else
                {
                    if (this.enemyAnzCards >= 1)
                    {
                        this.enemycarddraw--;
                        this.enemyAnzCards--;
                        this.triggerACardWasDiscarded(false);
                    }
                }
            }
            else
            {
                int anz = (own) ? owncards.Count : enemyAnzCards;
                if (own)
                {
                    owncards.Clear();
                }
                else
                {
                    enemyAnzCards = 0;
                }

                for (int i = 0; i<anz; i++)
                {
                    triggerACardWasDiscarded(own);
                }
            }
        }


        public Minion searchRandomMinionForDamage(List<Minion> enemies, int damage, bool ownPlay, bool includeEnemyHero)
        {
            // own = true -> search for us the worst-case scenario (i.e. random target = enemy's lowest atk minion that doesn't die)
            // own = false -> search for enemy the best-case scenario (i.e. random target = our highest atk minion that can die)
            Minion targetHero = (ownPlay ? this.enemyHero : this.ownHero);
            Minion selected = (includeEnemyHero ? targetHero : null);

            if (enemies.Count == 0) return selected;
            if (includeEnemyHero && !ownPlay && damage >= this.ownHero.Hp) return this.ownHero;  // best-case for enemy: if it can kill us, it will

            List<Minion> temp = new List<Minion>(enemies);
            if (ownPlay)
                temp.Sort((a, b) => a.Angr.CompareTo(b.Angr)); // increasing Atk
            else
                temp.Sort((a, b) => -a.Angr.CompareTo(b.Angr)); // decreasing Atk

            Minion firstAlive = null;
            foreach (Minion m in temp)
            {
                if (m.Hp <= 0) continue;
                if (firstAlive == null) firstAlive = m;

                if ((ownPlay && m.Hp > damage) || (!ownPlay && m.Hp <= damage))
                    return m;
            }

            if (includeEnemyHero && ownPlay && damage < this.enemyHero.Hp - 15) return this.enemyHero;  // worst-case for us: no minions damaged

            // no minions found = all ours live or all enemies die (so just return the first one, highest/lowest atk)
            return (firstAlive ?? targetHero);
        }


        public void doDmgToRandomEnemyCLIENT2(int dmg, bool targetHero, bool ownPlay)
        {
            /* //TODO
            if (!targetHero)
            {
                Minion m = this.searchRandomMinion((side) ? this.ownMinions : this.enemyMinions, Playfield.searchmode.searchHighestHP);
                if (m != null) this.minionGetDamageOrHeal(m, dmg);
            }
            else
            {
                Minion m = this.searchRandomMinion((side) ? this.ownMinions : this.enemyMinions, Playfield.searchmode.searchHighestHP);
                if (m != null)
                {
                    int hp = (side) ? this.ownHero.Hp : this.enemyHero.Hp;
                    if (m.Hp <= dmg && hp-5 > dmg)
                    {
                        this.minionGetDamageOrHeal((side) ? this.ownHero : this.enemyHero, dmg);
                    }
                    else
                    {
                        this.minionGetDamageOrHeal(m, dmg);
                    }
                }
                else
                {
                    this.minionGetDamageOrHeal((side) ? this.ownHero : this.enemyHero, dmg);
                }*/

             Minion m = this.searchRandomMinionForDamage((ownPlay ? this.enemyMinions : this.ownMinions), dmg, ownPlay, targetHero);
             if (m != null) this.minionGetDamageOrHeal(m, dmg);

            }
        
    }

   

}