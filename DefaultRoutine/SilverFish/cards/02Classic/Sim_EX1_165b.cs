using HREngine.Bots;

namespace SilverFish.cards._02Classic
{
	class Sim_EX1_165b : SimTemplate //bearform
	{

//    +2 leben und spott/.
        CardDB.Card bear = CardDB.Instance.getCardDataFromID(CardIdEnum.EX1_165t2);

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.minionTransform(target, bear);
        }
	}
}