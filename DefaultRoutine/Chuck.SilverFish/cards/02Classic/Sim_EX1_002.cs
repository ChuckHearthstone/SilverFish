using Chuck.SilverFish;

namespace SilverFish.cards._02Classic
{
	class Sim_EX1_002 : SimTemplate //theblackknight
	{

//    kampfschrei:/ vernichtet einen feindlichen diener mit spott/.
		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            if(target!= null) p.minionGetDestroyed(target);
		}


	}
}