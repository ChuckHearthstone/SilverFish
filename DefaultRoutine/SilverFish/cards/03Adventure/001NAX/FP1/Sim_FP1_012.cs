using HREngine.Bots;

namespace SilverFish.cards._03Adventure._001NAX.FP1
{
	class Sim_FP1_012 : SimTemplate //* Sludge Belcher
	{
		//Taunt. Deathrattle: Summon a 1/2 Slime with Taunt.
		
        CardDB.Card c = CardDB.Instance.getCardDataFromID(CardDB.CardIdEnum.FP1_012t);
		
        public override void onDeathrattle(Playfield p, Minion m)
        {
            p.CallKid(c, m.zonepos - 1, m.own);
        }
	}
}