using HREngine.Bots;

namespace SilverFish.cards._02Classic
{
	class Sim_EX1_398t : SimTemplate //battleaxe
	{

//
        CardDB.Card wcard = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_398t);
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.equipWeapon(wcard, ownplay);
        }
	}
}