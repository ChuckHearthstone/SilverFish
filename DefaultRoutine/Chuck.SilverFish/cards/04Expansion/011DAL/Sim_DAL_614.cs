namespace Chuck.SilverFish
{
    /// <summary>
    /// Kobold Lackey
	/// 狗头人跟班
    /// </summary>
    class Sim_DAL_614 : SimTemplate
    {
        /// <summary>
        /// Battlecry: Deal 2 damage.
		/// 战吼：造成2点伤害。
        /// </summary>
        /// <param name="p"></param>
        /// <param name="own"></param>
        /// <param name="target"></param>
        /// <param name="choice"></param>
        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            int dmg = 2;
            p.minionGetDamageOrHeal(target, dmg);
        }
    }
}