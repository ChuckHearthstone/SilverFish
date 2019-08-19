using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_UNG_927 : SimTemplate //* Sudden Genesis
	{
		//Summon copies of your damaged minions.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            List<Minion> temp = (ownplay) ? p.ownMinions : p.enemyMinions;
            List<Minion> temp2;
            int pos = temp.Count;
			bool spawnKid = false;
            if (pos > 0 && pos < 7)
            {
                foreach (Minion m in temp.ToArray())
                {
					if (!m.wounded) continue;
                    p.callKid(m.handcard.card, pos, ownplay, spawnKid);
					spawnKid = true;
                    temp2 = (ownplay) ? p.ownMinions : p.enemyMinions;
                    temp2[pos].setMinionToMinion(m);
                    pos++;
                    if (pos > 6) break;
                }
            }
        }
    }
}