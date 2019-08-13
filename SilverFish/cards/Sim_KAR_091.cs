using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_KAR_091 : SimTemplate //Ironforge Portal
    {
        // Gain 4 Armor. Summon a random 4-Cost minion.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            if (ownplay)
            {
                p.minionGetArmor(p.ownHero, 4);
                p.callKid(p.getRandomCardForManaMinion(4), p.ownMinions.Count, ownplay);
            }
            else
            {
                p.minionGetArmor(p.enemyHero, 4);
                p.callKid(p.getRandomCardForManaMinion(4), p.enemyMinions.Count, ownplay);
            }
        }
    }
}