using Chuck.SilverFish;

namespace SilverFish.cards._03Adventure._003LOE
{
	class Sim_LOE_019t2 : SimTemplate //* Golden Monkey
	{
		//Taunt. Battlecry: Replace your hand and deck with Legendary minions.
		
		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
			int bonus = 0;
            if (own.own) bonus = -5 * p.owncards.Count;
            else bonus = 5 * p.enemyAnzCards;
			p.evaluatePenality += bonus;
		}
	}
}