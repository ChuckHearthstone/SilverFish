using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_AT_032 : SimTemplate //* Shady Dealer
	{
		//Battlecry: If you have a Pirate, gain +1/+1.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            List<Minion> temp = (own.own) ? p.ownMinions : p.enemyMinions;
            foreach (Minion m in temp)
            {
                if ((TAG_RACE)m.handcard.card.race == TAG_RACE.PIRATE)
                {
                    p.minionGetBuffed(own, 1, 1);
					break;
                }
            }
        }
    }
}