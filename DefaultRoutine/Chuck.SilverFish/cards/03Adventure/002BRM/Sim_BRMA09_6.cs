using Chuck.SilverFish;

namespace SilverFish.cards._03Adventure._002BRM
{
    class Sim_BRMA09_6 : SimTemplate //* The True Warchief
    {
        // Destroy a Legendary minion.
		
		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
			if (target != null) p.minionGetDestroyed(target);
        }
    }
}