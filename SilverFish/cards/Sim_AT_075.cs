using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_AT_075 : SimTemplate //* Warhorse Trainer
	{
		//Your Silver Hand Recruits have +1 Attack.

        public override void onAuraStarts(Playfield p, Minion own)
		{
            if (own.own) p.anzOwnWarhorseTrainer++;
            else p.anzEnemyWarhorseTrainer++;
			
			List<Minion> temp = (own.own) ? p.ownMinions : p.enemyMinions;
            foreach (Minion m in temp)
            {
                if (m.name == CardDB.cardName.silverhandrecruit) p.minionGetBuffed(m, 1, 0);
            }            
		}

        public override void onAuraEnds(Playfield p, Minion own)
        {
            if (own.own) p.anzOwnWarhorseTrainer--;
            else p.anzEnemyWarhorseTrainer--;
			
			List<Minion> temp = (own.own) ? p.ownMinions : p.enemyMinions;
            foreach (Minion m in temp)
            {
                if (m.name == CardDB.cardName.silverhandrecruit) p.minionGetBuffed(m, -1, 0);
            }
        }
	}
}