using Chuck.SilverFish;
using SilverFish.Enums;

namespace SilverFish.cards._04Expansion._002AT
{
	class Sim_AT_042b : SimTemplate //* Panther Form
	{
		//Transform into a +1/+1 and Stealth
		
        CardDB.Card Stealth = CardDB.Instance.getCardDataFromID(CardIdEnum.AT_042t2);

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.minionTransform(target, Stealth);
        }
	}
}