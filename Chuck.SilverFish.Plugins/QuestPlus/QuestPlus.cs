using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Markup;
using System.Text;
using Chuck.SilverFish;
using log4net;
using Triton.Bot;
using Triton.Bot.Logic.Bots.DefaultBot;
using Triton.Common;
using Triton.Game;
using Triton.Game.Data;
using Triton.Game.Mapping;
using Logger = Triton.Common.LogUtilities.Logger;

namespace QuestPlus
{
    /// <summary>
    /// NOTE: Due to the old design of HSBs dev tools, this GUI implementation is very ugly.
    /// </summary>
    public class QuestPlus : IPlugin
    {
        private static readonly ILog Log = Logger.GetLoggerInstanceForType();

        private bool _enabled;

        private bool _findNewQuest = true;
        private string _lastDeck;
        private GameRule _lastRule;
        private GameMode _lastGameMode;
        private ConstructedMode _lastConstructedMode;
        private Dictionary<long, deck> myDecks = new Dictionary<long, deck>();

        private deck bestDeck;
        private int _theWorstQuestId = -1; // Avoid global/local variables with same name
        private bool canCancel = false;
        private StringBuilder allQuestsString = new StringBuilder("", 1000);
        private StringBuilder botStopReason = new StringBuilder("", 1000);

        private Dictionary<Triton.Game.Mapping.TAG_CLASS, int> classPriorityForQuests = new Dictionary<Triton.Game.Mapping.TAG_CLASS, int>();
        private Dictionary<long, Triton.Game.Mapping.TAG_CLASS> topDeckNames = new Dictionary<long, Triton.Game.Mapping.TAG_CLASS>();
        private Dictionary<Triton.Game.Mapping.TAG_CLASS, int> classLvl = new Dictionary<Triton.Game.Mapping.TAG_CLASS, int>();
        private questPlan QuestsPlan = questPlan.MaxQuests;
        private playPlanAfterQuestsAreDone afterQuestsPlan = playPlanAfterQuestsAreDone.Stop;
        private GameMode AfterQuestGameMode = GameMode.Constructed;
        private ConstructedMode QuestPlayMode = ConstructedMode.Casual;
        private ConstructedMode AfterQuestPlayMode = ConstructedMode.Casual;
        private bool removeTheWorstQuest = false;
        private bool removeTavernBrawl = false;
        private bool afterQuests = false;
        private bool RankedModeForQuests = true;
        private bool stopIfXfreeSlots = false;
        private int StopIfXfreeSlotsNum = 2;
        private bool ChangeClassIfUReachLvlX = false;
        private int ChangeClassLvl = 60;
        private bool useSuitableDeck = false;
        private int NumReCacheQuests = 0;
        private int profit = 55;


        private int min_spells = 1;
        private int min_secrets = 1;
        private int min_murlocs = 1;
        private int min_demons = 1;
        private int min_beasts = 1;
        private int min_elems = 1;
        private int min_pirates = 1;
        private int min_taunts = 1;
        private int min_combos = 1;
        private int min_weapons = 1;
        private int min_bc = 1;
        private int min_dr = 1;
        private int min_m2 = 1;
        private int min_m5 = 1;
        private int min_c8 = 3;
        private int min_shield = 1;
        private int min_enrage = 1;
        private int min_overload = 1;
        private int min_classCards = 1;


        DefaultBotSettings botset
        {
            get { return DefaultBotSettings.Instance; }
        }
        QuestPlusSettings questset
        {
            get { return QuestPlusSettings.Instance; }
        }
		
        public enum questPlan
        {
            MaxQuests = 0,
            MaxGold = 1
        }

        public enum playPlanAfterQuestsAreDone
        {
            Stop = 0,
            Play = 1,
            PlayAvoidingCheapQuests = 2
        }

        public class questInfo
        {
            public string Name = "";
            public int CurProgress = 0;
            public string Description = "";
            public int Id = 0;
            public int MaxProgress = 0;
            public int goldReward = 0;

            public questInfo(AchievementData quest, int grevard)
            {
                getQuestInfo(quest, grevard);
            }

            private void getQuestInfo(AchievementData quest, int grevard)
            {
                this.Name = quest.Name;
                this.CurProgress = quest.CurProgress;
                this.Description = quest.Description;
                this.Id = quest.Id;
                this.MaxProgress = quest.MaxProgress;
                this.goldReward = grevard;
            }
        }
        
        public class deck
        {
            public List <string> CardIds = null;
            public long DeckId;
            public Triton.Game.Mapping.TAG_CLASS heroClass = Triton.Game.Mapping.TAG_CLASS.INVALID;
            public bool IsWild = false;
            public string Name = "";

            public int spells = 0;
            public int secrets = 0;
            public int murlocs = 0;
            public int demons = 0;
            public int beasts = 0;
            public int elems = 0;
            public int pirates = 0;
            public int taunts = 0;
            public int combos = 0;
            public int weapons = 0;
            public int bc = 0;
            public int dr = 0;
            public int m2 = 0;
            public int m5 = 0;
            public int c8 = 0;
            public int shield = 0;
            public int enrage = 0;
            public int overload = 0;
            public int classCards = 0;

            public Dictionary<int, int> Id40 = new Dictionary<int, int>();
            public Dictionary<int, int> Id50 = new Dictionary<int, int>();
            public Dictionary<int, int> Id60 = new Dictionary<int, int>();
            public Dictionary<int, int> Id100 = new Dictionary<int, int>(); 
            public Dictionary<int, Tuple<int, questInfo>> allQuestsId = new Dictionary<int, Tuple<int, questInfo>>(); 
            public int sumGold = 0;
            public float Id40averagePercentAvl = 0;
            public float Id50averagePercentAvl = 0;
            public float Id60averagePercentAvl = 0;
            public float Id100averagePercentAvl = 0;
            public int allReqSum = 0;

            public deck (CustomDeckCache baseDeck)
            {
                getDeckInfo(baseDeck);
            }

