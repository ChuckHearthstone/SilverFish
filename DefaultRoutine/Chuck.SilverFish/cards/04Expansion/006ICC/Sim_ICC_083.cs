using Chuck.SilverFish;

namespace SilverFish.cards._04Expansion._006ICC
{
    class Sim_ICC_083: SimTemplate //* Doomed Apprentice
    {
        // Your opponent's spells cost (1) more.

        public override void onAuraStarts(Playfield p, Minion own)
        {
            if (!own.own) p.ownSpelsCostMore++;
        }

        public override void onAuraEnds(Playfield p, Minion own)
        {
            if (!own.own) p.ownSpelsCostMore--;
        }
    }
}