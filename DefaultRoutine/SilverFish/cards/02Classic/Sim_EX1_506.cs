using HREngine.Bots;

namespace SilverFish.cards._02Classic
{
	class Sim_EX1_506 : SimTemplate //murloctidehunter
	{
        CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.CardIdEnum.EX1_506a);//murlocscout
//    kampfschrei:/ ruft einen murlocspäher (1/1) herbei.
		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            p.CallKid(kid, own.zonepos, own.own);
		}


	}
}