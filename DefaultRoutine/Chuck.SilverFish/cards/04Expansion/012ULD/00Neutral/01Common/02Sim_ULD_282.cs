using SilverFish.Helpers;

namespace Chuck.SilverFish.cards._04Expansion._012ULD._00Neutral._01Common
{
    /// <summary>
    /// Jar Dealer
    /// 陶罐商人
    /// </summary>
    public class Sim_ULD_282 : SimTemplate
    {
        /// <summary>
        /// Deathrattle: Add a random 1-Cost minion to your hand.
        /// 亡语：随机将一张法力值消耗为（1）点的随从牌置入你的手牌。
        /// </summary>
        /// <param name="p"></param>
        /// <param name="m"></param>
        public override void onDeathrattle(Playfield p, Minion m)
        {
            var cardIdEnum = CardHelper.MinionWithManaCost[1];
            p.drawACard(cardIdEnum, m.own, true);
        }
    }
}
