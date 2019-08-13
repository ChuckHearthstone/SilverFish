using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_UNG_111t1 : SimTemplate //* Mana Treant
	{
		//Deathrattle: Gain an empty Mana Crystal.

        public override void onDeathrattle(Playfield p, Minion m)
        {
            if (m.own) p.ownMaxMana = Math.Min(10, p.ownMaxMana + 1);
            else p.enemyMaxMana = Math.Min(10, p.enemyMaxMana + 1);
        }
    }
}