using Chuck.SilverFish;
using SilverFish.Enums;

namespace SilverFish.cards._04Expansion._012ULD
{
    /// <summary>
    /// Worthy Expedition
    /// 不虚此行
    /// </summary>
    public class Sim_ULD_136 : SimTemplate
    {
        /// <summary>
        /// Discover a Choose One card.
        /// 发现一张抉择牌。
        /// </summary>
        /// <param name="p"></param>
        /// <param name="ownplay"></param>
        /// <param name="target"></param>
        /// <param name="choice"></param>
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.drawACard(CardName.unknown, ownplay, true);
        }
    }
}