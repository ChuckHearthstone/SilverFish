namespace Chuck.SilverFish.cards._04Expansion._011DAL
{
    /// <summary>
    /// Conjurer's Calling
    /// 咒术师的召唤
    /// </summary>
    public class Sim_DAL_177 : SimTemplate
    {
        /// <summary>
        /// Twinspell Destroy a minion.Summon 2 minions of the same Cost to replace it.
        /// 双生法术消灭一个随从。召唤两个法力值消耗相同的随从来替换它。
        /// </summary>
        /// <param name="p"></param>
        /// <param name="ownplay"></param>
        /// <param name="target"></param>
        /// <param name="choice"></param>
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.minionGetDestroyed(target);
            int pos = (ownplay) ? p.ownMinions.Count : p.enemyMinions.Count;
            p.CallKid(p.getRandomCardForManaMinion(target.handcard.manacost), pos, ownplay);
            p.CallKid(p.getRandomCardForManaMinion(target.handcard.manacost), pos + 1, ownplay);
        }
    }
}