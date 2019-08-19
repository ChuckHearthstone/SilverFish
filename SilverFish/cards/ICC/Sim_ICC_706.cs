using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_ICC_706: SimTemplate //* Nerubian Unraveler
    {
        // Spells cost (2) more.

        public override void onAuraStarts(Playfield p, Minion own)
        {
            p.ownSpelsCostMore += 2;
        }

        public override void onAuraEnds(Playfield p, Minion m)
        {
            p.ownSpelsCostMore -= 2;
        }
    }
}