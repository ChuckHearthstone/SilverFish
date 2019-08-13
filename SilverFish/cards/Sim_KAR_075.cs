using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_KAR_075 : SimTemplate //Moonglade Portal
    {
        // Restore 6 Health. Summon a random 6-Cost minion.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            if (ownplay)
            {
                p.minionGetDamageOrHeal(target, 6, true);
                p.callKid(p.getRandomCardForManaMinion(6), p.ownMinions.Count, ownplay);
            }
            else
            {
                p.minionGetDamageOrHeal(target, 6, true);
                p.callKid(p.getRandomCardForManaMinion(6), p.enemyMinions.Count, ownplay);
            }
        }
    }
}