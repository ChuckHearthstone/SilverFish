using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using log4net;
using Newtonsoft.Json;
using Triton.Bot;
using Triton.Bot.Settings;
using Triton.Common;
using Triton.Game;
using Triton.Game.Mapping;
using Logger = Triton.Common.LogUtilities.Logger;
using System.Collections.ObjectModel;


using System;

namespace QuestPlus
{
	/// <summary>Settings for the Quest plugin. </summary>
	public class QuestPlusSettings : JsonSettings
	{
		private static readonly ILog Log = Logger.GetLoggerInstanceForType();

		private static QuestPlusSettings _instance;

		/// <summary>The current instance for this class. </summary>
		public static QuestPlusSettings Instance
		{
			get
			{
                if (_instance == null)
                {
                    _instance = new QuestPlusSettings();
                    _instance.setDesc();
                }
				return _instance;
			}
		}

		/// <summary>The default ctor. Will use the settings path "Quest".</summary>
		public QuestPlusSettings()
			: base(GetSettingsFilePath(Configuration.Instance.Name, string.Format("{0}.json", "QuestPlus")))
		{
		}

		/// <summary>
		/// Returns a list of non-ignored custom decks.
		/// </summary>
		[JsonIgnore]
		public List<CustomDeckCache> UsableDecks
		{
			get
			{
				var decks = new List<CustomDeckCache>();
				foreach (var deck in MainSettings.Instance.CustomDecks)
				{
					//if (!IgnoredDecks.Contains(deck.Name))
					{
                        switch (deck.HeroCardId)
                        {
                            case "HERO_05a": deck.HeroCardId = "HERO_05"; break;
                            case "HERO_04a": deck.HeroCardId = "HERO_04"; break;
                            case "HERO_01a": deck.HeroCardId = "HERO_01"; break;
                            case "HERO_02a": deck.HeroCardId = "HERO_02"; break;
                            case "HERO_03a": deck.HeroCardId = "HERO_03"; break;
                            case "HERO_08a": deck.HeroCardId = "HERO_08"; break;
                            case "HERO_08b": deck.HeroCardId = "HERO_08"; break;
                            case "HERO_09a": deck.HeroCardId = "HERO_09"; break;
                        }
                        decks.Add(deck);
					}
				}
				return decks;
			}
		}
        
        private int _priority1;
        private int _priority2;
        private int _priority3;
        private int _priority4;
        private int _priority5;
        private int _priority6;
        private int _priority7;
        private int _priority8;
        private int _priority9;
        private TAG_CLASS _HeroClass1 = TAG_CLASS.DRUID;
        private TAG_CLASS _HeroClass2 = TAG_CLASS.HUNTER;
        private TAG_CLASS _HeroClass3 = TAG_CLASS.MAGE;
        private TAG_CLASS _HeroClass4 = TAG_CLASS.PALADIN;
        private TAG_CLASS _HeroClass5 = TAG_CLASS.PRIEST;
        private TAG_CLASS _HeroClass6 = TAG_CLASS.ROGUE;
        private TAG_CLASS _HeroClass7 = TAG_CLASS.SHAMAN;
        private TAG_CLASS _HeroClass8 = TAG_CLASS.WARLOCK;
        private TAG_CLASS _HeroClass9 = TAG_CLASS.WARRIOR;
        private string _topDeck1;
        private string _topDeck2;
        private string _topDeck3;
        private string _topDeck4;
        private string _topDeck5;
        private string _topDeck6;
        private string _topDeck7;
        private string _topDeck8;
        private string _topDeck9;

        private ConstructedMode _QuestPlayMode;
        private ConstructedMode _afterQuestPlayMode;
        private QuestPlus.questPlan _QuestsPlan;
        private QuestPlus.playPlanAfterQuestsAreDone _afterQuestsPlan;
        private GameMode _afterQuestGameMode;
        private bool _useSuitableDeck;
        private bool _removeTheWorstQuest;
        private bool _removeTavernBrawl;
        private bool _rankedModeForQuests;
        private bool _stopIfXfreeSlots;
        private int _stopIfXfreeSlotsNum;
        private bool _changeClassIfUReachLvlX;
        private int _changeClassLvl;
        private bool _keepRank;
        private int _keepRankLvl;

