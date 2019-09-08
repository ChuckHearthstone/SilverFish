using HREngine.Bots;

namespace SilverFish.cards._01Basic._06Rogue
{
	class Sim_CS2_077 : SimTemplate //sprint
	{

//    zieht 4 karten.
		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            p.drawACard(CardDB.CardName.unknown, ownplay);
            p.drawACard(CardDB.CardName.unknown, ownplay);
            p.drawACard(CardDB.CardName.unknown, ownplay);
            p.drawACard(CardDB.CardName.unknown, ownplay);
		}

	}
}