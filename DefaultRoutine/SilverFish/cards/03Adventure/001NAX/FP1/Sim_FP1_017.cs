using HREngine.Bots;

namespace SilverFish.cards._03Adventure._001NAX.FP1
{
	class Sim_FP1_017 : SimTemplate //nerubarweblord
	{

//    diener mit kampfschrei/ kosten (2) mehr.
        public override void onAuraStarts(Playfield p, Minion own)
		{
            p.nerubarweblord++;
		}

        public override void onAuraEnds(Playfield p, Minion m)
        {
            p.nerubarweblord--;
        }


	}
}