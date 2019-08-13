using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_CFM_807 : SimTemplate //* Auctionmaster Beardo
	{
		// After you cast a spell, refresh your Hero Power.

        public override void onCardIsGoingToBePlayed(Playfield p, CardDB.Card c, bool wasOwnCard, Minion triggerEffectMinion, Minion target, int choice)
        {
            if (triggerEffectMinion.own == wasOwnCard && c.type == CardDB.cardtype.SPELL)
            {
                if (triggerEffectMinion.own)
                {
                    p.ownHeroPowerAllowedQuantity++;
                    p.ownAbilityReady = true;
                }
                else
                {
                    p.enemyHeroPowerAllowedQuantity++;
                    p.enemyAbilityReady = true;
                }
            }
        }
    }
}