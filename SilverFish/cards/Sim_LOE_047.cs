using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_LOE_047 : SimTemplate //* Tomb Spider
	{
		//Battlecry: Discover a Beast.
		
		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            p.drawACard(CardDB.cardName.rivercrocolisk, own.own, true);
		}
	}
}