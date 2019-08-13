using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_OG_150 : SimTemplate //* Aberrant Berserker
	{
		//Enrage: +2 Attack.
		
        public override void onEnrageStart(Playfield p, Minion m)
        {
            m.Angr += 2;
        }

        public override void onEnrageStop(Playfield p, Minion m)
        {
            m.Angr -= 2;
        }
	}
}