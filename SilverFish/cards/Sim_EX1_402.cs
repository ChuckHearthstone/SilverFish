using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_EX1_402 : SimTemplate //armorsmith
	{

//    erhaltet jedes mal 1 rüstung, wenn ein befreundeter diener schaden erleidet.

        public override void onMinionGotDmgTrigger(Playfield p, Minion triggerEffectMinion, bool ownDmgdmin)
        {
            if (triggerEffectMinion.own == ownDmgdmin)
            {
                p.minionGetArmor(triggerEffectMinion.own ? p.ownHero : p.enemyHero, 1);
            }
        }
	}
}