using HREngine.Bots;

namespace SilverFish.cards._04Expansion._003OG
{
	class Sim_OG_211 : SimTemplate //* Call of the Wild
	{
		//Summon all 3 Animal Companions.
		
        CardDB.Card c1 = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.NEW1_034);//Huffer
        CardDB.Card c2 = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.NEW1_033);//Leokk
        CardDB.Card c3 = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.NEW1_032);//Misha
        
		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            int pos = (ownplay)?  p.ownMinions.Count : p.enemyMinions.Count;
            p.CallKid(c1, pos, ownplay, false);
            p.CallKid(c2, pos, ownplay);
            p.CallKid(c3, pos, ownplay);
		}
	}
}