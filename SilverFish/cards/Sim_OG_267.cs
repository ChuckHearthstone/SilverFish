using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_OG_267 : SimTemplate //* Southsea Squidface
	{
		//Deathrattle: Give your weapon +2 Attack.
		
        public override void onDeathrattle(Playfield p, Minion m)
        {
            if (m.own)
            {
                if (p.ownWeapon.Durability >= 1)
                {
                    p.ownWeapon.Angr += 2;
                    p.ownHero.Angr += 2;
                }
            }
            else
            {
                if (p.enemyWeapon.Durability >= 1)
                {
                    p.enemyWeapon.Angr += 2;
                    p.enemyHero.Angr += 2;
                }
            }
        }
	}
}