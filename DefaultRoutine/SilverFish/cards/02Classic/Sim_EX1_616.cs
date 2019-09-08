using HREngine.Bots;

namespace SilverFish.cards._02Classic
{
	class Sim_EX1_616 : SimTemplate //manawraith
	{

//    alle diener kosten (1) mehr.
        public override void onAuraStarts(Playfield p, Minion own)
		{
            p.managespenst ++;
		}

        public override void onAuraEnds(Playfield p, Minion m)
        {
            p.managespenst--;
        }

	}
}