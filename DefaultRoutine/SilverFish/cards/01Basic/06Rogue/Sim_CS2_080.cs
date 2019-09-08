using HREngine.Bots;

namespace SilverFish.cards._01Basic._06Rogue
{
	class Sim_CS2_080 : SimTemplate //assassinsblade
	{

//
        CardDB.Card w = CardDB.Instance.getCardDataFromID(CardIdEnum.CS2_080);

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.equipWeapon(w, ownplay);
        }

	}
}