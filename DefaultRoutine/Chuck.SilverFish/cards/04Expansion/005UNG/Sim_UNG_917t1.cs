using Chuck.SilverFish;

namespace SilverFish.cards._04Expansion._005UNG
{
	class Sim_UNG_917t1 : SimTemplate //* Dinomancy
	{
		//Hero Power: Give a Beast +2/+2.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.minionGetBuffed(target, 2, 2);
        }
	}
}