using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_ICC_079 : SimTemplate //* Gnash
    {
        // Give your hero +3 Attack this turn. Gain 3 Armor.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            if (ownplay)
            {
                p.minionGetArmor(p.ownHero, 3);
                p.minionGetTempBuff(p.ownHero, 3, 0);
            }
            else
            {
                p.minionGetArmor(p.enemyHero, 3);
                p.minionGetTempBuff(p.enemyHero, 3, 0);
            }
        }
    }
}