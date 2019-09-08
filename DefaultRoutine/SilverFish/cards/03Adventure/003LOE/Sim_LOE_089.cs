using HREngine.Bots;
using SilverFish.Enums;

namespace SilverFish.cards._03Adventure._003LOE
{
	class Sim_LOE_089 : SimTemplate //* Wobbling Runts
	{
		//Deathrattle: Summon three 2/2 Runts.
        
        public override void onDeathrattle(Playfield p, Minion m)
        {
            p.CallKid(CardDB.Instance.getCardDataFromID(CardIdEnum.LOE_089t), m.zonepos - 1, m.own); //Rascally Runt
            p.CallKid(CardDB.Instance.getCardDataFromID(CardIdEnum.LOE_089t2), m.zonepos, m.own); //Wily Runt
            p.CallKid(CardDB.Instance.getCardDataFromID(CardIdEnum.LOE_089t3), m.zonepos + 1, m.own); //Grumbly Runt
        }
	}
}