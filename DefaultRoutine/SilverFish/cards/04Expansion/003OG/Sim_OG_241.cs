using HREngine.Bots;

namespace SilverFish.cards._04Expansion._003OG
{
	class Sim_OG_241 : SimTemplate //* Possessed Villager
	{
		//Deathrattle: Summon a 1/1 Shadowbeast.

        CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.CardIdEnum.OG_241a);

        public override void onDeathrattle(Playfield p, Minion m)
        {
            p.CallKid(kid, m.zonepos-1, m.own);
        }
	}
}