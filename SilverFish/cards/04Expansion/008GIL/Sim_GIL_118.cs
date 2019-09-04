using HREngine.Bots;

namespace SilverFish.cards._04Expansion._008GIL
{
    /// <summary>
    /// Deranged Doctor
    /// 癫狂的医生
    /// </summary>
    public class Sim_GIL_118 : SimTemplate
    {
        /// <summary>
        /// Deathrattle: Restore #8 Health to your hero.
        /// 亡语：为你的英雄恢复#8点生命值。
        /// </summary>
        /// <param name="p"></param>
        /// <param name="m"></param>
        public override void onDeathrattle(Playfield p, Minion m)
        {
            if (m.own)
            {
                int heal = p.getMinionHeal(8);
                p.minionGetDamageOrHeal(p.ownHero, -heal, true);
            }
            else
            {
                int heal = p.getEnemyMinionHeal(8);
                p.minionGetDamageOrHeal(p.enemyHero, -heal, true);
            }
        }
    }
}
