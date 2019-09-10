using Chuck.SilverFish;
using SilverFish.Enums;

namespace SilverFish.cards._01Basic
{
	class Sim_CS2_151 : SimTemplate //silverhandknight
	{
        CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardIdEnum.CS2_152);//squire
//    kampfschrei:/ ruft einen knappen (2/2) herbei.
		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            p.CallKid(kid, own.zonepos, own.own);
		}

	}
}