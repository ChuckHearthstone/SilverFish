using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_EX1_277 : SimTemplate //* Arcane Missiles
    {
        
        //Deal $3 damage randomly split among all enemies.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            int times = (ownplay) ? p.getSpellDamageDamage(3) : p.getEnemySpellDamageDamage(3);
            p.allCharsOfASideGetRandomDamage(!ownplay, times);
        }
    }
}