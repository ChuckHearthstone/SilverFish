using HREngine.Bots;

namespace SilverFish.cards._02Classic
{
	class Sim_EX1_573b : SimTemplate //* shandoslesson
	{
        //Summon two 2/2 Treants with Taunt.

        CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardIdEnum.EX1_573t); //special treant
		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            int pos = (ownplay) ? p.ownMinions.Count : p.enemyMinions.Count;
            p.CallKid(kid, pos, ownplay, false);
            p.CallKid(kid, pos, ownplay);
		}

	}
}