using HREngine.Bots;
using SilverFish.Enums;

namespace SilverFish.cards._04Expansion._008GIL
{
    /// <summary>
    /// Blazing Invocation
    /// 炽焰祈咒
    /// </summary>
    public class Sim_GIL_836 : SimTemplate
    {
        /// <summary>
        /// Discover a Battlecry minion.
        /// 发现一张具有战吼的随从牌。
        /// </summary>
        /// <param name="p"></param>
        /// <param name="ownplay"></param>
        /// <param name="target"></param>
        /// <param name="choice"></param>
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.drawACard(CardName.lepergnome, ownplay, true);
        }
    }
}
