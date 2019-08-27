using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Linq;
using Buddy.Coroutines;
using HREngine.Bots.SilverFish.AI;
using Triton.Bot;
using Triton.Common;
using Triton.Game;
using Triton.Game.Mapping;
 





namespace HREngine.Bots
{
    public class SilverFishBot
    {
        public string versionnumber = "117.178";
        private bool singleLog = false;
        private string botbehave = "noname";
        private bool needSleep = false;

        public Playfield lastpf;
        private Settings _settings = Settings.Instance;

        private List<Minion> ownMinions = new List<Minion>();
        private List<Minion> enemyMinions = new List<Minion>();
        private List<Handmanager.Handcard> handCards = new List<Handmanager.Handcard>();
        private int ownPlayerController = 0;
        private List<string> ownSecretList = new List<string>();
        private Dictionary<int, TAG_CLASS> enemySecretList = new Dictionary<int, TAG_CLASS>();
        private Dictionary<int, IDEnumOwner> LurkersDB = new Dictionary<int, IDEnumOwner>();
        public Dictionary<string, Behavior> BehaviorDB = new Dictionary<string, Behavior>();
        public Dictionary<string, string> BehaviorPath = new Dictionary<string, string>();
        List<HSCard> ETallcards = new List<HSCard>();
        Dictionary<string, int> startDeck = new Dictionary<string, int>();
        Dictionary<CardDB.cardIDEnum, int> turnDeck = new Dictionary<CardDB.cardIDEnum, int>();
        Dictionary<int, extraCard> extraDeck = new Dictionary<int, extraCard>();
        bool noDuplicates = false;

        private int currentMana = 0;
        private int ownMaxMana = 0;
        private int numOptionPlayedThisTurn = 0;
        private int numMinionsPlayedThisTurn = 0;
        private int cardsPlayedThisTurn = 0;
        private int ueberladung = 0;
        private int lockedMana = 0;

        private int enemyMaxMana = 0;
        
        private string heroname = "";
        private string enemyHeroname = "";

        private CardDB.Card heroAbility = new CardDB.Card();
        private int ownHeroPowerCost = ChuckHelper.GetOwnHeroPowerCost();
        private bool ownAbilityisReady = false;
        private CardDB.Card enemyAbility = new CardDB.Card();
        private int enemyHeroPowerCost = 2;

        private Weapon ownWeapon;
        private Weapon enemyWeapon;

        private int anzcards = 0;
        private int enemyAnzCards = 0;

        private int ownHeroFatigue = 0;
        private int enemyHeroFatigue = 0;
        private int ownDecksize = 0;
        private int enemyDecksize = 0;

        private Minion ownHero;
        private Minion enemyHero;

        private int gTurn = 0;
        private int gTurnStep = 0;
        private int anzOgOwnCThunHpBonus = 0;
        private int anzOgOwnCThunAngrBonus = 0;
        private int anzOgOwnCThunTaunt = 0;
        private int ownCrystalCore = 0;
        private bool ownMinionsCost0 = false;

        private class extraCard
        {
            public string id;
            public bool isindeck;

            public extraCard(string s, bool b)
            {
                this.id = s;
                this.isindeck = b;
            }
            public void setId(string s)
            {
                this.id = s;
            }
            public void setisindeck(bool b)
            {
                this.isindeck = b;
            }

        }
        
        private static SilverFishBot instance;

        public static SilverFishBot Instance
        {
            get { return instance ?? (instance = new SilverFishBot()); }
        }

        private SilverFishBot()
        {
            this.singleLog = Settings.Instance.writeToSingleFile;
            Helpfunctions.Instance.InfoLog("init Silverfish");
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;

            string silverFishLogFolderPath = @"Logs\Silverfish";
            string logFolderPath = Path.Combine(baseDirectory, silverFishLogFolderPath);
            if (!Directory.Exists(logFolderPath))
            {
                Directory.CreateDirectory(logFolderPath);
            }

            string dataFolderPath = Path.Combine(baseDirectory, @"Routines\DefaultRoutine\Silverfish\data");
            _settings.DataFolderPath = dataFolderPath;

            if (!singleLog)
            {
                string combatLogFolderPath = "CombatLogs";
                _settings.LogFolderPath = Path.Combine(logFolderPath, combatLogFolderPath);
            }
            else
            {
                //single log file mode
                _settings.LogFolderPath = logFolderPath;
                Helpfunctions.Instance.createNewLoggfile();
            }
            setBehavior();
        }

        private bool setBehavior()
        {
            Type[] types = Assembly.GetExecutingAssembly().GetTypes().Where(t => t.BaseType == typeof(Behavior)).ToArray();
            foreach (var t in types)
            {
                string s = t.Name;
                if (s == "BehaviorMana") continue;
                if (s.Length > 8 && s.Substring(0, 8) == "Behavior")
                {
                    Behavior b = (Behavior)Activator.CreateInstance(t);
                    BehaviorDB.Add(b.BehaviorName(), b);
                }
            }

            string p = Path.Combine("Routines", "DefaultRoutine", "Silverfish", "behavior");
            string[] files = Directory.GetFiles(p, "Behavior*.cs", SearchOption.AllDirectories);
            int bCount = 0;
            foreach (string file in files)
            {
                bCount++;
                string bPath = Path.GetDirectoryName(file);
                var fullPath = Path.GetFullPath(file);
                var bNane = Path.GetFileNameWithoutExtension(file).Remove(0, 8);
                if (BehaviorDB.ContainsKey(bNane))
                {
                    if (!BehaviorPath.ContainsKey(bNane)) BehaviorPath.Add(bNane, bPath);
                }
            }

            if (BehaviorDB.Count != BehaviorPath.Count || BehaviorDB.Count != bCount)
            {
                Helpfunctions.Instance.ErrorLog("Behavior: registered - " + BehaviorDB.Count + ", folders - " + bCount + ", have a path - "
                    + BehaviorPath.Count + ". These values should be the same. Maybe you have some extra files in the 'custom_behavior' folder.");
            }

            if (BehaviorDB.ContainsKey("Control"))
            {
                Ai.Instance.botBase = BehaviorDB["Control"];
                return true;
            }
            else
            {
                Helpfunctions.Instance.ErrorLog("ERROR#################################################");
                Helpfunctions.Instance.ErrorLog("ERROR#################################################");
                Helpfunctions.Instance.ErrorLog("The default behavior is not found!");
                Helpfunctions.Instance.ErrorLog("Add the right behavior files or reinstall the bot.");
                Helpfunctions.Instance.ErrorLog("ERROR#################################################");
                Helpfunctions.Instance.ErrorLog("ERROR#################################################");
                return false;
            }
        }
        public Behavior getBehaviorByName(string bName)
        {
            if (BehaviorDB.ContainsKey(bName))
            {
                _settings.setSettings(bName);
                ComboBreaker.Instance.readCombos(bName);
                RulesEngine.Instance.readRules(bName);
                return BehaviorDB[bName];
            }
            else
            {
                if (BehaviorDB.ContainsKey("Control")) return BehaviorDB["Control"];
                else
                {
                    Helpfunctions.Instance.ErrorLog("ERROR#################################################");
                    Helpfunctions.Instance.ErrorLog("ERROR#################################################");
                    Helpfunctions.Instance.ErrorLog("The default behavior is not found!");
                    Helpfunctions.Instance.ErrorLog("Add the right behavior files or reinstall the bot.");
                    Helpfunctions.Instance.ErrorLog("ERROR#################################################");
                    Helpfunctions.Instance.ErrorLog("ERROR#################################################");
                }
            }
            return null;
        }