        /// <summary>
        /// HeroClass for the quests.
        /// </summary>
        [DefaultValue(TAG_CLASS.DRUID)]
        public TAG_CLASS HeroClass1
        {
            get { return _HeroClass1; }
            set
            {
                if (!value.Equals(_HeroClass1))
                {
                    _HeroClass1 = value;
                    NotifyPropertyChanged(() => HeroClass1);
                }
            }
        }
        [DefaultValue(TAG_CLASS.HUNTER)]
        public TAG_CLASS HeroClass2
        {
            get { return _HeroClass2; }
            set
            {
                if (!value.Equals(_HeroClass2))
                {
                    _HeroClass2 = value;
                    NotifyPropertyChanged(() => HeroClass2);
                }
            }
        }
        [DefaultValue(TAG_CLASS.MAGE)]
        public TAG_CLASS HeroClass3
        {
            get { return _HeroClass3; }
            set
            {
                if (!value.Equals(_HeroClass3))
                {
                    _HeroClass3 = value;
                    NotifyPropertyChanged(() => HeroClass3);
                }
            }
        }
        [DefaultValue(TAG_CLASS.PALADIN)]
        public TAG_CLASS HeroClass4
        {
            get { return _HeroClass4; }
            set
            {
                if (!value.Equals(_HeroClass4))
                {
                    _HeroClass4 = value;
                    NotifyPropertyChanged(() => HeroClass4);
                }
            }
        }
        [DefaultValue(TAG_CLASS.PRIEST)]
        public TAG_CLASS HeroClass5
        {
            get { return _HeroClass5; }
            set
            {
                if (!value.Equals(_HeroClass5))
                {
                    _HeroClass5 = value;
                    NotifyPropertyChanged(() => HeroClass5);
                }
            }
        }
        [DefaultValue(TAG_CLASS.ROGUE)]
        public TAG_CLASS HeroClass6
        {
            get { return _HeroClass6; }
            set
            {
                if (!value.Equals(_HeroClass6))
                {
                    _HeroClass6 = value;
                    NotifyPropertyChanged(() => HeroClass6);
                }
            }
        }
        [DefaultValue(TAG_CLASS.SHAMAN)]
        public TAG_CLASS HeroClass7
        {
            get { return _HeroClass7; }
            set
            {
                if (!value.Equals(_HeroClass7))
                {
                    _HeroClass7 = value;
                    NotifyPropertyChanged(() => HeroClass7);
                }
            }
        }
        [DefaultValue(TAG_CLASS.WARLOCK)]
        public TAG_CLASS HeroClass8
        {
            get { return _HeroClass8; }
            set
            {
                if (!value.Equals(_HeroClass8))
                {
                    _HeroClass8 = value;
                    NotifyPropertyChanged(() => HeroClass8);
                }
            }
        }
        [DefaultValue(TAG_CLASS.WARRIOR)]
        public TAG_CLASS HeroClass9
        {
            get { return _HeroClass9; }
            set
            {
                if (!value.Equals(_HeroClass9))
                {
                    _HeroClass9 = value;
                    NotifyPropertyChanged(() => HeroClass9);
                }
            }
        }

