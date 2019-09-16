namespace Chuck.SilverFish.cards._04Expansion._012ULD
{
    /// <summary>
    /// Mortuary Machine
    /// 机械法医
    /// </summary>
    public class Sim_ULD_702 : SimTemplate
    {
        /// <summary>
        /// After your opponent plays a minion, give it Reborn.
        /// 在你的对手使用一张随从牌后，使其获得复生。
        /// </summary>
        /// <param name="p"></param>
        /// <param name="triggerEffectMinion"></param>
        /// <param name="summonedMinion"></param>
        public override void onMinionWasSummoned(Playfield p, Minion triggerEffectMinion, Minion summonedMinion)
        {
            if (triggerEffectMinion.own != summonedMinion.own)
            {
                summonedMinion.Reborn = true;
            }
        }
    }
}