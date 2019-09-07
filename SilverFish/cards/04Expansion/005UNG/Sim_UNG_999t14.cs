using HREngine.Bots;

namespace SilverFish.cards._04Expansion._005UNG
{
	class Sim_UNG_999t14 : SimTemplate //* Volcanic Might
	{
		//+1/+1

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.minionGetBuffed(target, 1, 1);
        }
    }
}