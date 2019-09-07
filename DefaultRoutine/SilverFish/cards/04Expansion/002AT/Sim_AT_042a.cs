using HREngine.Bots;

namespace SilverFish.cards._04Expansion._002AT
{
	class Sim_AT_042a : SimTemplate //* Lion Form
	{
		//Transform into a Charge
		
        CardDB.Card Charge = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.AT_042t);

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.minionTransform(target, Charge);
        }
	}
}