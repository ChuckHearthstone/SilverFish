using HREngine.Bots;

namespace SilverFish.cards._04Expansion._006ICC
{
    class Sim_ICC_093: SimTemplate //* Tuskarr Fisherman
    {
        // Battlecry: Give a friendly minion Spell Damage +1

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            if (target != null)
            {
                target.spellpower++;
                if (target.own) p.spellpower++;
                else p.enemyspellpower++;
            }
        }
    }
}