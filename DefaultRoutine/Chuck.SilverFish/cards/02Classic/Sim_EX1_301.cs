using Chuck.SilverFish;

namespace SilverFish.cards._02Classic
{
	class Sim_EX1_301 : SimTemplate //felguard
	{

//    spott/. kampfschrei:/ zerstört einen eurer manakristalle.
		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            if (own.own)
            {
                p.ownMaxMana--;
            }
            else
            {
                p.enemyMaxMana--;
            }
		}


	}
}