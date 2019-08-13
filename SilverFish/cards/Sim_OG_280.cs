using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_OG_280 : SimTemplate //* C'Thun
    {
        //Battlecry: Deal damage equal to this minion's Attack randomly split among all enemies.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            int times = p.anzOgOwnCThunAngrBonus + 6 - own.Angr;
            if (times < 1) times = own.Angr;
            else times += own.Angr;
            p.allCharsOfASideGetRandomDamage(!own.own, times);
            p.allMinionOfASideGetDamage(!own.own, 1);
        }
    }
}