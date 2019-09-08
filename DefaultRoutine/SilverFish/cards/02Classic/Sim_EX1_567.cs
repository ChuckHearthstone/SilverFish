using HREngine.Bots;
using SilverFish.Enums;

namespace SilverFish.cards._02Classic
{
	class Sim_EX1_567 : SimTemplate //doomhammer
	{

//    windzorn/, überladung:/ (2)
        CardDB.Card card = CardDB.Instance.getCardDataFromID(CardIdEnum.EX1_567);

		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            p.equipWeapon(card, ownplay);
            if (ownplay) p.ueberladung += 2;
		}

	}
}