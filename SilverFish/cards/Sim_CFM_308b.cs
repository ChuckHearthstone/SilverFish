using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_CFM_308b : SimTemplate //* Forgotten Mana
	{
		// Refresh your Mana Crystals.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            if (ownplay) p.mana = p.ownMaxMana;
            else p.mana = p.enemyMaxMana;
        }
    }
}