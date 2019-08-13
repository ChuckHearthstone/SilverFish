using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_ICC_221 : SimTemplate //* Leeching Poison
    {
        //Give your weapon Lifesteal.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            if (ownplay) p.ownWeapon.lifesteal = true;
            else p.enemyWeapon.lifesteal = true;
        }
    }
}