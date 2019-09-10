using Chuck.SilverFish;

namespace SilverFish.cards._04Expansion._005UNG
{
	class Sim_UNG_999t7 : SimTemplate //* Lightning Speed
	{
		//Windfury

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.minionGetWindfurry(target);
        }
    }
}