            private void getDeckInfo (CustomDeckCache baseDeck)
            {
                this.DeckId = baseDeck.DeckId;
                this.heroClass = TritonHs.GetBasicHeroClassFromCardId(baseDeck.HeroCardId);
                this.IsWild = baseDeck.IsWild;
                this.Name = baseDeck.Name;
                this.CardIds = new List<string> (baseDeck.CardIds);
                QuestCardDB.QuestCard c;
                foreach (string tmp in CardIds)
                {
                    c = QuestCardDB.Instance.getCardDataFromStringID(tmp);
                    if (c == null) continue;
                    switch (c.type)
                    {
                        case QuestCardDB.cardtype.WEAPON:
                            weapons++;
                            break;
                        case QuestCardDB.cardtype.SPELL:
                            spells++;
                            if (c.Secret) secrets++;
                            break;
                        case QuestCardDB.cardtype.MOB:
                            switch ((Triton.Game.Mapping.TAG_RACE)c.race)
                            {
                                case Triton.Game.Mapping.TAG_RACE.MURLOC: murlocs++; break;
                                case Triton.Game.Mapping.TAG_RACE.DEMON: demons++; break;
                                case Triton.Game.Mapping.TAG_RACE.PET: beasts++; break;
                                case Triton.Game.Mapping.TAG_RACE.ELEMENTAL: elems++; break;
                                case Triton.Game.Mapping.TAG_RACE.PIRATE: pirates++; break;
                            }
                            switch (c.cost)
                            {
                                case 0: m2++; break;
                                case 1: m2++; break;
                                case 2: m2++; break;
                                case 3: break;
                                case 4: break;
                                default:
                                    m5++;
                                    break;
                            }
                            if (c.battlecry) bc++;
                            if (c.deathrattle) dr++;
                            if (c.Shield) shield++;
                            if (c.Enrage) enrage++;
                            if (c.tank) taunts++;
                            break;
                    }
                    if (c.cost >= 8) c8++;
                    if (c.overload > 0) overload++;
                    if (c.Combo) combos++;
                    if ((Triton.Game.Mapping.TAG_CLASS)c.Class == heroClass) classCards++;

                }
            }

            public string getQuestsInfo()
            {
                StringBuilder questsInfoSB = new StringBuilder("", 1000);
                foreach (var q in allQuestsId)
                {
                    questsInfoSB.Append(" [").Append(q.Value.Item2.goldReward).Append("gold]").Append(q.Value.Item2.Name).Append("(").Append(q.Value.Item1).Append(" %) ");
                }
                return questsInfoSB.ToString();
            }

            public void addRewards(questInfo qi, int availability)
            {
                sumGold += qi.goldReward;
                allReqSum += availability;
                int percentAval = availability * 100 / (qi.MaxProgress - qi.CurProgress);
                switch (qi.goldReward)
                {
                    case 40:
                        Id40.Add(qi.Id, availability);
                        Id40averagePercentAvl = (Id40averagePercentAvl * (Id40.Count() - 1) + percentAval) / Id40.Count();
                        break;
                    case 50:
                        Id50.Add(qi.Id, availability);
                        Id50averagePercentAvl = (Id50averagePercentAvl * (Id50.Count() - 1) + percentAval) / Id50.Count();
                        break;
                    case 60:
                        Id60.Add(qi.Id, availability);
                        Id60averagePercentAvl = (Id60averagePercentAvl * (Id60.Count() - 1) + percentAval) / Id60.Count();
                        break;
                    case 100:
                        Id100.Add(qi.Id, availability);
                        Id100averagePercentAvl = (Id100averagePercentAvl * (Id100.Count() - 1) + percentAval) / Id100.Count();
                        break;
                }

                allQuestsId.Add(qi.Id, new Tuple<int, questInfo>(percentAval, qi));
            }
                        
            public void resetRewards()
            {
                Id40.Clear();
                Id50.Clear();
                Id60.Clear();
                Id100.Clear();
                allQuestsId.Clear();
                sumGold = 0;
                Id40averagePercentAvl = 0;
                Id50averagePercentAvl = 0;
                Id60averagePercentAvl = 0;
                Id100averagePercentAvl = 0;
                allReqSum = 0;
            }

            public bool isBetterMaxGoldThen(deck tmp)
            {
                if (!(this.Id100.Count() == 0 && tmp.Id100.Count() == 0))
                {
                    if (this.Id100.Count() > tmp.Id100.Count()) return true;
                    else if (tmp.Id100.Count() > this.Id100.Count()) return false;
                    else if (this.Id100averagePercentAvl > tmp.Id100averagePercentAvl) return true;
                    return false;
                }
                
                if (!(this.Id60.Count() == 0 && tmp.Id60.Count() == 0))
                {
                    if (this.Id60.Count() > tmp.Id60.Count()) return true;
                    else if (tmp.Id60.Count() > this.Id60.Count()) return false;
                    else if (this.Id60averagePercentAvl > tmp.Id60averagePercentAvl) return true;
                    return false;
                }
                
                if (!(this.Id50.Count() == 0 && tmp.Id50.Count() == 0))
                {
                    if (this.Id50.Count() > tmp.Id50.Count()) return true;
                    else if (tmp.Id50.Count() > this.Id50.Count()) return false;
                    else if (this.Id50averagePercentAvl > tmp.Id50averagePercentAvl) return true;
                    return false;
                }

                if (!(this.Id40.Count() == 0 && tmp.Id40.Count() == 0))
                {
                    if (this.Id40.Count() > tmp.Id40.Count()) return true;
                    else if (tmp.Id40.Count() > this.Id40.Count()) return false;
                    else if (this.Id40averagePercentAvl > tmp.Id40averagePercentAvl) return true;
                    return false;
                }

                return false;
            }
        }

        #region Implementation of IPlugin

        /// <summary> The name of the plugin. </summary>
        public string Name
        {
            get
            {
                return "QuestPlus";
            }
        }

        /// <summary> The description of the plugin. </summary>
        public string Description
        {
            get
            {
                return "A plugin that provides quest functionality for Hearthbuddy and bot behavior after the bot will complete all the available quests.\n*Old Quest plugin must be disabled.";
            }
        }

        /// <summary>The author of the plugin.</summary>
        public string Author
        {
            get
            {
                return "Bossland GmbH";
            }
        }

        /// <summary>The version of the plugin.</summary>
        public string Version
        {
            get
            {
                return "0.0.2.4";
            }
        }

        /// <summary>Initializes this object. This is called when the object is loaded into the bot.</summary>
        public void Initialize()
        {
            Log.DebugFormat("[QuestPlus] Initialize");
        }

        /// <summary> The plugin start callback. Do any initialization here. </summary>
        public void Start()
        {
            Log.DebugFormat("[QuestPlus] Start v." + this.Version);

            GameEventManager.PreStartingNewGame += GameEventManagerOnPreStartingNewGame;
            GameEventManager.QuestUpdate += GameEventManagerOnQuestUpdate;
            GameEventManager.NewGame += GameEventManagerOnNewGame;
            GameEventManager.GameOver += GameEventManagerOnGameOver;
			GameEventManager.QuestLoad += GameEventManagerOnQuestLoad;

            if (!(BotManager.CurrentBot is DefaultBot))
            {
                Log.ErrorFormat(
                    "[QuestPlus] This plugin is not compatible with this bot. Please disable the plugin before starting again or change the bot being used.");
                BotManager.Stop();
                return;
            }

            _lastDeck = botset.ConstructedCustomDeck;
            _lastRule = botset.ConstructedGameRule;
            _lastGameMode = botset.GameMode;
            _lastConstructedMode = botset.ConstructedMode;

            if (botset.GameMode != GameMode.Constructed)
            {
                botset.NeedsToCacheQuests = true;
                botset.GameMode = GameMode.Constructed;
            }
            botset.ConstructedGameRule = GameRule.Auto;
            botset.ConstructedMode = QuestPlayMode;
        }

