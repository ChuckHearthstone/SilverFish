using HREngine.Bots;
using SilverFish.Enums;

namespace SilverFish.cards._04Expansion._012ULD
{
    /// <summary>
    /// Frightened Flunky
    /// 惊恐的仆从
    /// </summary>
    public class Sim_ULD_195 : SimTemplate
    {
        /// <summary>
        /// Taunt Battlecry: Discover a Taunt minion.
        /// 嘲讽，战吼：发现一张具有嘲讽的随从牌。
        /// </summary>
        /// <param name="p"></param>
        /// <param name="own"></param>
        /// <param name="target"></param>
        /// <param name="choice"></param>
        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            p.drawACard(CardName.unknown, own.own, true);
        }
    }
}