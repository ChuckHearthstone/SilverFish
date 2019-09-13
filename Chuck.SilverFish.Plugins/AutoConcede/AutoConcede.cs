using System.Windows.Controls;
using log4net;
using SilverFish.Helpers;
using Triton.Bot;
using Triton.Common;
using Triton.Game;

namespace Chuck.SilverFish.Plugins.AutoConcede
{
    public class AutoConcede : IPlugin
    {
        private static readonly ILog Log = Hearthbuddy.Windows.MainWindow.ChuckLog;

        private int _defeatCount;

        private int _winCount = 1;

        private double _winRateThreshold = 0.2;

        private double _realWinRate = 0;

        public void Start()
        {
            Log.InfoFormat("[AutoConcede] Initialize");
            CustomEventManager.Instance.MulliganStarted += CustomEventManager_MulliganStarted;
            GameEventManager.GameOver += GameEventManager_GameOver;
        }

        private void CustomEventManager_MulliganStarted(object sender, MulliganStartedEventArgs e)
        {
			Log.InfoFormat("CustomEventManager_MulliganStarted");
            if (_realWinRate >= _winRateThreshold)
            {
                e.ConcedeSuccessfully = TritonHs.Concede(true);
            }
        }

        private void GameEventManager_GameOver(object sender, GameOverEventArgs e)
        {
            if (e.Result == GameOverFlag.Victory)
            {
                _winCount++;

            }
            else if (e.Result == GameOverFlag.Defeat)
            {
                _defeatCount++;
            }

            CalculateRealWinRate();
        }

        private void CalculateRealWinRate()
        {
            double totalCount = _winCount + _defeatCount;
            _realWinRate = _winCount / totalCount;
            Log.InfoFormat($"[AutoConcede] CalculateRealWinRate {_winCount}/{totalCount} = {_realWinRate:P}");
        }

        public void Tick()
        {
        }

        public void Stop()
        {
            CustomEventManager.Instance.MulliganStarted -= CustomEventManager_MulliganStarted;
            GameEventManager.GameOver -= GameEventManager_GameOver;
        }

        public string Name => "AutoConcede";

        public string Author => "Chuck Lu";

        public string Description => "Auto concede to reduce the odds.";

        public string Version => "0.1.3";

        public void Initialize()
        {
        }

        public void Deinitialize()
        {
        }

        public UserControl Control => null;

        public JsonSettings Settings => null;

        public void Enable()
        {
			IsEnabled = true;
			Log.DebugFormat("[AutoConcede] Enabled");
        }

        public void Disable()
        {
			IsEnabled = false;
			Log.DebugFormat("[AutoConcede] Disabled");
        }

        public bool IsEnabled { get; private set; }
    }
}
