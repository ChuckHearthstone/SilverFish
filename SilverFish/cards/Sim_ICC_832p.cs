using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_ICC_832p: SimTemplate //* Plague Lord
    {
        // Hero Power: Choose One - +3 Attack this turn; or Gain 3 Armor.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            if (choice == 1 || (p.ownFandralStaghelm > 0 && ownplay))
            {
                if (ownplay) p.minionGetTempBuff(p.ownHero, 3, 0);
                else p.minionGetTempBuff(p.enemyHero, 3, 0);
            }
            if (choice == 2 || (p.ownFandralStaghelm > 0 && ownplay))
            {
                if (ownplay) p.minionGetArmor(p.ownHero, 3);
                else p.minionGetArmor(p.enemyHero, 3);
            }
        }
    }
}