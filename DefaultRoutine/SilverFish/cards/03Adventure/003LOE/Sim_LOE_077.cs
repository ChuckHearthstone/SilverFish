using Chuck.SilverFish;

namespace SilverFish.cards._03Adventure._003LOE
{
	class Sim_LOE_077 : SimTemplate //* Brann Bronzebeard
	{
		//Your Battlecries trigger twice.
		
        public override void onAuraStarts(Playfield p, Minion own)
		{
            if (own.own) p.ownBrannBronzebeard++;
            else p.enemyBrannBronzebeard++;
		}

        public override void onAuraEnds(Playfield p, Minion m)
        {
            if (m.own) p.ownBrannBronzebeard--;
            else p.enemyBrannBronzebeard--;
        }
	}
}