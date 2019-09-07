using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_PART_003 : SimTemplate //* Rusty Horn
    {
        // Give a minion Taunt.  

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            if (!target.taunt)
            {
                target.taunt = true;
                if (target.own) p.anzOwnTaunt++;
                else p.anzEnemyTaunt++;
            }
        }
    }
}