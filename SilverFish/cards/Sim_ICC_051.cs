using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_ICC_051 : SimTemplate //* Druid of the Swarm
    {
        // Choose One - Transform into a 1/2 with Poisonous; or a 1/5 with Taunt.

        CardDB.Card kid12 = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.ICC_051t);
        CardDB.Card kid15 = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.ICC_051t2);
        CardDB.Card kidMix = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.ICC_051t3);

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            if (p.ownFandralStaghelm > 0)
            {
                p.minionTransform(own, kidMix);
            }
            else
            {
                switch (choice)
                {
                    case 1: p.minionTransform(own, kid12); break;
                    case 2: p.minionTransform(own, kid15); break;
                }
            }
        }
    }
}