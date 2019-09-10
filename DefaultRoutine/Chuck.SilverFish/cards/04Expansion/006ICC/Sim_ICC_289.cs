using Chuck.SilverFish;

namespace SilverFish.cards._04Expansion._006ICC
{
    class Sim_ICC_289: SimTemplate //* Moorabi
    {
        // Whenever another minion is Frozen, add a copy of it to your hand.

        public override void onAuraStarts(Playfield p, Minion own)
        {
            p.anzMoorabi++;
        }

        public override void onAuraEnds(Playfield p, Minion m)
        {
            p.anzMoorabi--;
        }
    }
}