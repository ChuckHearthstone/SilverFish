using System.IO;
using System.Linq;
using Chuck.SilverFish;
using NUnit.Framework;
using SilverFish.Enums;

namespace SilverFish.Test
{
    [TestFixture]
    public class RebornTest : TestBase
    {
        /// <summary>
        /// ULD_723
        /// Murmy
        /// 鱼人木乃伊
        /// Reborn
        /// 复生
        /// </summary>
        [Test]
        public void RebornCheckForMurmy()
        {
            var card = CardDB.Instance.getCardDataFromID(CardIdEnum.ULD_723);
            Assert.AreEqual(true, card.Reborn);
        }

        [Test]
        public void RebornMinionCount()
        {
            int expectedCount = 13;
            var cards = CardDB.Instance.CardList;
            var rebornMinions = cards.Where(x => x.Reborn).ToList();
            Assert.AreEqual(expectedCount,rebornMinions.Count);
        }

        [Test]
        public void KhartutDefenderTest()
        {
            var testFilePath = Path.Combine(Settings.Instance.BaseDirectory, @"SilverFish.Test\Data\RebornTest.txt");
            var data = File.ReadAllText(testFilePath);
            //Console.WriteLine(data);

            Ai ai = Ai.Instance;
            ai.autoTester(true, data, 0);
            
        }
    }
}
