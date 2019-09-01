using HREngine.Bots;

namespace SilverFish.cards._04Expansion._002AT
{
	class Sim_AT_014 : SimTemplate //* Shadowfiend
	{
		//Whenever you draw a card reduce its cost by (1)

        public override void onAuraStarts(Playfield p, Minion own)
		{
            if (own.own) p.anzOwnShadowfiend++;
		}

        public override void onAuraEnds(Playfield p, Minion own)
        {
            if (own.own) p.anzOwnShadowfiend--;
        }
	}
}