        /// <summary> The plugin tick callback. Do any update logic here. </summary>
        public void Tick()
        {
        }

        /// <summary> The plugin stop callback. Do any pre-dispose cleanup here. </summary>
        public void Stop()
        {
            Log.DebugFormat("[QuestPlus] Stop");

            GameEventManager.PreStartingNewGame -= GameEventManagerOnPreStartingNewGame;
            GameEventManager.QuestUpdate -= GameEventManagerOnQuestUpdate;
            GameEventManager.NewGame -= GameEventManagerOnNewGame;
            GameEventManager.GameOver -= GameEventManagerOnGameOver;
			GameEventManager.QuestLoad -= GameEventManagerOnQuestLoad;

            DefaultBotSettings.Instance.ConstructedCustomDeck = _lastDeck;
            DefaultBotSettings.Instance.ConstructedGameRule = _lastRule;
            DefaultBotSettings.Instance.GameMode = _lastGameMode;
            DefaultBotSettings.Instance.ConstructedMode = _lastConstructedMode;

            _findNewQuest = true;
        }
        
        public JsonSettings Settings
        {
            get
            {
                return questset;
            }
        }

        private UserControl _control;

        /// <summary> The plugin's settings control. This will be added to the Hearthbuddy Settings tab.</summary>
        public UserControl Control
        {
            get
            {
                if (_control != null)
                {
                    return _control;
                }

                using (var fs = new FileStream(@"Plugins\QuestPlus\SettingsGui.xaml", FileMode.Open))
                {
                    var root = (UserControl)XamlReader.Load(fs);

                    // Your settings binding here.

                    // QuestsPlan
                    if (!Wpf.SetupComboBoxItemsBinding(root, "QuestsPlanComboBox", "AllQuestsPlans", BindingMode.OneWay, questset))
                    {
                        Log.DebugFormat("[SettingsControl] SetupCheckBoxBinding failed for 'QuestsPlan'.");
                        throw new Exception("The SettingsControl could not be created.");
                    }
                    if (!Wpf.SetupComboBoxSelectedItemBinding(root, "QuestsPlanComboBox", "QuestsPlan", BindingMode.TwoWay, questset))
                    {
                        Log.DebugFormat("[SettingsControl] SetupComboBoxSelectedItemBinding failed for 'QuestsPlan'.");
                        throw new Exception("The SettingsControl could not be created.");
                    }

                    // QuestPlayMode
                    if (!Wpf.SetupComboBoxItemsBinding(root, "QuestPlayModeComboBox", "AllConstructedModes", BindingMode.OneWay, questset))
                    {
                        Log.DebugFormat("[SettingsControl] SetupCheckBoxBinding failed for 'QuestPlayMode'.");
                        throw new Exception("The SettingsControl could not be created.");
                    }
                    if (!Wpf.SetupComboBoxSelectedItemBinding(root, "QuestPlayModeComboBox", "QuestPlayMode", BindingMode.TwoWay, questset))
                    {
                        Log.DebugFormat("[SettingsControl] SetupComboBoxSelectedItemBinding failed for 'QuestPlayMode'.");
                        throw new Exception("The SettingsControl could not be created.");
                    }

                    // AfterQuestsPlan
                    if (!Wpf.SetupComboBoxItemsBinding(root, "AfterQuestsPlanComboBox", "AllAfterQuestsPlans", BindingMode.OneWay, questset))
                    {
                        Log.DebugFormat("[SettingsControl] SetupCheckBoxBinding failed for 'AfterQuestsPlan'.");
                        throw new Exception("The SettingsControl could not be created.");
                    }
                    if (!Wpf.SetupComboBoxSelectedItemBinding(root, "AfterQuestsPlanComboBox", "AfterQuestsPlan", BindingMode.TwoWay, questset))
                    {
                        Log.DebugFormat("[SettingsControl] SetupComboBoxSelectedItemBinding failed for 'AfterQuestsPlan'.");
                        throw new Exception("The SettingsControl could not be created.");
                    }

                    // AfterQuestGameMode
                    if (!Wpf.SetupComboBoxItemsBinding(root, "AfterQuestGameModeComboBox", "AllGameModes", BindingMode.OneWay, questset))
                    {
                        Log.DebugFormat("[SettingsControl] SetupCheckBoxBinding failed for 'AfterQuestGameMode'.");
                        throw new Exception("The SettingsControl could not be created.");
                    }
                    if (!Wpf.SetupComboBoxSelectedItemBinding(root, "AfterQuestGameModeComboBox", "AfterQuestGameMode", BindingMode.TwoWay, questset))
                    {
                        Log.DebugFormat("[SettingsControl] SetupComboBoxSelectedItemBinding failed for 'AfterQuestGameMode'.");
                        throw new Exception("The SettingsControl could not be created.");
                    }
                    
                    // AfterQuestPlayMode
                    if (!Wpf.SetupComboBoxItemsBinding(root, "AfterQuestPlayModeComboBox", "AllConstructedModes", BindingMode.OneWay, questset))
                    {
                        Log.DebugFormat("[SettingsControl] SetupCheckBoxBinding failed for 'AfterQuestPlayMode'.");
                        throw new Exception("The SettingsControl could not be created.");
                    }
                    if (!Wpf.SetupComboBoxSelectedItemBinding(root, "AfterQuestPlayModeComboBox", "AfterQuestPlayMode", BindingMode.TwoWay, questset))
                    {
                        Log.DebugFormat("[SettingsControl] SetupComboBoxSelectedItemBinding failed for 'AfterQuestPlayMode'.");
                        throw new Exception("The SettingsControl could not be created.");
                    }

                    // useSuitableDeck
                    if (!Wpf.SetupCheckBoxBinding(root, "UseSuitableDeck_chb", "useSuitableDeck", BindingMode.TwoWay, questset))
                    {
                        Log.DebugFormat("[SettingsControl] SetupCheckBoxBinding failed for 'useSuitableDeck'.");
                        throw new Exception("The SettingsControl could not be created.");
                    }

                    // removeTheWorstQuest
                    if (!Wpf.SetupCheckBoxBinding(root, "RemoveTheWorstQuest_chb", "removeTheWorstQuest", BindingMode.TwoWay, questset))
                    {
                        Log.DebugFormat("[SettingsControl] SetupCheckBoxBinding failed for 'removeTheWorstQuest'.");
                        throw new Exception("The SettingsControl could not be created.");
                    }

                    // RankedModeForQuests
                    if (!Wpf.SetupCheckBoxBinding(root, "RankedModeForQuests_chb", "rankedModeForQuests", BindingMode.TwoWay, questset))
                    {
                        Log.DebugFormat("[SettingsControl] SetupCheckBoxBinding failed for 'rankedModeForQuests'.");
                        throw new Exception("The SettingsControl could not be created.");
                    }

                    // removeTavernBrawl
                    if (!Wpf.SetupCheckBoxBinding(root, "RemoveTavernBrawl_chb", "removeTavernBrawl", BindingMode.TwoWay, questset))
                    {
                        Log.DebugFormat("[SettingsControl] SetupCheckBoxBinding failed for 'removeTavernBrawl'.");
                        throw new Exception("The SettingsControl could not be created.");
                    }

                    // stopIfXfreeSlots
                    if (!Wpf.SetupCheckBoxBinding(root, "StopIfXfreeSlots_chb", "stopIfXfreeSlots", BindingMode.TwoWay, questset))
                    {
                        Log.DebugFormat("[SettingsControl] SetupCheckBoxBinding failed for 'stopIfXfreeSlots'.");
                        throw new Exception("The SettingsControl could not be created.");
                    }
                    if (!Wpf.SetupComboBoxItemsBinding(root, "StopIfXfreeSlotsNumComboBox", "AllFreeSlots", BindingMode.OneWay, questset))
                    {
                        Log.DebugFormat("[SettingsControl] SetupCheckBoxBinding failed for 'AllFreeSlots'.");
                        throw new Exception("The SettingsControl could not be created.");
                    }
                    if (!Wpf.SetupComboBoxSelectedItemBinding(root, "StopIfXfreeSlotsNumComboBox", "StopIfXfreeSlotsNum", BindingMode.TwoWay, questset))
                    {
                        Log.DebugFormat("[SettingsControl] SetupComboBoxSelectedItemBinding failed for 'StopIfXfreeSlotsNum'.");
                        throw new Exception("The SettingsControl could not be created.");
                    }

                    // ChangeClassLvl
                    if (!Wpf.SetupCheckBoxBinding(root, "ChangeClassIfUReachLvlX_chb", "changeClassIfUReachLvlX", BindingMode.TwoWay, questset))
                    {
                        Log.DebugFormat("[SettingsControl] SetupCheckBoxBinding failed for 'changeClassIfUReachLvlX'.");
                        throw new Exception("The SettingsControl could not be created.");
                    }
                    if (!Wpf.SetupComboBoxItemsBinding(root, "ChangeClassLvlComboBox", "AllLvlsForChangeClass", BindingMode.OneWay, questset))
                    {
                        Log.DebugFormat("[SettingsControl] SetupCheckBoxBinding failed for 'AllLvlsForChangeClass'.");
                        throw new Exception("The SettingsControl could not be created.");
                    }
                    if (!Wpf.SetupComboBoxSelectedItemBinding(root, "ChangeClassLvlComboBox", "ChangeClassLvl", BindingMode.TwoWay, questset))
                    {
                        Log.DebugFormat("[SettingsControl] SetupComboBoxSelectedItemBinding failed for 'ChangeClassLvl'.");
                        throw new Exception("The SettingsControl could not be created.");
                    }

                    // KeepRank
                    if (!Wpf.SetupCheckBoxBinding(root, "KeepRank_chb", "KeepRank", BindingMode.TwoWay, questset))
                    {
                        Log.DebugFormat("[SettingsControl] SetupCheckBoxBinding failed for 'KeepRank'.");
                        throw new Exception("The SettingsControl could not be created.");
                    }
                    if (!Wpf.SetupComboBoxItemsBinding(root, "KeepRankComboBox", "AllLvlsForKeepRank", BindingMode.OneWay, questset))
                    {
                        Log.DebugFormat("[SettingsControl] SetupCheckBoxBinding failed for 'AllLvlsForKeepRank'.");
                        throw new Exception("The SettingsControl could not be created.");
                    }
                    if (!Wpf.SetupComboBoxSelectedItemBinding(root, "KeepRankComboBox", "KeepRankLvl", BindingMode.TwoWay, questset))
                    {
                        Log.DebugFormat("[SettingsControl] SetupComboBoxSelectedItemBinding failed for 'KeepRankLvl'.");
                        throw new Exception("The SettingsControl could not be created.");
                    }

                    // Priority
                    string name = "";
                    string ctrlName = "";
                    for (var i = 1; i <= 9; i++)
                    {
                        name = string.Format("Priority{0}", i);
                        ctrlName = string.Format("priority{0}_tb", i);
                        if (!Wpf.SetupTextBoxBinding(root, ctrlName, name, BindingMode.TwoWay, questset))
                        {
                            Log.DebugFormat("[SettingsControl] SetupCheckBoxBinding failed for '{0}'.", ctrlName);
                            throw new Exception("The SettingsControl could not be created.");
                        }
                    }

                    // HeroClass
                    for (var i = 1; i <= 9; i++)
                    {
                        name = string.Format("HeroClass{0}", i);
                        ctrlName = string.Format("HeroClass{0}_lbl", i);
                        if (!Wpf.SetupLabelBinding(root, ctrlName, name, BindingMode.OneWay, questset))
                        {
                            Log.DebugFormat("[SettingsControl] SetupCheckBoxBinding failed for '{0}'.", ctrlName);
                            throw new Exception("The SettingsControl could not be created.");
                        }
                    }

                    // TopDeckNames
                    for (var i = 1; i <= 9; i++)
                    {
                        name = string.Format("TopDeck{0}", i);
                        ctrlName = string.Format("topDeck{0}_tb", i);
                        if (!Wpf.SetupTextBoxBinding(root, ctrlName, name, BindingMode.TwoWay, questset))
                        {
                            Log.DebugFormat("[SettingsControl] SetupCheckBoxBinding failed for '{0}'.", ctrlName);
                            throw new Exception("The SettingsControl could not be created.");
                        }
                    }

                    if (!Wpf.SetupTextBoxBinding(root, "QuestsPlanDesc_tb", "QuestsPlanDesc", BindingMode.TwoWay, questset))
                    {
                        Log.DebugFormat("[SettingsControl] SetupCheckBoxBinding failed for 'QuestsPlanDesc'.");
                        throw new Exception("The SettingsControl could not be created.");
                    }


                    // Your settings event handlers here.

                    _control = root;
                }

                return _control;
            }
        }