        /// <summary>
        /// The value of the priority for the quests.
        /// </summary>
        [DefaultValue(1)]
        public int Priority1
        {
            get { return _priority1; }
            set
            {
                if (!value.Equals(_priority1))
                {
                    _priority1 = value;
                    NotifyPropertyChanged(() => Priority1);
                }
            }
        }
        [DefaultValue(2)]
        public int Priority2
        {
            get { return _priority2; }
            set
            {
                if (!value.Equals(_priority2))
                {
                    _priority2 = value;
                    NotifyPropertyChanged(() => Priority2);
                }
            }
        }
        [DefaultValue(3)]
        public int Priority3
        {
            get { return _priority3; }
            set
            {
                if (!value.Equals(_priority3))
                {
                    _priority3 = value;
                    NotifyPropertyChanged(() => Priority3);
                }
            }
        }
        [DefaultValue(4)]
        public int Priority4
        {
            get { return _priority4; }
            set
            {
                if (!value.Equals(_priority4))
                {
                    _priority4 = value;
                    NotifyPropertyChanged(() => Priority4);
                }
            }
        }
        [DefaultValue(5)]
        public int Priority5
        {
            get { return _priority5; }
            set
            {
                if (!value.Equals(_priority5))
                {
                    _priority5 = value;
                    NotifyPropertyChanged(() => Priority5);
                }
            }
        }
        [DefaultValue(6)]
        public int Priority6
        {
            get { return _priority6; }
            set
            {
                if (!value.Equals(_priority6))
                {
                    _priority6 = value;
                    NotifyPropertyChanged(() => Priority6);
                }
            }
        }
        [DefaultValue(7)]
        public int Priority7
        {
            get { return _priority7; }
            set
            {
                if (!value.Equals(_priority7))
                {
                    _priority7 = value;
                    NotifyPropertyChanged(() => Priority7);
                }
            }
        }
        [DefaultValue(8)]
        public int Priority8
        {
            get { return _priority8; }
            set
            {
                if (!value.Equals(_priority8))
                {
                    _priority8 = value;
                    NotifyPropertyChanged(() => Priority8);
                }
            }
        }
        [DefaultValue(9)]
        public int Priority9
        {
            get { return _priority9; }
            set
            {
                if (!value.Equals(_priority9))
                {
                    _priority9 = value;
                    NotifyPropertyChanged(() => Priority9);
                }
            }
        }
        
        /// <summary>
        /// The name of the best deck for the class.
        /// </summary>
        [DefaultValue("")]
        public string TopDeck1
        {
            get { return _topDeck1; }
            set
            {
                if (!value.Equals(_topDeck1))
                {
                    _topDeck1 = value;
                    NotifyPropertyChanged(() => TopDeck1);
                }
            }
        }
        [DefaultValue("")]
        public string TopDeck2
        {
            get { return _topDeck2; }
            set
            {
                if (!value.Equals(_topDeck2))
                {
                    _topDeck2 = value;
                    NotifyPropertyChanged(() => TopDeck2);
                }
            }
        }
        [DefaultValue("")]
        public string TopDeck3
        {
            get { return _topDeck3; }
            set
            {
                if (!value.Equals(_topDeck3))
                {
                    _topDeck3 = value;
                    NotifyPropertyChanged(() => TopDeck3);
                }
            }
        }
        [DefaultValue("")]
        public string TopDeck4
        {
            get { return _topDeck4; }
            set
            {
                if (!value.Equals(_topDeck4))
                {
                    _topDeck4 = value;
                    NotifyPropertyChanged(() => TopDeck4);
                }
            }
        }
        [DefaultValue("")]
        public string TopDeck5
        {
            get { return _topDeck5; }
            set
            {
                if (!value.Equals(_topDeck5))
                {
                    _topDeck5 = value;
                    NotifyPropertyChanged(() => TopDeck5);
                }
            }
        }
        [DefaultValue("")]
        public string TopDeck6
        {
            get { return _topDeck6; }
            set
            {
                if (!value.Equals(_topDeck6))
                {
                    _topDeck6 = value;
                    NotifyPropertyChanged(() => TopDeck6);
                }
            }
        }
        [DefaultValue("")]
        public string TopDeck7
        {
            get { return _topDeck7; }
            set
            {
                if (!value.Equals(_topDeck7))
                {
                    _topDeck7 = value;
                    NotifyPropertyChanged(() => TopDeck7);
                }
            }
        }
        [DefaultValue("")]
        public string TopDeck8
        {
            get { return _topDeck8; }
            set
            {
                if (!value.Equals(_topDeck8))
                {
                    _topDeck8 = value;
                    NotifyPropertyChanged(() => TopDeck8);
                }
            }
        }
        [DefaultValue("")]
        public string TopDeck9
        {
            get { return _topDeck9; }
            set
            {
                if (!value.Equals(_topDeck9))
                {
                    _topDeck9 = value;
                    NotifyPropertyChanged(() => TopDeck9);
                }
            }
        }
        

