using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_UNG_999t7 : SimTemplate //* Lightning Speed
	{
		//Windfury

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.minionGetWindfurry(target);
        }
    }
}