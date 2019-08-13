using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_ICC_062: SimTemplate //* Mountainfire Armor
    {
        // Deathrattle: If it's your opponent's turn, gain 6 Armor.

        public override void onDeathrattle(Playfield p, Minion m)
        {
            if (!p.isOwnTurn) p.minionGetArmor(m.own ? p.ownHero : p.enemyHero, 6);
        }
    }
}