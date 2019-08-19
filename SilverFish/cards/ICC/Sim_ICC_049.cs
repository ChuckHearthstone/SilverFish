using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_ICC_049 : SimTemplate //* Toxic Arrow
    {
        // Deal 2 damage to a minion. If it survives, give it Poisonous.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            int dmg = (ownplay) ? p.getSpellDamageDamage(2) : p.getEnemySpellDamageDamage(2);

            p.minionGetDamageOrHeal(target, dmg);
            if (target.Hp > 0) target.poisonous = true;
        }
    }
}