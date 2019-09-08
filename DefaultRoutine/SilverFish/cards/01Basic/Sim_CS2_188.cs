using HREngine.Bots;

namespace SilverFish.cards._01Basic
{
	class Sim_CS2_188 : SimTemplate //abusivesergeant
	{

//    kampfschrei:/ verleiht einem diener +2 angriff in diesem zug.
		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            if (target != null) p.minionGetTempBuff(target, 2, 0);
		}


	}
}