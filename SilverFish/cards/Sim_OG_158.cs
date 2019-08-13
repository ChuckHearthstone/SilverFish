using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_OG_158 : SimTemplate //* Zealous Initiate
	{
		//Deathrattle: Give a random friendly minion +1/+1.
		
        public override void onDeathrattle(Playfield p, Minion m)
        {
			Minion target = (m.own) ? p.searchRandomMinion(p.ownMinions, Playfield.searchmode.searchLowestAttack) : p.searchRandomMinion(p.enemyMinions, Playfield.searchmode.searchLowestAttack);
			if (target != null) p.minionGetBuffed(target, 1, 1);
        }
    }
}