        /// <summary>
        /// Returns a Dictionary<TAG_CLASS, Priority>.
        /// </summary>
        [JsonIgnore]
        private Dictionary<TAG_CLASS, int> _classPriorityForQuests = new Dictionary<TAG_CLASS, int>();

        public Dictionary<TAG_CLASS, int> classPriorityForQuests()
        {
            _classPriorityForQuests.Clear();
            _classPriorityForQuests.Add(_HeroClass1, Priority1);
            _classPriorityForQuests.Add(_HeroClass2, Priority2);
            _classPriorityForQuests.Add(_HeroClass3, Priority3);
            _classPriorityForQuests.Add(_HeroClass4, Priority4);
            _classPriorityForQuests.Add(_HeroClass5, Priority5);
            _classPriorityForQuests.Add(_HeroClass6, Priority6);
            _classPriorityForQuests.Add(_HeroClass7, Priority7);
            _classPriorityForQuests.Add(_HeroClass8, Priority8);
            _classPriorityForQuests.Add(_HeroClass9, Priority9);
            return _classPriorityForQuests;
            
        }

        /// <summary>
        /// Returns a Dictionary<TAG_CLASS, TopDeckName>.
        /// </summary>
        [JsonIgnore]
        private Dictionary<TAG_CLASS, string> _topDeckNames = new Dictionary<TAG_CLASS, string>();

        public Dictionary<TAG_CLASS, string> topDeckNames()
        {
            _topDeckNames.Clear();
            if (!string.IsNullOrEmpty(TopDeck1)) _topDeckNames.Add(_HeroClass1, TopDeck1);
            if (!string.IsNullOrEmpty(TopDeck2)) _topDeckNames.Add(_HeroClass2, TopDeck2);
            if (!string.IsNullOrEmpty(TopDeck3)) _topDeckNames.Add(_HeroClass3, TopDeck3);
            if (!string.IsNullOrEmpty(TopDeck4)) _topDeckNames.Add(_HeroClass4, TopDeck4);
            if (!string.IsNullOrEmpty(TopDeck5)) _topDeckNames.Add(_HeroClass5, TopDeck5);
            if (!string.IsNullOrEmpty(TopDeck6)) _topDeckNames.Add(_HeroClass6, TopDeck6);
            if (!string.IsNullOrEmpty(TopDeck7)) _topDeckNames.Add(_HeroClass7, TopDeck7);
            if (!string.IsNullOrEmpty(TopDeck8)) _topDeckNames.Add(_HeroClass8, TopDeck8);
            if (!string.IsNullOrEmpty(TopDeck9)) _topDeckNames.Add(_HeroClass9, TopDeck9);
            return _topDeckNames;
        }
        

        /// All enum values for this type.
        private ObservableCollection<ConstructedMode> _allConstructedModes;
		[JsonIgnore]
        public ObservableCollection<ConstructedMode> AllConstructedModes
        {            
            get { return _allConstructedModes ?? (_allConstructedModes = new ObservableCollection<ConstructedMode>
			        {
				        ConstructedMode.Casual,
				        ConstructedMode.Ranked
                    });
                }
        }
        
        /// <summary>
        /// The constructed game mode (PlayMode) to use for Quests.
        /// </summary>
        [DefaultValue(ConstructedMode.Casual)]
        public ConstructedMode QuestPlayMode
        {
            get
            {
                return _QuestPlayMode;
            }
            set
            {
                if (!value.Equals(_QuestPlayMode))
                {
                    _QuestPlayMode = value;
                    NotifyPropertyChanged(() => QuestPlayMode);
                }
                Log.InfoFormat("[QuestPlusSettings] QuestPlayMode = {0}.", _QuestPlayMode);
            }
        }

