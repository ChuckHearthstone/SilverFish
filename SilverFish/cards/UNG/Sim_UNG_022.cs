using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_UNG_022 : SimTemplate //* Mirage Caller
	{
		//Battlecry: Choose a friendly minion. Summon a 1/1 copy of it.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            if (target != null && p.ownMinions.Count < 7)
            {
                p.CallKid(own.handcard.card, own.zonepos, own.own);
                p.ownMinions[own.zonepos].setMinionToMinion(target);
                p.ownMinions[own.zonepos].Attack = 1;
                p.ownMinions[own.zonepos].HealthPoints = 1;
                p.ownMinions[own.zonepos].maxHp = 1;
            }
        }
    }
}