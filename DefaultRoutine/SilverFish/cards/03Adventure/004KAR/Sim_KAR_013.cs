using HREngine.Bots;

namespace SilverFish.cards._03Adventure._004KAR
{
	class Sim_KAR_013 : SimTemplate //* Purify
	{
		//Silence a friendly minion. Draw a card.

		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            p.minionGetSilenced(target);
            p.drawACard(CardDB.CardName.unknown, ownplay);
		}
	}
}