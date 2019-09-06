using HREngine.Bots;

namespace SilverFish.cards._04Expansion._008GIL
{
    /// <summary>
    /// Lifedrinker
    /// 吸血蚊
    /// </summary>
    public class Sim_GIL_622 : SimTemplate
    {
        /// <summary>
        /// Battlecry: Deal 3 damage to the enemy hero. Restore #3 Health to your hero.
        /// 战吼：对敌方英雄造成3点伤害。为你的英雄恢复#3点生命值。
        /// </summary>
        /// <param name="p"></param>
        /// <param name="own"></param>
        /// <param name="target"></param>
        /// <param name="choice"></param>
        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            int damageValue = 3;
            int healValue = 3;

            var heroToDamage = !own.own ? p.ownHero : p.enemyHero;
            p.minionGetDamageOrHeal(heroToDamage, damageValue);

            var heroToHeal = own.own ? p.ownHero : p.enemyHero;
            healValue = p.getMinionHeal(healValue);
            p.minionGetDamageOrHeal(heroToHeal, -healValue);
        }
    }
}
