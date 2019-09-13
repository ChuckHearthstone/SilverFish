using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Markup;
using log4net;
using Triton.Bot;
using Triton.Bot.Settings;
using Triton.Common;
using Triton.Game;
using Logger = Triton.Common.LogUtilities.Logger;

namespace AutoStop
{
    public class AutoStop : IPlugin
    {
        private static readonly ILog Log = Logger.GetLoggerInstanceForType();

        private bool _enabled;

        private UserControl _control;

        #region Implementation of IPlugin

        /// <summary> The name of the plugin. </summary>
        public string Name
        {
            get { return "AutoStop"; }
        }

        /// <summary> The description of the plugin. </summary>
        public string Description
        {
            get { return "A plugin that provides basic auto-stop logic for Hearthbuddy."; }
        }

        /// <summary>The author of the plugin.</summary>
        public string Author
        {
            get { return "Bossland GmbH"; }
        }

        /// <summary>The version of the plugin.</summary>
        public string Version
        {
            get { return "0.0.1.1"; }
        }

        /// <summary>Initializes this object. This is called when the object is loaded into the bot.</summary>
        public void Initialize()
        {
            Log.DebugFormat("[AutoStop] Initialize");
        }

        /// <summary> The plugin start callback. Do any initialization here. </summary>
        public void Start()
        {
            Log.DebugFormat("[AutoStop] Start");

            GameEventManager.GameOver += GameEventManagerOnGameOver;
            GameEventManager.StartingNewGame += GameEventManagerOnStartingNewGame;
        }

        /// <summary> The plugin tick callback. Do any update logic here. </summary>
        public void Tick()
        {
        }

        /// <summary> The plugin stop callback. Do any pre-dispose cleanup here. </summary>
        public void Stop()
        {
            Log.DebugFormat("[AutoStop] Stop");

            GameEventManager.GameOver -= GameEventManagerOnGameOver;
            GameEventManager.StartingNewGame -= GameEventManagerOnStartingNewGame;
        }

        public JsonSettings Settings
        {
            get { return AutoStopSettings.Instance; }
        }

