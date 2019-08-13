using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_UNG_999t13 : SimTemplate //* Poison Spit
	{
		//Poisonous

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            target.poisonous= true;
        }
    }
}