using Chuck.SilverFish;

namespace SilverFish.cards._01Basic
{
	class Sim_CS2_227 : SimTemplate //* Venture Co. Mercenary
	{
        //Your minions cost (3) more.

        public override void onAuraStarts(Playfield p, Minion own)
		{
           if(own.own) p.ownMinionsCostMore += 3;
		}

        public override void onAuraEnds(Playfield p, Minion own)
        {
           if(own.own) p.ownMinionsCostMore -= 3;
        }
	}
}