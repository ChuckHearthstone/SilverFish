using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_UNG_109 : SimTemplate //* Elder Longneck
	{
		//Battlecry: If you're holding a minion with 5 or more Attack, Adapt.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
			if(own.own)
			{
				foreach (Handmanager.Handcard hc in p.owncards)
				{
					if ((hc.card.Attack + hc.addattack) >= 5)
					{
						p.getBestAdapt(own);
						break;
					}
				}
			}
        }
    }
}