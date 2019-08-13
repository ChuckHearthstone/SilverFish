using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_OG_334 : SimTemplate //* Hooded Acolyte
	{
		// Whenever a character is healed, give your C'Thun +1/+1 (wherever it is)

        public override void onACharGotHealed(Playfield p, Minion triggerEffectMinion, int charsGotHealed)
        {
            p.cthunGetBuffed(charsGotHealed, charsGotHealed, 0);
        }
	}
}