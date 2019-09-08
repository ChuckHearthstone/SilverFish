using HREngine.Bots;

namespace SilverFish.cards._02Classic
{
	class Sim_EX1_339 : SimTemplate //thoughtsteal
	{

//    kopiert 2 karten aus dem deck eures gegners und fügt sie eurer hand hinzu.
		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            p.drawACard(CardDB.CardName.unknown, ownplay, true);
            p.drawACard(CardDB.CardName.unknown, ownplay, true);
		}

	}
}