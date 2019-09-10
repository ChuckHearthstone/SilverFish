using Chuck.SilverFish;

namespace SilverFish.cards._02Classic
{
	class Sim_EX1_243 : SimTemplate //dustdevil
	{

//    windzorn/, überladung:/ (2)
		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            if (own.own) p.ueberladung += 2;
		}

	}
}