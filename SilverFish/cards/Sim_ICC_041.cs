using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_ICC_041: SimTemplate //* Defile
    {
        // Deal 1 damage to all minions. If any die, cast this again.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            int dmg = (ownplay) ? p.getSpellDamageDamage(1) : p.getEnemySpellDamageDamage(1);
            int count = p.tempTrigger.ownMinionsDied + p.tempTrigger.enemyMinionsDied;
            int nextcount = 0;
            bool repeat;
            do
            {
                repeat = false;
                p.allMinionsGetDamage(dmg);
                nextcount = p.tempTrigger.ownMinionsDied + p.tempTrigger.enemyMinionsDied;
                if (nextcount > count) repeat = true;
                count = nextcount;
                if (count == (p.ownMinions.Count + p.enemyMinions.Count)) break;
            }
            while (repeat);
        }
    }
}