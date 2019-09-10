using Chuck.SilverFish;

namespace SilverFish.cards._04Expansion._005UNG
{
	class Sim_UNG_211c : SimTemplate //* Invocation of Fire
	{
		//Deal 6 damage to the enemy hero.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            int dmg = (ownplay) ? p.getSpellDamageDamage(6) : p.getEnemySpellDamageDamage(6);
            p.minionGetDamageOrHeal(ownplay ? p.enemyHero : p.ownHero, dmg);
        }
    }
}