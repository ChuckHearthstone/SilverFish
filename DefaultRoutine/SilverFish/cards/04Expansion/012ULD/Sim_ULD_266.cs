using HREngine.Bots;
using SilverFish.Enums;

namespace SilverFish.cards._04Expansion._012ULD
{
    /// <summary>
    /// Grandmummy
    /// 木奶伊
    /// </summary>
    public class Sim_ULD_266 : SimTemplate
    {
        /// <summary>
        /// Reborn Deathrattle: Give a random friendly minion +1/+1.
        /// 复生，亡语：随机使一个友方随从获得+1/+1。
        /// </summary>
        /// <param name="p"></param>
        /// <param name="m"></param>
        public override void onDeathrattle(Playfield p, Minion m)
        {
            Minion target = (m.own) ? p.searchRandomMinion(p.ownMinions, searchmode.searchLowestAttack) : p.searchRandomMinion(p.enemyMinions, searchmode.searchLowestAttack);
            if (target != null) p.minionGetBuffed(target, 1, 1);
        }
    }
}