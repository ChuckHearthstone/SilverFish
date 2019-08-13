using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_OG_286 : SimTemplate //* Twilight Elder
	{
		//At the end of your turn, give your C'Thun +1/+1 (wherever it is).
		
        public override void onTurnEndsTrigger(Playfield p, Minion triggerEffectMinion, bool turnEndOfOwner)
        {
            if (triggerEffectMinion.own == turnEndOfOwner)
            {
                if (triggerEffectMinion.own)
                {
                    p.anzOgOwnCThunHpBonus++;
                    p.anzOgOwnCThunAngrBonus++;
                }
            }
        }
	}
}