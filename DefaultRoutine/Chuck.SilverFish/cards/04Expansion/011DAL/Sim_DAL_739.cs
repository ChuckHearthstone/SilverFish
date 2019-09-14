namespace Chuck.SilverFish.cards._04Expansion._011DAL
{
    /// <summary>
    /// Goblin Lackey
    /// 地精跟班
    /// </summary>
    class Sim_DAL_739 : SimTemplate
    {
        /// <summary>
        /// Battlecry: Give a friendly minion +1 Attack and Rush.
        /// 战吼：使一个友方随从获得+1攻击力和突袭。
        /// </summary>
        /// <param name="p"></param>
        /// <param name="own"></param>
        /// <param name="target"></param>
        /// <param name="choice"></param>
        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            if (target != null)
            {
                p.minionGetBuffed(target, 1, 0);
            }
            //未实现突袭
        }
    }
}