using HREngine.Bots;

namespace SilverFish.cards._01Basic._03Mage
{
	class Sim_CS2_027 : SimTemplate //* mirrorimage
	{
        //Summon two 0/2 minions with Taunt.
		
        CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.CS2_mirror);
		
		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            int pos = (ownplay) ? p.ownMinions.Count : p.enemyMinions.Count;            
            p.CallKid(kid, pos, ownplay, false);
            p.CallKid(kid, pos, ownplay);
		}
	}
}