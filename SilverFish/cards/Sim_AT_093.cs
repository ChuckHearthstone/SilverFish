using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_AT_093 : SimTemplate //* Frigid Snobold
	{
		//Spell Damage +1.

        public override void onAuraStarts(Playfield p, Minion own)
		{
            if (own.own) p.spellpower++;
            else p.enemyspellpower++;
		}

        public override void onAuraEnds(Playfield p, Minion m)
        {
            if (m.own) p.spellpower--;
            else p.enemyspellpower--;
        }
	}
}