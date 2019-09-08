using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_BOT_535: SimTemplate //* 微机操控者
    {
        // 战吼：召唤两个1/1的微型机器人。

        CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.CardIdEnum.BOT_312t); //1/1 微型机器人

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            p.CallKid(kid, own.zonepos - 1, own.own); //1st left
            p.CallKid(kid, own.zonepos, own.own);
        }
    }
}