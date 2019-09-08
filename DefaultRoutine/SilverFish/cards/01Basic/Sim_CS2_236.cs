using HREngine.Bots;

namespace SilverFish.cards._01Basic
{
	class Sim_CS2_236 : SimTemplate //divinespirit
	{

//    verdoppelt das leben eines dieners.

		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            p.minionGetBuffed(target, 0, target.HealthPoints);
		}

	}
}