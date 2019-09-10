using Chuck.SilverFish;

namespace SilverFish.cards._04Expansion._003OG
{
	class Sim_OG_044 : SimTemplate //* Fandral Staghelm
	{
		//Your Choose One cards have both effects combine.

        public override void onAuraStarts(Playfield p, Minion own)
        {
            if (own.own) p.ownFandralStaghelm++;
        }

        public override void onAuraEnds(Playfield p, Minion m)
        {
            if (m.own) p.ownFandralStaghelm--;
        }
	}
}