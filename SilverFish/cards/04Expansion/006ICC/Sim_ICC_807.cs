using System.Collections.Generic;
using HREngine.Bots;

namespace SilverFish.cards._04Expansion._006ICC
{
    class Sim_ICC_807: SimTemplate //* Strongshell Scavenger
    {
        // Battlecry: Give your Taunt minions +2/+2.

        public override void getBattlecryEffect(Playfield p, Minion m, Minion target, int choice)
        {
            List<Minion> temp = (m.own) ? p.ownMinions : p.enemyMinions;
            foreach (Minion mnn in temp)
            {
                if (mnn.taunt) p.minionGetBuffed(mnn, 2, 2);
            }
        }
    }
}