using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_ICC_832pa: SimTemplate //* Scarab Shell
    {
        // +3 Armor.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            if (ownplay) p.minionGetArmor(p.ownHero, 3);
            else p.minionGetArmor(p.enemyHero, 3);
        }
    }
}