using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_LOE_051 : SimTemplate //* Jungle Moonkin
	{
		//Both players have Spell Damage +2.

        public override void onAuraStarts(Playfield p, Minion own)
		{
			p.spellpower+=2;
			p.enemyspellpower+=2;
		}

        public override void onAuraEnds(Playfield p, Minion m)
        {
			p.spellpower-=2;
			p.enemyspellpower-=2;
        }
	}
}