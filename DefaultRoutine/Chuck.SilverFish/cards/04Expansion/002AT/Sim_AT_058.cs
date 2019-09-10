using Chuck.SilverFish;
using SilverFish.Enums;

namespace SilverFish.cards._04Expansion._002AT
{
	class Sim_AT_058 : SimTemplate //* King's Elekk
	{
		//Battlecry: Reveal a minion in each deck. If yours costs more, draw it.

		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            p.drawACard(CardName.unknown, own.own);
		}
	}
}