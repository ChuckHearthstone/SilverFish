using System.Collections.Generic;
using HREngine.Bots;

namespace SilverFish.cards._04Expansion._008GIL
{
    /// <summary>
    /// Wyrmguard
    /// 龙骨卫士
    /// </summary>
    public class Sim_GIL_526 : SimTemplate
    {
        /// <summary>
        /// Battlecry: If you're holding a Dragon, gain +1 Attack and Taunt.
        /// 战吼：如果你的手牌中有龙牌，便获得+1攻击力和嘲讽。
        /// </summary>
        /// <param name="p"></param>
        /// <param name="m"></param>
        /// <param name="target"></param>
        /// <param name="choice"></param>
        public override void getBattlecryEffect(Playfield p, Minion m, Minion target, int choice)
        {
            if (m.own)
            {
                bool dragonInHand = false;
                foreach (Handmanager.Handcard hc in p.owncards)
                {
                    if ((TAG_RACE)hc.card.race == TAG_RACE.DRAGON)
                    {
                        dragonInHand = true;
                        break;
                    }
                }
                if (dragonInHand)
                {
                    p.minionGetBuffed(m, 1, 0);
                    m.taunt = true;
                    p.anzOwnTaunt++;
                }
            }
            else
            {
                if (p.enemyAnzCards >= 2)
                {
                    p.minionGetBuffed(m, 1, 0);
                    m.taunt = true;
                    p.anzEnemyTaunt++;
                }
            }
        }
    }
}
