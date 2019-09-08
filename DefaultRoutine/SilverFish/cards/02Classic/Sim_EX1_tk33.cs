using HREngine.Bots;

namespace SilverFish.cards._02Classic
{
	class Sim_EX1_tk33 : SimTemplate //* inferno
	{
        //Hero PowerSummon a 6/6 Infernal.

        CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardIdEnum.EX1_tk34);//infernal

		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            int pos = (ownplay)? p.ownMinions.Count : p.enemyMinions.Count;
            p.CallKid(kid, pos, ownplay, false);
		}
	}
}