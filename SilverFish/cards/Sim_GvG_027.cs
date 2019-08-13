using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_GVG_027 : SimTemplate //* Iron Sensei
    {
        //At the end of your turn, give another friendly Mech +2/+2.

        public override void onTurnEndsTrigger(Playfield p, Minion triggerEffectMinion, bool turnEndOfOwner)
        {
            if (triggerEffectMinion.own == turnEndOfOwner)
            {
                List<Minion> tmp = turnEndOfOwner ? p.ownMinions : p.enemyMinions;
                int count = tmp.Count;
                if (count > 1)
                {
                    Minion mnn = null;
                    if (triggerEffectMinion.entitiyID != tmp[0].entitiyID) mnn = tmp[0];
                    else mnn = tmp[1];

                    for (int i = 1; i < count; i++)
                    {
                        if (triggerEffectMinion.entitiyID == tmp[i].entitiyID) continue;
                        if (tmp[i].Hp < mnn.Hp) mnn = tmp[i]; //take the weakest
                    }
                    if (mnn != null) p.minionGetBuffed(mnn, 2, 2);
                }
            }
        }
    }
}