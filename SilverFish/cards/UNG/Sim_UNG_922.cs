using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_UNG_922 : SimTemplate //* Explore Un'Goro
	{
		//Replace your deck with copies of "Discover a card."

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
			p.evaluatePenality -= 20;
        }
    }
}