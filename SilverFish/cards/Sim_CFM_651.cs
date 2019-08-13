using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_CFM_651 : SimTemplate //* Naga Corsair
	{
		// Battlecry: Give your weapon +1 Attack.

        public override void getBattlecryEffect(Playfield p, Minion m, Minion target, int choice)
        {
            if (m.own)
            {
                if (p.ownWeaponDurability > 0)
                {
                    p.ownWeaponAttack++;
                    p.minionGetBuffed(p.ownHero, 1, 0);
                }
            }
            else
            {
                if (p.enemyWeaponDurability > 0)
                {
                    p.enemyWeaponAttack++;
                    p.minionGetBuffed(p.enemyHero, 1, 0);
                }
            }
        }
    }
}