using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_OG_200 : SimTemplate //* Validated Doomsayer
    {
        //At the start of your turn, set this minion's Attack to 7.

        public override void onTurnStartTrigger(Playfield p, Minion triggerEffectMinion, bool turnStartOfOwner)
        {
            if (triggerEffectMinion.own == turnStartOfOwner)
            {
                if (triggerEffectMinion.Angr != 7) triggerEffectMinion.Angr = 7;
            }
        }
    }
}