using System.Collections.Generic;
using Chuck.SilverFish;

namespace SilverFish.cards._04Expansion._005UNG
{
	class Sim_UNG_800 : SimTemplate //* Terrorscale Stalker
	{
		//Battlecry: Trigger a friendly minion's Deathrattle.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            if (target != null) p.doDeathrattles(new List<Minion>() { target });
        }
    }
}