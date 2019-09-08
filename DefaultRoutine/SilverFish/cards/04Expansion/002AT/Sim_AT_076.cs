using HREngine.Bots;

namespace SilverFish.cards._04Expansion._002AT
{
	class Sim_AT_076 : SimTemplate //* Murloc Knight
	{
		//Inspire: Summon a random Murloc.
		
		CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardIdEnum.EX1_050);//Coldlight Oracle 2/2

		public override void onInspire(Playfield p, Minion m, bool own)
        {
			if (m.own == own)
			{
				p.CallKid(kid, m.zonepos, m.own);
			}
        }
	}
}