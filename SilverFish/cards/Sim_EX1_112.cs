using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_EX1_112 : SimTemplate //gelbinmekkatorque
	{
        CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.Mekka1);//homingchicken
        CardDB.Card kid1 = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.Mekka2);
        CardDB.Card kid2 = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.Mekka3);
        CardDB.Card kid3 = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.Mekka4);
//    kampfschrei:/ konstruiert eine fantastische erfindung.
		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            p.callKid(kid, own.zonepos, own.own, true);
		}
	}
}