using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_UNG_845 : SimTemplate //* Igneous Elemental
	{
		//Deathrattle: Add two 1/2 Elementals to your hand.

        public override void onDeathrattle(Playfield p, Minion m)
        {
            p.drawACard(CardDB.cardIDEnum.UNG_809t1, m.own, true);
            p.drawACard(CardDB.cardIDEnum.UNG_809t1, m.own, true);
        }
	}
}