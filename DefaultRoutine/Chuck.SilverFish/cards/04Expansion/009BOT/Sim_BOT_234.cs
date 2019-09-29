namespace Chuck.SilverFish.cards._04Expansion._009BOT
{
    /// <summary>
    /// Shrink Ray
    /// 萎缩射线
    /// </summary>
    public class Sim_BOT_234 : SimTemplate
    {
        /// <summary>
        /// Set the Attack and Health of all minions to 1.
        /// 将所有随从的攻击力和生命值变为1。
        /// </summary>
        /// <param name="p"></param>
        /// <param name="ownplay"></param>
        /// <param name="target"></param>
        /// <param name="choice"></param>
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            foreach (Minion m in p.ownMinions)
            {
                p.minionSetAngrToX(m, 1);
                p.minionSetLifetoX(m, 1);
            }
            foreach (Minion m in p.enemyMinions)
            {
                p.minionSetAngrToX(m, 1);
                p.minionSetLifetoX(m, 1);
            }
        }
    }
}