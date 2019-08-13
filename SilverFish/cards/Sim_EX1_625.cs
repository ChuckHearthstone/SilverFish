using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_EX1_625 : SimTemplate //* Shadowform
    {
        // Your Hero Power becomes 'Deal 2 damage'. If already in Shadowform: 3 damage.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            CardDB.cardIDEnum newHeroPower = CardDB.cardIDEnum.EX1_625t; // Mind Spike
            if ((ownplay ? p.ownHeroAblility.card.cardIDenum : p.enemyHeroAblility.card.cardIDenum) == CardDB.cardIDEnum.EX1_625t) newHeroPower = CardDB.cardIDEnum.EX1_625t2; // Mind Shatter
            p.setNewHeroPower(newHeroPower, ownplay);
        }
    }
}