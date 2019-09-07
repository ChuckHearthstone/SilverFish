using HREngine.Bots;

namespace SilverFish.cards._04Expansion._002AT
{
	class Sim_AT_086 : SimTemplate //* Saboteur
	{
		//Battlecry: Your opponent's Hero Power costs (5) more next turn.

		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
			if (own.own) p.enemyHeroPowerCostLessOnce += 5;
			else p.ownHeroPowerCostLessOnce += 5;
		}
	}
}