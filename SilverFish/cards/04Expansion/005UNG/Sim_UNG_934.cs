using HREngine.Bots;

namespace SilverFish.cards._04Expansion._005UNG
{
	class Sim_UNG_934 : SimTemplate //* Fire Plume's Heart
	{
		//Quest: Play 7 Taunt minions. Reward: Sulfuras.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            if (p.playactions.Count < 2) p.evaluatePenality -= 30;
        }
    }
}