using HREngine.Bots;

namespace SilverFish.cards._04Expansion._008GIL
{
    /// <summary>
    /// Witchwood Imp
    /// 女巫森林小鬼
    /// </summary>
    public class Sim_GIL_608 : SimTemplate
    {
        /// <summary>
        /// Stealth Deathrattle: Give a random   friendly minion +2 Health.
        /// 潜行，亡语：随机使一个友方随从获得+2生命值。
        /// </summary>
        /// <param name="p"></param>
        /// <param name="m"></param>
        public override void onDeathrattle(Playfield p, Minion m)
        {
            Minion target = (m.own) ? p.searchRandomMinion(p.ownMinions, searchmode.searchLowestAttack) : p.searchRandomMinion(p.enemyMinions, searchmode.searchLowestAttack);
            if (target != null) p.minionGetBuffed(target, 0, 2);
        }
    }
}
