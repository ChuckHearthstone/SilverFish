using Chuck.SilverFish;

namespace SilverFish.cards._04Expansion._005UNG
{
    class Sim_UNG_057t1 : SimTemplate //* Razorpetal
	{
        //Deal $1 damage.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            int dmg = (ownplay) ? p.getSpellDamageDamage(1) : p.getEnemySpellDamageDamage(1);
            p.minionGetDamageOrHeal(target, dmg);
        }
    }
}