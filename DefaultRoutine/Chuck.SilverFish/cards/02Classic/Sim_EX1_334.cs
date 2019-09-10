using Chuck.SilverFish;

namespace SilverFish.cards._02Classic
{
	class Sim_EX1_334 : SimTemplate //shadowmadness
	{

//    übernehmt bis zum ende des zuges die kontrolle über einen feindlichen diener mit max. 3 angriff.
		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            target.shadowmadnessed = true;
            p.shadowmadnessed++;
            p.minionGetControlled(target, ownplay, true);
		}

	}
}