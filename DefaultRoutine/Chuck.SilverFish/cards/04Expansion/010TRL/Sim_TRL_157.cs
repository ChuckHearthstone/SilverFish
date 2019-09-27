namespace Chuck.SilverFish.cards._04Expansion._010TRL
{
    /// <summary>
    /// Walk the Plank
    /// 走跳板
    /// </summary>
    public class Sim_TRL_157 : SimTemplate
    {
        /// <summary>
        /// Destroy an undamaged minion.
        /// 消灭一个未受伤的随从。
        /// </summary>
        /// <param name="p"></param>
        /// <param name="ownplay"></param>
        /// <param name="target"></param>
        /// <param name="choice"></param>
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            if (target != null)
            {
                p.minionGetDestroyed(target);
            }
        }
    }
}