using Chuck.SilverFish;
using SilverFish.Enums;

namespace SilverFish.cards._02Classic
{
	class Sim_EX1_247 : SimTemplate //stormforgedaxe
	{
        CardDB.Card card = CardDB.Instance.getCardDataFromID(CardIdEnum.EX1_247);
        //
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.equipWeapon(card,ownplay);
            if (ownplay) p.ueberladung ++;
        }

	}
}