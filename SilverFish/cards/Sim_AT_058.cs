using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_AT_058 : SimTemplate //* King's Elekk
	{
		//Battlecry: Reveal a minion in each deck. If yours costs more, draw it.

		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            p.drawACard(CardDB.cardName.unknown, own.own);
		}
	}
}