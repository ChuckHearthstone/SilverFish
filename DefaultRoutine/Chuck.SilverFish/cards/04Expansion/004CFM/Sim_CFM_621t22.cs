using Chuck.SilverFish;
using SilverFish.Enums;

namespace SilverFish.cards._04Expansion._004CFM
{
	class Sim_CFM_621t22 : SimTemplate //* Kingsblood
	{
		// Draw 2 cards.
		
		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            p.drawACard(CardName.unknown, ownplay);
            p.drawACard(CardName.unknown, ownplay);
		}
	}
}