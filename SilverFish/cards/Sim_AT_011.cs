using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_AT_011 : SimTemplate //* Holy Champion
	{
		// Whenever a character is healed, gain +2 attack.
        
        public override void onACharGotHealed(Playfield p, Minion triggerEffectMinion, int charsGotHealed)
        {
            p.minionGetBuffed(triggerEffectMinion, 2 * charsGotHealed, 0);
        }
	}
}