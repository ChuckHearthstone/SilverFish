using Chuck.SilverFish;
using SilverFish.Enums;

namespace SilverFish.cards._03Adventure._003LOE
{
	class Sim_LOE_020 : SimTemplate //* Desert Camel
	{
        //Battlecry: Put a 1-Cost minion from each deck into the battlefield.
		
        CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardIdEnum.BRM_004); //Twilight Whelp

		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            p.CallKid(kid, p.ownMinions.Count, true);
			p.CallKid(kid, p.enemyMinions.Count, false);
		}
	}
}