        /// <summary>Is this plugin currently enabled?</summary>
        public bool IsEnabled
        {
            get
            {
                return _enabled;
            }
        }

        /// <summary> The plugin is being enabled.</summary>
        public void Enable()
        {
            Log.DebugFormat("[QuestPlus] Enable");
            _enabled = true;
        }

        /// <summary> The plugin is being disabled.</summary>
        public void Disable()
        {
            Log.DebugFormat("[QuestPlus] Disable");
            _enabled = false;
        }

        #endregion

        #region Implementation of IDisposable

        /// <summary>Deinitializes this object. This is called when the object is being unloaded from the bot.</summary>
        public void Deinitialize()
        {
        }

        #endregion

        #region Override of Object

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Name + ": " + Description;
        }

        #endregion


        private void GameEventManagerOnQuestLoad(object sender, QuestLoadEventArgs questLoadEventArgs)
        {
            updateSettings();
            var quests = TritonHs.CurrentQuests;
            int numQuests = quests.Count;
            foreach (var q in QuestLog.Get().m_currentQuests)
            {
                canCancel = q.m_cancelButtonRoot.Active;
                break;
            }

            Log.InfoFormat("[QuestPlus] OnQuestLoad");
            getTheBestWorstQuests(ref _theWorstQuestId);
            if (_theWorstQuestId > 0)
            {
                string infoText = "error";
                foreach (var q in quests)
                {
                    if (q.Id == _theWorstQuestId)
                    {
                        infoText = q.Name;
                        break;
                    }
                }
                string infoText2 = (removeTheWorstQuest) ? " Remove the worst quest is checked" : "";
                // here remove quest with id theWorstQuestId
                if (removeTheWorstQuest)
                {
                    if (canCancel)
                    {
                        Log.InfoFormat("[QuestPlus] The worst quest: {0}.{1} [{2}]", infoText, infoText2, QuestsPlan);
                        DefaultRoutineSettings.Instance.QuestIdsToCancel.Clear(); // Remove old quest ids
                        DefaultRoutineSettings.Instance.QuestIdsToCancel.Add(_theWorstQuestId); // Add the quest to be removed
                        canCancel = false;
                    }
                }
            }
        }

