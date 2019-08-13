using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_CFM_342 : SimTemplate //* Luckydo Buccaneer
	{
		// Battlecry: If your weapon has at least 3 Attack, gain +4/+4.

        public override void getBattlecryEffect(Playfield p, Minion m, Minion target, int choice)
        {
            if (m.own)
            {
                if (p.ownWeaponDurability > 0 && p.ownWeaponAttack > 2)
                {
                    p.minionGetBuffed(m, 4, 4);
                }
            }
            else
            {
                if (p.enemyWeaponDurability > 0 && p.enemyWeaponAttack > 2)
                {
                    p.minionGetBuffed(m, 4, 4);
                }
            }
        }
    }
}