using System.Collections.Generic;
using HREngine.Bots;

namespace SilverFish.cards._04Expansion._001GvG
{
    class Sim_GVG_107 : SimTemplate //* Enhance-o Mechano
    {
        //  Battlecry: Give your other minions Windfury Taunt or Divine Shield

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            List<Minion> temp = (own.own) ? p.ownMinions : p.enemyMinions;

            foreach (Minion m in temp)
            {
                if (m.entitiyID == own.entitiyID) continue;
                if (!m.taunt)
                {
                    m.taunt = true;
                    if (m.own) p.anzOwnTaunt++;
                    else p.anzEnemyTaunt++;
                }
            }
        }
    }
}