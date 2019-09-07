using System.Collections.Generic;
using HREngine.Bots;

namespace SilverFish.cards._04Expansion._006ICC
{
    class Sim_ICC_052: SimTemplate //* Play Dead
    {
        // Triger a friendly minion's deathrattle

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.doDeathrattles(new List<Minion>() { target });
        }
    }
}