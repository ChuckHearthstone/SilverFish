using HREngine.Bots;

namespace SilverFish.cards._04Expansion._008GIL
{
    /// <summary>
    /// Night Prowler
    /// 暗夜徘徊者
    /// </summary>
    public class Sim_GIL_624 : SimTemplate
    {
        /// <summary>
        /// Battlecry: If this is the only minion on the battlefield, gain +3/+3.
        /// 战吼：如果它是战场上的唯一一个随从，获得+3/+3。
        /// </summary>
        /// <param name="p"></param>
        /// <param name="own"></param>
        /// <param name="target"></param>
        /// <param name="choice"></param>
        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            if (own.own)
            {
                if (p.ownMinions.Count == 0) p.minionGetBuffed(own, 3, 3);
            }
            else
            {
                if (p.enemyMinions.Count == 0) p.minionGetBuffed(own, 3, 3);
            }
        }
    }
}
