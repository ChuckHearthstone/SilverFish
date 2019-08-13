using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_AT_006 : SimTemplate //* Dalaran Aspirant
	{
		//Inspire: Gain Spell Damage +1.

		public override void onInspire(Playfield p, Minion m, bool own)
        {
			if (m.own == own)
			{
				m.spellpower++;
				if (m.own) p.spellpower++;
				else p.enemyspellpower++;
			}
        }
				
        public override void onAuraEnds(Playfield p, Minion m)
        {
            if (m.own) p.spellpower -= m.spellpower;
            else p.enemyspellpower -= m.spellpower;
        }
	}
}