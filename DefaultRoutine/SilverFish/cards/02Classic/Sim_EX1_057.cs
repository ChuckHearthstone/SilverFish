using Chuck.SilverFish;

namespace SilverFish.cards._02Classic
{
	class Sim_EX1_057 : SimTemplate //ancientbrewmaster
	{

//    kampfschrei:/ lasst einen befreundeten diener vom schlachtfeld auf eure hand zurückkehren.
		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            if (target != null) p.minionReturnToHand(target, target.own, 0);
		}

	}
}