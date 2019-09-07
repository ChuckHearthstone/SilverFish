using HREngine.Bots;

namespace SilverFish.cards._04Expansion._006ICC
{
    class Sim_ICC_214: SimTemplate //* Obsidian Statue
    {
        // Taunt. Lifesteal. Deathrattle: Destroy a random enemy minion.

        public override void onDeathrattle(Playfield p, Minion m)
        {
            Minion target = p.searchRandomMinion(m.own ? p.enemyMinions : p.ownMinions, searchmode.searchLowestHP);
            if (target != null) p.minionGetDestroyed(target);
        }
    }
}