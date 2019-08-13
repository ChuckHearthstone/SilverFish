using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_OG_121 : SimTemplate //* Cho'Gall
    {
        //Battlecry: The next spell you cast this turn costs Health instead of Mana.

        public override void getBattlecryEffect(Playfield p, Minion m, Minion target, int choice)
        {
            if (m.own) p.nextSpellThisTurnCostHealth = true;
        }
    }
}