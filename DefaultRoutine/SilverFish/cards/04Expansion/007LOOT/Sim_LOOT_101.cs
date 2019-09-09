using HREngine.Bots;

namespace SilverFish.cards._04Expansion._007LOOT
{
    /// <summary>
    /// Explosive Runes
    /// 爆炸符文
    /// </summary>
    public class Sim_LOOT_101 : SimTemplate
    {
        /// <summary>
        /// Secret: After your opponent plays a minion, deal $6 damage to it and any excess to their hero.
        /// 奥秘：在你的对手使用一张随从牌后，对该随从造成$6点伤害，超过其生命值上限的伤害将由对方英雄承
        /// </summary>
        /// <param name="p"></param>
        /// <param name="ownplay"></param>
        /// <param name="target"></param>
        /// <param name="number"></param>
        public override void onSecretPlay(Playfield p, bool ownplay, Minion target, int number)
        {
            int dmg2minion = (ownplay) ? p.getSpellDamageDamage(6) : p.getEnemySpellDamageDamage(6);
            int damg2hero = 0;
            p.minionGetDamageOrHeal(target, dmg2minion);
            if (dmg2minion >= target.HealthPoints && !target.DivineShield && !target.immune)
            {
                damg2hero = dmg2minion - target.HealthPoints;
            }
            p.minionGetDamageOrHeal(ownplay ? p.enemyHero : p.ownHero, damg2hero);
        }
    }
}
