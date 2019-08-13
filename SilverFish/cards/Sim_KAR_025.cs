using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_KAR_025 : SimTemplate //Kara Kazham!
    {
        // Summon a 1/1 Candle, 2/2 Broom, and 3/3 Teapot.

        CardDB.Card kid1 = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.KAR_025a); //Candle
        CardDB.Card kid2 = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.KAR_025b); //Broom
        CardDB.Card kid3 = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.KAR_025c); //Teapot

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            int pos = (ownplay) ? p.ownMinions.Count : p.enemyMinions.Count;

            p.callKid(kid1, pos, ownplay);
            p.callKid(kid2, pos, ownplay);
            p.callKid(kid3, pos, ownplay);
        }
    }
}