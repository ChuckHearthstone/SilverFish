namespace Chuck.SilverFish.cards._04Expansion._012ULD
{
    /// <summary>
    /// Generous Mummy
    /// 慷慨的木乃伊
    /// </summary>
    public class Sim_ULD_214 : SimTemplate
    {
        /// <summary>
        /// Reborn Your opponent's cards cost (1) less.
        /// 复生 你对手的卡牌法力值消耗减少（1）点。
        /// </summary>
        /// <param name="p"></param>
        /// <param name="own"></param>
        public override void onAuraStarts(Playfield p, Minion own)
        {
            if (!own.own) p.myCardsCostLess++;
        }

        public override void onAuraEnds(Playfield p, Minion own)
        {
            if (!own.own) p.myCardsCostLess--;
        }
    }
}