using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_ICC_827: SimTemplate //* Valeera the Hollow
    {
        // Battlecry: Gain Stealth until your next turn.
        
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.setNewHeroPower(CardDB.cardIDEnum.ICC_827p, ownplay); // Death's Shadow
            if (ownplay)
            {
                p.ownHero.armor += 5;
                p.ownHero.stealth = true;
                p.ownHero.conceal = true;
            }
            else
            {
                p.enemyHero.armor += 5;
                p.enemyHero.stealth = true;
                p.enemyHero.conceal = true;
            }
        }
    }
}