using Chuck.SilverFish;
using SilverFish.Enums;

namespace SilverFish.cards._03Adventure._002BRM
{
	class Sim_BRMA01_2 : SimTemplate //* Pile On!
	{
		// Hero Power: Put a minion from each deck into the battlefield.
		
		CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardIdEnum.FP1_007t);//4/4Nerubian

		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
			if (p.ownDeckSize > 0)
            {
				p.CallKid(kid, p.ownMinions.Count, true, false);
                p.ownDeckSize--;
            }
			
            if (p.enemyDeckSize > 0)
            {
				p.CallKid(kid, p.enemyMinions.Count, false, false);
                p.enemyDeckSize--;
            }
		}
	}
}