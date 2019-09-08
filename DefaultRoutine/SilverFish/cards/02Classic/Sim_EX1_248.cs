using HREngine.Bots;

namespace SilverFish.cards._02Classic
{
	class Sim_EX1_248 : SimTemplate //* feralspirit
	{
        //Summon two 2/3 Spirit Wolves with Taunt. Overload: (2)

        CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardIdEnum.EX1_tk11);//spiritwolf

		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            int pos = (ownplay) ? p.ownMinions.Count : p.enemyMinions.Count;

            p.CallKid(kid, pos, ownplay, false);
            p.CallKid(kid, pos, ownplay);
            if (ownplay) p.ueberladung += 2;
		}
	}
}