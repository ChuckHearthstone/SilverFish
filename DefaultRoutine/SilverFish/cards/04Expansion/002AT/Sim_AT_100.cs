using HREngine.Bots;
using SilverFish.Enums;

namespace SilverFish.cards._04Expansion._002AT
{
	class Sim_AT_100 : SimTemplate //* Silver Hand Regent
	{
		//Inspire: Summon a 1/1 Silver Hand Recruit.
		
		CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardIdEnum.CS2_101t);//silverhandrecruit
		
		public override void onInspire(Playfield p, Minion m, bool own)
        {
            if (m.own == own) p.CallKid(kid, m.zonepos, own);
        }
	}
}