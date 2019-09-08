using System.Collections.Generic;
using HREngine.Bots;
using SilverFish.Enums;

namespace SilverFish.cards._04Expansion._004CFM
{
	class Sim_CFM_668t : SimTemplate //* Doppelgangster
	{
		// Battlecry: Summon 2 copies of this minion.

        public override void getBattlecryEffect(Playfield p, Minion m, Minion target, int choice)
        {
            p.CallKid(m.handcard.card, m.zonepos, m.own);
            p.CallKid(m.handcard.card, m.zonepos, m.own);
            List<Minion> temp = (m.own) ? p.ownMinions : p.enemyMinions;
            int count = 0;
            foreach (Minion mnn in temp)
            {
                if (mnn.name == CardName.doppelgangster && m.entitiyID != mnn.entitiyID && mnn.playedThisTurn)
                {
                    mnn.setMinionToMinion(m);
                    count++;
                    if (count >= 2) break;
                }
            }
        }
    }
}