using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_GVG_023 : SimTemplate //Goblin Auto-Barber
    {

        //    Battlecry: Give your weapon +1 Attack.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            if (own.own)
            {
                if (p.ownWeapon.Durability >= 1)
                {
                    p.ownWeapon.Angr += 1;
                    p.minionGetBuffed(p.ownHero, 1, 0);
                }
                
            }
            else
            {
                if (p.enemyWeapon.Durability >= 1)
                {
                    p.enemyWeapon.Angr += 1;
                    p.minionGetBuffed(p.enemyHero, 1, 0);
                }
                
            }
        }


    }

}