using HREngine.Bots;

namespace SilverFish.cards._01Basic._04Paladin
{
	class Sim_CS2_097 : SimTemplate //truesilverchampion
	{

        CardDB.Card card = CardDB.Instance.getCardDataFromID(CardDB.CardIdEnum.CS2_097);
        //
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.equipWeapon(card, ownplay);
        }

	}
}