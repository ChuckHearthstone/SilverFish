using HREngine.Bots;

namespace SilverFish.cards._02Classic._02Hunter
{
	class Sim_DS1_188 : SimTemplate //gladiatorslongbow
	{
        CardDB.Card c = CardDB.Instance.getCardDataFromID(CardIdEnum.DS1_188);
//    euer held ist immun/, während er angreift.
		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            p.equipWeapon(c,ownplay);
		}

	}
}