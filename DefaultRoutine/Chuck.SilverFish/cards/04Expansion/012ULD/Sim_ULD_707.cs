namespace Chuck.SilverFish.cards._04Expansion._012ULD
{
    /// <summary>
    /// Plague of Wrath
    /// 愤怒之灾祸
    /// </summary>
    public class Sim_ULD_707 : SimTemplate
    {
        /// <summary>
        /// Destroy all damaged minions.
        /// 消灭所有受伤的随从。
        /// </summary>
        /// <param name="p"></param>
        /// <param name="ownplay"></param>
        /// <param name="target"></param>
        /// <param name="choice"></param>
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            foreach (Minion m in p.ownMinions)
            {
                if (m.wounded) p.minionGetDestroyed(m);
            }
            foreach (Minion m in p.enemyMinions)
            {
                if (m.wounded) p.minionGetDestroyed(m);
            }
        }
    }
}