using HREngine.Bots;
using SilverFish.Enums;

namespace SilverFish.cards._03Adventure._004KAR
{
	class Sim_KAR_005 : SimTemplate //* Kindly Grandmother
	{
		//Deathrattle: Summon a 3/2 Big Bad Wolf.
		
        CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardIdEnum.KAR_005a);//Big Bad Wolf

        public override void onDeathrattle(Playfield p, Minion m)
        {
            p.CallKid(kid, m.zonepos-1, m.own);
        }
	}
}