using System.Collections.Generic;
using HREngine.Bots;

namespace SilverFish.cards._04Expansion._008GIL
{
    /// <summary>
    /// Totem Cruncher
    /// 图腾啃食者
    /// </summary>
    public class Sim_GIL_583 : SimTemplate
    {
        /// <summary>
        /// Taunt Battlecry: Destroy your Totems. Gain +2/+2 for each destroyed.
        /// 嘲讽，战吼：摧毁你的所有图腾。每摧毁一个图腾，便获得+2/+2。
        /// </summary>
        /// <param name="p"></param>
        /// <param name="own"></param>
        /// <param name="target"></param>
        /// <param name="choice"></param>
        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            List<Minion> temp = (own.own) ? p.ownMinions : p.enemyMinions;
            int totemNum = 0;
            foreach (Minion m in temp)
            {
                if ((TAG_RACE)m.handcard.card.race == TAG_RACE.TOTEM)
                {
                    p.minionGetDestroyed(m);
                    totemNum++;
                }
            }
            if (totemnum >= 1) p.minionGetBuffed(own, totemnum * 2, totemnum * 2);
        }
    }
}
