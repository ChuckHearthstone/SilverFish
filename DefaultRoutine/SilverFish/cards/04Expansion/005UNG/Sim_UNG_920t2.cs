using HREngine.Bots;
using SilverFish.Enums;

namespace SilverFish.cards._04Expansion._005UNG
{
	class Sim_UNG_920t2 : SimTemplate //* Carnassa's Brood
	{
		//Battlecry: Draw a card.

		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            p.drawACard(CardName.unknown, own.own);
		}
	}
}