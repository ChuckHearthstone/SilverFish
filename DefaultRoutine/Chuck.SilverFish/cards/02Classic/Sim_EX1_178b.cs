using Chuck.SilverFish;

namespace SilverFish.cards._02Classic
{
    class Sim_EX1_178b : SimTemplate //* Uproot
	{
        //+5 Attack.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.minionGetBuffed(target, 5, 0);
        }
	}
}