using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_AT_108 : SimTemplate //* Armored Warhorse
	{
		//Battlecry: Reveal a minion in each deck.If yours costs more, gain Charge.
		
		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            p.minionGetCharge(own); // optimistic
		}
	}
}