namespace Chuck.SilverFish.cards._04Expansion._011DAL
{
    /// <summary>
    /// Mutate
    /// 突变
    /// </summary>
    public class Sim_DAL_071 : SimTemplate
    {
        /// <summary>
        /// Transform a friendly minion into a random one that costs (1) more.
        /// 将一个友方随从随机变形成为一个法力值消耗增加（1）点的随从。
        /// </summary>
        /// <param name="p"></param>
        /// <param name="ownplay"></param>
        /// <param name="target"></param>
        /// <param name="choice"></param>
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.minionTransform(target, p.getRandomCardForManaMinion(target.handcard.card.cost + 1));
        }
    }
}