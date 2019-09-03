using HREngine.Bots;

namespace SilverFish.cards._04Expansion._006ICC
{
    class Sim_ICC_808: SimTemplate //* Crypt Lord
    {
        // Taunt. After you summon a minion, gain +1 Health.
        
        public override void onMinionWasSummoned(Playfield p, Minion m, Minion summonedMinion)
        {
            if (m.entitiyID != summonedMinion.entitiyID && m.own == summonedMinion.own)
            {
                p.minionGetBuffed(m, 0, 1);
            }
        }
    }
}