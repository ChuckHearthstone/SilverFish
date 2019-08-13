using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_LOEA16_4 : SimTemplate //* Timepiece of Horror
	{
        //Deal $10 damage randomly split among all enemies.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            int times = (ownplay) ? p.getSpellDamageDamage(10) : p.getEnemySpellDamageDamage(10);
            p.allCharsOfASideGetRandomDamage(!ownplay, times);
        }
    }
}