using Chuck.SilverFish;
using SilverFish.Enums;

namespace SilverFish.cards._04Expansion._002AT
{
	class Sim_AT_099 : SimTemplate //* Kodorider
	{
		//Inspire: Summon a 3/5 War Kodo.

        CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardIdEnum.AT_099t); //War Kodo
		
		public override void onInspire(Playfield p, Minion m, bool own)
        {
            if (m.own == own) p.CallKid(kid, m.zonepos, own);
        }
	}
}