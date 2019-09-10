using Chuck.SilverFish;

namespace SilverFish.cards._04Expansion._008GIL
{
    /// <summary>
    /// Squashling
    /// 南瓜宝宝
    /// </summary>
    public class Sim_GIL_835 : SimTemplate
    {
        /// <summary>
        /// Echo Battlecry: Restore #2 Health.
        /// 回响，战吼：恢复#2点生命值。
        /// </summary>
        /// <param name="p"></param>
        /// <param name="own"></param>
        /// <param name="target"></param>
        /// <param name="choice"></param>
        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            int heal = (own.own) ? p.getMinionHeal(2) : p.getEnemyMinionHeal(2);
            p.minionGetDamageOrHeal(target, -heal);
        }
    }
}
