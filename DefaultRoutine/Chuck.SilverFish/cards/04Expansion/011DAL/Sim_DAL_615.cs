namespace Chuck.SilverFish
{
    /// <summary>
    /// Witchy Lackey
    /// 女巫跟班
    /// </summary>
    class Sim_DAL_615 : SimTemplate
    {
        /// <summary>
        /// Battlecry: Transform a friendly minion into one that costs 1 more.
        /// 战吼：将一个友方随从变形成为一个法力值消耗增加1点的随从。
        /// </summary>
        /// <param name="p"></param>
        /// <param name="own"></param>
        /// <param name="target"></param>
        /// <param name="choice"></param>
        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            if (target != null)
            {
                p.minionTransform(target, p.getRandomCardForManaMinion(target.handcard.card.cost + 1));
            }
        }
    }
}