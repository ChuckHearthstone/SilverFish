using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_OG_310 : SimTemplate //* Steward of Darkshire
	{
		//Whenever you summon a 1-Health minion, give it Divine Shield.

        public override void onMinionWasSummoned(Playfield p, Minion m, Minion summonedMinion)
        {
            if (summonedMinion.Hp == 1 && m.own == summonedMinion.own && m.entitiyID != summonedMinion.entitiyID)
            {
                summonedMinion.divineshild = true;
            }
        }
    }
}