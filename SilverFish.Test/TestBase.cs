using System.IO;
using HREngine.Bots;
using NUnit.Framework;

namespace SilverFish.Test
{
    [TestFixture]
    public class TestBase
    {
        [SetUp]
        public void InitSetting()
        {

            Settings.Instance.Test = true;

            var repositoryFolder = @"C:\repository\GitHub\ChuckLu\SilverFish";
            Settings.Instance.LogFolderPath = Path.Combine(repositoryFolder, "Logs");
            Settings.Instance.DataFolderPath = Path.Combine(repositoryFolder, @"DefaultRoutine\SilverFish\data");
            Settings.Instance.BaseDirectory = repositoryFolder;

            //C:\repository\GitHub\ChuckLu\SilverFish\Logs\ChuckSilverFishAi\CombatLogs
            Settings.Instance.writeToSingleFile = true;

            if (Hrtprozis.Instance.settings == null)
            {
                Hrtprozis.Instance.setInstances();
                ComboBreaker.Instance.setInstances();
                PenaltyManager.Instance.setInstances();
            }

        }
    }
}
