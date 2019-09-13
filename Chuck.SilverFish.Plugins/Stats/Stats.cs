using System;
using System.Diagnostics;
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

namespace Stats
{
    public class Stats : IPlugin
    {
        private static readonly ILog Log = Logger.GetLoggerInstanceForType();

        private bool _enabled;

        #region Implementation of IPlugin

        /// <summary> The name of the plugin. </summary>
        public string Name
        {
            get { return "Stats"; }
        }

        /// <summary> The description of the plugin. </summary>
        public string Description
        {
            get { return "A plugin that provides basic stats for Hearthbuddy."; }
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
            Log.DebugFormat("[Stats] Initialize");
            TritonHs.OnGuiTick += TritonHsOnOnGuiTick;
        }

        /// <summary> The plugin start callback. Do any initialization here. </summary>
        public void Start()
        {
            Log.DebugFormat("[Stats] Start");

            GameEventManager.GameOver += GameEventManagerOnGameOver;
        }

        /// <summary> The plugin tick callback. Do any update logic here. </summary>
        public void Tick()
        {
        }

        /// <summary> The plugin stop callback. Do any pre-dispose cleanup here. </summary>
        public void Stop()
        {
            Log.DebugFormat("[Stats] Stop");

            GameEventManager.GameOver -= GameEventManagerOnGameOver;
        }

        public JsonSettings Settings
        {
            get { return StatsSettings.Instance; }
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

                using (var fs = new FileStream(@"Plugins\Stats\SettingsGui.xaml", FileMode.Open))
                {
                    var root = (UserControl) XamlReader.Load(fs);

                    // Your settings binding here.

                    if (!Wpf.SetupTextBoxBinding(root, "WinsTextBox", "Wins",
                        BindingMode.TwoWay, StatsSettings.Instance))
                    {
                        Log.DebugFormat("[SettingsControl] SetupTextBoxBinding failed for 'WinsTextBox'.");
                        throw new Exception("The SettingsControl could not be created.");
                    }

                    if (!Wpf.SetupTextBoxBinding(root, "LossesTextBox", "Losses",
                        BindingMode.TwoWay, StatsSettings.Instance))
                    {
                        Log.DebugFormat("[SettingsControl] SetupTextBoxBinding failed for 'LossesTextBox'.");
                        throw new Exception("The SettingsControl could not be created.");
                    }

                    if (!Wpf.SetupTextBoxBinding(root, "ConcedesTextBox", "Concedes",
                        BindingMode.TwoWay, StatsSettings.Instance))
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

                    UpdateMainGuiStats();

                    _control = root;
                }

                return _control;
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
            Log.DebugFormat("[Stats] Enable");
            _enabled = true;
        }

        /// <summary> The plugin is being disabled.</summary>
        public void Disable()
        {
            Log.DebugFormat("[Stats] Disable");
            _enabled = false;
        }

        #endregion

        #region Implementation of IDisposable

        /// <summary>Deinitializes this object. This is called when the object is being unloaded from the bot.</summary>
        public void Deinitialize()
        {
            TritonHs.OnGuiTick -= TritonHsOnOnGuiTick;
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

        private void GameEventManagerOnGameOver(object sender, GameOverEventArgs gameOverEventArgs)
        {
            if (gameOverEventArgs.Result == GameOverFlag.Victory)
            {
                StatsSettings.Instance.Wins++;
                UpdateMainGuiStats();
            }
            else if (gameOverEventArgs.Result == GameOverFlag.Defeat)
            {
                if (gameOverEventArgs.Conceded)
                {
                    StatsSettings.Instance.Concedes++;
                }
                else
                {
                    StatsSettings.Instance.Losses++;
                }
                UpdateMainGuiStats();
            }
        }

        private void ResetButtonOnClick(object sender, RoutedEventArgs routedEventArgs)
        {
            StatsSettings.Instance.Wins = 0;
            StatsSettings.Instance.Losses = 0;
            StatsSettings.Instance.Concedes = 0;
            UpdateMainGuiStats();
        }

        private void AddWinButtonOnClick(object sender, RoutedEventArgs routedEventArgs)
        {
            StatsSettings.Instance.Wins++;
            UpdateMainGuiStats();
        }

        private void AddLossButtonOnClick(object sender, RoutedEventArgs routedEventArgs)
        {
            StatsSettings.Instance.Losses++;
            UpdateMainGuiStats();
        }

        private void AddConcedeButtonOnClick(object sender, RoutedEventArgs routedEventArgs)
        {
            StatsSettings.Instance.Concedes++;
            UpdateMainGuiStats();
        }

        private void RemoveWinButtonOnClick(object sender, RoutedEventArgs routedEventArgs)
        {
            if (StatsSettings.Instance.Wins > 0)
            {
                StatsSettings.Instance.Wins--;
                UpdateMainGuiStats();
            }
        }

        private void RemoveLossButtonOnClick(object sender, RoutedEventArgs routedEventArgs)
        {
            if (StatsSettings.Instance.Losses > 0)
            {
                StatsSettings.Instance.Losses--;
                UpdateMainGuiStats();
            }
        }

        private void RemoveConcedeButtonOnClick(object sender, RoutedEventArgs routedEventArgs)
        {
            if (StatsSettings.Instance.Concedes > 0)
            {
                StatsSettings.Instance.Concedes--;
                UpdateMainGuiStats();
            }
        }

        private void UpdateMainGuiStats()
        {
            Application.Current.Dispatcher.BeginInvoke(new Action(() =>
            {
                var leftControl = Wpf.FindControlByName<Label>(Application.Current.MainWindow, "StatusBarLeftLabel");
                var rightControl = Wpf.FindControlByName<Label>(Application.Current.MainWindow, "StatusBarRightLabel");

                if (StatsSettings.Instance.Wins + StatsSettings.Instance.Losses == 0)
                {
                    if (StatsSettings.Instance.Concedes == 0)
                    {
                        rightControl.Content = string.Format("(No Games)");
                    }
                    else
                    {
                        rightControl.Content = string.Format("[{0} concedes]", StatsSettings.Instance.Concedes);
                    }
                }
                else
                {
                    rightControl.Content = string.Format("{0} / {1} ({2:0.00} %) [{3} concedes]",
                        StatsSettings.Instance.Wins,
                        StatsSettings.Instance.Wins + StatsSettings.Instance.Losses,
                        100.0f*(float) StatsSettings.Instance.Wins/
                        (float) (StatsSettings.Instance.Wins + StatsSettings.Instance.Losses),
                        StatsSettings.Instance.Concedes);

                    Log.InfoFormat("[Stats] Summary: {0}", rightControl.Content);
                }

                // Force a save all.
                Configuration.Instance.SaveAll();
            }));
        }

        private void TritonHsOnOnGuiTick(object sender, GuiTickEventArgs guiTickEventArgs)
        {
            // Only update if we're actually enabled.
            if (IsEnabled)
            {
                Application.Current.Dispatcher.BeginInvoke(new Action(() =>
                {
                    var leftControl = Wpf.FindControlByName<Label>(Application.Current.MainWindow, "StatusBarLeftLabel");
                    leftControl.Content = string.Format("Runtime: {0}", TritonHs.Runtime.Elapsed.ToString("h'h 'm'm 's's'"));
                }));
            }
        }
    }
}
