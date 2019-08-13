using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_CFM_308 : SimTemplate //* Kun the Forgotten King
	{
		// Choose One - Gain 10 Armor; or Refresh your Mana Crystals.

        public override void getBattlecryEffect(Playfield p, Minion m, Minion target, int choice)
        {
            if (choice == 1 || (p.ownFandralStaghelm > 0 && m.own))
            {
                p.minionGetArmor(m.own ? p.ownHero : p.enemyHero, 10);
            }

            if (choice == 2 || (p.ownFandralStaghelm > 0 && m.own))
            {
                if (m.own) p.mana = p.ownMaxMana;
                else p.mana = p.enemyMaxMana;
            }
        }
    }
}