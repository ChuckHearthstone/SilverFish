using HREngine.Bots;

namespace SilverFish.cards._04Expansion._006ICC
{
    class Sim_ICC_831p: SimTemplate //* Siphon Life
    {
        // Hero Power: Lifesteal. Deal 3 damage.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            int dmg = (ownplay) ? p.getHeroPowerDamage(3) : p.getEnemyHeroPowerDamage(3);

            int oldHp = target.HealthPoints;
            p.minionGetDamageOrHeal(target, dmg);
            if (oldHp > target.HealthPoints) p.applySpellLifesteal(oldHp - target.HealthPoints, ownplay);
        }
    }
}