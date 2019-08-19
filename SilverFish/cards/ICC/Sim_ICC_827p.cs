using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_ICC_827p: SimTemplate //* Death's Shadow
    {
        // Passive Hero Power: During your turn, add a 'Shadow Reflection' to your hand.

        public override void onTurnStartTrigger(Playfield p, Minion triggerEffectMinion, bool turnStartOfOwner)
        {
            //!triggerEffectMinion = null
            bool found = false;
            if (turnStartOfOwner)
            {
                foreach (Handmanager.Handcard hc in p.owncards)
                {
                    if (hc.card.name == CardDB.cardName.shadowreflection)
                    {
                        found = true;
                        break;
                    }
                }
            }
            if (!found) p.drawACard(CardDB.cardName.shadowreflection, turnStartOfOwner, true);
        }
    }
}