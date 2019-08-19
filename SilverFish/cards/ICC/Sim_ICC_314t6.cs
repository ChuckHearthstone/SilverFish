using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_ICC_314t6 : SimTemplate //* Obliterate
    {
        // Destroy a minion. Your hero takes damage equal to its Health.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.minionGetDamageOrHeal(ownplay ? p.ownHero : p.enemyHero, target.Hp);
            p.minionGetDestroyed(target);
        }
    }
}