using HREngine.Bots;

namespace SilverFish.cards._03Adventure._001NAX
{
	class Sim_NAX15_02 : SimTemplate //* frostblast normal
	{
        //Hero Power: Deal 2 damage to the enemy hero and Freeze it.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            int dmg = (ownplay) ? p.getHeroPowerDamage(2) : p.getEnemyHeroPowerDamage(2);
            p.minionGetDamageOrHeal(ownplay ? p.enemyHero : p.ownHero, dmg);
            p.minionGetFrozen(target);
        }
	}
}