        public void SetNewLogFile()
        {
            gTurn = 0;
            gTurnStep = 0;
            anzOgOwnCThunHpBonus = 0;
            anzOgOwnCThunAngrBonus = 0;
            anzOgOwnCThunTaunt = 0;
            ownCrystalCore = 0;
            ownMinionsCost0 = false;
            Questmanager.Instance.Reset();
            if (!singleLog)
            {
                _settings.LogFileName = $"{DateTime.Now:yyyyMMdd-HHmmss}.log";
                Helpfunctions.Instance.createNewLoggfile();
                Helpfunctions.Instance.InfoLog("#######################################################");
                Helpfunctions.Instance.InfoLog($"fight is logged in: {Path.Combine(_settings.LogFolderPath,_settings.LogFileName)}");
                Helpfunctions.Instance.InfoLog("#######################################################");
            }
            startDeck.Clear();
            extraDeck.Clear();
            long DeckId = Triton.Bot.Logic.Bots.DefaultBot.DefaultBotSettings.Instance.LastDeckId;
            foreach (var deck in Triton.Bot.Settings.MainSettings.Instance.CustomDecks)
            {
                if (deck.DeckId == DeckId)
                {
                    foreach (string s in deck.CardIds)
                    {
                        if (startDeck.ContainsKey(s)) startDeck[s]++;
                        else startDeck.Add(s, 1);
                    }
                    break;
                }
            }
        }

        public bool updateEverything(Behavior botbase, int numcal, out bool sleepRetry)
        {
            this.needSleep = false;
            this.updateBehaveString(botbase);
            ownPlayerController = TritonHs.OurHero.ControllerId;

            Hrtprozis.Instance.clearAllRecalc();
            Handmanager.Instance.clearAllRecalc();
            
            getHerostuff();
            getMinions();
            getHandcards();
            getDecks();


            Hrtprozis.Instance.updateTurnDeck(turnDeck, noDuplicates);
            Hrtprozis.Instance.setOwnPlayer(ownPlayerController);                
            Handmanager.Instance.setOwnPlayer(ownPlayerController);

            this.numOptionPlayedThisTurn = 0;
            this.numOptionPlayedThisTurn += this.cardsPlayedThisTurn + this.ownHero.numAttacksThisTurn;
            foreach (Minion m in this.ownMinions)
            {
                if (m.Hp >= 1) this.numOptionPlayedThisTurn += m.numAttacksThisTurn;
            }
            
            List<HSCard> list = TritonHs.GetCards(CardZone.Graveyard, true);
            foreach (GraveYardItem gi in Probabilitymaker.Instance.turngraveyard)
            {
                if (gi.own)
                {
                    foreach (HSCard entiti in list)
                    {
                        if (gi.entity == entiti.EntityId)
                        {
                            this.numOptionPlayedThisTurn += entiti.NumAttackThisTurn;
                            break;
                        }
                    }
                }
            }

            Hrtprozis.Instance.updatePlayer(this.ownMaxMana, this.currentMana, this.cardsPlayedThisTurn,
                this.numMinionsPlayedThisTurn, this.numOptionPlayedThisTurn, this.ueberladung, this.lockedMana, TritonHs.OurHero.EntityId,
                TritonHs.EnemyHero.EntityId);
            Hrtprozis.Instance.updateSecretStuff(this.ownSecretList, this.enemySecretList.Count);

            Hrtprozis.Instance.updateHero(this.ownWeapon, this.heroname, this.heroAbility, this.ownAbilityisReady, this.ownHeroPowerCost, this.ownHero);
            Hrtprozis.Instance.updateHero(this.enemyWeapon, this.enemyHeroname, this.enemyAbility, false, this.enemyHeroPowerCost, this.enemyHero, this.enemyMaxMana);

            Questmanager.Instance.updatePlayedMobs(this.gTurnStep);
            Hrtprozis.Instance.updateMinions(this.ownMinions, this.enemyMinions);
            Hrtprozis.Instance.updateLurkersDB(this.LurkersDB);
            Handmanager.Instance.setHandcards(this.handCards, this.anzcards, this.enemyAnzCards);
            Hrtprozis.Instance.updateFatigueStats(this.ownDecksize, this.ownHeroFatigue, this.enemyDecksize, this.enemyHeroFatigue);
            Hrtprozis.Instance.updateJadeGolemsInfo(GameState.Get().GetFriendlySidePlayer().GetTag(GAME_TAG.JADE_GOLEM), GameState.Get().GetOpposingSidePlayer().GetTag(GAME_TAG.JADE_GOLEM));

            Hrtprozis.Instance.updateTurnInfo(this.gTurn, this.gTurnStep);
            updateCThunInfobyCThun();
            Hrtprozis.Instance.updateCThunInfo(this.anzOgOwnCThunAngrBonus, this.anzOgOwnCThunHpBonus, this.anzOgOwnCThunTaunt);
            Hrtprozis.Instance.updateCrystalCore(this.ownCrystalCore);
            Hrtprozis.Instance.updateOwnMinionsInDeckCost0(this.ownMinionsCost0);            
            Probabilitymaker.Instance.setEnemySecretGuesses(this.enemySecretList);

            sleepRetry = this.needSleep;
            if (sleepRetry && numcal == 0) return false;


            if (!Hrtprozis.Instance.setGameRule)
            {
                RulesEngine.Instance.setCardIdRulesGame(this.ownHero.cardClass, this.enemyHero.cardClass);
                Hrtprozis.Instance.setGameRule = true;
            }

            Playfield p = new Playfield();
            p.enemyCardsOut = new Dictionary<CardDB.cardIDEnum, int>(Probabilitymaker.Instance.enemyCardsOut);

            if (lastpf != null)
            {
                if (lastpf.isEqualf(p))
                {
                    return false;
                }
                else
                {
                     if (p.gTurnStep > 0 && Ai.Instance.nextMoveGuess.ownMinions.Count == p.ownMinions.Count)
                     {
                         if (Ai.Instance.nextMoveGuess.ownHero.Ready != p.ownHero.Ready && !p.ownHero.Ready)
                         {
                             sleepRetry = true;
                             Helpfunctions.Instance.ErrorLog("[AI] Hero ready = " + p.ownHero.Ready + ". Attempting recover....");
                             Ai.Instance.nextMoveGuess = new Playfield { mana = -100 };
                             return false;
                         }                         
                         for (int i = 0; i < p.ownMinions.Count; i++)
                         {
                             if (Ai.Instance.nextMoveGuess.ownMinions[i].Ready != p.ownMinions[i].Ready && !p.ownMinions[i].Ready)
                             {
                                 sleepRetry = true;
                                 Helpfunctions.Instance.ErrorLog("[AI] Minion ready = " + p.ownMinions[i].Ready + " (" + p.ownMinions[i].entitiyID + " " + p.ownMinions[i].handcard.card.cardIDenum + " " + p.ownMinions[i].name + "). Attempting recover....");
                                 Ai.Instance.nextMoveGuess = new Playfield { mana = -100 };
                                 return false;
                             }
                         }                         
                     }
                }
                
                Probabilitymaker.Instance.updateSecretList(p, lastpf);
                lastpf = p;
            }
            else
            {
                lastpf = p;
            }

            p = new Playfield(); 
            
            Helpfunctions.Instance.InfoLog("calculating stuff... " + DateTime.Now.ToString("HH:mm:ss.ffff"));
            
            
            using (TritonHs.Memory.ReleaseFrame(true))
            {
                printstuff();
                Ai.Instance.dosomethingclever(botbase);    
            }

            Helpfunctions.Instance.InfoLog("calculating ended! " + DateTime.Now.ToString("HH:mm:ss.ffff"));
            if (_settings.printRules > 0)
            {
                String[] rulesStr = Ai.Instance.bestplay.rulesUsed.Split('@');
                if (rulesStr.Count() > 0 && rulesStr[0] != "")
                {
                    Helpfunctions.Instance.InfoLog("ruleWeight " + Ai.Instance.bestplay.ruleWeight * -1);
                    foreach (string rs in rulesStr)
                    {
                        if (rs == "") continue;
                        Helpfunctions.Instance.InfoLog("rule: " + rs);
                    }
                }
            }
            return true;
        }




