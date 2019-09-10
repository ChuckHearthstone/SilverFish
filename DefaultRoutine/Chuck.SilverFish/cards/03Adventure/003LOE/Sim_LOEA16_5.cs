using Chuck.SilverFish;
using SilverFish.Enums;

namespace SilverFish.cards._03Adventure._003LOE
{
	class Sim_LOEA16_5 : SimTemplate //* Mirror of Doom
	{
		// Fill your board with 3/3 Mummy Zombies.
		CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardIdEnum.LOEA16_5t);//Mummy Zombie

		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
			int MinionsCount = (ownplay) ? p.ownMinions.Count : p.enemyMinions.Count;

            p.CallKid(kid, MinionsCount, ownplay, false);
            int kids = 6 - MinionsCount;
            for (int i = 0; i < kids; i++)
            {
                p.CallKid(kid, MinionsCount, ownplay);
            }			
		}
	}
}