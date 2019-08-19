using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_OG_291 : SimTemplate //* Shadowcaster
    {
        //Battlecry: Choose a friendly minion. Add a 1/1 copy to your hand that costs (1).

        public override void getBattlecryEffect(Playfield p, Minion m, Minion target, int choice)
        {
            if (target != null)
            {
                if (m.own)
                {
                    p.drawACard(target.handcard.card.name, m.own, true);
                    int i = p.owncards.Count - 1;
                    p.owncards[i].addattack = 1 - p.owncards[i].card.Attack;
                    p.owncards[i].addHp = 1 - p.owncards[i].card.Health;
                    p.owncards[i].manacost = 1;
                }
            }
        }
    }
}