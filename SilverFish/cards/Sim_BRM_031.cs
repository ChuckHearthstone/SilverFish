using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_BRM_031 : SimTemplate //* Chromaggus
	{
		// Whenever you draw a card, put another copy into your hand.
		
        public override void onAuraStarts(Playfield p, Minion own)
        {
            if (own.own) p.anzOwnChromaggus++;
            else p.anzEnemyChromaggus++;
        }

        public override void onAuraEnds(Playfield p, Minion own)
        {
            if (own.own) p.anzOwnChromaggus--;
            else p.anzEnemyChromaggus--;
        }
	}
}
