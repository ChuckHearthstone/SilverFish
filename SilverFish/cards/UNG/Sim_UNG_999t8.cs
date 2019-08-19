using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_UNG_999t8 : SimTemplate //* Crackling Shield
	{
		//Divine Shield

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
			target.divineshild = true;
        }
    }
}