using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_EX1_154 : SimTemplate //* Wrath
    {
        // Choose One - Deal $3 damage to a minion; or $1 damage and draw a card.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            int damage = 0;
            if (choice == 1 || (p.anzOwnFandralStaghelm > 0 && ownplay))
            {
                damage += (ownplay) ? p.getSpellDamageDamage(3) : p.getEnemySpellDamageDamage(3);
            }
            if (choice == 2 || (p.anzOwnFandralStaghelm > 0 && ownplay))
            {
                damage += (ownplay) ? p.getSpellDamageDamage(1) : p.getEnemySpellDamageDamage(1);
                p.drawACard(CardDB.cardName.unknown, ownplay);
            }

            p.minionGetDamageOrHeal(target, damage);
        }
    }
}