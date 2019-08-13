using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_AT_127 : SimTemplate //* Nexus-Champion Saraad
	{
		//Inspire: Add a random spell to your hand.
		
		public override void onInspire(Playfield p, Minion m, bool own)
        {
			if (m.own == own)
			{
                p.drawACard(CardDB.cardName.frostbolt, own, true);
			}
        }
	}
}