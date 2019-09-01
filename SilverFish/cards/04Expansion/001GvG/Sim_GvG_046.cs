using System.Collections.Generic;
using HREngine.Bots;

namespace SilverFish.cards._04Expansion._001GvG
{
    class Sim_GVG_046 : SimTemplate //* King of Beasts
    {
        //   Taunt Battlecry: Gain +1 Attack for each other Beast you have.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            int bonusattack = 0;
            List<Minion> temp  = (own.own) ? p.ownMinions : p.enemyMinions;
            foreach (Minion m in temp)
            {
                if (m.entitiyID == own.entitiyID) continue;
                if ((TAG_RACE)m.handcard.card.race == TAG_RACE.PET) bonusattack++;
            }
            p.minionGetBuffed(own, bonusattack, 0);
        }
    }
}