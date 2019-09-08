using HREngine.Bots;
using SilverFish.Enums;

namespace SilverFish.cards._04Expansion._002AT
{
	class Sim_AT_053 : SimTemplate //* Ancestral Knowledge
	{
		//Draw 2 Cards. Overload: (2)
		
		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            p.drawACard(CardName.unknown, ownplay);
            p.drawACard(CardName.unknown, ownplay);
			if (ownplay) p.ueberladung += 2;
		}
	}
}