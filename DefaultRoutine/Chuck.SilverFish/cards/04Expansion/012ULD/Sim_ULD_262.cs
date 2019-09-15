namespace Chuck.SilverFish.cards._04Expansion._012ULD
{
    /// <summary>
    /// High Priest Amet
    /// 高阶祭司阿门特 
    /// </summary>
    public class Sim_ULD_262 : SimTemplate
    {
        /// <summary>
        /// Whenever you summon a minion, set its Health equal to this minion's.
        /// 每当你召唤一个随从，将其生命值设置为与本随从相同。
        /// </summary>
        /// <param name="p"></param>
        /// <param name="triggerEffectMinion"></param>
        /// <param name="summonedMinion"></param>
        public override void onMinionWasSummoned(Playfield p, Minion triggerEffectMinion, Minion summonedMinion)
        {
            if (triggerEffectMinion.own == summonedMinion.own && triggerEffectMinion.entitiyID != summonedMinion.entitiyID)
            {
                summonedMinion.HealthPoints = triggerEffectMinion.HealthPoints;
            }
        }
    }
}