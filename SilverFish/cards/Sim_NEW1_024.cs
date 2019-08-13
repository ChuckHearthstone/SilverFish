using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_NEW1_024 : SimTemplate //captaingreenskin
	{
//    kampfschrei:/ verleiht eurer waffe +1/+1.
		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            if (own.own)
            {
                if (p.ownWeapon.Durability >= 1)
                {
                    p.ownWeapon.Durability++;
                    p.ownWeapon.Angr++;
                    p.minionGetBuffed(p.ownHero, 1, 0);
                }
            }
            else
            {
                if (p.enemyWeapon.Durability >= 1)
                {
                    p.enemyWeapon.Durability++;
                    p.enemyWeapon.Angr++;
                    p.minionGetBuffed(p.enemyHero, 1, 0);
                }
            }
		}

	}
}