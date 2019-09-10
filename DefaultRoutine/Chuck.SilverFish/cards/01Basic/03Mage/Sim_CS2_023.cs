using Chuck.SilverFish;
using SilverFish.Enums;

namespace SilverFish.cards._01Basic._03Mage
{
	class Sim_CS2_023 : SimTemplate //arcaneintellect
	{

//    zieht 2 karten.

		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            p.drawACard(CardName.unknown, ownplay);
            p.drawACard(CardName.unknown, ownplay);
		}

	}
}