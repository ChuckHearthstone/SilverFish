using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using log4net;
using Newtonsoft.Json;
using Triton.Bot.Settings;
using Triton.Common;
using Triton.Game;
using Triton.Game.Mapping;
using Logger = Triton.Common.LogUtilities.Logger;

namespace AutoStop
{
    /// <summary>Settings for the Stats plugin. </summary>
    public class AutoStopSettings : JsonSettings
    {
        private static readonly ILog Log = Logger.GetLoggerInstanceForType();

        private static AutoStopSettings _instance;

        /// <summary>The current instance for this class. </summary>
        public static AutoStopSettings Instance
        {
            get { return _instance ?? (_instance = new AutoStopSettings()); }
        }

        /// <summary>The default ctor. Will use the settings path "Stats".</summary>
        public AutoStopSettings()
            : base(GetSettingsFilePath(Configuration.Instance.Name, string.Format("{0}.json", "AutoStop")))
        {
        }

        private bool _stopAfterXGames;
        private bool _stopAfterXWins;
        private bool _stopAfterXLosses;
        private bool _stopAfterXConcedes;

        private int _stopGameCount;
        private int _stopWinCount;
        private int _stopLossCount;
        private int _stopConcedeCount;

        private bool _stopAtRank;
        private int _rankToStopAt;

        private int _wins;
        private int _losses;
        private int _concedes;
        private int _rank;

        public void Reset()
        {
            Wins = 0;
            Losses = 0;
            Concedes = 0;
            Rank = TritonHs.MyRank;
        }

        /// <summary>
        /// Should the bot stop when a certain rank is reached?
        /// </summary>
        [DefaultValue(false)]
        public bool StopAtRank
        {
            get { return _stopAtRank; }
            set
            {
                if (!value.Equals(_stopAtRank))
                {
                    _stopAtRank = value;
                    NotifyPropertyChanged(() => StopAtRank);
                }
                Log.InfoFormat("[AutoStopSettings] StopAtRank = {0}.", _stopAtRank);
            }
        }

        /// <summary>The rank to stop at.</summary>
        [DefaultValue(20)]
        public int RankToStopAt
        {
            get { return _rankToStopAt; }
            set
            {
                if (!value.Equals(_rankToStopAt))
                {
                    _rankToStopAt = value;
                    NotifyPropertyChanged(() => RankToStopAt);
                }
                Log.InfoFormat("[AutoStopSettings] RankToStopAt = {0}.", _rankToStopAt);
            }
        }

        /// <summary>Current stored rank.</summary>
        [DefaultValue(-1)]
        public int Rank
        {
            get { return _rank; }
            set
            {
                if (value.Equals(_rank))
                {
                    return;
                }
                _rank = value;
                NotifyPropertyChanged(() => Rank);
            }
        }

        /// <summary>Current stored wins.</summary>
        [DefaultValue(0)]
        public int Wins
        {
            get { return _wins; }
            set
            {
                if (value.Equals(_wins))
                {
                    return;
                }
                _wins = value;
                NotifyPropertyChanged(() => Wins);
            }
        }

        /// <summary>Current stored losses.</summary>
        [DefaultValue(0)]
        public int Losses
        {
            get { return _losses; }
            set
            {
                if (value.Equals(_losses))
                {
                    return;
                }
                _losses = value;
                NotifyPropertyChanged(() => Losses);
            }
        }

        /// <summary>Current stored concedes.</summary>
        [DefaultValue(0)]
        public int Concedes
        {
            get { return _concedes; }
            set
            {
                if (value.Equals(_concedes))
                {
                    return;
                }
                _concedes = value;
                NotifyPropertyChanged(() => Concedes);
            }
        }

        /// <summary>
        /// How many games should the bot play before stopping?
        /// </summary>
        [DefaultValue(1)]
        public int StopGameCount
        {
            get { return _stopGameCount; }
            set
            {
                if (!value.Equals(_stopGameCount))
                {
                    _stopGameCount = value;
                    NotifyPropertyChanged(() => StopGameCount);
                }
                Log.InfoFormat("[AutoStopSettings] StopGameCount = {0}.", _stopGameCount);
            }
        }

        /// <summary>
        /// How many games should the bot win before stopping?
        /// </summary>
        [DefaultValue(1)]
        public int StopWinCount
        {
            get { return _stopWinCount; }
            set
            {
                if (!value.Equals(_stopWinCount))
                {
                    _stopWinCount = value;
                    NotifyPropertyChanged(() => StopWinCount);
                }
                Log.InfoFormat("[AutoStopSettings] StopWinCount = {0}.", _stopWinCount);
            }
        }

        /// <summary>
        /// How many games should the bot lose before stopping?
        /// </summary>
        [DefaultValue(1)]
        public int StopLossCount
        {
            get { return _stopLossCount; }
            set
            {
                if (!value.Equals(_stopLossCount))
                {
                    _stopLossCount = value;
                    NotifyPropertyChanged(() => StopLossCount);
                }
                Log.InfoFormat("[AutoStopSettings] StopLossCount = {0}.", _stopLossCount);
            }
        }

        /// <summary>
        /// How many games should the bot concede before stopping?
        /// </summary>
        [DefaultValue(1)]
        public int StopConcedeCount
        {
            get { return _stopConcedeCount; }
            set
            {
                if (!value.Equals(_stopConcedeCount))
                {
                    _stopConcedeCount = value;
                    NotifyPropertyChanged(() => StopConcedeCount);
                }
                Log.InfoFormat("[AutoStopSettings] StopConcedeCount = {0}.", _stopConcedeCount);
            }
        }

        /// <summary>
        /// Should the bot stop after each game played?
        /// </summary>
        [DefaultValue(false)]
        public bool StopAfterXGames
        {
            get { return _stopAfterXGames; }
            set
            {
                if (!value.Equals(_stopAfterXGames))
                {
                    _stopAfterXGames = value;
                    NotifyPropertyChanged(() => StopAfterXGames);
                }
                Log.InfoFormat("[AutoStopSettings] StopAfterXGames = {0}.", _stopAfterXGames);
            }
        }

        /// <summary>
        /// Should the bot stop after each win?
        /// </summary>
        [DefaultValue(false)]
        public bool StopAfterXWins
        {
            get { return _stopAfterXWins; }
            set
            {
                if (!value.Equals(_stopAfterXWins))
                {
                    _stopAfterXWins = value;
                    NotifyPropertyChanged(() => StopAfterXWins);
                }
                Log.InfoFormat("[AutoStopSettings] StopAfterXWins = {0}.", _stopAfterXWins);
            }
        }

        /// <summary>
        /// Should the bot stop after each loss?
        /// </summary>
        [DefaultValue(false)]
        public bool StopAfterXLosses
        {
            get { return _stopAfterXLosses; }
            set
            {
                if (!value.Equals(_stopAfterXLosses))
                {
                    _stopAfterXLosses = value;
                    NotifyPropertyChanged(() => StopAfterXLosses);
                }
                Log.InfoFormat("[AutoStopSettings] StopAfterXLosses = {0}.", _stopAfterXLosses);
            }
        }

        /// <summary>
        /// Should the bot stop after each concede?
        /// </summary>
        [DefaultValue(false)]
        public bool StopAfterXConcedes
        {
            get { return _stopAfterXConcedes; }
            set
            {
                if (!value.Equals(_stopAfterXConcedes))
                {
                    _stopAfterXConcedes = value;
                    NotifyPropertyChanged(() => StopAfterXConcedes);
                }
                Log.InfoFormat("[AutoStopSettings] StopAfterXConcedes = {0}.", _stopAfterXConcedes);
            }
        }
    }
}