        /// <summary>
        /// The constructed game mode (PlayMode) after all available quests are done.
        /// </summary>
        [DefaultValue(ConstructedMode.Casual)]
        public ConstructedMode AfterQuestPlayMode
        {
            get
            {
                return _afterQuestPlayMode;
            }
            set
            {
                if (!value.Equals(_afterQuestPlayMode))
                {
                    _afterQuestPlayMode = value;
                    NotifyPropertyChanged(() => AfterQuestPlayMode);
                }
                Log.InfoFormat("[QuestPlusSettings] AfterQuestPlayMode = {0}.", _afterQuestPlayMode);
            }
        }

        /// <summary>
        /// Game mode after all available quests are done.
        /// </summary>
        [DefaultValue(GameMode.Constructed)]
        public GameMode AfterQuestGameMode
        {
            get
            {
                return _afterQuestGameMode;
            }
            set
            {
                if (!value.Equals(_afterQuestGameMode))
                {
                    _afterQuestGameMode = value;
                    NotifyPropertyChanged(() => AfterQuestPlayMode);
                }
                Log.InfoFormat("[QuestPlusSettings] AfterQuestGameMode = {0}.", _afterQuestGameMode);
            }
        }
        /// All enum values for this type.
        private ObservableCollection<GameMode> _allGameModes;
        [JsonIgnore]
        public ObservableCollection<GameMode> AllGameModes
        {
            get { return _allGameModes ?? (_allGameModes = new ObservableCollection<GameMode>
			        {
				        GameMode.Arena,
				        GameMode.Constructed,
				        GameMode.Friendly,
				        GameMode.Practice,
                        GameMode.TavernBrawl,
                    });
                }
        }

        /// <summary>
        /// The plan (rules) for the game during quests.
        /// </summary>
        [DefaultValue(QuestPlus.questPlan.MaxQuests)]
        public QuestPlus.questPlan QuestsPlan
        {
            get
            {
                return _QuestsPlan;
            }
            set
            {
                if (!value.Equals(_QuestsPlan))
                {
                    _QuestsPlan = value;
                    NotifyPropertyChanged(() => QuestsPlan);
                    setDesc();
                }
                Log.InfoFormat("[QuestPlusSettings] QuestsPlan = {0}.", _QuestsPlan);
            }
        }
        /// All enum values for this type.
        private ObservableCollection<QuestPlus.questPlan> _allQuestsPlans;
        [JsonIgnore]
        public ObservableCollection<QuestPlus.questPlan> AllQuestsPlans
        {
            get { return _allQuestsPlans ?? (_allQuestsPlans = new ObservableCollection<QuestPlus.questPlan>
			        {
				        QuestPlus.questPlan.MaxGold,
				        QuestPlus.questPlan.MaxQuests
                    });
                }
        }

        /// <summary>
        /// The plan (rules) for game after all available quests are done
        /// </summary>
        [DefaultValue(QuestPlus.playPlanAfterQuestsAreDone.Play)]
        public QuestPlus.playPlanAfterQuestsAreDone AfterQuestsPlan
        {
            get
            {
                return _afterQuestsPlan;
            }
            set
            {
                if (!value.Equals(_afterQuestsPlan))
                {
                    _afterQuestsPlan = value;
                    NotifyPropertyChanged(() => AfterQuestsPlan);
                }
                Log.InfoFormat("[QuestPlusSettings] AfterQuestsPlan = {0}.", _afterQuestsPlan);
            }
        }
        /// All enum values for this type.
        private ObservableCollection<QuestPlus.playPlanAfterQuestsAreDone> _allAfterQuestsPlans;
        [JsonIgnore]
        public ObservableCollection<QuestPlus.playPlanAfterQuestsAreDone> AllAfterQuestsPlans
        {
            get { return _allAfterQuestsPlans ?? (_allAfterQuestsPlans = new ObservableCollection<QuestPlus.playPlanAfterQuestsAreDone>
			        {
				        QuestPlus.playPlanAfterQuestsAreDone.Stop,
				        QuestPlus.playPlanAfterQuestsAreDone.Play,
				        QuestPlus.playPlanAfterQuestsAreDone.PlayAvoidingCheapQuests
                    });
                }
        }
                
