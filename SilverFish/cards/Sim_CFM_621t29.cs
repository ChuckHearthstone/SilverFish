using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_CFM_621t29 : SimTemplate //* Mystic Wool
	{
		// Transform all minions into 1/1 Sheep.
		
		private CardDB.Card sheep = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.CFM_621_m5);

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            foreach (Minion m in p.ownMinions)
            {
				p.minionTransform(m, sheep);
            }
            foreach (Minion m in p.enemyMinions)
            {
				p.minionTransform(m, sheep);
            }
        }
    }
}