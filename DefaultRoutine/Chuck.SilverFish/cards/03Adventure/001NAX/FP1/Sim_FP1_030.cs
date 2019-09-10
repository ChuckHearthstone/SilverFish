using Chuck.SilverFish;

namespace SilverFish.cards._03Adventure._001NAX.FP1
{
	class Sim_FP1_030 : SimTemplate //loatheb
	{

//    kampfschrei:/ im nächsten zug kosten zauber für euren gegner (5) mehr.
		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            p.loatheb = true;
		}

	

	}
}