using System;
using System.IO;
using HREngine.Bots;

namespace SilverFish.Helpers
{
    public class LogHelper
    {
        private static string LogFolder = "Logs";

        private static string MainLogFileName { get; set; }

        private static void AppendText(object obj, string fileName, string subfolder = "")
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

            AppendText(filePath, obj);
        }

        private static void AppendText(string filePath, object obj)
        {
            using (StreamWriter sw = File.AppendText(filePath))
            {
                sw.WriteLine(obj?.ToString());
            }
        }

        private static void WriteAllText(string filePath, object obj)
        {
            File.WriteAllText(filePath, obj?.ToString());
        }

        private static void WriteAllText(object obj, string fileName, string subfolder)
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

            WriteAllText(filePath, obj);
        }

        public static void WriteNotImplementedCardSimulationLog(string content)
        {
            WriteAllText(content, "notImplementedCardSimulation.log", string.Empty);
        }

        public static string CombatLogFileName { get; set; } = "Combat.log";

        public static void WriteCombatLog(object obj)
        {
            AppendText(obj, CombatLogFileName, "CombatLogs");
        }

        public static void WriteMainLog(object obj)
        {
            MainLogFileName = $"SilverFish{DateTime.Now:yyyyMMdd}.log";
            AppendText(obj, MainLogFileName);
        }
    }
}
