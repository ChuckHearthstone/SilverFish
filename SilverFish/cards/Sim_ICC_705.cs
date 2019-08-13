using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_ICC_705: SimTemplate //* Bonemare
    {
        // Battlecry: Give a friendly minion +4/+4 and Taunt.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            if (target != null)
            {
                p.minionGetBuffed(target, 4, 4);
                if (!target.taunt)
                {
                    target.taunt = true;
                    if (target.own) p.anzOwnTaunt++;
                    else p.anzEnemyTaunt++;
                }
            }
        }
    }
}