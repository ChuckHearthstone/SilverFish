using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_OG_047 : SimTemplate //* Feral Rage
    {
        //Choose One - Give your hero +4 attack this turn; or Gain 8 armor.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            if (choice == 1 || (p.ownFandralStaghelm > 0 && ownplay))
            {
                if (ownplay) p.minionGetTempBuff(p.ownHero, 4, 0);
                else p.minionGetTempBuff(p.enemyHero, 4, 0);
            }
            if (choice == 2 || (p.ownFandralStaghelm > 0 && ownplay))
            {        
                if (ownplay) p.minionGetArmor(p.ownHero, 8);
                else p.minionGetArmor(p.enemyHero, 8);
            }
        }
    }
}