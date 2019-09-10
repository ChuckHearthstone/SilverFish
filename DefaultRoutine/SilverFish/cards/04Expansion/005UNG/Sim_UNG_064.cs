using Chuck.SilverFish;

namespace SilverFish.cards._04Expansion._005UNG
{
	class Sim_UNG_064 : SimTemplate //* Vilespine Slayer
	{
		//Combo: Destroy a minion.

		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            if (p.cardsPlayedThisTurn >= 1 && target != null && own.own)
            {
                p.minionGetDestroyed(target);
            }
		}
	}
}