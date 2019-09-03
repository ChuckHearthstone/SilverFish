using HREngine.Bots;

namespace SilverFish.cards._04Expansion._005UNG
{
	class Sim_UNG_807 : SimTemplate //* Golakka Crawler
	{
		//Battlecry: Destroy a Pirate and gain +1/+1.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            if (target != null)
            {
                p.minionGetDestroyed(target);
                p.minionGetBuffed(own, 1, 1);
            }
        } 
    }
}