        private void getHerostuff()
        {
            List<HSCard> allcards = TritonHs.GetAllCards();

            HSCard ownHeroCard = TritonHs.OurHero;
            HSCard enemHeroCard = TritonHs.EnemyHero;
            int ownheroentity = TritonHs.OurHero.EntityId;
            int enemyheroentity = TritonHs.EnemyHero.EntityId;
            this.ownHero = new Minion();
            this.enemyHero = new Minion();

            foreach (HSCard ent in allcards)
            {
                if (ent.IsHero == true)
                {
                    if (ent.ControllerId == 1 && this.ownHero.cardClass == TAG_CLASS.INVALID)
                    {
                        this.ownHero.cardClass = (TAG_CLASS)ent.Class;

                    }
                    if (ent.ControllerId == 2 && this.enemyHero.cardClass == TAG_CLASS.INVALID)
                    {
                        this.enemyHero.cardClass = (TAG_CLASS)ent.Class;

                    }
                    if (ent.EntityId == enemyheroentity) enemHeroCard = ent;
                    if (ent.EntityId == ownheroentity) ownHeroCard = ent;
                }
            }

            
            
            this.currentMana = TritonHs.CurrentMana;
            this.ownMaxMana = TritonHs.Resources;
            this.enemyMaxMana = ownMaxMana;

            
            ownSecretList.Clear();
            enemySecretList.Clear();
            foreach (HSCard ent in allcards)
            {
                if (ent.IsSecret && ent.ControllerId != ownPlayerController && ent.GetTag(GAME_TAG.ZONE) == 7)
                {
                    enemySecretList.Add(ent.EntityId, (TAG_CLASS)ent.Class);
                }
                if (ent.IsSecret && ent.ControllerId == ownPlayerController && ent.GetTag(GAME_TAG.ZONE) == 7)
                {
                    ownSecretList.Add(ent.Id);
                }
            }

            var ownSecretZoneCards = GameState.Get().GetFriendlySidePlayer().GetSecretZone().GetCards();
            foreach (var card in ownSecretZoneCards)
            {
                var entity = card.GetEntity();
                if (entity != null && entity.GetZone() == Triton.Game.Mapping.TAG_ZONE.SECRET)
                {
                    if (entity.m_card != null)
                    {
                        string eId = "";



                        
                        if (entity.IsQuest())
                        {
                            int currentQuestProgress = entity.GetTag(GAME_TAG.QUEST_PROGRESS);
                            int questProgressTotal = entity.GetTag(GAME_TAG.QUEST_PROGRESS_TOTAL);

                            var entityDef = DefLoader.Get().GetEntityDef(entity.GetTag(GAME_TAG.QUEST_CONTRIBUTOR));
                            if (entityDef != null)
                            {
                                var nme = entityDef.GetName();
                            }

                            Questmanager.Instance.updateQuestStuff(eId, currentQuestProgress, questProgressTotal, true);
                        }
                    }
                }
            }

            var enemySecretZoneCards = GameState.Get().GetOpposingSidePlayer().GetSecretZone().GetCards();
            foreach (var card in enemySecretZoneCards)
            {
                var entity = card.GetEntity();
                if (entity != null && entity.GetZone() == Triton.Game.Mapping.TAG_ZONE.SECRET)
                {
                    if (entity.m_card != null)
                    {
                        string eId = "";



                        
                        if (entity.IsQuest())
                        {
                            int currentQuestProgress = entity.GetTag(GAME_TAG.QUEST_PROGRESS);
                            int questProgressTotal = entity.GetTag(GAME_TAG.QUEST_PROGRESS_TOTAL);
                            Questmanager.Instance.updateQuestStuff(eId, currentQuestProgress, questProgressTotal, false);
                        }
                    }
                }
            }
            
            numMinionsPlayedThisTurn = TritonHs.NumMinionsPlayedThisTurn;
            cardsPlayedThisTurn = TritonHs.NumCardsPlayedThisTurn;
            ueberladung = TritonHs.OverloadOwed;
            lockedMana = TritonHs.OverloadLocked;

            this.ownHeroFatigue = ownHeroCard.GetTag(GAME_TAG.FATIGUE);
            this.enemyHeroFatigue = enemHeroCard.GetTag(GAME_TAG.FATIGUE);

            this.ownDecksize = 0;
            this.enemyDecksize = 0;
            
            foreach (HSCard ent in allcards)
            {
                if (ent.ControllerId == ownPlayerController && ent.GetTag(GAME_TAG.ZONE) == 2) ownDecksize++;
                if (ent.ControllerId != ownPlayerController && ent.GetTag(GAME_TAG.ZONE) == 2) enemyDecksize++;
            }

            this.heroname = Hrtprozis.Instance.heroIDtoName(TritonHs.OurHero.Id);

            this.ownHero.Angr = ownHeroCard.GetTag(GAME_TAG.ATK);
            this.ownHero.Hp = ownHeroCard.GetTag(GAME_TAG.HEALTH) - ownHeroCard.GetTag(GAME_TAG.DAMAGE);
            this.ownHero.armor = ownHeroCard.GetTag(GAME_TAG.ARMOR);            
            this.ownHero.frozen = (ownHeroCard.GetTag(GAME_TAG.FROZEN) == 0) ? false : true;
            this.ownHero.stealth = (ownHeroCard.GetTag(GAME_TAG.STEALTH) == 0) ? false : true;
            this.ownHero.numAttacksThisTurn = ownHeroCard.GetTag(GAME_TAG.NUM_ATTACKS_THIS_TURN);
            this.ownHero.windfury = (ownHeroCard.GetTag(GAME_TAG.WINDFURY) == 0) ? false : true;
            this.ownHero.immune = (ownHeroCard.GetTag(GAME_TAG.IMMUNE) == 0) ? false : true;
            if (!ownHero.immune) this.ownHero.immune = (ownHeroCard.GetTag(GAME_TAG.IMMUNE_WHILE_ATTACKING) == 0) ? false : true; //turn immune
            
            ownWeapon = new Weapon();
            if (TritonHs.DoWeHaveWeapon)
            {
                HSCard weapon = TritonHs.OurWeaponCard;

                ownWeapon.equip(CardDB.Instance.getCardDataFromID(CardDB.Instance.cardIdstringToEnum(weapon.Id)));
                ownWeapon.Angr = weapon.GetTag(GAME_TAG.ATK);
                ownWeapon.Durability = weapon.GetTag(GAME_TAG.DURABILITY) - weapon.GetTag(GAME_TAG.DAMAGE);
                ownWeapon.poisonous = (weapon.GetTag(GAME_TAG.POISONOUS) == 1) ? true : false;
                ownWeapon.lifesteal = (weapon.GetTag(GAME_TAG.LIFESTEAL) == 1) ? true : false;
                if (!this.ownHero.windfury) this.ownHero.windfury = ownWeapon.windfury;
            }
                        
            this.enemyHeroname = Hrtprozis.Instance.heroIDtoName(TritonHs.EnemyHero.Id);

            this.enemyHero.Angr = enemHeroCard.GetTag(GAME_TAG.ATK);
            this.enemyHero.Hp = enemHeroCard.GetTag(GAME_TAG.HEALTH) - enemHeroCard.GetTag(GAME_TAG.DAMAGE);
            this.enemyHero.armor = enemHeroCard.GetTag(GAME_TAG.ARMOR);
            this.enemyHero.frozen = (enemHeroCard.GetTag(GAME_TAG.FROZEN) == 0) ? false : true;
            this.enemyHero.stealth = (enemHeroCard.GetTag(GAME_TAG.STEALTH) == 0) ? false : true;
            this.enemyHero.windfury = (enemHeroCard.GetTag(GAME_TAG.WINDFURY) == 0) ? false : true;
            this.enemyHero.immune = (enemHeroCard.GetTag(GAME_TAG.IMMUNE) == 0) ? false : true; //don't use turn immune
            
            enemyWeapon = new Weapon();
            if (TritonHs.DoesEnemyHasWeapon)
            {
                HSCard weapon = TritonHs.EnemyWeaponCard;

                enemyWeapon.equip(CardDB.Instance.getCardDataFromID(CardDB.Instance.cardIdstringToEnum(weapon.Id)));
                enemyWeapon.Angr = weapon.GetTag(GAME_TAG.ATK);
                enemyWeapon.Durability = weapon.GetTag(GAME_TAG.DURABILITY) - weapon.GetTag(GAME_TAG.DAMAGE);
                enemyWeapon.poisonous = (weapon.GetTag(GAME_TAG.POISONOUS) == 1) ? true : false;
                enemyWeapon.lifesteal = (weapon.GetTag(GAME_TAG.LIFESTEAL) == 1) ? true : false;
                if (!this.enemyHero.windfury) this.enemyHero.windfury = enemyWeapon.windfury;
            }
            
            this.heroAbility =
                CardDB.Instance.getCardDataFromID(CardDB.Instance.cardIdstringToEnum(TritonHs.OurHeroPowerCard.Id));
            this.ownAbilityisReady = (TritonHs.OurHeroPowerCard.GetTag(GAME_TAG.EXHAUSTED) == 0) ? true : false;
            this.enemyAbility =
                CardDB.Instance.getCardDataFromID(CardDB.Instance.cardIdstringToEnum(TritonHs.EnemyHeroPowerCard.Id));
            int ownHeroAbilityEntity = TritonHs.OurHeroPowerCard.EntityId;
            int enemyHeroAbilityEntity = TritonHs.EnemyHeroPowerCard.EntityId;
            
            int needBreak = 0;
            foreach (HSCard ent in allcards)
            {
                if (ent.EntityId == ownHeroAbilityEntity)
                {
                    this.ownHeroPowerCost = ent.Cost;
                    needBreak++;
                }
                else if (ent.EntityId == enemyHeroAbilityEntity)
                {
                    this.enemyHeroPowerCost = ent.Cost;
                    needBreak++;
                }
                if (needBreak > 1) break;
            }
            
            this.ownHero.isHero = true;
            this.enemyHero.isHero = true;
            this.ownHero.own = true;
            this.enemyHero.own = false;
            this.ownHero.maxHp = ownHeroCard.GetTag(GAME_TAG.HEALTH);
            this.enemyHero.maxHp = enemHeroCard.GetTag(GAME_TAG.HEALTH);
            this.ownHero.entitiyID = ownHeroCard.EntityId;
            this.enemyHero.entitiyID = enemHeroCard.EntityId;

            this.ownHero.Ready = ownHeroCard.CanBeUsed;
            this.enemyHero.Ready = false;
            
            List<miniEnch> miniEnchlist = new List<miniEnch>();
            foreach (HSCard ent in allcards)
            {
                if (ent.GetTag(GAME_TAG.ATTACHED) == this.ownHero.entitiyID && ent.GetTag(GAME_TAG.ZONE) == 1) 
                {
                    CardDB.cardIDEnum id = CardDB.Instance.cardIdstringToEnum(ent.Id);
                    int controler = ent.GetTag(GAME_TAG.CONTROLLER);
                    int creator = ent.GetTag(GAME_TAG.CREATOR);
                    int copyDeathrattle = ent.GetTag(GAME_TAG.COPY_DEATHRATTLE);
                    miniEnchlist.Add(new miniEnch(id, creator, controler, copyDeathrattle));
                }

            }

            this.ownHero.loadEnchantments(miniEnchlist, ownHeroCard.GetTag(GAME_TAG.CONTROLLER));

            miniEnchlist.Clear();

            foreach (HSCard ent in allcards)
            {
                if (ent.GetTag(GAME_TAG.ATTACHED) == this.enemyHero.entitiyID && ent.GetTag(GAME_TAG.ZONE) == 1)
                    
                {
                    CardDB.cardIDEnum id = CardDB.Instance.cardIdstringToEnum(ent.Id);
                    int controler = ent.GetTag(GAME_TAG.CONTROLLER);
                    int creator = ent.GetTag(GAME_TAG.CREATOR);
                    int copyDeathrattle = ent.GetTag(GAME_TAG.COPY_DEATHRATTLE);
                    miniEnchlist.Add(new miniEnch(id, creator, controler, copyDeathrattle));
                }

            }

            this.enemyHero.loadEnchantments(miniEnchlist, enemHeroCard.GetTag(GAME_TAG.CONTROLLER));

            if (this.ownHero.Angr < this.ownWeapon.Angr) this.ownHero.Angr = this.ownWeapon.Angr;
            if (this.enemyHero.Angr < this.enemyWeapon.Angr) this.enemyHero.Angr = this.enemyWeapon.Angr;
        }



