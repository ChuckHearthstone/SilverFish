using System.Collections.Generic;

namespace Chuck.SilverFish.cards._04Expansion._011DAL
{
    /// <summary>
    /// Dalaran Librarian
    /// 达拉然图书管理员
    /// </summary>
    public class Sim_DAL_735 : SimTemplate
    {
        /// <summary>
        /// Battlecry: Silence adjacent minions.
        /// 战吼：沉默相邻的随从。
        /// </summary>
        /// <param name="p"></param>
        /// <param name="own"></param>
        /// <param name="target"></param>
        /// <param name="choice"></param>
        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            List<Minion> temp = (own.own) ? p.ownMinions : p.enemyMinions;
            foreach (Minion m in temp)
            {
                if (m.zonepos == own.zonepos - 1 || m.zonepos == own.zonepos + 1)
                {
                    p.minionGetSilenced(m);
                }
            }
        }
    }
}