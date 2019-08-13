using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_OG_134 : SimTemplate //* Yogg-Saron, Hope's End
    {
        //Battlecry: Cast a random spell for each spell you've cast this game (targets chosen randomly).

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            if (own.own)
            {
                if (p.ownMinions.Count < p.enemyMinions.Count) p.evaluatePenality -= 15;
                else p.evaluatePenality -= 5;
                foreach (Minion m in p.ownMinions) m.Ready = false;
                foreach (Minion m in p.enemyMinions) m.frozen = true;
                p.ownHero.Hp += 7;
            }
        }
    }
}