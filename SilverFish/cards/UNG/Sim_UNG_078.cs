using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_UNG_078 : SimTemplate //* Tortollan Forager
	{
		//Battlecry: Add a random minion with 5 or more Attack to your hand.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            p.drawACard(CardDB.cardName.bootybaybodyguard, own.own, true);
        }
}
}