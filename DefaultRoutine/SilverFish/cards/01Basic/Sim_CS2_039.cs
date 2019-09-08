using HREngine.Bots;

namespace SilverFish.cards._01Basic
{
	class Sim_CS2_039 : SimTemplate //windfury
	{

//    verleiht einem diener windzorn/.
		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            p.minionGetWindfurry(target);
		}

	}
}