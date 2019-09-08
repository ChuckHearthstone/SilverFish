using HREngine.Bots;

namespace SilverFish.cards._04Expansion._005UNG
{
	class Sim_UNG_076 : SimTemplate //* Eggnapper
	{
		//Deathrattle: Summon two 1/1 Raptors.

        CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardIdEnum.UNG_076t1); //1/1 Raptor
        
        public override void onDeathrattle(Playfield p, Minion m)
        {
            p.CallKid(kid, m.zonepos-1, m.own);
            p.CallKid(kid, m.zonepos-1, m.own);
        }
	}
}