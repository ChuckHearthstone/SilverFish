namespace Chuck.SilverFish.cards._04Expansion._010TRL
{
    /// <summary>
    /// Regenerate
    /// 再生
    /// </summary>
    public class Sim_TRL_128 : SimTemplate
    {
        /// <summary>
        /// Restore 3 Health.
        /// 恢复3点生命值。
        /// </summary>
        /// <param name="p"></param>
        /// <param name="ownplay"></param>
        /// <param name="target"></param>
        /// <param name="choice"></param>
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            int heal = (ownplay) ? p.getSpellHeal(3) : p.getEnemySpellHeal(3);
            p.minionGetDamageOrHeal(target, -heal);
        }
    }
}