namespace Chuck.SilverFish.cards._04Expansion._012ULD
{
    /// <summary>
    /// Tomb Warden
    /// 陵墓守望者
    /// </summary>
    public class Sim_ULD_253 : SimTemplate
    {
        /// <summary>
        /// Taunt Battlecry: Summon a copy of this minion.
        /// 嘲讽战吼：召唤一个该随从的复制。
        /// </summary>
        /// <param name="p"></param>
        /// <param name="own"></param>
        /// <param name="target"></param>
        /// <param name="choice"></param>
        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            p.CallKid(own.handcard.card, own.zonepos, own.own);
            p.ownMinions[own.zonepos + 1].setMinionToMinion(own);
        }
    }
}