        /// <summary>
        /// Automatically selects the most suitable deck ignoring all priorities
        /// </summary>
        [DefaultValue(true)]
        public bool useSuitableDeck
        {
            get
            {
                return _useSuitableDeck;
            }
            set
            {
                if (!value.Equals(_useSuitableDeck))
                {
                    _useSuitableDeck = value;
                    NotifyPropertyChanged(() => useSuitableDeck);
                }
                Log.InfoFormat("[QuestPlusSettings] useSuitableDeck = {0}.", _useSuitableDeck);
            }
        }
            
        /// <summary>
        /// Should the plugin to remove 40Gold quests?
        /// </summary>
        [DefaultValue(true)]
        public bool removeTheWorstQuest
        {
            get
            {
                return _removeTheWorstQuest;
            }
            set
            {
                if (!value.Equals(_removeTheWorstQuest))
                {
                    _removeTheWorstQuest = value;
                    NotifyPropertyChanged(() => removeTheWorstQuest);
                }
                Log.InfoFormat("[QuestPlusSettings] removeTheWorstQuest = {0}.", _removeTheWorstQuest);
            }
        }
            
        /// <summary>
        /// Should the plugin to remove Tavern Brawls quest?
        /// </summary>
        [DefaultValue(false)]
        public bool removeTavernBrawl
        {
            get
            {
                return _removeTavernBrawl;
            }
            set
            {
                if (!value.Equals(removeTavernBrawl))
                {
                    _removeTavernBrawl = value;
                    NotifyPropertyChanged(() => removeTavernBrawl);
                }
                Log.InfoFormat("[QuestPlusSettings] removeTavernBrawl = {0}.", _removeTavernBrawl);
            }
        }


        /// <summary>
        /// The description for the selected QuestsPlan
        /// </summary>
        private string _QuestsPlanDesc;
        [JsonIgnore]
        [DefaultValue("")]
        public string QuestsPlanDesc
        {
            get { return _QuestsPlanDesc; }
            set
            {
                if (!value.Equals(_QuestsPlanDesc))
                {
                    _QuestsPlanDesc = value;
                    NotifyPropertyChanged(() => QuestsPlanDesc);
                }
            }
        }
        
            
        /// <summary>
        /// Should be forced to use Ranked mode for quests?
        /// </summary>
        [DefaultValue(true)]
        public bool rankedModeForQuests
        {
            get { return _rankedModeForQuests; }
            set
            {
                if (!value.Equals(_rankedModeForQuests))
                {
                    _rankedModeForQuests = value;
                    NotifyPropertyChanged(() => rankedModeForQuests);
                }
                Log.InfoFormat("[QuestPlusSettings] rankedModeForQuests = {0}.", _rankedModeForQuests);
            }
        }

        /// <summary>
        /// Should the plugin stop the bot if there is X free place for new quests?
        /// </summary>
        [DefaultValue(false)]
        public bool stopIfXfreeSlots
        {
            get { return _stopIfXfreeSlots; }
            set
            {
                if (!value.Equals(_stopIfXfreeSlots))
                {
                    _stopIfXfreeSlots = value;
                    NotifyPropertyChanged(() => stopIfXfreeSlots);
                }
                Log.InfoFormat("[QuestPlusSettings] stopIfXfreeSlots = {0}.", _stopIfXfreeSlots);
            }
        }
        [DefaultValue(60)]
        public int StopIfXfreeSlotsNum
        {
            get { return _stopIfXfreeSlotsNum; }
            set
            {
                if (!value.Equals(_stopIfXfreeSlotsNum))
                {
                    _stopIfXfreeSlotsNum = value;
                    NotifyPropertyChanged(() => StopIfXfreeSlotsNum);
                }
                Log.InfoFormat("[QuestPlusSettings] StopIfXfreeSlotsNum = {0}.", _stopIfXfreeSlotsNum);
            }
        }
        /// All enum values for this type.
        private ObservableCollection<int> _allFreeSlots;
        [JsonIgnore]
        public ObservableCollection<int> AllFreeSlots
        {
            get
            {
                return _allFreeSlots ?? (_allFreeSlots = new ObservableCollection<int> { 1, 2 });
            }
        }
        

