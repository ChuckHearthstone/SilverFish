using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_UNG_999t2 : SimTemplate //* Living Spores
	{
		//Deathrattle: Summon two 1/1 Plants.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            target.livingspores++;
        }
    }
}