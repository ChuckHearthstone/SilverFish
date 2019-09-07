using System.Collections.Generic;
using HREngine.Bots;

namespace SilverFish.cards._04Expansion._001GvG
{
    class Sim_GVG_048 : SimTemplate //* Metaltooth Leaper
    {
        //Battlecry: Give your other Mechs +2 Attack.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            List<Minion> temp = (own.own) ? p.ownMinions : p.enemyMinions;
            foreach (Minion m in temp)
            {
                if (m.entitiyID == own.entitiyID) continue;
                if ((TAG_RACE)m.handcard.card.race == TAG_RACE.MECHANICAL)
                {
                    p.minionGetBuffed(m, 2, 0);
                }
            }
        }
    }
}