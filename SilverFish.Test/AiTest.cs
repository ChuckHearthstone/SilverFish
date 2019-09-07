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

            Settings.Instance.LogFolderPath = @"C:\repository\GitHub\ChuckLu\SilverFish\Logs";
            Settings.Instance.DataFolderPath = @"C:\repository\GitHub\ChuckLu\SilverFish\src\data";
            Settings.Instance.BaseDirectory = @"C:\repository\GitHub\ChuckLu\SilverFish";
            
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