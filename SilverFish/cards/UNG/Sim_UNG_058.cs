using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_UNG_058 : SimTemplate //* Razorpetal Lasher
	{
		//Battlecry: Add a Razorpetal to your hand that deals 1 damage.

		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            p.drawACard(CardDB.cardIDEnum.UNG_057t1, own.own, true);
        }
	}
}