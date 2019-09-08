using HREngine.Bots;

namespace SilverFish.cards._02Classic
{
	class Sim_EX1_536 : SimTemplate //eaglehornbow
	{

//    erhält jedes mal +1 haltbarkeit, wenn ein eigenes geheimnis/ aufgedeckt wird.

        CardDB.Card weapon = CardDB.Instance.getCardDataFromID(CardDB.CardIdEnum.EX1_536);

		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            p.equipWeapon(weapon, ownplay);
		}

	}
}