using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_NAX2_05 : SimTemplate //* Worshipper
	{
		// Your hero has +1 Attack on your turn.

        public override void onAuraStarts(Playfield p, Minion own)
		{
            p.minionGetBuffed(own.own ? p.ownHero : p.enemyHero, 1, 0);
		}

        public override void onAuraEnds(Playfield p, Minion own)
        {
            p.minionGetBuffed(own.own ? p.ownHero : p.enemyHero, -1, 0);
        }
	}
}