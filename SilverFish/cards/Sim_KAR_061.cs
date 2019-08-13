using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_KAR_061 : SimTemplate //* The Curator
	{
		//Taunt. Battlecry: Draw a Beast, Dragon, and Murloc from your deck.
		
		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            p.drawACard(CardDB.cardName.unknown, own.own);
            p.drawACard(CardDB.cardName.unknown, own.own);
		}
	}
}