using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_OG_322 : SimTemplate //* Blackwater Pirate
    {
        //Your weapons cost (2) less.
        
        public override void onAuraStarts(Playfield p, Minion own)
        {
            if (own.own) p.blackwaterpirate++;
        }

        public override void onAuraEnds(Playfield p, Minion m)
        {
            if (m.own) p.blackwaterpirate--;
        }
    }
}