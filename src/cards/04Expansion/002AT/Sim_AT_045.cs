using HREngine.Bots;

namespace SilverFish.cards._04Expansion._002AT
{
	class Sim_AT_045 : SimTemplate //* Aviana
	{
		//Your minions cost (1).

		public override void onAuraStarts(Playfield p, Minion m)
		{
            if (m.own) p.anzOwnAviana++;
		}

        public override void onAuraEnds(Playfield p, Minion m)
        {
            if (m.own) p.anzOwnAviana--;
        }
	}
}