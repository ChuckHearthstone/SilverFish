using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_BOT_532: SimTemplate //* 投弹机器人
    {
        // 战吼：召唤两个0/2的地精炸弹。

        CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.CardIdEnum.BOT_031); //地精炸弹

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            p.CallKid(kid, own.zonepos - 1, own.own); //1st left
            p.CallKid(kid, own.zonepos, own.own);
        }
    }
}