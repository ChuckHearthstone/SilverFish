using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_PRO_001a : SimTemplate//I Am Murloc
    {
        //Summon three, four, or five 1/1 Murlocs.
        CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.PRO_001at);

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            int posi = (ownplay) ? p.ownMinions.Count : p.enemyMinions.Count ;

            p.callKid(kid, posi, ownplay, false);
            p.callKid(kid, posi, ownplay);
            p.callKid(kid, posi, ownplay);
            p.callKid(kid, posi, ownplay);
        }
    }
}
