using Chuck.SilverFish;
using SilverFish.Enums;

namespace SilverFish.cards._04Expansion._002AT
{
	class Sim_AT_037b : SimTemplate //* Living Roots
	{
		//Summon two 1/1 Saplings.
		
        CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardIdEnum.AT_037t); //Sapling
		
		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            int place = (ownplay) ? p.ownMinions.Count : p.enemyMinions.Count;
            
            p.CallKid(kid, place, ownplay, false);
            p.CallKid(kid, place, ownplay);
		}
	}
}