        private void getMinions()
        {
            int tmp = Triton.Game.Mapping.GameState.Get().GetTurn();
            if (gTurn == tmp) gTurnStep++;
            else gTurnStep = 0;
            gTurn = tmp;
            
            List<HSCard> list = TritonHs.GetCards(CardZone.Battlefield, true);
            list.AddRange(TritonHs.GetCards(CardZone.Battlefield, false));

            var enchantments = new List<HSCard>();
            ownMinions.Clear();
            enemyMinions.Clear();
            LurkersDB.Clear();
            List<HSCard> allcards = TritonHs.GetAllCards();

            foreach (HSCard entiti in list)
            {
                int zp = entiti.GetTag(GAME_TAG.ZONE_POSITION);

                if (entiti.IsMinion && zp >= 1)
                {

                    HSCard entitiy = entiti;

                    foreach (HSCard ent in allcards)
                    {
                        if (ent.EntityId == entiti.EntityId)
                        {
                            entitiy = ent;
                            break;
                        }
                    }


                    CardDB.Card c = CardDB.Instance.getCardDataFromID(CardDB.Instance.cardIdstringToEnum(entitiy.Id));
                    Minion m = new Minion();
                    m.name = c.name;
                    m.handcard.card = c;

                    m.Angr = entitiy.GetTag(GAME_TAG.ATK);
                    m.maxHp = entitiy.GetTag(GAME_TAG.HEALTH);
                    m.Hp = entitiy.GetTag(GAME_TAG.HEALTH) - entitiy.GetTag(GAME_TAG.DAMAGE);
                    if (m.Hp <= 0) continue;
                    m.wounded = false;
                    if (m.maxHp > m.Hp) m.wounded = true;

                    int ctarget = entitiy.GetTag(GAME_TAG.CARD_TARGET);
                    if (ctarget > 0)
                    {
                        foreach (HSCard hcard in allcards)
                        {
                            if (hcard.EntityId == ctarget)
                            {
                                LurkersDB.Add(entitiy.EntityId, new IDEnumOwner()
                                {
                                    IDEnum = CardDB.Instance.cardIdstringToEnum(hcard.Id),
                                    own = (hcard.GetTag(GAME_TAG.CONTROLLER) == this.ownPlayerController) ? true : false
                                });
                                break;
                            }
                        }
                    }

                    m.exhausted = (entitiy.GetTag(GAME_TAG.EXHAUSTED) == 0) ? false : true;

                    m.taunt = (entitiy.GetTag(GAME_TAG.TAUNT) == 0) ? false : true;

                    m.numAttacksThisTurn = entitiy.GetTag(GAME_TAG.NUM_ATTACKS_THIS_TURN);

                    int temp = entitiy.GetTag(GAME_TAG.NUM_TURNS_IN_PLAY);
                    m.playedThisTurn = (temp == 0) ? true : false;

                    m.windfury = (entitiy.GetTag(GAME_TAG.WINDFURY) == 0) ? false : true;

                    m.frozen = (entitiy.GetTag(GAME_TAG.FROZEN) == 0) ? false : true;

                    m.divineshild = (entitiy.GetTag(GAME_TAG.DIVINE_SHIELD) == 0) ? false : true;

                    m.stealth = (entitiy.GetTag(GAME_TAG.STEALTH) == 0) ? false : true;

                    m.poisonous = (entitiy.GetTag(GAME_TAG.POISONOUS) == 0) ? false : true;

                    m.lifesteal = (entitiy.GetTag(GAME_TAG.LIFESTEAL) == 0) ? false : true;

                    m.immune = (entitiy.GetTag(GAME_TAG.IMMUNE) == 0) ? false : true;
                    if (!m.immune) m.immune = (entitiy.GetTag(GAME_TAG.IMMUNE_WHILE_ATTACKING) == 0) ? false : true;

                    m.untouchable = (entitiy.GetTag(GAME_TAG.UNTOUCHABLE) == 0) ? false : true;

                    m.silenced = (entitiy.GetTag(GAME_TAG.SILENCED) == 0) ? false : true;

                    m.cantAttackHeroes = (entitiy.GetTag(GAME_TAG.CANNOT_ATTACK_HEROES) == 0) ? false : true;

                    m.cantAttack = (entitiy.GetTag(GAME_TAG.CANT_ATTACK) == 0) ? false : true;
                    
                    m.cantBeTargetedBySpellsOrHeroPowers = (entitiy.GetTag(GAME_TAG.CANT_BE_TARGETED_BY_HERO_POWERS) == 0) ? false : true;

                    m.charge = entitiy.HasCharge ? 1 : 0;


                    m.zonepos = zp;

                    m.entitiyID = entitiy.EntityId;
                    

                    
                    m.hChoice = entitiy.GetTag(GAME_TAG.HIDDEN_CHOICE);

                    List<miniEnch> enchs = new List<miniEnch>();
                    foreach (HSCard ent in allcards)
                    {
                        if (ent.GetTag(GAME_TAG.ATTACHED) == m.entitiyID && ent.GetTag(GAME_TAG.ZONE) == 1) 
                        {
                            CardDB.cardIDEnum id = CardDB.Instance.cardIdstringToEnum(ent.Id);
                            int controler = ent.GetTag(GAME_TAG.CONTROLLER);
                            int creator = ent.GetTag(GAME_TAG.CREATOR);
                            int copyDeathrattle = ent.GetTag(GAME_TAG.COPY_DEATHRATTLE);
                            enchs.Add(new miniEnch(id, creator, controler, copyDeathrattle));
                        }
                    }
                    
                    m.loadEnchantments(enchs, entitiy.GetTag(GAME_TAG.CONTROLLER));
                    if (m.extraParam2 != 0)
                    {
                        bool needBreak = false;
                        foreach (HSCard ent in allcards)
                        {
                            if (m.extraParam2 == ent.EntityId)
                            {
                                int copyDeathrattle = ent.GetTag(GAME_TAG.COPY_DEATHRATTLE);
                                switch (ent.Id)
                                {
                                    case "LOE_019":
                                        foreach (HSCard ent2 in allcards)
                                        {
                                            if (copyDeathrattle == ent2.EntityId)
                                            {
                                                if (ent2.Id == "LOE_019")
                                                {
                                                    copyDeathrattle = ent2.GetTag(GAME_TAG.COPY_DEATHRATTLE);
                                                    goto case "LOE_019";
                                                }
                                                m.deathrattle2 = CardDB.Instance.getCardDataFromID(CardDB.Instance.cardIdstringToEnum(ent2.Id));
                                                needBreak = true;
                                                break;
                                            }
                                        }
                                        break;
                                    default:
                                        m.deathrattle2 = CardDB.Instance.getCardDataFromID(CardDB.Instance.cardIdstringToEnum(ent.Id));
                                        needBreak = true;
                                        break;
                                }
                            }
                            if (needBreak) break;
                        }
                    }

                    m.Ready = entitiy.CanBeUsed;
                    if (m.charge > 0 && m.playedThisTurn && !m.Ready && m.numAttacksThisTurn == 0)
                    {
                        needSleep = true;
                        Helpfunctions.Instance.ErrorLog("[AI] Charge minion not ready");
                                 
                    }

                    if (entitiy.GetTag(GAME_TAG.CONTROLLER) == this.ownPlayerController) 
                    {
                        m.own = true;                        
                        m.synergy = PenalityManager.Instance.getClassRacePriorityPenality(this.ownHero.cardClass, (TAG_RACE)c.race);
                        this.ownMinions.Add(m);
                    }
                    else
                    {
                        m.own = false;
                        m.synergy = PenalityManager.Instance.getClassRacePriorityPenality(this.enemyHero.cardClass, (TAG_RACE)c.race);
                        this.enemyMinions.Add(m);
                    }
                }
            }

        }

