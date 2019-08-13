using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_UNG_057 : SimTemplate //* Razorpetal Volley
	{
		//Add two Razorpetals to your hand that deal 1 damage.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.drawACard(CardDB.cardIDEnum.UNG_057t1,ownplay, true);
            p.drawACard(CardDB.cardIDEnum.UNG_057t1, ownplay, true);
        }
    }
}