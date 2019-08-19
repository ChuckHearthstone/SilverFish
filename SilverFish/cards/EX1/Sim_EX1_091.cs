using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_EX1_091 : SimTemplate //* Cabal Shadow Priest
	{
        //Battlecry: Take control of an enemy minion that has 2 or less Attack.

		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            if (target != null)
            {
                List<Minion> temp = (own.own) ? p.ownMinions : p.enemyMinions;
                int num = temp.Count;
                p.minionGetControlled(target, own.own, false, true);
                if (num < 7)
                {
                    foreach (Minion m in temp)
                    {
                        if (m.name == CardDB.cardName.knifejuggler && !m.silenced) m.handcard.card.sim_card.onMinionWasSummoned(p, m, temp[num]);
                    }
                }
            }
		}
	}
}