using System.IO;
using HREngine.Bots;
using NUnit.Framework;

namespace SilverFish.Test
{
    [TestFixture]
    public class AiTest : TestBase
    {
        [Test]
        public void Test()
        {
            var testFilePath = Path.Combine(Settings.Instance.BaseDirectory,
                @"SilverFish.Test\Data\test.txt");
            var data = File.ReadAllText(testFilePath);

            //-mode: 0-all, 1-lethalcheck, 2-normal
            Ai ai = Ai.Instance;
            ai.autoTester(true, data, 0);

        }
    }
}