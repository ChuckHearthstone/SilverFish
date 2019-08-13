using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_OG_102 : SimTemplate //* Darkspeaker
    {
        //Battlecry: Swap stats with a friendly minion.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            if (target == null) return;

            int tmpHp = target.Hp;
            int tmpMHp = target.maxHp;
            int tmpAngr = target.Angr;

            target.Hp = own.Hp;
            target.maxHp = own.maxHp;
            target.Angr = own.Angr;

            own.Hp = tmpHp;
            own.maxHp= tmpMHp;
            own.Angr = tmpAngr;
        }
    }
}