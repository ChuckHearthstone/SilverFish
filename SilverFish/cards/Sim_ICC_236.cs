using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_ICC_236: SimTemplate //* Ice Breaker
    {
        // Destroy any Frozen minion damaged by this.
        //done in Playfield

        CardDB.Card w = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.ICC_236);

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.equipWeapon(w, ownplay);
        }
    }
}