        private void GameEventManagerOnNewGame(object sender, NewGameEventArgs newGameEventArgs)
        {
            if (questset.KeepRank && botset.ConstructedMode == ConstructedMode.Ranked && TritonHs.MyRank < questset.KeepRankLvl)
            {
                botset.ForceConcedeAtMulligan = true;
                Log.InfoFormat("[QuestPlus] Current rank: {0}. Keep rank: {1}. Need Concede.", TritonHs.MyRank, questset.KeepRankLvl);
                return;
            }
            foreach (var quest in TritonHs.CurrentQuests)
            {
                Log.InfoFormat("[QuestPlus::GameEventManagerOnNewGame] {0}: {1} ({2} / {3}) [{5}x {4}]", quest.Name, quest.Description,
                    quest.CurProgress,
                    quest.MaxProgress, quest.RewardData[0].Type, quest.RewardData[0].Count);
            }
        }
        
        private void GameEventManagerOnPreStartingNewGame(object sender, PreStartingNewGameEventArgs startingNewGameEventArgs)
		{
            // This plugin is for construted mode only, as routines must implement quest logic for arena drafts, and most non-basic quests
            // require Play mode or Arena to be completed.

            updateSettings();
            var usableDecks = questset.UsableDecks;
            afterQuests = false;
			if (_findNewQuest)
			{
				var quests = TritonHs.CurrentQuests;
                int numQuests = quests.Count;
                                
                getTheBestWorstQuests(ref _theWorstQuestId);
                if (_theWorstQuestId > 0)
                {
                    string infoText = "error";
                    foreach (var q in quests)
                    {
                        if (q.Id == _theWorstQuestId)
                        {
                            infoText = q.Name;
                            break;
                        }
                    }
                    string infoText2 = (removeTheWorstQuest) ? " (Remove the worst quest is checked)" : "";
                    if (removeTheWorstQuest)
                    {
                        Log.InfoFormat("[QuestPlus] The worst quest: {0}.{1} [{2}]", infoText, infoText2, QuestsPlan);
                        DefaultRoutineSettings.Instance.QuestIdsToCancel.Clear(); // Remove old quest ids
                        DefaultRoutineSettings.Instance.QuestIdsToCancel.Add(_theWorstQuestId); // Add the quest to be removed
                    }
                }

                botStopReason.Clear();

                int freeSlotsNum = 3 - numQuests;
                if (stopIfXfreeSlots && freeSlotsNum >= StopIfXfreeSlotsNum)
                {
                    bestDeck = null;
                    canCancel = false;
                    botStopReason.Append("We have ").Append(freeSlotsNum).Append(freeSlotsNum == 1 ? "  free slot for new quest" : " free slots for new quests").Append(" (stopIfXfreeSlots = true)");
                }
                else
                {
                    if (QuestsPlan == questPlan.MaxGold)
                    {
                        //Doing quests or just play avoiding quests, if it's specified by the rules
                        if (bestDeck == null)
                        {
                            if (canCancel && NumReCacheQuests == 0) botset.NeedsToCacheQuests = true;
                            else
                            {
                                if (numQuests == 3)
                                {
                                    setNonQuestDeck(); //We do 1 quest if all slots are full
                                    allQuestsString.Append(". 3 full slots.");
                                }
                                else
                                {
                                    if (afterQuestsPlan == playPlanAfterQuestsAreDone.Stop)
                                    {
                                        botStopReason.Append("There are no profitable quests we can complete with the current custom decks today.");
                                    }
                                    else if (afterQuestsPlan == playPlanAfterQuestsAreDone.PlayAvoidingCheapQuests)
                                    {
                                        foreach (var tmp in myDecks)
                                        {
                                            if (tmp.Value.allQuestsId.Count == 0) chooseTheBestDeckByPriority(tmp.Value);
                                        }
                                        if (bestDeck == null)
                                        {
                                            botStopReason.Append("We can't avoid cheap quests today.");
                                        }
                                    }
                                    else if (afterQuestsPlan == playPlanAfterQuestsAreDone.Play) setNonQuestDeck();
                                }
                            }
                        }
                    }
                    else if (QuestsPlan == questPlan.MaxQuests)
                    {
                        if (bestDeck == null)
                        {
                            if (canCancel && NumReCacheQuests == 0) botset.NeedsToCacheQuests = true;
                            else
                            {
                                if (afterQuestsPlan == playPlanAfterQuestsAreDone.Stop)
                                {
                                    botStopReason.Append("There are no quests we can complete with the current custom decks.");
                                }
                                else setNonQuestDeck();
                            }
                        }
                    }
                }

                if (bestDeck != null)
                {
                    if (!afterQuests)
                    {
                        string infoText = quests.Count > 1 ? "quests" : "quest";
                        Log.InfoFormat("[QuestPlus] Now choosing the deck {0} ({1}) to complete the {2}: {3}. [{4}]",
                            bestDeck.Name, bestDeck.heroClass, infoText, bestDeck.getQuestsInfo(), QuestsPlan);

                        bool forcedRank = false;
                        if (RankedModeForQuests && TritonHs.MyRank > 20) forcedRank = true;
                        if (forcedRank)
                        {
                            if (botset.ConstructedMode != ConstructedMode.Ranked) botset.ConstructedMode = ConstructedMode.Ranked;
                        }
                        else if (botset.ConstructedMode != QuestPlayMode) botset.ConstructedMode = QuestPlayMode;
                    }
                    else
                    {
                        Log.InfoFormat("[QuestPlus] Now choosing '{0}'. {1} [{2}]", bestDeck.heroClass, allQuestsString.ToString(), QuestsPlan);
                        if (botset.GameMode != AfterQuestGameMode) botset.GameMode = AfterQuestGameMode;
                        if (botset.ConstructedMode != AfterQuestPlayMode) botset.ConstructedMode = AfterQuestPlayMode;
                    }
                    if (botset.ConstructedCustomDeck != bestDeck.Name) botset.ConstructedCustomDeck = bestDeck.Name;
                    if (botset.PracticeCustomDeck != bestDeck.Name) botset.PracticeCustomDeck = bestDeck.Name;
                    if (bestDeck.IsWild) botset.ConstructedGameRule = GameRule.Wild;
                    else botset.ConstructedGameRule = GameRule.Standard;
                    return;
                }
                else
                {
                    if (allQuestsString.Length > 10) Log.DebugFormat("[QuestPlus] Remaining quests: {0}.", allQuestsString.ToString());
                    if (!canCancel || NumReCacheQuests > 0)
                    {
                        if (botset.NeedsToCacheQuests == true) return;
                        botStopReason.Append(" [").Append(QuestsPlan).Append("]").Append("because there are no quests");
                        Log.InfoFormat("[QuestPlus] Now stopping the bot. {0}", botStopReason.ToString());
                        BotManager.Stop();
                        NumReCacheQuests = 0;
                    }
                    else
                    {
                        botset.NeedsToCacheQuests = true;
                        NumReCacheQuests++;
                    }
                    return;
                }

                
            }
		}

