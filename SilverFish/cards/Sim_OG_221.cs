using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_OG_221 : SimTemplate //* Selfless Hero
	{
		//Deathrattle: Give a random friendly minion Divine Shield.

        public override void onDeathrattle(Playfield p, Minion m)
        {
			Minion target = (m.own) ? p.searchRandomMinion(p.ownMinions, searchmode.searchLowestAttack) : p.searchRandomMinion(p.enemyMinions, searchmode.searchLowestAttack);
			if (target != null) target.divineshild = true;
        }
    }
}