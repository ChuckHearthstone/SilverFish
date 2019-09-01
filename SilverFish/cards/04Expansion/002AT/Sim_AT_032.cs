using System.Collections.Generic;
using HREngine.Bots;

namespace SilverFish.cards._04Expansion._002AT
{
	class Sim_AT_032 : SimTemplate //* Shady Dealer
	{
		//Battlecry: If you have a Pirate, gain +1/+1.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            List<Minion> temp = (own.own) ? p.ownMinions : p.enemyMinions;
            foreach (Minion m in temp)
            {
                if ((TAG_RACE)m.handcard.card.race == TAG_RACE.PIRATE)
                {
                    p.minionGetBuffed(own, 1, 1);
					break;
                }
            }
        }
    }
}