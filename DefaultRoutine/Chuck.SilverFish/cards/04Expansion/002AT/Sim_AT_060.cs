using Chuck.SilverFish;
using SilverFish.Enums;

namespace SilverFish.cards._04Expansion._002AT
{
	class Sim_AT_060 : SimTemplate //* Bear Trap
	{
		//Secret: After your hero is attacked, summon a 3/3 Bear with Taunt.

		CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardIdEnum.CS2_125);//Ironfur Grizzly

        public override void onSecretPlay(Playfield p, bool ownplay, int number)
        {
            int place = (ownplay) ? p.ownMinions.Count : p.enemyMinions.Count;
            p.CallKid(kid, place, ownplay);
        }
    }
}