using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_UNG_211a : SimTemplate //* Invocation of Earth
	{
		//Fill your board with 1/1 Elementals.

		CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.UNG_211aa); //Stone Elemental

		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
			int MinionsCount = (ownplay) ? p.ownMinions.Count : p.enemyMinions.Count;

            p.callKid(kid, MinionsCount, ownplay, false);
            int kids = 6 - MinionsCount;
            for (int i = 0; i < kids; i++)
            {
                p.callKid(kid, MinionsCount, ownplay);
            }			
		}
	}
}