using HREngine.Bots;

namespace SilverFish.cards._02Classic
{
	class Sim_EX1_112 : SimTemplate //gelbinmekkatorque
	{
        CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardIdEnum.Mekka1);//homingchicken
//    kampfschrei:/ konstruiert eine fantastische erfindung.
		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            p.CallKid(kid, own.zonepos, own.own);
		}


	}
}