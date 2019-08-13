using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_OG_218 : SimTemplate //* Bloodhoof Brave
	{
		//Taunt. Enrage:+3 Attack.
		
        public override void onEnrageStart(Playfield p, Minion m)
        {
            m.Angr += 3;
        }

        public override void onEnrageStop(Playfield p, Minion m)
        {
            m.Angr -= 3;
        }
	}
}