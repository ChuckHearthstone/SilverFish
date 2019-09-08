using HREngine.Bots;

namespace SilverFish.cards._02Classic
{
	class Sim_EX1_345 : SimTemplate //* Mindgames
	{
        // Put a copy of a random minion from your opponent's deck into the battlefield.

        CardDB.Card copymin = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.CS2_182); // we take a icewindjety :D

		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            if (p.enemyDeckSize < 1) copymin = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_345t); // Shadow of Nothing
            p.CallKid(copymin, p.ownMinions.Count, ownplay, false);
		}
	}
}