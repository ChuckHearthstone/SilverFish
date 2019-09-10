using Chuck.SilverFish;

namespace SilverFish.cards._02Classic
{
    class Sim_EX1_608 : SimTemplate //* Sorcerer's Apprentice
	{
        // Your spells cost (1) less.

        public override void onAuraStarts(Playfield p, Minion own)
        {
            if (own.own) p.ownSpelsCostMore--;
        }

        public override void onAuraEnds(Playfield p, Minion own)
        {
            if (own.own) p.ownSpelsCostMore++;
        }
	}
}