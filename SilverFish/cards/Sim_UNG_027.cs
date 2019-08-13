using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_UNG_027 : SimTemplate //* Pyros
	{
		//Deathrattle: Return this to your hand as a 6/6 that costs (6).

        public override void onDeathrattle(Playfield p, Minion m)
        {
		    p.drawACard(CardDB.cardIDEnum.UNG_027t2, m.own, true);
        }
	}
}