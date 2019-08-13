using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_AT_094 : SimTemplate //Flame Juggler
    {

        //Battlecry: Deal 1 damage to a random enemy.


        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            p.doDmgToRandomEnemyCLIENT2(1, true, own.own);
        }
    }
}