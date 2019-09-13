using Chuck.SilverFish;
using SilverFish.Helpers;

namespace SilverFish.cards._04Expansion._012ULD
{
    /// <summary>
    /// Sinister Deal
    /// 邪恶交易
    /// </summary>
    public class Sim_ULD_160 : SimTemplate
    {
        /// <summary>
        /// Discover a Lackey.
        /// 发现一张跟班牌。
        /// </summary>
        /// <param name="p"></param>
        /// <param name="ownplay"></param>
        /// <param name="target"></param>
        /// <param name="choice"></param>
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            var cardIdEnum = LackeyHelper.Instance.GetRandomLackey();
            p.drawACard(cardIdEnum, ownplay, true);
        }
    }
}
