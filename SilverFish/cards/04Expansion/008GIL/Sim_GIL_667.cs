using HREngine.Bots;

namespace SilverFish.cards._04Expansion._008GIL
{
    /// <summary>
    /// Rotten Applebaum
    /// 腐烂的苹果树
    /// </summary>
    public class Sim_GIL_667 : SimTemplate
    {
        /// <summary>
        /// Taunt Deathrattle: Restore #4 Health to your hero.
        /// 嘲讽，亡语：为你的英雄恢复#4点生命值。
        /// </summary>
        /// <param name="p"></param>
        /// <param name="m"></param>
        public override void onDeathrattle(Playfield p, Minion m)
        {
            if (m.own)
            {
                int heal = p.getMinionHeal(4);
                p.minionGetDamageOrHeal(p.ownHero, -heal, true);
            }
            else
            {
                int heal = p.getEnemyMinionHeal(4);
                p.minionGetDamageOrHeal(p.enemyHero, -heal, true);
            }
        }
    }
}
