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
            int healValue = 8;
            if (m.own)
            {
                healValue = p.getMinionHeal(healValue);
                p.minionGetDamageOrHeal(p.ownHero, -healValue, true);
            }
            else
            {
                healValue = p.getEnemyMinionHeal(healValue);
                p.minionGetDamageOrHeal(p.enemyHero, -healValue, true);
            }
        }
    }
}
