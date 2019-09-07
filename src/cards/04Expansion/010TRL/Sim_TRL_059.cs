using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_TRL_059 : SimTemplate //*Bog Slosher
//沼泽游荡者
    {
        //<b>Battlecry:</b> Return a friendly minion to your hand and give it +2/+2."


        public override void getBattlecryEffect(Playfield p, Minion m, Minion target, int choice)
        {
            if (target != null) p.minionReturnToHand(target, target.own, 0,2,2);

        }
    }
}