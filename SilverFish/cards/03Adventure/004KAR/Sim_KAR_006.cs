using HREngine.Bots;

namespace SilverFish.cards._03Adventure._004KAR
{
	class Sim_KAR_006 : SimTemplate //* Cloaked Huntress
	{
		//Your Secrets cost (0).

		public override void onAuraStarts(Playfield p, Minion m)
		{
            if (m.own) p.anzOwnCloakedHuntress++;
		}

        public override void onAuraEnds(Playfield p, Minion m)
        {
            if (m.own) p.anzOwnCloakedHuntress--;
        }
	}
}