using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_DAL_087: SimTemplate //* 荆棘帮巫婆
    {
        // 战吼：召唤两个1/1的融合怪。

        CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.CardIdEnum.DAL_087t); //1/1 融合怪

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            p.CallKid(kid, own.zonepos - 1, own.own); //1st left
            p.CallKid(kid, own.zonepos, own.own);
        }
    }
}