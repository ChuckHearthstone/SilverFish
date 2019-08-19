using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_UNG_202 : SimTemplate //* Fire Plume Harbinger
	{
		//Battlecry: Reduce the Cost of Elementals in your hand by (1).
        
		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            if (own.own)
            {
                foreach (Handmanager.Handcard hc in p.owncards)
                {
                    if ((TAG_RACE)hc.card.race == TAG_RACE.ELEMENTAL) hc.manacost--;
                }
            }
		}
	}
}