        private void updateSettings()
        {
            QuestsPlan = questset.QuestsPlan;
            afterQuestsPlan = questset.AfterQuestsPlan;
            QuestPlayMode = questset.QuestPlayMode;
            AfterQuestGameMode = questset.AfterQuestGameMode;
            AfterQuestPlayMode = questset.AfterQuestPlayMode;
            useSuitableDeck = questset.useSuitableDeck;
            removeTheWorstQuest = questset.removeTheWorstQuest;
            removeTavernBrawl = questset.removeTavernBrawl;
            RankedModeForQuests = questset.rankedModeForQuests;
            stopIfXfreeSlots = questset.stopIfXfreeSlots;
            StopIfXfreeSlotsNum = questset.StopIfXfreeSlotsNum;
            ChangeClassIfUReachLvlX = questset.changeClassIfUReachLvlX;
            ChangeClassLvl = questset.ChangeClassLvl;
        }

        public void setNonQuestDeck()
        {
            if (myDecks.Count == 0) return;

            afterQuests = true;
            allQuestsString.Clear();
            foreach (var tmp in myDecks)
            {
                if (ChangeClassIfUReachLvlX && classLvl[tmp.Value.heroClass] >= ChangeClassLvl) continue;
                chooseTheBestDeckByPriority(tmp.Value);
            }
            if (bestDeck == null)
            {
                if (ChangeClassIfUReachLvlX) botStopReason.Append("Level ").Append(ChangeClassLvl).Append(" is reached. ChangeClassIfUReachLvlX = true. ");
            }
            else
            {
                Triton.Game.Mapping.TAG_CLASS hClass = bestDeck.heroClass;
                int priority = classPriorityForQuests[hClass];
                allQuestsString.Append(". ").Append(hClass).Append(" priority ").Append(priority).Append(". AfterQuestsPlan = ").Append(afterQuestsPlan);
            }
        }

        private void chooseTheBestDeckByPriority(deck challenger)
        {
            if (bestDeck == null) bestDeck = challenger;
            else
            {
                int bestDeckPriority = 100;
                int challengerPriority = 100;
                if (topDeckNames.ContainsKey(bestDeck.DeckId)) bestDeckPriority = 0;
                if (topDeckNames.ContainsKey(challenger.DeckId)) challengerPriority = 0;
                if (challengerPriority < bestDeckPriority) bestDeck = challenger;
                else if (challengerPriority == bestDeckPriority)
                {
                    bestDeckPriority = 100;
                    challengerPriority = 100;
                    if (classPriorityForQuests.ContainsKey(bestDeck.heroClass)) bestDeckPriority = classPriorityForQuests[bestDeck.heroClass];
                    if (classPriorityForQuests.ContainsKey(challenger.heroClass)) challengerPriority = classPriorityForQuests[challenger.heroClass];
                    if (challengerPriority < bestDeckPriority) bestDeck = challenger;
                }
            }
        }

        /// <summary> Set the most suitable deck and return the worst quests ID. </summary>
        public void getTheBestWorstQuests(ref int theWorstQuestId)
        {
			theWorstQuestId = -1;
			setDBs();
            var quests = TritonHs.CurrentQuests;

            bestDeck = null;
            if (quests.Count == 0) return;
            int myDecksCount = myDecks.Count;
            if (myDecksCount == 0) return;
            
            if (QuestsPlan == questPlan.MaxGold)
            {
                //Looking for the bestDeck
                decimal averageCost = 0;
                foreach (deck myDeck in myDecks.Values)
                {
                    int numQuests = myDeck.allQuestsId.Count;
                    if (numQuests == 0) continue;
                    int sumGold = myDeck.sumGold;
                    decimal tmp = sumGold / numQuests;
                    if (tmp == 50 && numQuests == 2) tmp -= 1;
                    if (tmp == 40) tmp = tmp - numQuests + 1;
                    if (averageCost < tmp)
                    {
                        averageCost = tmp;
                        bestDeck = myDeck;
                    }
                    else if (averageCost == tmp)
                    {
                        if (useSuitableDeck)
                        {
                            if (myDeck.isBetterMaxGoldThen(bestDeck)) bestDeck = myDeck;
                        }
                        else chooseTheBestDeckByPriority(myDeck);
                    }
                }

                if (averageCost < profit)
                {
                    if (bestDeck == null)
                    {
                        int tmp = -1;
                        int tmpCost = 1000;
                        foreach (var quest in quests)
                        {
                            if (quest.Id == 214 || quest.Id == 342) continue; 
                            if (quest.Id == 222 && removeTavernBrawl) 
                            {
                                tmp = quest.Id;
                                tmpCost = 0;
                                break;
                            }
                            tmpCost = 1000;
                            if (tmp == -1)
                            {
                                tmp = quest.Id;
                                if (getQuestsGoldCost(quest) > 10) tmpCost = getQuestsGoldCost(quest); 
                            }
                            else
                            {
                                if (getQuestsGoldCost(quest) > 10 && getQuestsGoldCost(quest) < tmpCost)
                                {
                                    tmpCost = getQuestsGoldCost(quest);
                                    tmp = quest.Id;
                                }                                
                            }
                        }
                        if (tmp > 0 && tmpCost < 1000) theWorstQuestId = tmp;
                    }
                    else
                    {
                        if (bestDeck.Id40.Count > 0) theWorstQuestId = bestDeck.Id40.ElementAt(0).Key;
                        else if (bestDeck.Id50.Count > 0) theWorstQuestId = bestDeck.Id50.ElementAt(0).Key;
                    }
                    bestDeck = null;
                }
            }
            else if (QuestsPlan == questPlan.MaxQuests)
            {
                //Looking for the deck with the maximum number of quests
                foreach (deck myDeck in myDecks.Values)
                {
                    if (bestDeck == null)
                    {
                        bestDeck = myDeck;
                        continue;
                    }
                    if (bestDeck.allQuestsId.Count < myDeck.allQuestsId.Count)
                    {
                        bestDeck = myDeck;
                    }
                    else if (bestDeck.allQuestsId.Count == myDeck.allQuestsId.Count)
                    {
                        if (useSuitableDeck)
                        {
                            if (myDeck.allReqSum > bestDeck.allReqSum) bestDeck = myDeck;
                            else if (myDeck.allReqSum == bestDeck.allReqSum) chooseTheBestDeckByPriority(myDeck);
                        }
                        else chooseTheBestDeckByPriority(myDeck);
                    }
                }

                if (bestDeck != null && bestDeck.allQuestsId.Count < 3)
                {
                    int theWorstQuestCost = 0;

                    if (quests.Count == 1)
                    {
                        if (getQuestsGoldCost(quests[0]) < profit)
                        {
                            if (quests[0].Id == 222)
                            {
                                if (removeTavernBrawl) theWorstQuestId = quests[0].Id;
                            }
                            else if (!(quests[0].Id == 214 || quests[0].Id == 342)) theWorstQuestId = quests[0].Id;
                        }
                    }
                    else
                    {
                        foreach (var quest in quests)
                        {
                            if (bestDeck.allQuestsId.ContainsKey(quest.Id)) continue;
                            if (theWorstQuestId < 0)
                            {
                                if (quest.Id == 214 || quest.Id == 342) continue; 
                                if (quest.Id == 222 && removeTavernBrawl) 
                                {
                                    theWorstQuestId = quest.Id;
                                    break;
                                }
                                if (getQuestsGoldCost(quest) < profit)
                                {
                                    theWorstQuestId = quest.Id;
                                    theWorstQuestCost = getQuestsGoldCost(quest);
                                }
                            }
                            else
                            {
                                if (quest.Id == 214 || quest.Id == 342) continue; 
                                if (quest.Id == 222 && removeTavernBrawl) 
                                {
                                    theWorstQuestId = quest.Id;
                                    break;
                                }
                                if (theWorstQuestCost > getQuestsGoldCost(quest))
                                {
                                    theWorstQuestId = quest.Id;
                                    theWorstQuestCost = getQuestsGoldCost(quest);
                                }
                            }
                        }
                    }
                }
                if (bestDeck.allQuestsId.Count == 0) bestDeck = null;
            }
        }

