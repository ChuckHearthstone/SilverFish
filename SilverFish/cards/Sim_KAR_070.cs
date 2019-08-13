using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_KAR_070 : SimTemplate //* Ethereal Peddler
	{
		//Battlecry: Reduce the Cost of cards in your hand from other classes by (2).
		
		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
			if (own.own)
			{
                int heroClass = (int)p.ownHeroStartClass;
				foreach (Handmanager.Handcard hc in p.owncards)
                {
                    if (hc.card.Class != heroClass && hc.card.Class != 0) hc.manacost = Math.Max(0, hc.manacost - 2);
                }
			}
		}
	}
}