using Chuck.SilverFish;

namespace SilverFish.cards._03Adventure._001NAX.FP1
{
	class Sim_FP1_024 : SimTemplate //unstableghoul
	{

//    spott/. todesröcheln:/ fügt allen dienern 1 schaden zu.

        public override void onDeathrattle(Playfield p, Minion m)
        {
            p.allMinionsGetDamage(1);
        }


	}
}