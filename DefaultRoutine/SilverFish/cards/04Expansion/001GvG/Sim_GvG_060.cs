using System.Collections.Generic;
using HREngine.Bots;

namespace SilverFish.cards._04Expansion._001GvG
{
    class Sim_GVG_060 : SimTemplate //Quartermaster
    {

        //   Battlecry: Give your Silver Hand Recruits +2/+2.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            List<Minion> temp = (own.own) ? p.ownMinions : p.enemyMinions;
            foreach (Minion m in temp)
            {
                if (m.name == CardDB.CardName.silverhandrecruit) p.minionGetBuffed(m, 2, 2);
            }
        }

       
    }

}