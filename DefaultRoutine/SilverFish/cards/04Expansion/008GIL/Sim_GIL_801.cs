using Chuck.SilverFish;

namespace SilverFish.cards._04Expansion._008GIL
{
    /// <summary>
    /// Snap Freeze
    /// 急速冷冻
    /// </summary>
    public class Sim_GIL_801 : SimTemplate
    {
        /// <summary>
        /// Freeze a minion. If it's already Frozen, destroy it.
        /// 冻结一个随从。如果该随从已被冻结，则将其消灭。
        /// </summary>
        /// <param name="p"></param>
        /// <param name="ownplay"></param>
        /// <param name="target"></param>
        /// <param name="choice"></param>
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            if (target.frozen)
            {
                p.minionGetDestroyed(target);
            }
            else
            {
                p.minionGetFrozen(target);
            }
        }
    }
}
