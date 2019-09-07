using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_EX1_384 : SimTemplate //* avengingwrath
    {
        //Deal $8 damage randomly split among all enemies.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            int times = (ownplay) ? p.getSpellDamageDamage(8) : p.getEnemySpellDamageDamage(8);
            p.allCharsOfASideGetRandomDamage(!ownplay, times);
        }
    }
}