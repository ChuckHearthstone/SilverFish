using Chuck.SilverFish;

namespace SilverFish.cards._04Expansion._002AT
{
	class Sim_AT_115 : SimTemplate //* Fencing Coach
	{
		//Battlecry: The next time you use your Hero Power, it costs (2) less.

		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
			if (own.own) p.ownHeroPowerCostLessOnce -= 2;
			else p.enemyHeroPowerCostLessOnce -= 2;
		}
	}
}