using Chuck.SilverFish;
using SilverFish.Enums;

namespace SilverFish.cards._04Expansion._012ULD
{
    /// <summary>
    /// Zephrys the Great
    /// 了不起的杰弗里斯
    /// </summary>
    public class Sim_ULD_003 : SimTemplate
    {
        /// <summary>
        /// Battlecry: If your deck has no duplicates, wish for the perfect card.
        /// 战吼：如果你的牌库里没有相同的牌，则可以许愿获得一张完美的卡牌。
        /// </summary>
        /// <param name="p"></param>
        /// <param name="own"></param>
        /// <param name="target"></param>
        /// <param name="choice"></param>
        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            if (own.own && p.prozis.noDuplicates)
                p.drawACard(CardName.unknown, own.own, true);
        }
    }
}