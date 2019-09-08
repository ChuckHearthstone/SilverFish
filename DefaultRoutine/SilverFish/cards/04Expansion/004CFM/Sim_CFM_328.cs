using System.Collections.Generic;
using HREngine.Bots;
using SilverFish.Enums;

namespace SilverFish.cards._04Expansion._004CFM
{
	class Sim_CFM_328 : SimTemplate //* Fight Promoter
	{
		// Battlecry: If you control a minion with 6 or more Health, draw two cards.

        public override void getBattlecryEffect(Playfield p, Minion m, Minion target, int choice)
        {
            List<Minion> temp = (m.own) ? p.ownMinions : p.enemyMinions;
            foreach (Minion mnn in temp)
            {
                if (mnn.HealthPoints >= 6)
                {
                    p.drawACard(CardName.unknown, m.own);
                    p.drawACard(CardName.unknown, m.own);
                    break;
                }
            }
        }
    }
}