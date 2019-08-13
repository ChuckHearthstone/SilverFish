using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_OG_122 : SimTemplate //* Mukla, Tyrant of the Vale
	{
		//Battlecry: Add 2 Bananas to your hand.
		
		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            p.drawACard(CardDB.cardName.bananas, own.own, true);
            p.drawACard(CardDB.cardName.bananas, own.own, true);
		}
	}
}