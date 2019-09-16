namespace Chuck.SilverFish.cards._04Expansion._012ULD
{
    /// <summary>
    /// Conjured Mirage
    /// 魔法幻象 
    /// </summary>
    public class Sim_ULD_198 : SimTemplate
    {
        /// <summary>
        /// Taunt At the start of your turn, shuffle this minion into your deck.
        /// 嘲讽在你的回合开始时，将该随从洗入你的牌库。
        /// </summary>
        /// <param name="p"></param>
        /// <param name="triggerEffectMinion"></param>
        /// <param name="turnStartOfOwner"></param>
        public override void onTurnStartTrigger(Playfield p, Minion triggerEffectMinion, bool turnStartOfOwner)
        {
            if (triggerEffectMinion.own == turnStartOfOwner)
            {
                p.minionReturnToDeck(triggerEffectMinion, turnStartOfOwner);
            }
        }
    }
}