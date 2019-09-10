using Chuck.SilverFish;
using SilverFish.Enums;

namespace SilverFish.cards._03Adventure._001NAX.FP1
{
	class Sim_FP1_002 : SimTemplate //* hauntedcreeper
	{
        //Deathrattle: Summon two 1/1 Spectral Spiders.

        CardDB.Card c = CardDB.Instance.getCardDataFromID(CardIdEnum.FP1_002t);
		
        public override void onDeathrattle(Playfield p, Minion m)
        {
            p.CallKid(c, m.zonepos-1, m.own);
            p.CallKid(c, m.zonepos-1, m.own);
        }
	}
}