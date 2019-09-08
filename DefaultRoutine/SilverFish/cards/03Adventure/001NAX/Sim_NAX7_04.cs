using HREngine.Bots;

namespace SilverFish.cards._03Adventure._001NAX
{
	class Sim_NAX7_04 : SimTemplate //* 5/2 Massive Runeblade
	{
		//Deals double damage to heroes.
		//Handled in minionAttacksMinion()

		CardDB.Card weapon = CardDB.Instance.getCardDataFromID(CardIdEnum.NAX7_04);

		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            p.equipWeapon(weapon, ownplay);
		}
	}
}