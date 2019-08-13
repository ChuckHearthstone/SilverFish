using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_UNG_912 : SimTemplate //* Jeweled Macaw
	{
		//Battlecry: Add a random Beast to your hand.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            p.drawACard(CardDB.cardName.rivercrocolisk, own.own, true);
        }
}
}