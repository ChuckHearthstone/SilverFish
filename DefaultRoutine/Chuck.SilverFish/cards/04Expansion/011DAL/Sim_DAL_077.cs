namespace Chuck.SilverFish.cards._04Expansion._011DAL
{
    /// <summary>
    /// Toxfin
    /// 毒鳍鱼人
    /// </summary>
    public class Sim_DAL_077 : SimTemplate
    {
        /// <summary>
        /// Battlecry: Give a friendly Murloc Poisonous.
        /// 战吼：使一个友方鱼人获得剧毒。
        /// </summary>
        /// <param name="p"></param>
        /// <param name="own"></param>
        /// <param name="target"></param>
        /// <param name="choice"></param>
        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            if (target != null)
            {
                target.poisonous = true;
            }
        }
    }
}