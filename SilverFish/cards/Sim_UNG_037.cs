using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_UNG_037 : SimTemplate //* Tortollan Shellraiser
	{
		//Taunt. Deathrattle: Give a random friendly minion +1/+1.

        public override void onDeathrattle(Playfield p, Minion m)
        {
			Minion target = (m.own) ? p.searchRandomMinion(p.ownMinions, searchmode.searchLowestAttack) : p.searchRandomMinion(p.enemyMinions, searchmode.searchLowestAttack);
			if (target != null) p.minionGetBuffed(target, 1, 1);
        }
    }
}