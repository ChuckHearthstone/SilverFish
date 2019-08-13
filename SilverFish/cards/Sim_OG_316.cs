using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_OG_316 : SimTemplate //* Herald Volazj
	{
		//Battlecry: Summon a 1/1 copy of each of your other minions.

		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            List<Minion> temp = (own.own) ? p.ownMinions : p.enemyMinions;
		    foreach (Minion m in (own.own) ? p.ownMinions.ToArray() : p.enemyMinions.ToArray())
		    {
		        if (m.entityID == own.entityID) continue;
		        int pos = (own.own) ? p.ownMinions.Count : p.enemyMinions.Count;
		        p.callKid(m.handcard.card, pos, own.own, true);
		        if (pos < 6)
		        {
		            Minion kidminion = temp[own.zonepos - 1]; //volazj isn't on the playfield yet but the kid is where volazj will be

		            int angr = 1 - kidminion.Angr;
		            int hp = 1 - kidminion.maxHp;

		            p.minionGetBuffed(kidminion, angr, hp);
		        }
		    }
        }
    }
}