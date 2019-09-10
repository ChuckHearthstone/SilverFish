using Chuck.SilverFish;

namespace SilverFish.cards._04Expansion._007LOOT
{
	class Sim_LOOT_998k : SimTemplate //* Golden Kobold
	{
		//Taunt. Battlecry: Replace your hand with Legendary minions.
		
		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            if (ownplay) p.evaluatePenality -= p.ownDeckSize;
            else p.evaluatePenality += p.enemyDeckSize;
		}
	}
}