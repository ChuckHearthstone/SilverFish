using Chuck.SilverFish;
using SilverFish.Enums;

namespace SilverFish.cards._04Expansion._002AT
{
	class Sim_AT_019 : SimTemplate //* Dreadsteed
	{
		//Deathrattle: Summon a Dreadsteed.

        CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardIdEnum.AT_019);

        public override void onDeathrattle(Playfield p, Minion m)
        {
            p.CallKid(kid, m.zonepos - 1, m.own);
        }
	}
}