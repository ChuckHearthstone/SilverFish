using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_AT_047 : SimTemplate //* Draenei Totemcarver
	{
		//Battlecry: Gain +1/+1 for each friendly Totem.

		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            int gain = 0;
            List<Minion> temp  = (own.own) ? p.ownMinions : p.enemyMinions;
            foreach (Minion m in temp)
            {
                if ((TAG_RACE)m.handcard.card.race == TAG_RACE.TOTEM) gain++;
            }
            if(gain >= 1) p.minionGetBuffed(own, gain, gain);
		}
	}
}