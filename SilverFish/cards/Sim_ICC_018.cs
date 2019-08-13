using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_ICC_018: SimTemplate //* Phantom Freebooter
    {
        // Battlecry: Gain stats equal to your weapon's.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            p.minionGetBuffed(own, 1, 1);
            if (own.own)
            {
                own.Angr += p.ownWeapon.Angr;
                own.Hp += p.ownWeapon.Durability;
                own.maxHp += p.ownWeapon.Durability;
            }
            else
            {
                own.Angr += p.enemyWeapon.Angr;
                own.Hp += p.enemyWeapon.Durability;
                own.maxHp += p.enemyWeapon.Durability;
            }
        }
    }
}
