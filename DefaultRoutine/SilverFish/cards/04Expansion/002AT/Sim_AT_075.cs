using System.Collections.Generic;
using HREngine.Bots;

namespace SilverFish.cards._04Expansion._002AT
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
                if (m.name == CardDB.CardName.silverhandrecruit) p.minionGetBuffed(m, 1, 0);
            }            
		}

        public override void onAuraEnds(Playfield p, Minion own)
        {
            if (own.own) p.anzOwnWarhorseTrainer--;
            else p.anzEnemyWarhorseTrainer--;
			
			List<Minion> temp = (own.own) ? p.ownMinions : p.enemyMinions;
            foreach (Minion m in temp)
            {
                if (m.name == CardDB.CardName.silverhandrecruit) p.minionGetBuffed(m, -1, 0);
            }
        }
	}
}