using HREngine.Bots;

namespace SilverFish.cards._04Expansion._005UNG
{
	class Sim_UNG_830 : SimTemplate //* Cruel Dinomancer
	{
		//Deathrattle: Summon a random minion you discarded this game.

        public override void onDeathrattle(Playfield p, Minion m)
        {
			p.CallKid(CardDB.Instance.getCardDataFromID(CardIdEnum.KAR_205), m.zonepos-1, m.own); //Silverware Golem.
        }
	}
}