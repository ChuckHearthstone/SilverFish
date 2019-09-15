namespace Chuck.SilverFish.cards._04Expansion._012ULD
{
    /// <summary>
    /// Wretched Reclaimer
    /// 卑劣的回收者
    /// </summary>
    public class Sim_ULD_269 : SimTemplate
    {
        /// <summary>
        /// Battlecry: Destroy a friendly minion, then return it to life with full Health.
        /// 战吼：消灭一个友方随从，然后将其复活，并具有所有生命值。
        /// </summary>
        /// <param name="p"></param>
        /// <param name="own"></param>
        /// <param name="target"></param>
        /// <param name="choice"></param>
        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            if (target != null)
            {
                bool minionOwn = target.own;
                int minionPos = target.zonepos;
                CardDB.Card c = target.handcard.card;
                p.minionGetDestroyed(target);
                p.CallKid(c, minionPos, minionOwn);
            }
        }
    }
}