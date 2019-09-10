using Chuck.SilverFish;
using SilverFish.Enums;

namespace SilverFish.cards._02Classic
{
    class Sim_EX1_571 : SimTemplate //* Force of Nature
	{
        //Summon three 2/2 Treants.

        CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardIdEnum.EX1_158t);//Treant

		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            int pos =(ownplay) ? p.ownMinions.Count : p.enemyMinions.Count;

            p.CallKid(kid, pos, ownplay, false);
            p.CallKid(kid, pos, ownplay);
            p.CallKid(kid, pos, ownplay);
		}
	}
}