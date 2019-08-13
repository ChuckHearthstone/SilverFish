using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_EX1_055 : SimTemplate //manaaddict
	{

//    erhält jedes mal +2 angriff in diesem zug, wenn ihr einen zauber wirkt.
        public override void onCardIsGoingToBePlayed(Playfield p, Handmanager.Handcard hc, bool wasOwnCard, Minion triggerEffectMinion)
        {
            if (triggerEffectMinion.own == wasOwnCard && hc.card.type == CardDB.cardtype.SPELL)
            {
                p.minionGetTempBuff(triggerEffectMinion, 2, 0);
            }
        }

	}
}