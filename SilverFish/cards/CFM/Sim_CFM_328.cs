using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_CFM_328 : SimTemplate //* Fight Promoter
	{
		// Battlecry: If you control a minion with 6 or more Health, draw two cards.

        public override void getBattlecryEffect(Playfield p, Minion m, Minion target, int choice)
        {
            List<Minion> temp = (m.own) ? p.ownMinions : p.enemyMinions;
            foreach (Minion mnn in temp)
            {
                if (mnn.Hp >= 6)
                {
                    p.drawACard(CardDB.cardName.unknown, m.own);
                    p.drawACard(CardDB.cardName.unknown, m.own);
                    break;
                }
            }
        }
    }
}