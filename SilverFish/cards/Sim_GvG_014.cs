using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_GVG_014 : SimTemplate //* Vol'jin
    {
       //Battlecry: Swap Health with another minion.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            if (target == null) return;

            own.maxHp = target.Hp;
            target.maxHp = own.Hp;

            own.Hp = own.maxHp;
            target.Hp = target.maxHp;
            if (target.wounded)
            {
                target.wounded = false;
                target.handcard.card.sim_card.onEnrageStop(p, target);
            }
        }
    }
}