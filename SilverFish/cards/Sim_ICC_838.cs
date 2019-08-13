using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_ICC_838 : SimTemplate //* Sindragosa
    {
        // Battlecry: Summon two 0/1 Frozen Champions.

        CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.ICC_838t); //Frozen Champion

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            p.callKid(kid, own.zonepos - 1, own.own); //1st left
            p.callKid(kid, own.zonepos, own.own);
        }
    }
}