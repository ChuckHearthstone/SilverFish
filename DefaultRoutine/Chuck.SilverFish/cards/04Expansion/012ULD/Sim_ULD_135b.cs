namespace Chuck.SilverFish.cards._04Expansion._012ULD
{
    /// <summary>
    /// Drink the Water
    /// 饮用泉水
    /// </summary>
    public class Sim_ULD_135b : SimTemplate
    {
        /// <summary>
        /// Restore 12 Health.
        /// 恢复12点生命值。
        /// </summary>
        /// <param name="p"></param>
        /// <param name="ownplay"></param>
        /// <param name="target"></param>
        /// <param name="choice"></param>
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            int heal = (ownplay) ? p.getSpellHeal(12) : p.getEnemySpellHeal(12);
            p.minionGetDamageOrHeal(target, -heal);
        }
    }
}