        /// <summary> The plugin's settings control. This will be added to the Hearthbuddy Settings tab.</summary>
        public UserControl Control
        {
            get
            {
                if (_control != null)
                {
                    return _control;
                }

                using (var fs = new FileStream(@"Plugins\AutoStop\SettingsGui.xaml", FileMode.Open))
                {
                    var root = (UserControl) XamlReader.Load(fs);

                    // Your settings binding here.

                    // StopAfterXGames
                    if (
                        !Wpf.SetupCheckBoxBinding(root, "StopAfterXGamesCheckBox",
                            "StopAfterXGames",
                            BindingMode.TwoWay, AutoStopSettings.Instance))
                    {
                        Log.DebugFormat(
                            "[SettingsControl] SetupCheckBoxBinding failed for 'StopAfterXGamesCheckBox'.");
                        throw new Exception("The SettingsControl could not be created.");
                    }

                    // StopAfterXWins
                    if (
                        !Wpf.SetupCheckBoxBinding(root, "StopAfterXWinsCheckBox",
                            "StopAfterXWins",
                            BindingMode.TwoWay, AutoStopSettings.Instance))
                    {
                        Log.DebugFormat(
                            "[SettingsControl] SetupCheckBoxBinding failed for 'StopAfterXWinsCheckBox'.");
                        throw new Exception("The SettingsControl could not be created.");
                    }

                    // StopAfterXLosses
                    if (
                        !Wpf.SetupCheckBoxBinding(root, "StopAfterXLossesCheckBox",
                            "StopAfterXLosses",
                            BindingMode.TwoWay, AutoStopSettings.Instance))
                    {
                        Log.DebugFormat(
                            "[SettingsControl] SetupCheckBoxBinding failed for 'StopAfterXLossesCheckBox'.");
                        throw new Exception("The SettingsControl could not be created.");
                    }

                    // StopAfterXGames
                    if (
                        !Wpf.SetupCheckBoxBinding(root, "StopAfterXConcedesCheckBox",
                            "StopAfterXConcedes",
                            BindingMode.TwoWay, AutoStopSettings.Instance))
                    {
                        Log.DebugFormat(
                            "[SettingsControl] SetupCheckBoxBinding failed for 'StopAfterXConcedesCheckBox'.");
                        throw new Exception("The SettingsControl could not be created.");
                    }

                    // StopAfterXGames
                    if (
                        !Wpf.SetupCheckBoxBinding(root, "StopAtRankCheckBox",
                            "StopAtRank",
                            BindingMode.TwoWay, AutoStopSettings.Instance))
                    {
                        Log.DebugFormat(
                            "[SettingsControl] SetupCheckBoxBinding failed for 'StopAtRankCheckBox'.");
                        throw new Exception("The SettingsControl could not be created.");
                    }

                    // RankToStopAt
                    if (!Wpf.SetupTextBoxBinding(root, "RankToStopAtTextBox", "RankToStopAt",
                        BindingMode.TwoWay, AutoStopSettings.Instance))
                    {
                        Log.DebugFormat("[SettingsControl] SetupTextBoxBinding failed for 'RankToStopAtTextBox'.");
                        throw new Exception("The SettingsControl could not be created.");
                    }

                    // StopGameCount
                    if (!Wpf.SetupTextBoxBinding(root, "StopGameCountTextBox", "StopGameCount",
                        BindingMode.TwoWay, AutoStopSettings.Instance))
                    {
                        Log.DebugFormat("[SettingsControl] SetupTextBoxBinding failed for 'StopGameCountTextBox'.");
                        throw new Exception("The SettingsControl could not be created.");
                    }

                    // StopWinCount
                    if (!Wpf.SetupTextBoxBinding(root, "StopWinCountTextBox", "StopWinCount",
                        BindingMode.TwoWay, AutoStopSettings.Instance))
                    {
                        Log.DebugFormat("[SettingsControl] SetupTextBoxBinding failed for 'StopWinCountTextBox'.");
                        throw new Exception("The SettingsControl could not be created.");
                    }

                    // StopLossCount
                    if (!Wpf.SetupTextBoxBinding(root, "StopLossCountTextBox", "StopLossCount",
                        BindingMode.TwoWay, AutoStopSettings.Instance))
                    {
                        Log.DebugFormat("[SettingsControl] SetupTextBoxBinding failed for 'StopLossCountTextBox'.");
                        throw new Exception("The SettingsControl could not be created.");
                    }

                    // StopConcedeCount
                    if (!Wpf.SetupTextBoxBinding(root, "StopConcedeCountTextBox", "StopConcedeCount",
                        BindingMode.TwoWay, AutoStopSettings.Instance))
                    {
                        Log.DebugFormat("[SettingsControl] SetupTextBoxBinding failed for 'StopConcedeCountTextBox'.");
                        throw new Exception("The SettingsControl could not be created.");
                    }

                    // Rank
                    if (!Wpf.SetupTextBoxBinding(root, "RankTextBox", "Rank",
                        BindingMode.TwoWay, AutoStopSettings.Instance))
                    {
                        Log.DebugFormat("[SettingsControl] SetupTextBoxBinding failed for 'RankTextBox'.");
                        throw new Exception("The SettingsControl could not be created.");
                    }

                    // Wins
                    if (!Wpf.SetupTextBoxBinding(root, "WinsTextBox", "Wins",
                        BindingMode.TwoWay, AutoStopSettings.Instance))
                    {
                        Log.DebugFormat("[SettingsControl] SetupTextBoxBinding failed for 'WinsTextBox'.");
                        throw new Exception("The SettingsControl could not be created.");
                    }

                    // Losses
                    if (!Wpf.SetupTextBoxBinding(root, "LossesTextBox", "Losses",
                        BindingMode.TwoWay, AutoStopSettings.Instance))
                    {
                        Log.DebugFormat("[SettingsControl] SetupTextBoxBinding failed for 'LossesTextBox'.");
                        throw new Exception("The SettingsControl could not be created.");
                    }

                    // Concedes
                    if (!Wpf.SetupTextBoxBinding(root, "ConcedesTextBox", "Concedes",
                        BindingMode.TwoWay, AutoStopSettings.Instance))
                    {
                        Log.DebugFormat("[SettingsControl] SetupTextBoxBinding failed for 'ConcedesTextBox'.");
                        throw new Exception("The SettingsControl could not be created.");
                    }

                    // Your settings event handlers here.
                    var resetButton = Wpf.FindControlByName<Button>(root, "ResetButton");
                    resetButton.Click += ResetButtonOnClick;

                    //var addWinButton = Wpf.FindControlByName<Button>(root, "AddWinButton");
                    //addWinButton.Click += AddWinButtonOnClick;

                    //var addLossButton = Wpf.FindControlByName<Button>(root, "AddLossButton");
                    //addLossButton.Click += AddLossButtonOnClick;

                    //var addConcedeButton = Wpf.FindControlByName<Button>(root, "AddConcedeButton");
                    //addConcedeButton.Click += AddConcedeButtonOnClick;

                    //var removeWinButton = Wpf.FindControlByName<Button>(root, "RemoveWinButton");
                    //removeWinButton.Click += RemoveWinButtonOnClick;

                    //var removeLossButton = Wpf.FindControlByName<Button>(root, "RemoveLossButton");
                    //removeLossButton.Click += RemoveLossButtonOnClick;

                    //var removeConcedeButton = Wpf.FindControlByName<Button>(root, "RemoveConcedeButton");
                    //removeConcedeButton.Click += RemoveConcedeButtonOnClick;

                    _control = root;
                }

                return _control;
            }
        }

