using Chuck.SilverFish;
using SilverFish.Enums;

namespace SilverFish.cards._02Classic
{
	class Sim_EX1_562 : SimTemplate //onyxia
	{

        CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardIdEnum.EX1_116t);//whelp

//    kampfschrei:/ ruft welplinge (1/1) herbei, bis eure seite des schlachtfelds voll ist.
		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            int kids = 7 - p.ownMinions.Count;
           
            for (int i = 0; i < kids; i++)
            {
                p.CallKid(kid, own.zonepos, own.own);
            }

		}


	}
}