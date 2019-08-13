using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_ICC_469: SimTemplate //* Unwilling Sacrifice
    {
        // Choose a friendly minion. Destroy it and a random enemy minion

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.minionGetDestroyed(target);
            Minion found = null;
            if (ownplay) found = p.searchRandomMinion(p.enemyMinions, searchmode.searchLowestHP);
            else found = p.searchRandomMinion(p.ownMinions, searchmode.searchHighHPLowAttack);
            if (found != null) p.minionGetDestroyed(found);
        }
    }
}