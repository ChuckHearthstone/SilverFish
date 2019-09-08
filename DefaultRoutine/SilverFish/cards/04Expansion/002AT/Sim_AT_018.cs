using HREngine.Bots;

namespace SilverFish.cards._04Expansion._002AT
{
	class Sim_AT_018 : SimTemplate //* Confessor Paletress
	{
		//Inspire: Summon a random Legendary minion.

		CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.CardIdEnum.EX1_014);//King Mukla 5/5
		
		public override void onInspire(Playfield p, Minion m, bool own)
        {
			if (m.own == own)
			{				
				p.CallKid(kid, m.zonepos, m.own);
			}
        }
	}
}