        private void getHandcards()
        {
            handCards.Clear();
            anzcards = 0;
            enemyAnzCards = 0;
            List<HSCard> list = TritonHs.GetCards(CardZone.Hand);

            
            
            int wereElementalsLastTurn = 0;
            foreach (HSCard entitiy in list)
            {
                if (entitiy.ZonePosition >= 1) 
                {
                    CardDB.Card c = CardDB.Instance.getCardDataFromID(CardDB.Instance.cardIdstringToEnum(entitiy.Id));
                    


                    Handmanager.Handcard hc = new Handmanager.Handcard();
                    hc.card = c;
                    hc.position = entitiy.ZonePosition;
                    hc.entity = entitiy.EntityId;
                    hc.manacost = entitiy.Cost;
                    hc.elemPoweredUp = entitiy.GetTag(GAME_TAG.ELEMENTAL_POWERED_UP);
                    if (hc.elemPoweredUp > 0) wereElementalsLastTurn = 1;
                    
                    hc.addattack = entitiy.Attack - entitiy.DefATK;
                    if (entitiy.IsWeapon) hc.addHp = entitiy.Durability - entitiy.DefDurability;
                    else hc.addHp = entitiy.Health - entitiy.DefHealth;

                    handCards.Add(hc);
                    anzcards++;
                }
            }
            Hrtprozis.Instance.updateElementals(0, wereElementalsLastTurn, 0); //TODO

            List<HSCard> allcards = TritonHs.GetAllCards();
            enemyAnzCards = 0;
            foreach (HSCard hs in allcards)
            {
                if (hs.GetTag(GAME_TAG.ZONE) == 3 && hs.ControllerId != ownPlayerController &&
                    hs.GetTag(GAME_TAG.ZONE_POSITION) >= 1) enemyAnzCards++;
            }
            
        }

