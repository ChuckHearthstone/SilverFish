using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_UNG_900 : SimTemplate //* Spiritsinger Umbra
	{
		//After you summon a minion, trigger its Deathrattle effect.

        public override void onMinionWasSummoned(Playfield p, Minion m, Minion summonedMinion)
        {
            if (m.entitiyID != summonedMinion.entitiyID && m.own == summonedMinion.own)
            {
                p.doDeathrattles(new List<Minion>() { summonedMinion });
            }
        }
    }
}