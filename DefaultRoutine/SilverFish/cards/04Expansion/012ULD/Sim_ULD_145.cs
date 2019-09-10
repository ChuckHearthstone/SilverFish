using HREngine.Bots;

namespace SilverFish.cards._04Expansion._012ULDS
{
    /// <summary>
    /// Brazen Zealot
    /// 英勇狂热者
    /// </summary>
    public class Sim_ULD_145 : SimTemplate
    {
        /// <summary>
        /// Whenever you summon a minion, gain +1 Attack.
        /// 每当你召唤一个随从，获得+1攻击力。
        /// </summary>
        /// <param name="p"></param>
        /// <param name="m"></param>
        /// <param name="summonedMinion"></param>
        public override void onMinionWasSummoned(Playfield p, Minion m, Minion summonedMinion)
        {
            if (m.entitiyID != summonedMinion.entitiyID && m.own == summonedMinion.own)
            {
                p.minionGetBuffed(m, 1, 0);
            }
        }
    }
}