using Chuck.SilverFish;

namespace SilverFish.cards._04Expansion._008GIL
{
    /// <summary>
    /// Mossy Horror
    /// 苔藓恐魔
    /// </summary>
    public class Sim_GIL_124 : SimTemplate
    {
        /// <summary>
        /// Battlecry: Destroy all other minions with 2 or less Attack.
        /// 战吼：消灭所有其他攻击力小于或等于2的随从。
        /// </summary>
        /// <param name="p"></param>
        /// <param name="own"></param>
        /// <param name="target"></param>
        /// <param name="choice"></param>
        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            foreach (Minion m in p.enemyMinions)
            {
                if (m.Attack <= 2) p.minionGetDestroyed(m);
            }
            foreach (Minion m in p.ownMinions)
            {
                if (m.Attack <= 2) p.minionGetDestroyed(m);
            }
        }
    }
}
