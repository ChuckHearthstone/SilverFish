using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_ICC_808: SimTemplate //* Crypt Lord
    {
        // Taunt. After you summon a minion, gain +1 Health.
        
        public override void onMinionWasSummoned(Playfield p, Minion m, Minion summonedMinion)
        {
            if (m.entitiyID != summonedMinion.entitiyID && m.own == summonedMinion.own)
            {
                p.minionGetBuffed(m, 0, 1);
            }
        }
    }
}