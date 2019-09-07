using System.Collections.Generic;
using HREngine.Bots;

namespace SilverFish.cards._04Expansion._003OG
{
	class Sim_OG_316 : SimTemplate //* Herald Volazj
	{
		//Battlecry: Summon a 1/1 copy of each of your other minions.

		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            List<Minion> temp = (own.own) ? p.ownMinions : p.enemyMinions;
            int pos = temp.Count;
            if (pos > 1)
            {
                foreach (Minion m in (own.own) ? p.ownMinions.ToArray() : p.enemyMinions.ToArray())
                {
                    if (m.entitiyID == own.entitiyID) continue;
                    pos = (own.own) ? p.ownMinions.Count : p.enemyMinions.Count;
                    if (pos > 6) break;
                    p.CallKid(m.handcard.card, pos, own.own);
                    temp = (own.own) ? p.ownMinions : p.enemyMinions;
                    temp[pos].HealthPoints = 1;
                    temp[pos].Attack = 1;
                }
            }
        }
    }
}