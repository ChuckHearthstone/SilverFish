using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_CS2_221 : SimTemplate //spitefulsmith
	{

//    wutanfall:/ eure waffe hat +2 angriff.
        public override void onEnrageStart(Playfield p, Minion m)
        {
            if (m.own)
            {
                if (p.ownWeapon.Durability >= 1)
                {
                    p.minionGetBuffed(p.ownHero, 2, 0);
                    p.ownWeapon.Angr += 2;
                }
            }
            else 
            {
                if (p.enemyWeapon.Durability >= 1)
                {
                    p.enemyWeapon.Angr += 2;
                    p.minionGetBuffed(p.enemyHero, 2, 0);
                }
            }
        }

        public override void onEnrageStop(Playfield p, Minion m)
        {
            if (m.own)
            {
                if (p.ownWeapon.Durability >= 1)
                {
                    p.minionGetBuffed(p.ownHero, -2, 0);
                    p.ownWeapon.Angr -= 2;
                }
            }
            else
            {
                if (p.enemyWeapon.Durability >= 1)
                {
                    p.enemyWeapon.Angr -= 2;
                    p.minionGetBuffed(p.enemyHero, -2, 0);
                }
            }
        }

	}

}