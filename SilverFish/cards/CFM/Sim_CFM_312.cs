using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_CFM_312 : SimTemplate //* Jade Chieftain
	{
		// Battlecry: Summon a Jade Golem. Give it Taunt.

        public override void getBattlecryEffect(Playfield p, Minion m, Minion target, int choice)
        {
            p.callKid(p.getNextJadeGolem(m.own), m.zonepos, m.own);
            Minion mnn = m.own ? p.ownMinions[m.zonepos] : p.enemyMinions[m.zonepos];
            if (mnn.playedThisTurn && !mnn.taunt)
            {
                mnn.taunt = true;
                if (mnn.own) p.anzOwnTaunt++;
                else p.anzEnemyTaunt++;
            }
        }
    }
}