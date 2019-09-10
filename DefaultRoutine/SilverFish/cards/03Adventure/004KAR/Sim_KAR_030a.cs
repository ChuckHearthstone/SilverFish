using Chuck.SilverFish;
using SilverFish.Enums;

namespace SilverFish.cards._03Adventure._004KAR
{
	class Sim_KAR_030a : SimTemplate //* Pantry Spider
	{
		//Battlecry: Summon a 1/3 Spider.
		
        CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardIdEnum.KAR_030);//Cellar Spider
		
		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            p.CallKid(kid, own.zonepos, own.own);
		}
	}
}