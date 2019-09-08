using System.Linq;
using HREngine.Bots;
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
    }
}
