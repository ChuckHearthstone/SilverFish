using Chuck.SilverFish;
using SilverFish.Enums;

namespace SilverFish.cards._04Expansion._005UNG
{
	class Sim_UNG_035 : SimTemplate //* Curious Glimmerroot
	{
		//Battlecry: Look at 3 cards. Guess which one started in your opponent's deck to get a copy of it.

		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            p.drawACard(CardName.unknown, own.own, true);
		}
	}
}