using System;
using System.IO;
using HREngine.Bots;

namespace SilverFish.Helpers
{
    public class LogHelper
    {
        private static string LogFolder = "Logs";

        private static string MainLogFileName { get; set; }

        private static void WriteLog(object obj, string fileName, string subfolder = "")
        {
            var folder = Path.Combine(Settings.Instance.BaseDirectory, LogFolder);
            if (!string.IsNullOrWhiteSpace(subfolder))
            {
                folder = Path.Combine(folder, subfolder);
            }

            var filePath = Path.Combine(folder, fileName);
            if (!File.Exists(filePath))
            {
                FileHelper.CreateEmptyFile(filePath);
            }

            using (StreamWriter sw = File.AppendText(filePath))
            {
                sw.WriteLine(obj?.ToString());
            }
        }

        public static void WriteNotImplementedCardSimulationLog(string content)
        {
            WriteLog(content, "notImplementedCardSimulation.log");
        }

        public static string CombatLogFileName { get; set; } = "Combat.log";

        public static void WriteCombatLog(object obj)
        {
            WriteLog(obj, CombatLogFileName, "CombatLogs");
        }

        public static void WriteMainLog(object obj)
        {
            MainLogFileName = $"SilverFish{DateTime.Now:yyyyMMdd}.log";
            WriteLog(obj, MainLogFileName);
        }
    }
}
