using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_EX1_538 : SimTemplate //* unleashthehounds
	{
        // For each enemy minion, summon a 1/1 Hound with Charge.
        
        CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_538t); //hound

		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            int pos = (ownplay) ? p.ownMinions.Count : p.enemyMinions.Count;
            int anz = (ownplay) ? p.enemyMinions.Count : p.ownMinions.Count;
            if (anz > 0)
            {
                p.callKid(kid, pos, ownplay, false);
                anz--;
                for (int i = 0; i < anz; i++)
                {
                    p.callKid(kid, pos, ownplay);
                }
            }
		}
	}
}