using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_AT_109 : SimTemplate //* Argent Watchman
	{
		//Can't Attack. Inspire: Can attack as normal this turn.

		public override void onInspire(Playfield p, Minion m, bool own)
        {
			if (m.own == own)
			{
                m.cantAttack = false;
				m.updateReadyness();
			}
        }
		
		public override void onTurnEndsTrigger(Playfield p, Minion triggerEffectMinion, bool turnEndOfOwner)
        {
            if (triggerEffectMinion.own == turnEndOfOwner)
            {
                if (!triggerEffectMinion.silenced) triggerEffectMinion.cantAttack = true;
            }
        }
	}
}