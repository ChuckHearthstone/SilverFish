using System.Collections.Generic;
using HREngine.Bots;

namespace SilverFish.cards._04Expansion._008GIL
{
    /// <summary>
    /// Lost Spirit
    /// 迷失的幽魂
    /// </summary>
    public class Sim_GIL_513 : SimTemplate
    {
        /// <summary>
        /// "LocStringEnUs": "Deathrattle: Give your minions +1 Attack.",
        /// "LocStringZhCn": "亡语：使你的所有随从获得+1攻击力。",
        /// </summary>
        /// <param name="p"></param>
        /// <param name="m"></param>
        public override void onDeathrattle(Playfield p, Minion m)
        {
            List<Minion> temp = (m.own) ? p.ownMinions : p.enemyMinions;
            foreach (Minion mn in temp)
            {
                p.minionGetBuffed(mn, 1, 0);
            }
        }
    }
}