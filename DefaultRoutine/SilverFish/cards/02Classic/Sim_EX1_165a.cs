using Chuck.SilverFish;
using SilverFish.Enums;

namespace SilverFish.cards._02Classic
{
    class Sim_EX1_165a : SimTemplate //* Cat Form
	{
        //Charge

        CardDB.Card cat = CardDB.Instance.getCardDataFromID(CardIdEnum.EX1_165t1);

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.minionTransform(target, cat);
        }
	}
}