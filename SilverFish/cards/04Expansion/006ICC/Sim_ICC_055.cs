using HREngine.Bots;

namespace SilverFish.cards._04Expansion._006ICC
{
    /// <summary>
    /// Drain Soul
    /// 吸取灵魂
    /// </summary>
    class Sim_ICC_055: SimTemplate
    {
        /// <summary>
        /// Lifesteal Deal 2 damage to a minion.
        /// 吸血 对一个随从造成 2点伤害。
        /// </summary>
        /// <param name="p"></param>
        /// <param name="ownplay"></param>
        /// <param name="target"></param>
        /// <param name="choice"></param>
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            int dmg = (ownplay) ? p.getSpellDamageDamage(2) : p.getEnemySpellDamageDamage(2);

            int oldHp = target.HealthPoints;
            p.minionGetDamageOrHeal(target, dmg);
            if (oldHp > target.HealthPoints) p.applySpellLifesteal(oldHp-target.HealthPoints, ownplay);
        }
    }
}