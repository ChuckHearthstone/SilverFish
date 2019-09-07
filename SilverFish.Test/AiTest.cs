using System.IO;
using HREngine.Bots;
using NUnit.Framework;

namespace SilverFish.Test
{
    [TestFixture]
    public class AiTest
    {
        [Test]
        public void Test()
        {
            Settings.Instance.Test = true;

            var repositoryFolder = @"C:\repository\GitHub\ChuckLu\SilverFish";
            Settings.Instance.LogFolderPath = Path.Combine(repositoryFolder, "Logs");
            Settings.Instance.DataFolderPath = Path.Combine(repositoryFolder, @"src\data");
            Settings.Instance.BaseDirectory = repositoryFolder;
            
            //C:\repository\GitHub\ChuckLu\SilverFish\Logs\ChuckSilverFishAi\CombatLogs
            Settings.Instance.writeToSingleFile = true;

            if (Hrtprozis.Instance.settings == null)
            {
                Hrtprozis.Instance.setInstances();
                ComboBreaker.Instance.setInstances();
                PenalityManager.Instance.setInstances();
            }

            //-mode: 0-all, 1-lethalcheck, 2-normal
            Ai ai = Ai.Instance;
            ai.autoTester(true, string.Empty, 0);

        }
    }
}