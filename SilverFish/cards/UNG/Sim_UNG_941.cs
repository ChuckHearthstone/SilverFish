using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_UNG_941 : SimTemplate //* Primordial Glyph
	{
		//Discover a spell. Reduce its Cost by (2).

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.drawACard(CardDB.cardName.frostbolt, ownplay, true);
        }
    }
}