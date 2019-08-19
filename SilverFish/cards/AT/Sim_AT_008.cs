using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_AT_008 : SimTemplate //* Coldarra Drake
	{
		//You can use your Hero Power any number of times.
	
        public override void onAuraStarts(Playfield p, Minion own)
		{
            if (own.own) p.ownHeroPowerAllowedQuantity += 100;
            else p.enemyHeroPowerAllowedQuantity += 100;
		}

        public override void onAuraEnds(Playfield p, Minion own)
        {
            if (own.own)
			{
				p.ownHeroPowerAllowedQuantity -= 100;
				if (p.anzUsedOwnHeroPower >= p.ownHeroPowerAllowedQuantity) p.ownAbilityReady = false;
			}
            else
			{
				p.enemyHeroPowerAllowedQuantity -= 100;
                if (p.anzUsedEnemyHeroPower >= p.enemyHeroPowerAllowedQuantity) p.enemyAbilityReady = false;
			}
        }
	}
}