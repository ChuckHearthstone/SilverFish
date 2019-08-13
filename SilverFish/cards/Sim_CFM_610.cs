using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_CFM_610 : SimTemplate //* Crystalweaver
	{
		// Battlecry: Give your Demons +1/+1.

        public override void getBattlecryEffect(Playfield p, Minion m, Minion target, int choice)
        {
            List<Minion> temp = (m.own) ? p.ownMinions : p.enemyMinions;
            foreach (Minion mnn in temp)
            {
                if ((TAG_RACE)mnn.handcard.card.race == TAG_RACE.DEMON && mnn.entitiyID != m.entitiyID) p.minionGetBuffed(mnn, 1, 1);
            }
        }
    }
}