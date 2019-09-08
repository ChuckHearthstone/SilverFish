using HREngine.Bots;

namespace SilverFish.cards._04Expansion._003OG
{
	class Sim_OG_156 : SimTemplate //* Bilefin Tidehunter
	{
		//Battlecry: Summon a 1/1 Ooze with Taunt.

        CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.CardIdEnum.OG_156a);
		
		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            p.CallKid(kid, own.zonepos, own.own);
		}
	}
}