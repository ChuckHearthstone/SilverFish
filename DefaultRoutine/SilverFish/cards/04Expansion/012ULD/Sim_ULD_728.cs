using HREngine.Bots;
using SilverFish.Enums;

namespace SilverFish.cards._04Expansion._012ULD
{
    /// <summary>
    /// Subdue
    /// 制伏
    /// </summary>
    public class Sim_ULD_728 : SimTemplate
    {
        /// <summary>
        /// Set a minion's Attack and Health to 1.
        /// 将一个随从的攻击力和生命值变为1。
        /// </summary>
        /// <param name="p"></param>
        /// <param name="ownplay"></param>
        /// <param name="target"></param>
        /// <param name="choice"></param>
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.minionSetAngrToX(target, 1);
            p.minionSetLifetoX(target, 1);
        }
    }
}