using HREngine.Bots;
using SilverFish.Enums;

namespace SilverFish.cards._04Expansion._005UNG
{
	class Sim_UNG_113 : SimTemplate //* Bright-Eyed Scout
	{
		//Battlecry: Draw a card. Change its Cost to (5).

		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            p.drawACard(CardName.unknown, own.own);
                p.owncards[p.owncards.Count - 1].manacost = 5;
		}
	}
}