        private int getQuestsGoldCost(AchievementData q)
        {
            foreach (var tmp in q.RewardData)
            {
                if (tmp.Type == Triton.Game.Mapping.Reward.Type.GOLD) return tmp.Count;
                else if (tmp.Type == Triton.Game.Mapping.Reward.Type.BOOSTER_PACK) return 100;
            }
            return 0;
        }
        
        private void setDBs()
        {
            //Fill DBs
            foreach (var baseDeck in questset.UsableDecks)
            {
                if (myDecks.ContainsKey(baseDeck.DeckId)) myDecks[baseDeck.DeckId].resetRewards();
                else myDecks.Add(baseDeck.DeckId, new deck(baseDeck));
            }
            
            foreach (var @class in TritonHs.BasicHeroTagClasses)
            {
                if (classLvl.ContainsKey(@class))
                {
                    if (classLvl[@class] > 0) continue;
                    else classLvl[@class] = GameUtils.GetHeroLevel(@class).CurrentLevel.Level;
                }
                else
                {
                    classLvl.Add(@class, GameUtils.GetHeroLevel(@class).CurrentLevel.Level);
                }
            }

            classPriorityForQuests = questset.classPriorityForQuests();
            topDeckNames.Clear();
            foreach (var td in questset.topDeckNames())
            {
                bool found = false;
                foreach (var d in myDecks)
                {
                    if (d.Value.Name == td.Value && d.Value.heroClass == td.Key)
                    {
                        topDeckNames.Add(d.Key, d.Value.heroClass);
                        found = true;
                        break;
                    }
                }
                if (!found)
                {
                    Log.ErrorFormat("[QuestPlus] You don't have the deck name '{0}' for the class '{1}'. Please correct this DeckName or re-Cache Custom Decks.", td.Value, td.Key);
                }
            }

            allQuestsString.Clear();
            var quests = TritonHs.CurrentQuests;
            for (int i = 0; i < quests.Count; i++)
            {
                var quest = quests[i];
                questInfo qi = new questInfo(quest, getGolgRewards(quest));
                allQuestsString.Append(quest.Name);
                if (i < quests.Count - 1) allQuestsString.Append(", ");
                                
                // Loop through foreach each deck.                
                foreach (var mDeck in myDecks)
                {
                    long mDeckId = mDeck.Key;
                    int availability = -1;
                    switch (quest.Id)
                    {
                        case 50: 
                            availability = 15;
                            break;
                        case 51: 
                            if (mDeck.Value.m5 >= min_m5) availability = mDeck.Value.m5;
                            break;
                        case 52: 
                            if (mDeck.Value.m2 >= min_m2) availability = mDeck.Value.m2;
                            break;
                        case 53: 
                            if (mDeck.Value.spells >= min_spells) availability = mDeck.Value.spells;
                            break;
                        case 54: 
                            availability = 30;
                            break;
                        case 64: 
                            availability = 1;
                            break;
                        case 69: 
                            availability = 1;
                            break;
                        case 588: 
                            if (mDeck.Value.c8 >= min_c8) availability = mDeck.Value.c8;
                            break;
                        case 589: goto case 598; 
                        case 590: goto case 599; 
                        case 591: goto case 600; 
                        case 592: goto case 601; 
                        case 593: goto case 602; 
                        case 594: goto case 603; 
                        case 595: goto case 604; 
                        case 596: goto case 605; 
                        case 597: goto case 606; 
                        case 598: 
                            if (mDeck.Value.heroClass != Triton.Game.Mapping.TAG_CLASS.DRUID) continue;
                            if (mDeck.Value.classCards >= min_classCards) availability = mDeck.Value.classCards;
                            break;
                        case 599: 
                            if (mDeck.Value.heroClass != Triton.Game.Mapping.TAG_CLASS.HUNTER) continue;
                            if (mDeck.Value.classCards >= min_classCards) availability = mDeck.Value.classCards;
                            break;
                        case 600: 
                            if (mDeck.Value.heroClass != Triton.Game.Mapping.TAG_CLASS.MAGE) continue;
                            if (mDeck.Value.classCards >= min_classCards) availability = mDeck.Value.classCards;
                            break;
                        case 601: 
                            if (mDeck.Value.heroClass != Triton.Game.Mapping.TAG_CLASS.PALADIN) continue;
                            if (mDeck.Value.classCards >= min_classCards) availability = mDeck.Value.classCards;
                            break;
                        case 602: 
                            if (mDeck.Value.heroClass != Triton.Game.Mapping.TAG_CLASS.PRIEST) continue;
                            if (mDeck.Value.classCards >= min_classCards) availability = mDeck.Value.classCards;
                            break;
                        case 603: 
                            if (mDeck.Value.heroClass != Triton.Game.Mapping.TAG_CLASS.ROGUE) continue;
                            if (mDeck.Value.classCards >= min_classCards) availability = mDeck.Value.classCards;
                            break;
                        case 604: 
                            if (mDeck.Value.heroClass != Triton.Game.Mapping.TAG_CLASS.SHAMAN) continue;
                            if (mDeck.Value.classCards >= min_classCards) availability = mDeck.Value.classCards;
                            break;
                        case 605: 
                            if (mDeck.Value.heroClass != Triton.Game.Mapping.TAG_CLASS.WARLOCK) continue;
                            if (mDeck.Value.classCards >= min_classCards) availability = mDeck.Value.classCards;
                            break;
                        case 606: 
                            if (mDeck.Value.heroClass != Triton.Game.Mapping.TAG_CLASS.WARRIOR) continue;
                            if (mDeck.Value.classCards >= min_classCards) availability = mDeck.Value.classCards;
                            break;
                        case 607: 
                            if (mDeck.Value.beasts >= min_beasts) availability = mDeck.Value.beasts;
                            break;
		                case 761: //-Play 10 Elementals.
		                    if (mDeck.Value.elems >= min_elems) availability = mDeck.Value.elems;
		                    break;
                        case 608: 
                            if (mDeck.Value.demons >= min_demons) availability = mDeck.Value.demons;
                            break;
                        case 609: goto case 610; 
                        case 610: 
                            if (mDeck.Value.murlocs >= min_murlocs) availability = mDeck.Value.murlocs;
                            break;
                        case 611: 
                            if (mDeck.Value.pirates >= min_pirates) availability = mDeck.Value.pirates;
                            break;
                        case 612: goto case 613; 
                        case 613: 
                            if (mDeck.Value.bc >= min_bc) availability = mDeck.Value.bc;
                            break;
                        case 614: 
                            if (mDeck.Value.dr >= min_dr) availability = mDeck.Value.dr;
                            break;
                        case 615: 
                            if (mDeck.Value.shield >= min_shield) availability = mDeck.Value.shield;
                            break;
                        case 616: 
                            if (mDeck.Value.enrage >= min_enrage) availability = mDeck.Value.enrage;
                            break;
                        case 617: 
                            if (mDeck.Value.taunts >= min_taunts) availability = mDeck.Value.taunts;
                            break;
                        case 618: 
                            if (mDeck.Value.overload >= min_overload) availability = mDeck.Value.overload;
                            break;
                        case 619: 
                            if (mDeck.Value.combos >= min_combos) availability = mDeck.Value.combos;
                            break;
                        case 620: 
                            if (mDeck.Value.secrets >= min_secrets) availability = mDeck.Value.secrets;
                            break;
                        case 621: 
                            if (mDeck.Value.weapons >= min_weapons) availability = mDeck.Value.weapons;
                            break;
                        case 622: 
                            availability = 5;
                            break;
                        case 640: 
                            switch(mDeck.Value.heroClass)
                            {
                                case Triton.Game.Mapping.TAG_CLASS.HUNTER: goto case Triton.Game.Mapping.TAG_CLASS.WARRIOR;
                                case Triton.Game.Mapping.TAG_CLASS.PALADIN: goto case Triton.Game.Mapping.TAG_CLASS.WARRIOR;
                                case Triton.Game.Mapping.TAG_CLASS.WARRIOR:
                                    availability = 1;
                                    break;
                            }
                            break;
                        case 644: 
                            switch (mDeck.Value.heroClass)
                            {
                                case Triton.Game.Mapping.TAG_CLASS.DRUID: goto case Triton.Game.Mapping.TAG_CLASS.SHAMAN;
                                case Triton.Game.Mapping.TAG_CLASS.ROGUE: goto case Triton.Game.Mapping.TAG_CLASS.SHAMAN;
                                case Triton.Game.Mapping.TAG_CLASS.SHAMAN:
                                    availability = 1;
                                    break;
                            }
                            break;
                        case 646: 
                            switch (mDeck.Value.heroClass)
                            {
                                case Triton.Game.Mapping.TAG_CLASS.MAGE: goto case Triton.Game.Mapping.TAG_CLASS.WARLOCK;
                                case Triton.Game.Mapping.TAG_CLASS.PRIEST: goto case Triton.Game.Mapping.TAG_CLASS.WARLOCK;
                                case Triton.Game.Mapping.TAG_CLASS.WARLOCK:
                                    availability = 1;
                                    break;
                            }
                            break;
                        case 643: goto case 645; 
                        case 645: 
                            botset.NeedsToCacheQuests = true;
                            break;
                        default:                                
                            // If this is a class specific quest, find a suitable deck.
                            if (TritonHs.IsQuestForSpecificClass(quest.Id))
                            {
                                Triton.Game.Mapping.TAG_CLASS @class = mDeck.Value.heroClass;
                                // If this quest is a win quest for this class.
                                if (TritonHs.IsQuestForClass(quest.Id, @class))
                                {
                                    foreach (var tmp in quest.RewardData)
                                    {
                                        if (tmp.Type == Triton.Game.Mapping.Reward.Type.GOLD)
                                        {
                                            availability = 1;
                                            break;
                                        }
                                    }
                                }
                            }
                            break;
                    }
                    
                    if (availability > -1) mDeck.Value.addRewards(qi, availability);
                }
            }
        }

        public int getGolgRewards(AchievementData quest)
        {
            int goldReward = 0;
            foreach (var tmp in quest.RewardData)
            {
                if (tmp.Type == Triton.Game.Mapping.Reward.Type.GOLD)
                {
                    goldReward += tmp.Count;
                }
                else if (tmp.Type == Triton.Game.Mapping.Reward.Type.BOOSTER_PACK)
                {
                    goldReward += 100;
                }
            }
            return goldReward;
        }

        private void GameEventManagerOnQuestUpdate(object sender, QuestUpdateEventArgs questUpdateEventArgs)
        {
            _findNewQuest = true;
        }

        private void GameEventManagerOnGameOver(object sender, GameOverEventArgs gameOverEventArgs)
        {
            // Find the next quest to do ater a game over, regardless of the outcome.
            _findNewQuest = true;
            if (questset.changeClassIfUReachLvlX)
            {
                var hClass = TritonHs.OurHero.Class;
                int hClassLvl = GameUtils.GetHeroLevel(hClass).CurrentLevel.Level;
                if (classLvl.ContainsKey(hClass)) classLvl[hClass] = hClassLvl;
                else classLvl.Add(hClass, hClassLvl);
            }
        }
    }
}