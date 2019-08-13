using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_ICC_055: SimTemplate //* Drain Soul
    {
        // Lifesteal. Deal 2 damage to a minion.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            int dmg = (ownplay) ? p.getSpellDamageDamage(2) : p.getEnemySpellDamageDamage(2);

            int oldHp = target.Hp;
            p.minionGetDamageOrHeal(target, dmg);
            if (oldHp > target.Hp) p.applySpellLifesteal(oldHp-target.Hp, ownplay);
        }
    }
}