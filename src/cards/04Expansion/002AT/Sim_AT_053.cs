using HREngine.Bots;

namespace SilverFish.cards._04Expansion._002AT
{
	class Sim_AT_053 : SimTemplate //* Ancestral Knowledge
	{
		//Draw 2 Cards. Overload: (2)
		
		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            p.drawACard(CardDB.cardName.unknown, ownplay);
            p.drawACard(CardDB.cardName.unknown, ownplay);
			if (ownplay) p.ueberladung += 2;
		}
	}
}