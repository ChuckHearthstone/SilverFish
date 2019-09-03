using HREngine.Bots;

namespace SilverFish.cards._04Expansion._005UNG
{
	class Sim_UNG_116 : SimTemplate //* Jungle Giants
	{
		//Quest: Summon 5 minions with 5 or more Attack. Reward: Barnabus.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            if (p.playactions.Count < 2) p.evaluatePenality -= 30;
        }
    }
}