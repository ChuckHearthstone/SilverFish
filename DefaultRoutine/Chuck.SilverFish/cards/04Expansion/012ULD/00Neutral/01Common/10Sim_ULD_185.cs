namespace Chuck.SilverFish.cards._04Expansion._012ULD._00Neutral._01Common
{
    /// <summary>
    /// Temple Berserker
    /// 神殿狂战士
    /// </summary>
    public class Sim_ULD_185 : SimTemplate
    {
        /// <summary>
        /// Reborn Has +2 Attack while damaged.
        /// 复生受伤时具有+2攻击力。
        /// </summary>
        /// <param name="p"></param>
        /// <param name="m"></param>
        public override void onEnrageStart(Playfield p, Minion m)
        {
            m.Attack += 2;
        }

        public override void onEnrageStop(Playfield p, Minion m)
        {
            m.Attack -= 2;
        }
    }
}