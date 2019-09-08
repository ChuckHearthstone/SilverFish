using HREngine.Bots;

namespace SilverFish.cards._01Basic._02Hunter
{
	class Sim_DS1h_292 : SimTemplate //* Steady Shot
	{
		//Hero Power: Deal 2 damage to the enemy hero.
		
		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            int dmg = (ownplay) ? p.getHeroPowerDamage(2) : p.getEnemyHeroPowerDamage(2);
            if (target == null) target = ownplay ? p.enemyHero : p.ownHero;
            p.minionGetDamageOrHeal(target, dmg);
		}
	}

    class Sim_DS1h_292_H1 : SimTemplate //* Steady Shot
    {
        //Hero Power: Deal 2 damage to the enemy hero.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            int dmg = (ownplay) ? p.getHeroPowerDamage(2) : p.getEnemyHeroPowerDamage(2);
            if (target == null) target = ownplay ? p.enemyHero : p.ownHero;
            p.minionGetDamageOrHeal(target, dmg);
        }
    }

    class Sim_DS1h_292_H1_AT_132 : SimTemplate //* Ballista Shot
    {
        //Hero Power: Deal 3 damage to the enemy hero.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            int dmg = (ownplay) ? p.getHeroPowerDamage(3) : p.getEnemyHeroPowerDamage(3);
            if (target == null) target = ownplay ? p.enemyHero : p.ownHero;
            p.minionGetDamageOrHeal(target, dmg);
        }
    }
}