namespace Chuck.SilverFish.cards._04Expansion._012ULD
{
    /// <summary>
    /// Faceless Lurker
    /// 无面潜伏者
    /// </summary>
    public class Sim_ULD_189 : SimTemplate
    {
        /// <summary>
        /// Taunt Battlecry: Double this minion's Health.
        /// 嘲讽，战吼：将该随从的生命值翻倍。
        /// </summary>
        /// <param name="p"></param>
        /// <param name="own"></param>
        /// <param name="target"></param>
        /// <param name="choice"></param>
        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            p.minionGetBuffed(own, 0, own.HealthPoints);
        }
    }
}