using Chuck.SilverFish;

namespace SilverFish.cards._04Expansion._006ICC
{
    class Sim_ICC_856: SimTemplate //* Spellweaver
    {
        // Spell Damage +2

        public override void onAuraStarts(Playfield p, Minion own)
        {
            if (own.own) p.spellpower += 2;
            else p.enemyspellpower += 2;
        }

        public override void onAuraEnds(Playfield p, Minion m)
        {
            if (m.own) p.spellpower -= 2;
            else p.enemyspellpower -= 2;
        }
    }
}