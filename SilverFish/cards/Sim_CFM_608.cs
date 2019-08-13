using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_CFM_608 : SimTemplate //* Blastcrystal Potion
	{
		// Destroy a minion and one of your Mana Crystals.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.minionGetDestroyed(target);
            if (ownplay) p.ownMaxMana--;
            else p.enemyMaxMana--;
        }
    }
}