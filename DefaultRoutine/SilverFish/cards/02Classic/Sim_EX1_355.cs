using HREngine.Bots;

namespace SilverFish.cards._02Classic
{
	class Sim_EX1_355 : SimTemplate //blessedchampion
	{

//    verdoppelt den angriff eines dieners.

		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            p.minionGetBuffed(target, target.Attack, 0);
		}

	}
}