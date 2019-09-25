namespace Chuck.SilverFish.cards._04Expansion._009BOT
{
    /// <summary>
    /// Topsy Turvy
    /// 引力翻转
    /// </summary>
    public class Sim_BOT_517 : SimTemplate
    {
        /// <summary>
        /// Swap a minion's Attack and Health.
        /// 使一个随从的攻击力和生命值互换。
        /// </summary>
        /// <param name="p"></param>
        /// <param name="ownplay"></param>
        /// <param name="target"></param>
        /// <param name="choice"></param>
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.minionSwapAngrAndHP(target);
        }
    }
}