        private void ResetButtonOnClick(object sender, RoutedEventArgs routedEventArgs)
        {
	        using (TritonHs.AcquireFrame())
	        {
		        AutoStopSettings.Instance.Reset();
	        }
        }

        private void AddWinButtonOnClick(object sender, RoutedEventArgs routedEventArgs)
        {
            AutoStopSettings.Instance.Wins++;
        }

        private void AddLossButtonOnClick(object sender, RoutedEventArgs routedEventArgs)
        {
            AutoStopSettings.Instance.Losses++;
        }

        private void AddConcedeButtonOnClick(object sender, RoutedEventArgs routedEventArgs)
        {
            AutoStopSettings.Instance.Concedes++;
        }

        private void RemoveWinButtonOnClick(object sender, RoutedEventArgs routedEventArgs)
        {
            if (AutoStopSettings.Instance.Wins > 0)
            {
                AutoStopSettings.Instance.Wins--;
            }
        }

        private void RemoveLossButtonOnClick(object sender, RoutedEventArgs routedEventArgs)
        {
            if (AutoStopSettings.Instance.Losses > 0)
            {
                AutoStopSettings.Instance.Losses--;
            }
        }

        private void RemoveConcedeButtonOnClick(object sender, RoutedEventArgs routedEventArgs)
        {
            if (AutoStopSettings.Instance.Concedes > 0)
            {
                AutoStopSettings.Instance.Concedes--;
            }
        }

        /// <summary>Is this plugin currently enabled?</summary>
        public bool IsEnabled
        {
            get { return _enabled; }
        }

        /// <summary> The plugin is being enabled.</summary>
        public void Enable()
        {
            Log.DebugFormat("[AutoStop] Enable");
            _enabled = true;
        }

