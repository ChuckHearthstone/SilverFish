using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_BRM_010 : SimTemplate //* Druid of the Flame
    {
		// Choose One - Transform into a 5/2 minion; or a 2/5 minion.
        CardDB.Card fireCat52 = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.BRM_010t);
        CardDB.Card fireHawk25 = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.BRM_010t2);
        CardDB.Card CatHawk55 = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.OG_044b);
		
		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            if (p.ownFandralStaghelm > 0)
            {
                p.minionTransform(own, CatHawk55);
            }
            else
            {
                if (choice == 1)
                {
                    p.minionTransform(own, fireCat52);
                }
                else if (choice == 2)
                {
                    p.minionTransform(own, fireHawk25);
                }
            }
		}
	}
}