        private void getDecks()
        {
            Dictionary<string, int> tmpDeck = new Dictionary<string, int>(startDeck);
            List<GraveYardItem> graveYard = new List<GraveYardItem>();
            Dictionary<CardDB.cardIDEnum, int> og = new Dictionary<CardDB.cardIDEnum, int>();
            Dictionary<CardDB.cardIDEnum, int> eg = new Dictionary<CardDB.cardIDEnum, int>();
            int owncontroler = TritonHs.OurHero.GetTag(GAME_TAG.CONTROLLER);
            int enemycontroler = TritonHs.EnemyHero.GetTag(GAME_TAG.CONTROLLER);
            turnDeck.Clear();
            noDuplicates = false;

            List<HSCard> allcards = TritonHs.GetAllCards();

            int allcardscount = allcards.Count;
            for (int i = 0; i < allcardscount; i++)
            {
                HSCard entity = allcards[i];
                if (entity.Id == null || entity.Id == "") continue;

                if (CardDB.Instance.cardIdstringToEnum(entity.Id) == CardDB.cardIDEnum.UNG_116t) ownMinionsCost0 = true;

                if (entity.GetZone() == Triton.Game.Mapping.TAG_ZONE.GRAVEYARD)
                {
                    CardDB.cardIDEnum cide = CardDB.Instance.cardIdstringToEnum(entity.Id);
                    GraveYardItem gyi = new GraveYardItem(cide, entity.EntityId, entity.GetTag(GAME_TAG.CONTROLLER) == owncontroler);
                    graveYard.Add(gyi);

                    if (entity.GetTag(GAME_TAG.CONTROLLER) == owncontroler)
                    {
                        if (og.ContainsKey(cide)) og[cide]++;
                        else og.Add(cide, 1);
                    }
                    else if (entity.GetTag(GAME_TAG.CONTROLLER) == enemycontroler)
                    {
                        if (eg.ContainsKey(cide)) eg[cide]++;
                        else eg.Add(cide, 1);
                    }
                    if (cide == CardDB.cardIDEnum.UNG_067t1) ownCrystalCore = 5;
                }

                string entityId = entity.Id;
                Triton.Game.Mapping.TAG_ZONE entZone =  entity.GetZone();
                if (i < 30)
                {
                    if (entityId != "")
                    {
                        if (entZone == Triton.Game.Mapping.TAG_ZONE.DECK) continue;
                        if (tmpDeck.ContainsKey(entityId)) tmpDeck[entityId]--;
                    }
                }
                else if (i >= 60 && entity.ControllerId == owncontroler)
                {
                    if (extraDeck.ContainsKey(i))
                    {
                        if (entityId != "" && entityId != extraDeck[i].id) extraDeck[i].setId(entityId);
                        if ((entZone == Triton.Game.Mapping.TAG_ZONE.DECK) != extraDeck[i].isindeck) extraDeck[i].setisindeck(entZone == Triton.Game.Mapping.TAG_ZONE.DECK);
                    }
                    else if (entZone == Triton.Game.Mapping.TAG_ZONE.DECK)
                    {
                        extraDeck.Add(i, new extraCard(entityId, true));
                    }
                }
            }

            Action a = Ai.Instance.bestmove;
            foreach (var c in extraDeck)
            {
                if (c.Value.isindeck == false) continue;
                CardDB.cardIDEnum ce;
                string entityId = c.Value.id;
                if (entityId == "")
                {
                    if (a != null)
                    {
                        switch (a.actionType)
                        {
                            case actionEnum.playcard:
                                switch (a.card.card.cardIDenum)
                                {
                                    case CardDB.cardIDEnum.LOE_104: goto case CardDB.cardIDEnum.BRM_007; 
                                    case CardDB.cardIDEnum.BRM_007: 
                                        if (a.target != null) entityId = a.target.handcard.card.cardIDenum.ToString();
                                        break;
                                    case CardDB.cardIDEnum.LOE_002: entityId = "LOE_002t"; break; 
                                    case CardDB.cardIDEnum.LOE_079: entityId = "LOE_019t"; break; 
                                    case CardDB.cardIDEnum.LOE_019t: entityId = "LOE_019t2"; break;
                                    case CardDB.cardIDEnum.LOE_110: entityId = "LOE_110t"; break; 
                                }
                                break;
                        }
                    }
                    if (entityId == "")
                    {
                        var oldCardsOut = Probabilitymaker.Instance.enemyCardsOut;
                        foreach (var tmp in eg)
                        {
                            if (oldCardsOut.ContainsKey(tmp.Key) && tmp.Value == oldCardsOut[tmp.Key]) continue;
                            switch (tmp.Key)
                            {
                                case CardDB.cardIDEnum.AT_035: entityId = "AT_035t"; break; 
                                case CardDB.cardIDEnum.GVG_031: entityId = "aiextra1"; break; 
                                case CardDB.cardIDEnum.LOE_111: entityId = "LOE_111"; break; 
                            }
                        }
                        if (entityId == "" && lastpf != null)
                        {
                            int num = 0;
                            foreach (Minion m in this.enemyMinions)
                            {
                                if (m.handcard.card.cardIDenum == CardDB.cardIDEnum.GVG_056) num++; 
                            }
                            if (num > 0)
                            {
                                foreach (Minion m in lastpf.enemyMinions)
                                {
                                    if (m.handcard.card.cardIDenum == CardDB.cardIDEnum.GVG_056) num--;
                                }
                            }
                            if (num > 0) entityId = "GVG_056t";
                            else
                            {
                                num = 0;
                                foreach (Minion m in lastpf.ownMinions)
                                {
                                    if (m.handcard.card.cardIDenum == CardDB.cardIDEnum.GVG_035) num++; 
                                }
                                if (num > 0)
                                {
                                    foreach (Minion m in this.ownMinions)
                                    {
                                        if (m.handcard.card.cardIDenum == CardDB.cardIDEnum.GVG_035) num--;
                                    }
                                }
                                if (num > 0) entityId = "GVG_035";
                            }
                        }
                    }
                    if (entityId == "") entityId = "aiextra1";
                }
                c.Value.setId(entityId);
                ce = CardDB.Instance.cardIdstringToEnum(entityId);
                if (turnDeck.ContainsKey(ce)) turnDeck[ce]++;
                else turnDeck.Add(ce, 1);
            }
            foreach (var c in tmpDeck)
            {
                if (c.Value < 1) continue;
                CardDB.cardIDEnum ce = CardDB.Instance.cardIdstringToEnum(c.Key);
                if (ce == CardDB.cardIDEnum.None) continue;
                if (turnDeck.ContainsKey(ce)) turnDeck[ce] += c.Value;
                else turnDeck.Add(ce, c.Value);
            }

            Probabilitymaker.Instance.setOwnCardsOut(og);
            Probabilitymaker.Instance.setEnemyCardsOut(eg);
            bool isTurnStart = false;
            if (Ai.Instance.nextMoveGuess.mana == -100)
            {
                isTurnStart = true;
                Ai.Instance.updateTwoTurnSim();
            }
            Probabilitymaker.Instance.setGraveYard(graveYard, isTurnStart);

            if (startDeck.Count == 0) return;
            noDuplicates = true;
            foreach (int i in turnDeck.Values)
            {
                if (i > 1)
                {
                    noDuplicates = false;
                    break;
                }
            }
		}

