using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_ICC_233: SimTemplate //* Doomerang
    {
        // Throw your weapon at a minion. It deals it's damage, then returns to your hand.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            Weapon w = ownplay ? p.ownWeapon : p.enemyWeapon;

            p.minionGetDamageOrHeal(target, w.Angr);
            if (w.poisonous) p.minionGetDestroyed(target);

            p.lowerWeaponDurability(1000, ownplay);
            p.drawACard(w.name, ownplay, true);
        }
    }
}