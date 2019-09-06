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
            Settings.Instance.LogFolderPath = @"C:\repository\GitHub\ChuckLu\Test\HearthbuddyRelease\Logs";
            Settings.Instance.DataFolderPath =
                @"C:\repository\GitHub\ChuckLu\Test\HearthbuddyRelease\Routines\DefaultRoutine\SilverFish\Data\";
            Settings.Instance.BaseDirectory = @"C:\repository\GitHub\ChuckLu\Test\HearthbuddyRelease";
            Settings.Instance.writeToSingleFile = true;//C:\repository\GitHub\ChuckLu\Test\HearthbuddyRelease\Logs\SilverFish.log
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