        private void updateBehaveString(Behavior botbase)
        {
            this.botbehave = botbase.BehaviorName();
            this.botbehave += " " + Ai.Instance.maxwide;
            this.botbehave += " face " + ComboBreaker.Instance.attackFaceHP;
            if (Settings.Instance.berserkIfCanFinishNextTour > 0) this.botbehave += " berserk:" + Settings.Instance.berserkIfCanFinishNextTour;
            if (Settings.Instance.weaponOnlyAttackMobsUntilEnfacehp > 0) this.botbehave += " womob:" + Settings.Instance.weaponOnlyAttackMobsUntilEnfacehp;
            if (Settings.Instance.secondTurnAmount > 0)
            {
                if (Ai.Instance.nextMoveGuess.mana == -100)
                {
                    Ai.Instance.updateTwoTurnSim();
                }
                this.botbehave += " twoturnsim " + Settings.Instance.secondTurnAmount + " ntss " +
                                  Settings.Instance.nextTurnDeep + " " + Settings.Instance.nextTurnMaxWide + " " +
                                  Settings.Instance.nextTurnTotalBoards;
            }

            if (Settings.Instance.playaround)
            {
                this.botbehave += " playaround";
                this.botbehave += " " + Settings.Instance.playaroundprob + " " + Settings.Instance.playaroundprob2;
            }

            this.botbehave += " ets " + Settings.Instance.enemyTurnMaxWide;

            if (Settings.Instance.twotsamount > 0)
            {
                this.botbehave += " ets2 " + Settings.Instance.enemyTurnMaxWideSecondStep;
            }

            if (Settings.Instance.useSecretsPlayAround)
            {
                this.botbehave += " secret";
            }

            if (Settings.Instance.secondweight != 0.5f)
            {
                this.botbehave += " weight " + (int) (Settings.Instance.secondweight*100f);
            }

            if (Settings.Instance.placement != 0)
            {
                this.botbehave += " plcmnt:" + Settings.Instance.placement;
            }

            this.botbehave += " iC " + Settings.Instance.ImprovedCalculations;

            this.botbehave += " aA " + Settings.Instance.adjustActions;
            if (Settings.Instance.concedeMode != 0) this.botbehave += " cede:" + Settings.Instance.concedeMode;
            
        }
        
