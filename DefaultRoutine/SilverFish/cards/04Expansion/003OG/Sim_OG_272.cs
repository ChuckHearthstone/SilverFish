using HREngine.Bots;
using SilverFish.Enums;

namespace SilverFish.cards._04Expansion._003OG
{
	class Sim_OG_272 : SimTemplate //* Twilight Summoner
	{
		//Deathrattle: Summon a 5/5 Faceless Destroyer.

        CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardIdEnum.OG_272t);

        public override void onDeathrattle(Playfield p, Minion m)
        {
			p.CallKid(kid, m.zonepos-1, m.own);
        }
	}
}