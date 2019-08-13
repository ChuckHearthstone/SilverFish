using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_AT_003 : SimTemplate //* Fallen Hero
	{
		//Your Hero Power deals 1 extra damage.

        public override void onAuraStarts(Playfield p, Minion own)
		{
            if (own.own) p.ownHeroPowerExtraDamage++;
            else p.enemyHeroPowerExtraDamage++;
		}

        public override void onAuraEnds(Playfield p, Minion own)
        {
            if (own.own) p.ownHeroPowerExtraDamage--;
            else p.enemyHeroPowerExtraDamage--;
        }
	}
}