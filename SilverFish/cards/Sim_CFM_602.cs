using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_CFM_602 : SimTemplate //* Jade Idol
	{
		// Choose One - Summon a Jade Golem; or Shuffle 3 copies of this card into your deck.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            if (choice == 1 || (p.ownFandralStaghelm > 0 && ownplay))
            {
                int pos = (ownplay) ? p.ownMinions.Count : p.enemyMinions.Count;
                p.callKid(p.getNextJadeGolem(ownplay), pos, ownplay);
            }
            if (choice == 2 || (p.ownFandralStaghelm > 0 && ownplay))
            {
                if (ownplay)
                {
                    p.ownDeckSize += 3;
                    p.evaluatePenality -= 11;
                }
                else p.enemyDeckSize += 3;
            }
        }
    }
}