using System.Collections.Generic;
using Chuck.SilverFish;

namespace SilverFish.cards._04Expansion._001GvG
{
    class Sim_GVG_110t : SimTemplate //* Boom Bot
    {
        //  Deathrattle: Deal 1-4 damage to a random enemy.

        public override void onDeathrattle(Playfield p, Minion m)
        {
            List<Minion> temp = (m.own) ? p.enemyMinions : p.ownMinions;
            Minion target = p.searchRandomMinion(temp, searchmode.searchHighestHP);
            if (target == null) target = (m.own) ? p.enemyHero : p.ownHero;
            p.minionGetDamageOrHeal(target, 2);
        }
    }
}