using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_AT_051 : SimTemplate //Elemental Destruction
    {

        //    Deal $4-$5 damage to all minions. Overload: (5)

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.changeRecall(ownplay, 5);

            int dmg = (ownplay) ? p.getSpellDamageDamage(5) : p.getEnemySpellDamageDamage(5);
            p.allMinionsGetDamage(dmg);
        }
    }
}