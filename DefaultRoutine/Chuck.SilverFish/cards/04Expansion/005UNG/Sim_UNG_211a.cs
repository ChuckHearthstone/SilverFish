using Chuck.SilverFish;
using SilverFish.Enums;

namespace SilverFish.cards._04Expansion._005UNG
{
	class Sim_UNG_211a : SimTemplate //* Invocation of Earth
	{
		//Fill your board with 1/1 Elementals.

		CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardIdEnum.UNG_211aa); //Stone Elemental

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