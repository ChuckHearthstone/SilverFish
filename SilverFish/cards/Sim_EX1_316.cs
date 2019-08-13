using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_EX1_316 : SimTemplate //poweroverwhelming
	{
        //Give a friendly minion +4/+4 until end of turn. Then, it dies. Horribly.

		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            p.minionGetBuffed(target, 4, 4);
            if (ownplay)
            {
                target.destroyOnOwnTurnEnd = true;
            }
            else
            {
                target.destroyOnEnemyTurnEnd = true;
            }
		}
	}
}