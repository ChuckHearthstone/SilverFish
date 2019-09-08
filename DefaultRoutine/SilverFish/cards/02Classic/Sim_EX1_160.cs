using HREngine.Bots;

namespace SilverFish.cards._02Classic
{
	class Sim_EX1_160 : SimTemplate //* powerofthewild
	{
        //Choose One - Give your minions +1/+1; or Summon a 3/2 Panther.

        CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.CardIdEnum.EX1_160t);//panther

		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            if (choice == 1 || (p.ownFandralStaghelm > 0 && ownplay))
            {
                p.allMinionOfASideGetBuffed(ownplay, 1, 1);
            }
            if (choice == 2 || (p.ownFandralStaghelm > 0 && ownplay))
            {
                int pos = (ownplay) ? p.ownMinions.Count : p.enemyMinions.Count;
                p.CallKid(kid, pos, ownplay, false);
                
            }
		}
	}
}