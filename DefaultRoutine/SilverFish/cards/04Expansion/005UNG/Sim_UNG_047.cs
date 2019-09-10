using Chuck.SilverFish;

namespace SilverFish.cards._04Expansion._005UNG
{
	class Sim_UNG_047 : SimTemplate //* Ravenous Pterrordax
	{
		//Battlecry: Destroy a friendly minion to Adapt twice.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
			if (target != null)
			{
				p.minionGetDestroyed(target);
				p.getBestAdapt(own);
				p.getBestAdapt(own);
			}
        }
    }
}