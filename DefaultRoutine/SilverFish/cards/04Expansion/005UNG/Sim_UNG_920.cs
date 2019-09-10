using Chuck.SilverFish;

namespace SilverFish.cards._04Expansion._005UNG
{
	class Sim_UNG_920 : SimTemplate //* The Marsh Queen
	{
		//Quest: Play seven 1-Cost minions. Reward: Queen Carnassa.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            if (p.playactions.Count < 2) p.evaluatePenality -= 30;
        }
    }
}