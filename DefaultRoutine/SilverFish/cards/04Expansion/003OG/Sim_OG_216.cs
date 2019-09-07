using HREngine.Bots;

namespace SilverFish.cards._04Expansion._003OG
{
	class Sim_OG_216 : SimTemplate //* Infested Wolf
	{
		//Deathrattle: Summon two 1/1 Spiders.

        CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.OG_216a);
		
        public override void onDeathrattle(Playfield p, Minion m)
        {
            p.CallKid(kid, m.zonepos-1, m.own);
            p.CallKid(kid, m.zonepos-1, m.own);
        }
	}
}