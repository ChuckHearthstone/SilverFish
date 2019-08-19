using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_UNG_916 : SimTemplate //* Stampede
	{
		//Each time you play a Beast this turn, add a random Beast to your hand.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            if (ownplay)
            {
                p.stampede++;
            }
        }
    }
}