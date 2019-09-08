using HREngine.Bots;

namespace SilverFish.cards._03Adventure._002BRM
{
	class Sim_BRMA01_2H_2_TB : SimTemplate //* Pile On!
	{
		// Hero Power: Put two minions from your deck and one from your opponent's into the battlefield.
		
		CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.CardIdEnum.FP1_007t);//4/4Nerubian

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
			
			if (ownplay)
			{
				if (p.ownDeckSize > 0)
				{
                    p.CallKid(kid, p.ownMinions.Count, true, false);
					p.ownDeckSize--;
				}
			}
			else
			{
				if (p.enemyDeckSize > 0)
				{
                    p.CallKid(kid, p.enemyMinions.Count, false, false);
					p.enemyDeckSize--;
				}
			}
		}
	}
}