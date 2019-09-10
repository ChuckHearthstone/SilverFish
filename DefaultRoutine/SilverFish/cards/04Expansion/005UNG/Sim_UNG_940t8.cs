using Chuck.SilverFish;

namespace SilverFish.cards._04Expansion._005UNG
{
	class Sim_UNG_940t8 : SimTemplate //* Amara, Warden of Hope
	{
		//Taunt. Battlecry: Set your hero's Health to 40.

		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
			if (own.own) p.ownHero.HealthPoints = 40;
			else p.enemyHero.HealthPoints = 40;
		}
	}
}