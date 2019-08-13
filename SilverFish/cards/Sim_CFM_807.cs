using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_CFM_807 : SimTemplate //* Auctionmaster Beardo
	{
		// After you cast a spell, refresh your Hero Power.

        public override void onCardIsGoingToBePlayed(Playfield p, Handmanager.Handcard hc, bool ownplay, Minion m)
        {
            if (m.own == ownplay && hc.card.type == CardDB.cardtype.SPELL)
            {
                if (m.own)
                {
                    p.anzUsedOwnHeroPower = 0;
                    p.ownAbilityReady = true;
                }
                else
                {
                    p.anzUsedEnemyHeroPower = 0;
                    p.enemyAbilityReady = true;
                }
            }
        }
    }
}