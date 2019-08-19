using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_AT_073 : SimTemplate //* Competitive spirit
	{
		//Secret: When your turn starts, give your minions +1/+1.

        public override void onSecretPlay(Playfield p, bool ownplay, int number)
        {
            p.allMinionOfASideGetBuffed(ownplay, 1, 1);
        }
    }
}