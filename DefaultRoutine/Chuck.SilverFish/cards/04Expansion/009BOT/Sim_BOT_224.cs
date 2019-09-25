namespace Chuck.SilverFish.cards._04Expansion._009BOT
{
    /// <summary>
    /// Doubling Imp
    /// 双生小鬼
    /// </summary>
    public class Sim_BOT_224 : SimTemplate
    {
        /// <summary>
        /// Battlecry: Summon a copy of this minion.
        /// 战吼：召唤该随从的一个复制。
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