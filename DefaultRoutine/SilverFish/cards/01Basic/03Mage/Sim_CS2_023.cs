using HREngine.Bots;

namespace SilverFish.cards._01Basic._03Mage
{
	class Sim_CS2_023 : SimTemplate //arcaneintellect
	{

//    zieht 2 karten.

		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            p.drawACard(CardDB.CardName.unknown, ownplay);
            p.drawACard(CardDB.CardName.unknown, ownplay);
		}

	}
}