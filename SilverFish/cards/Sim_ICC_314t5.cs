using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_ICC_314t5 : SimTemplate //* Death Coil
    {
        // Deal $5 damage to an enemy, or restore #5 Health to a friendly character.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            int dmg = 0;
            if (target.own == ownplay) dmg = -1 * ((ownplay) ? p.getSpellHeal(5) : p.getEnemySpellHeal(5));
            else dmg = (ownplay) ? p.getSpellDamageDamage(5) : p.getEnemySpellDamageDamage(5);
            p.minionGetDamageOrHeal(target, dmg);
        }
    }
}