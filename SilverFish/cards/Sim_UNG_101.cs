using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_UNG_101 : SimTemplate //* Shellshifter
	{
		//Choose One - Transform into a 5/3 with Stealth or a 3/5 with Taunt.

        CardDB.Card m53 = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.UNG_101t);
        CardDB.Card m35 = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.UNG_101t2);
        CardDB.Card m55 = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.UNG_101t3);
		
		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            if (p.ownFandralStaghelm > 0)
            {
                p.minionTransform(own, m55);
            }
            else
            {
                if (choice == 1)
                {
                    p.minionTransform(own, m53);
                }
                else if (choice == 2)
                {
                    p.minionTransform(own, m35);
                }
            }
		}
	}
}