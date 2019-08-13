using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_EX1_160 : SimTemplate //* powerofthewild
    {
        //Choose One - Give your minions +1/+1; or Summon a 3/2 Panther.

        CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_160t);//panther

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            if (choice == 1 || (p.anzOwnFandralStaghelm > 0 && ownplay))
            {
                List<Minion> temp = (ownplay) ? p.ownMinions : p.enemyMinions;
                foreach (Minion m in temp)
                {
                    p.minionGetBuffed(m, 1, 1);
                }
            }
            if (choice == 2 || (p.anzOwnFandralStaghelm > 0 && ownplay))
            {
                int pos = (ownplay) ? p.ownMinions.Count : p.enemyMinions.Count;
                p.callKid(kid, pos, ownplay, false);

            }
        }
    }
}