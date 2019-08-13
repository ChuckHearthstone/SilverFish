using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_ICC_068: SimTemplate //* Ice Walker
    {
        // Your Hero Power also Freezes the target.

        public override void onAuraStarts(Playfield p, Minion own)
        {
            if (own.own) p.ownAbilityFreezesTarget++;
            else p.enemyAbilityFreezesTarget++;
        }

        public override void onAuraEnds(Playfield p, Minion own)
        {
            if (own.own) p.ownAbilityFreezesTarget--;
            else p.enemyAbilityFreezesTarget--;
        }
    }
}