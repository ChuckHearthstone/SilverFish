using HREngine.Bots;

namespace SilverFish.cards._04Expansion._002AT
{
	class Sim_AT_036 : SimTemplate //* Anub'arak
	{
		//Deathrattle: Return this to your hand and summon a 4/4 Nerubian.
		
		CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardIdEnum.FP1_007t);//Nerubian

        public override void onDeathrattle(Playfield p, Minion m)
        {
			p.minionReturnToHand(m, m.own, 0);
            p.CallKid(kid, m.zonepos - 1, m.own);		
        }
	}
}