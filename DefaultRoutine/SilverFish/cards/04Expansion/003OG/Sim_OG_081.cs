using HREngine.Bots;

namespace SilverFish.cards._04Expansion._003OG
{
	class Sim_OG_081 : SimTemplate //* Shatter
	{
		//Destroy a Frozen minion.
		
		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
			if (target != null) p.minionGetDestroyed(target);
        }
    }
}