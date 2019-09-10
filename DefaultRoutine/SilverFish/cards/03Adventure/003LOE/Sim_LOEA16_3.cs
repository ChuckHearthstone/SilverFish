using Chuck.SilverFish;

namespace SilverFish.cards._03Adventure._003LOE
{
	class Sim_LOEA16_3 : SimTemplate //* Lantern of Power
	{
		//Give a minion +10/+10.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.minionGetBuffed(target, 10, 10);
        }
    }
}
