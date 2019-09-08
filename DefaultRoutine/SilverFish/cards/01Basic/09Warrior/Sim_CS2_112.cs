using HREngine.Bots;

namespace SilverFish.cards._01Basic._09Warrior
{
	class Sim_CS2_112 : SimTemplate //arcanitereaper
	{

        CardDB.Card card = CardDB.Instance.getCardDataFromID(CardIdEnum.CS2_112);
        //
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.equipWeapon(card,ownplay);
        }

	}
}