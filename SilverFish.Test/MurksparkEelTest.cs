using System.IO;
using HREngine.Bots;
using NUnit.Framework;

namespace SilverFish.Test
{
    [TestFixture]
    class MurksparkEelTest : TestBase
    {
        [Test]
        public void Test()
        {

            var testFilePath = Path.Combine(Settings.Instance.BaseDirectory,
                @"SilverFish.Test\Data\MurksparkEelTest.txt");
            var data = File.ReadAllText(testFilePath);
            //Console.WriteLine(data);

            Ai ai = Ai.Instance;
            ai.autoTester(true, data, 0);

        }
    }
}
