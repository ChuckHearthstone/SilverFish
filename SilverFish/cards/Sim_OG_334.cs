using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_OG_334 : SimTemplate //* Hooded Acolyte
	{
		//Whenever a character is healed, give your C'Thun +1/+1 (wherever it is)
		
        public override void onAHeroGotHealedTrigger(Playfield p, Minion triggerEffectMinion)
        {
            p.anzOgOwnCThunHpBonus++;
            p.anzOgOwnCThunAngrBonus++;
        }

        public override void onAMinionGotHealedTrigger(Playfield p, Minion triggerEffectMinion)
        {
            p.anzOgOwnCThunHpBonus++;
            p.anzOgOwnCThunAngrBonus++;
        }
    }
}