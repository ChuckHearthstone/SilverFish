using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_ICC_851: SimTemplate //* Prince Keleseth
    {
        // Battlecry: If your deck has no 2-cost cards, give all minions in your deck +1/+1.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            if (own.own && p.prozis.getDeckCardsForCost(2) == CardDB.cardIDEnum.None) p.evaluatePenality -= 20;
        }
    }
}