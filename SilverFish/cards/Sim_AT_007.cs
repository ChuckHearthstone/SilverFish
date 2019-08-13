using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_AT_007 : SimTemplate //* Spellslinger
	{
		//Battlecry: Add a random spell card to each player's hand.
		
		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            p.drawACard(CardDB.cardName.frostbolt, true, true);
            p.drawACard(CardDB.cardName.frostbolt, false, true);
		}
	}
}