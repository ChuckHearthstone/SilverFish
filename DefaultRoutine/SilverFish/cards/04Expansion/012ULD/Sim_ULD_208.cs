using HREngine.Bots;

namespace SilverFish.cards._04Expansion._012ULD
{
    /// <summary>
    /// Khartut Defender
    /// 卡塔图防御者
    /// </summary>
    public class Sim_ULD_208 : SimTemplate
    {
        /// <summary>
        /// Taunt, Reborn Deathrattle: Restore #3 Health to your hero.
        /// 嘲讽，复生，亡语：为你的英雄恢复#3点生命值。
        /// </summary>
        /// <param name="p"></param>
        /// <param name="m"></param>
        public override void onDeathrattle(Playfield p, Minion m)
        {
            int healValue = 3;
            healValue = m.own ? p.getMinionHeal(healValue) : p.getEnemyMinionHeal(healValue);
            var hero = m.own ? p.ownHero : p.enemyHero;
            p.minionGetDamageOrHeal(hero, -healValue, true);
        }
    }
}
