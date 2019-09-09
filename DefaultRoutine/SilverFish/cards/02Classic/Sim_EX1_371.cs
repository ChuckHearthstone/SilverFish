using HREngine.Bots;

namespace SilverFish.cards._02Classic
{
	class Sim_EX1_371 : SimTemplate //handofprotection
	{

//    verleiht einem diener gottesschild/.

		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            target.DivineShield = true;
		}

	}
}