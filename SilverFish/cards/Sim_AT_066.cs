using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_AT_066 : SimTemplate //* Orgrimmar Aspirant
	{
		//Inspire: Give your weapon +1 Attack.

		public override void onInspire(Playfield p, Minion m, bool own)
        {
			if (m.own == own)
			{
                if (own)
                {
                    if (p.ownWeapon.Durability > 0) p.ownWeapon.Angr++;
                }
                else
                {
                    if (p.enemyWeapon.Durability > 0) p.enemyWeapon.Angr++;
                }
			}
        }
	}
}