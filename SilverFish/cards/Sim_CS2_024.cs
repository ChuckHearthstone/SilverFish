using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_CS2_024 : SimTemplate //Frostbolt
    {
        //Deal $3 damage to a character and Freeze it.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            int dmg = (ownplay) ? p.getSpellDamageDamage(3) : p.getEnemySpellDamageDamage(3);
            p.minionGetFrozen(target);
            p.minionGetDamageOrHeal(target,dmg);
        }
    }
}
