using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_AT_046 : SimTemplate //Tuskarr Totemic
    {

        //   btlcry: Summon ANY random Totem.
        //   sim worst case seems best for now
//        CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.CS2_050);//searing
//        CardDB.Card kid2 = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.CS2_052);//wrath of air
//        CardDB.Card kid3 = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.NEW1_009);//healing
//        CardDB.Card kid4 = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.CS2_051);//stoneclaw
//        CardDB.Card kid5 = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.GVG_039);//vitality
        CardDB.Card kid6 = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_575);//mana tide
//        CardDB.Card kid7 = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_565);//flametongue
//        CardDB.Card kid8 = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.AT_052);//golem

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            int pos = own.zonepos;
//            List<CardDB.Card> avail = new List<CardDB.Card>();
//            avail.Add(kid);
//            avail.Add(kid2);
//            avail.Add(kid3);
//            avail.Add(kid4);
//            avail.Add(kid5);
//            avail.Add(kid6);
//            avail.Add(kid7);
//            avail.Add(kid8);
//            int random = p.randomGenerator.Next(0, avail.Count);
//            p.callKid(avail[random], pos, own.own, true);
            p.callKid(kid6, pos, own.own, true);
        }
    }
}