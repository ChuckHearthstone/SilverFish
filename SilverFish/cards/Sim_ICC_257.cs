using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_ICC_257: SimTemplate //* Corpse Raiser
    {
        // Battlecry: Give a friendly minion "Deathrattle: Resummon this minion."

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            if (target != null) target.ancestralspirit++;
		}
	}
}