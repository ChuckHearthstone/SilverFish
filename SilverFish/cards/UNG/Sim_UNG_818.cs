using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_UNG_818 : SimTemplate //* Volatile Elemental
	{
		//Deathrattle: Deal 3 damage to a random enemy minion.

        public override void onDeathrattle(Playfield p, Minion m)
        {
            Minion target = null;
            if (m.own)
            {
                target = p.getEnemyCharTargetForRandomSingleDamage(3, true);
            }
            else
            {
                target = p.searchRandomMinion(p.ownMinions, searchmode.searchHighestAttack); //damage the Highest (pessimistic)
            }
            if (target != null) p.minionGetDamageOrHeal(target, 3);
        }
    }
}