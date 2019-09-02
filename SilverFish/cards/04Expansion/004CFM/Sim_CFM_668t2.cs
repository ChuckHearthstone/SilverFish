using System.Collections.Generic;
using HREngine.Bots;

namespace SilverFish.cards._04Expansion._004CFM
{
	class Sim_CFM_668t2 : SimTemplate //* Doppelgangster
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
                if (mnn.name == CardDB.cardName.doppelgangster && m.entitiyID != mnn.entitiyID && mnn.playedThisTurn)
                {
                    mnn.setMinionToMinion(m);
                    count++;
                    if (count >= 2) break;
                }
            }
        }
    }
}