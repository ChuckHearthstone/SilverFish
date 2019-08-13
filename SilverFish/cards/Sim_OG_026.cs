using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_OG_026 : SimTemplate //* Eternal Sentinel
	{
		//Battlecry: Unlock your Overloaded Mana Crystals.
		
		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            if (own.own) p.unlockMana();
		}
	}
}