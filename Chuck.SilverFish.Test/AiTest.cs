using System.IO;
using System.Text;
using Chuck.SilverFish;
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
                @"Chuck.SilverFish.Test\Data\test.txt");
            var data = File.ReadAllText(testFilePath);

            //-mode: 0-all, 1-lethalcheck, 2-normal
            Ai ai = Ai.Instance;
            ai.autoTester(true, data, 0);

        }

        [Test]
        public void TestWithHeroName()
        {
            var testFilePath = Path.Combine(Settings.Instance.BaseDirectory,
                @"Chuck.SilverFish.Test\Data\test-new.txt");
            var data = File.ReadAllText(testFilePath, Encoding.UTF8);

            //-mode: 0-all, 1-lethalcheck, 2-normal
            Ai ai = Ai.Instance;
            ai.autoTester(true, data, 0);

        }
    }
}