using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_AT_038 : SimTemplate //* Darnassus Aspirant
    {
		//Battlecry: Gain an empty mana crystal.
		//Deathrattle: Destroy a mana crystal.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            if (own.own) p.ownMaxMana = Math.Min(10, p.ownMaxMana + 1);
            else p.enemyMaxMana = Math.Min(10, p.enemyMaxMana + 1);
        }

        public override void onDeathrattle(Playfield p, Minion m)
        {
			if (m.own) p.ownMaxMana--;
            else p.enemyMaxMana--;
        }
    }
}