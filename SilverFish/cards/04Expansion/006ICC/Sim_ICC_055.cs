using HREngine.Bots;

namespace SilverFish.cards._04Expansion._006ICC
{
    class Sim_ICC_055: SimTemplate //* Drain Soul
    {
        // Lifesteal. Deal 2 damage to a minion.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            int dmg = (ownplay) ? p.getSpellDamageDamage(2) : p.getEnemySpellDamageDamage(2);

            int oldHp = target.HealthPoints;
            p.minionGetDamageOrHeal(target, dmg);
            if (oldHp > target.HealthPoints) p.applySpellLifesteal(oldHp-target.HealthPoints, ownplay);
        }
    }
}