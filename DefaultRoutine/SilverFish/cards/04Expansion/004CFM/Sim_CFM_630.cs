using System;
using Chuck.SilverFish;

namespace SilverFish.cards._04Expansion._004CFM
{
	class Sim_CFM_630 : SimTemplate //* Counterfeit Coin
	{
		// Gain 1 Mana Crystal this turn only.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.mana = Math.Min(p.mana + 1, 10);
        }
    }
}