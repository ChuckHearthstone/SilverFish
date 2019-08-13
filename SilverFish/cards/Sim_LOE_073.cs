using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_LOE_073 : SimTemplate //* Fossilized Devilsaur
	{
		//Battlecry: If you control a Beast, gain Taunt.
		
        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            List<Minion> temp = (own.own) ? p.ownMinions : p.enemyMinions;
            foreach (Minion m in temp)
            {
                if ((TAG_RACE)m.handcard.card.race == TAG_RACE.PET)
                {
					own.taunt = true;
                    if (own.own) p.anzOwnTaunt++;
                    else p.anzEnemyTaunt++;
                    break;
                }
            }
        }
    }
}