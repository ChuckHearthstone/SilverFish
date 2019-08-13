using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_KAR_028 : SimTemplate //Fool's Bane
    {
        // Unlimited attacks each turn. Can't attack heroes.

        CardDB.Card card = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.KAR_028);

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.equipWeapon(card, ownplay);
        }
    }
}