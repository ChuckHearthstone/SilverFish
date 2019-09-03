using HREngine.Bots;

namespace SilverFish.cards._04Expansion._006ICC
{
    class Sim_ICC_021: SimTemplate //* Exploding Bloatbat
    {
        // Deathrattle: Deal 2 damage to all enemy minions.

        public override void onDeathrattle(Playfield p, Minion m)
        {
            p.allMinionOfASideGetDamage(!m.own, 2);
        }
    }
}