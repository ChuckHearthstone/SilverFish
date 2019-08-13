using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_KAR_205 : SimTemplate //Silverware Golem
    {
        // If you discard this minion, summon it.
        
        CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.KAR_205);//Silverware Golem

        public override void onCardIsDiscarded(Playfield p, CardDB.Card card, bool own)
        {
            int pos = p.ownMinions.Count;
            p.callKid(kid, pos, own);
        }
    }
}