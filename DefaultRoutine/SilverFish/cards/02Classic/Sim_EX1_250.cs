using HREngine.Bots;

namespace SilverFish.cards._02Classic
{
	class Sim_EX1_250 : SimTemplate //earthelemental
	{

//    spott/, überladung:/ (3)
		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            if (own.own) p.ueberladung += 3;
		}


	}
}