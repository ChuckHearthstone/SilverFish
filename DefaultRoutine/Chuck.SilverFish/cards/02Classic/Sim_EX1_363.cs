using Chuck.SilverFish;

namespace SilverFish.cards._02Classic
{
	class Sim_EX1_363 : SimTemplate //blessingofwisdom
	{

//    wählt einen diener aus. zieht jedes mal eine karte, wenn er angreift.

		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            if (ownplay)
            {
                target.ownBlessingOfWisdom++;
            }
            else
            {
                target.enemyBlessingOfWisdom++;
            }

		}

	}
}