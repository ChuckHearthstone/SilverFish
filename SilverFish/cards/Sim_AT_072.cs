using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_AT_072 : SimTemplate //Varian Wrynn
    {

        //Battlecry: Draw 3 cards. Put any minions you drew directly into the battlefield.
        CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.AT_099t);

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            p.drawACard(CardDB.cardIDEnum.None, own.own);
            p.drawACard(CardDB.cardIDEnum.None, own.own);
            p.drawACard(CardDB.cardIDEnum.None, own.own);
            int posi2 = (own.own) ? p.ownMinions.Count : p.enemyMinions.Count;
            p.callKid(kid, posi2, own.own, true);
        }
    }
}