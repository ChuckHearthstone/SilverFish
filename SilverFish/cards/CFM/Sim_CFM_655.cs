using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_CFM_655 : SimTemplate //* Toxic Sewer Ooze
	{
		// Battlecry: Remove 1 Durability from your opponent's weapon.

        public override void getBattlecryEffect(Playfield p, Minion m, Minion target, int choice)
        {
            p.lowerWeaponDurability(1, !m.own);
        }
    }
}