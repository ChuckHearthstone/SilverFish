using HREngine.Bots;

namespace SilverFish.cards._04Expansion._006ICC
{
	class Sim_ICC_829t : SimTemplate //* 5/3 Grave Vengeance
	{
		//Lifesteal
		//Handled in minionAttacksMinion()

		CardDB.Card weapon = CardDB.Instance.getCardDataFromID(CardIdEnum.ICC_829t);

		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            p.equipWeapon(weapon, ownplay);
		}
	}
}