        /// <summary>
        /// Change Class if you reach level X.
        /// </summary>
        [DefaultValue(false)]
        public bool changeClassIfUReachLvlX
        {
            get { return _changeClassIfUReachLvlX; }
            set
            {
                if (!value.Equals(_changeClassIfUReachLvlX))
                {
                    _changeClassIfUReachLvlX = value;
                    NotifyPropertyChanged(() => changeClassIfUReachLvlX);
                }
                Log.InfoFormat("[QuestPlusSettings] changeClassIfUGotLvlX = {0}.", _changeClassIfUReachLvlX);
            }
        }
        [DefaultValue(60)]
        public int ChangeClassLvl
        {
            get  { return _changeClassLvl; }
            set
            {
                if (!value.Equals(_changeClassLvl))
                {
                    _changeClassLvl = value;
                    NotifyPropertyChanged(() => ChangeClassLvl);
                }
                Log.InfoFormat("[QuestPlusSettings] ChangeClassLvl = {0}.", _changeClassLvl);
            }
        }
        /// All enum values for this type.
        private ObservableCollection<int> _allLvlsForChangeClass;
        [JsonIgnore]
        public ObservableCollection<int> AllLvlsForChangeClass
        {
            get
            {
                return _allLvlsForChangeClass ?? (_allLvlsForChangeClass = new ObservableCollection<int> { 10, 20, 30, 40, 50, 60 });
            }
        }


        /// <summary>
        /// Keep Rank
        /// </summary>
        [DefaultValue(false)]
        public bool KeepRank
        {
            get { return _keepRank; }
            set
            {
                if (!value.Equals(_keepRank))
                {
                    _keepRank = value;
                    NotifyPropertyChanged(() => KeepRank);
                }
                Log.InfoFormat("[QuestPlusSettings] KeepRank = {0}.", _keepRank);
            }
        }
        [DefaultValue(60)]
        public int KeepRankLvl
        {
            get { return _keepRankLvl; }
            set
            {
                if (!value.Equals(_keepRankLvl))
                {
                    _keepRankLvl = value;
                    NotifyPropertyChanged(() => KeepRankLvl);
                }
                Log.InfoFormat("[QuestPlusSettings] KeepRankLvl = {0}.", _keepRankLvl);
            }
        }
        /// All enum values for this type.
        private ObservableCollection<int> _allLvlsForKeepRank;
        [JsonIgnore]
        public ObservableCollection<int> AllLvlsForKeepRank
        {
            get
            {
                return _allLvlsForKeepRank ?? (_allLvlsForKeepRank = new ObservableCollection<int> { 20, 19, 18, 17, 16, 15, 14, 13, 12, 11, 10, 9, 8, 7, 6, 5, 4, 3, 2, 1 });
            }
        }


        private void setDesc()
        {
            if (_QuestsPlan == QuestPlus.questPlan.MaxGold) QuestsPlanDesc = "Bot does only the most expensive quests, and removes cheap ones (removal only works in the new bot design)";
            else if (_QuestsPlan == QuestPlus.questPlan.MaxQuests) QuestsPlanDesc = "The bot picks up quests in such a way that would one hero does as many quests as possible.";
            NotifyPropertyChanged(() => QuestsPlanDesc);
        }
	}
}