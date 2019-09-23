using System.IO;
using Chuck.SilverFish;
using NUnit.Framework;

namespace SilverFish.Test
{
    [TestFixture]
    class RushTest : TestBase
    {
        [Test]
        public void RushCardTest()
        {
            var testFilePath = Path.Combine(Settings.Instance.BaseDirectory, @"Chuck.SilverFish.Test\Data\Mechanism\Rush\RushCard.txt");
            var data = File.ReadAllText(testFilePath);
            //Console.WriteLine(data);

            Ai ai = Ai.Instance;
            ai.autoTester(true, data, 2);
        }
    }
}
