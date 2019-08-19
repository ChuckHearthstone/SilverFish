using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_ICC_812: SimTemplate //* Meat Wagon
    {
        // Deathrattle: Summon a minion from your deck with less Attack than this minion.

        public override void onDeathrattle(Playfield p, Minion m)
        {
            CardDB.cardIDEnum cId = CardDB.cardIDEnum.None;
            for (int i = m.Angr - 1; i >= 0; i--)
            {
                cId = p.prozis.getDeckCardsForCost(i);
                if (cId != CardDB.cardIDEnum.None) break;
            }
            if (cId != CardDB.cardIDEnum.None)
            {
                CardDB.Card kid = CardDB.Instance.getCardDataFromID(cId);
                p.callKid(kid, m.zonepos - 1, m.own);
            }
        }
    }
}