using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_ICC_019: SimTemplate //* Skelemancer
    {
        // Deathrattle: If it's your opponent's turn, summon an 8/8 Skeleton.

        CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.ICC_019t); //Skeletal Flayer

        public override void onDeathrattle(Playfield p, Minion m)
        {
            if (!p.isOwnTurn) p.callKid(kid, m.zonepos, m.own);
        }
    }
}