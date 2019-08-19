using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_OG_082 : SimTemplate //* Evolved Kobold
	{
		//Spell Damage +2
		
        public override void onAuraStarts(Playfield p, Minion own)
		{
            if (own.own) p.spellpower += 2;
            else p.enemyspellpower += 2;
		}

        public override void onAuraEnds(Playfield p, Minion m)
        {
            if (m.own) p.spellpower -= 2;
            else p.enemyspellpower -= 2;
        }
	}
}