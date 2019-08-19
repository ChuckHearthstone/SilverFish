using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_EX1_345 : SimTemplate //* Mindgames
	{
        // Put a copy of a random minion from your opponent's deck into the battlefield.

        CardDB.Card copymin = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.CS2_182); // we take a icewindjety :D

		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            if (p.enemyDeckSize < 1) copymin = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_345t); // Shadow of Nothing
            p.callKid(copymin, p.ownMinions.Count, ownplay, false);
		}
	}
}