        public void updateCThunInfo(int OgOwnCThunAngrBonus, int OgOwnCThunHpBonus, int OgOwnCThunTaunt)
        {
            this.anzOgOwnCThunAngrBonus = OgOwnCThunAngrBonus;
            this.anzOgOwnCThunHpBonus = OgOwnCThunHpBonus;
            this.anzOgOwnCThunTaunt = OgOwnCThunTaunt;
            Hrtprozis.Instance.updateCThunInfo(this.anzOgOwnCThunAngrBonus, this.anzOgOwnCThunHpBonus, this.anzOgOwnCThunTaunt);
        }

        public void updateCThunInfobyCThun()
        {
            bool found = false;
            foreach (Handmanager.Handcard hc in this.handCards)
            {
                if (hc.card.name == CardDB.cardName.cthun)
                {
                    this.anzOgOwnCThunAngrBonus = hc.addattack;
                    this.anzOgOwnCThunHpBonus = hc.addHp;
                    found = true;
                    break;
                }
            }

            if (!found)
            {
                foreach (Minion m in this.ownMinions)
                {
                    if (m.name == CardDB.cardName.cthun)
                    {
                        if (this.anzOgOwnCThunAngrBonus < m.Angr - 6) this.anzOgOwnCThunAngrBonus = m.Angr - 6;
                        if (this.anzOgOwnCThunHpBonus < m.Hp - 6) this.anzOgOwnCThunHpBonus = m.Angr - 6;
                        if (m.taunt && this.anzOgOwnCThunTaunt < 1) this.anzOgOwnCThunTaunt++;
                        found = true;
                        break;
                    }
                }
            }
        }

        public static int getLastAffected(int entityid)
        {

            List<HSCard> allEntitys = TritonHs.GetAllCards();

            foreach (HSCard ent in allEntitys)
            {
                if (ent.GetTag(GAME_TAG.LAST_AFFECTED_BY) == entityid) return ent.GetTag(GAME_TAG.ENTITY_ID);
            }

            return 0;
        }

        public static int getCardTarget(int entityid)
        {

            List<HSCard> allEntitys = TritonHs.GetAllCards();

            foreach (HSCard ent in allEntitys)
            {
                if (ent.GetTag(GAME_TAG.ENTITY_ID) == entityid) return ent.GetTag(GAME_TAG.CARD_TARGET);
            }

            return 0;

        }


        private void printstuff()
        {
            string dtimes = DateTime.Now.ToString("HH:mm:ss:ffff");
            string enemysecretIds = "";
            enemysecretIds = Probabilitymaker.Instance.getEnemySecretData();
            Helpfunctions.Instance.logg("#######################################################################");
            Helpfunctions.Instance.logg("#######################################################################");
            Helpfunctions.Instance.logg("start calculations, current time: " + DateTime.Now.ToString("HH:mm:ss") + " V" +
                                        this.versionnumber + " " + this.botbehave);
            Helpfunctions.Instance.logg("#######################################################################");
            Helpfunctions.Instance.logg("turn " + gTurn + "/" + gTurnStep);
            Helpfunctions.Instance.logg("mana " + currentMana + "/" + ownMaxMana);
            Helpfunctions.Instance.logg("emana " + enemyMaxMana);
            Helpfunctions.Instance.logg("own secretsCount: " + ownSecretList.Count);
            Helpfunctions.Instance.logg("enemy secretsCount: " + enemySecretList.Count + " ;" + enemysecretIds);

            Ai.Instance.currentCalculatedBoard = dtimes;

            Hrtprozis.Instance.printHero();
            Hrtprozis.Instance.printOwnMinions();
            Hrtprozis.Instance.printEnemyMinions();
            Handmanager.Instance.printcards();
            Probabilitymaker.Instance.printTurnGraveYard();
            Probabilitymaker.Instance.printGraveyards();
            Hrtprozis.Instance.printOwnDeck();
        }

    }
}


