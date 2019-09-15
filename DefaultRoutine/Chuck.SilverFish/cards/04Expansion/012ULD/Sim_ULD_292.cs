namespace Chuck.SilverFish.cards._04Expansion._012ULD
{
    /// <summary>
    /// Oasis Surger
    /// 绿洲涌动者
    /// </summary>
    public class Sim_ULD_292 : SimTemplate
    {
        /// <summary>
        /// Rush Choose One - Gain +2/+2; or Summon a copy of this minion.
        /// 突袭抉择：获得+2/+2；或召唤一个该随从的复制。
        /// </summary>
        /// <param name="p"></param>
        /// <param name="own"></param>
        /// <param name="target"></param>
        /// <param name="choice"></param>
        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            if (choice == 1 || (p.ownFandralStaghelm > 0 && own.own))
            {
                p.minionGetBuffed(own, 2, 2);
            }
            if (choice == 2 || (p.ownFandralStaghelm > 0 && own.own))
            {
                p.CallKid(target.handcard.card, own.zonepos, own.own);
                p.ownMinions[own.zonepos + 1].setMinionToMinion(own);
            }
        }
    }
}