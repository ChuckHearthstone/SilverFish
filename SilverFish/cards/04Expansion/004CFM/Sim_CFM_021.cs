using HREngine.Bots;

namespace SilverFish.cards._04Expansion._004CFM
{
	class Sim_CFM_021 : SimTemplate //* Freezing Potion
	{
		// Freeze an enemy.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.minionGetFrozen(target);
        }
    }
}
