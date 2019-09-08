using HREngine.Bots;
using SilverFish.Enums;

namespace SilverFish.cards._02Classic
{
	class Sim_EX1_383t : SimTemplate //ashbringer
	{

//
        CardDB.Card wcard = CardDB.Instance.getCardDataFromID(CardIdEnum.EX1_383t);
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.equipWeapon(wcard, ownplay);
        }

	}
}