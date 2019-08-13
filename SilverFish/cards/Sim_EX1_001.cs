using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_EX1_001 : SimTemplate //* lightwarden
	{
        // Whenever a character is healed, gain +2 Attack.

        public override void onACharGotHealed(Playfield p, Minion triggerEffectMinion, int charsGotHealed)
        {
            p.minionGetBuffed(triggerEffectMinion, 2 * charsGotHealed, 0);
        }
	}
}