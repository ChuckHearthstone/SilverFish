using System.IO;
using HREngine.Bots;

namespace SilverFish.Helpers
{
    public class LogHelper
    {
        public static string LogFolder = "Logs";

        private static void WriteLog(object obj, string fileName,string subfolder="")
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
    }
}
