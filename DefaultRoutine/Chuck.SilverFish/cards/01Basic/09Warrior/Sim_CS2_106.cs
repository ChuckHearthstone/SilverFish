using Chuck.SilverFish;
using SilverFish.Enums;

namespace SilverFish.cards._01Basic._09Warrior
{
	class Sim_CS2_106 : SimTemplate //fierywaraxe
	{
        CardDB.Card card = CardDB.Instance.getCardDataFromID(CardIdEnum.CS2_106);
//
		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            p.equipWeapon(card,ownplay);
		}

	}
}