        /// <summary> The plugin is being disabled.</summary>
        public void Disable()
        {
            Log.DebugFormat("[AutoStop] Disable");
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

        private void GameEventManagerOnStartingNewGame(object sender, StartingNewGameEventArgs startingNewGameEventArgs)
        {
            if (AutoStopSettings.Instance.StopAfterXGames)
            {
                var total = AutoStopSettings.Instance.Losses + AutoStopSettings.Instance.Concedes +
                            AutoStopSettings.Instance.Wins;
                if (total >= AutoStopSettings.Instance.StopGameCount)
                {
                    Log.InfoFormat(
                        "[GameEventManagerOnStartingNewGame] Now stopping the bot because StopAfterXGames is enabled and we have finished playing {0} games out of a desired {1}.",
                        total, AutoStopSettings.Instance.StopGameCount);
                    BotManager.Stop();
                    AutoStopSettings.Instance.Reset();
                    return;
                }
            }

            if (AutoStopSettings.Instance.StopAfterXWins)
            {
                var total = AutoStopSettings.Instance.Wins;
                if (total >= AutoStopSettings.Instance.StopWinCount)
                {
                    Log.InfoFormat(
                        "[GameEventManagerOnStartingNewGame] Now stopping the bot because StopAfterXWins is enabled and we have {0} wins out of a desired {1}.",
                        total, AutoStopSettings.Instance.StopWinCount);
                    BotManager.Stop();
                    AutoStopSettings.Instance.Reset();
                    return;
                }
            }

            if (AutoStopSettings.Instance.StopAfterXLosses)
            {
                var total = AutoStopSettings.Instance.Losses;
                if (total >= AutoStopSettings.Instance.StopLossCount)
                {
                    Log.InfoFormat(
                        "[GameEventManagerOnStartingNewGame] Now stopping the bot because StopAfterXLosses is enabled and we have {0} losses out of a desired {1}.",
                        total, AutoStopSettings.Instance.StopLossCount);
                    BotManager.Stop();
                    AutoStopSettings.Instance.Reset();
                    return;
                }
            }

            if (AutoStopSettings.Instance.StopAfterXConcedes)
            {
                var total = AutoStopSettings.Instance.Concedes;
                if (total >= AutoStopSettings.Instance.StopConcedeCount)
                {
                    Log.InfoFormat(
                        "[GameEventManagerOnStartingNewGame] Now stopping the bot because StopAfterXConcedes is enabled and we have {0} concedes out of a desired {1}.",
                        total, AutoStopSettings.Instance.StopConcedeCount);
                    BotManager.Stop();
                    AutoStopSettings.Instance.Reset();
                    return;
                }
            }

            if (AutoStopSettings.Instance.StopAtRank)
            {
                AutoStopSettings.Instance.Rank = TritonHs.MyRank;
                var total = AutoStopSettings.Instance.Rank;
                if (total == -1)
                {
                    Log.ErrorFormat("[GameEventManagerOnGameOver] The player's current rank is unknown.");
                }
                else if (total <= AutoStopSettings.Instance.RankToStopAt)
                {
                    Log.InfoFormat(
                        "[GameEventManagerOnGameOver] Now stopping the bot because RankToStopAt is enabled and we are at rank {0} of a desired {1}.",
                        total, AutoStopSettings.Instance.RankToStopAt);
                    BotManager.Stop();
                    AutoStopSettings.Instance.Reset();
                    return;
                }
            }
        }

        private void GameEventManagerOnGameOver(object sender, GameOverEventArgs gameOverEventArgs)
        {
            if (gameOverEventArgs.Result == GameOverFlag.Victory)
            {
                AutoStopSettings.Instance.Wins++;
            }
            else if (gameOverEventArgs.Result == GameOverFlag.Defeat)
            {
                if (gameOverEventArgs.Conceded)
                {
                    AutoStopSettings.Instance.Concedes++;
                }
                else
                {
                    AutoStopSettings.Instance.Losses++;
                }
            }
        }
    }
}
