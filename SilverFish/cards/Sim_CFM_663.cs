using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_CFM_663 : SimTemplate //* Kabal Trafficker
	{
		// At the end of your turn, add a random Demon to your hand.

        public override void onTurnEndsTrigger(Playfield p, Minion triggerEffectMinion, bool turnEndOfOwner)
        {
            if (triggerEffectMinion.own == turnEndOfOwner)
            {
                p.drawACard(CardDB.cardName.malchezaarsimp, turnEndOfOwner, true);
            }
        }
    }
}