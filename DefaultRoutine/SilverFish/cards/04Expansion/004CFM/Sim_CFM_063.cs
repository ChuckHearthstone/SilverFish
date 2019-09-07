using HREngine.Bots;

namespace SilverFish.cards._04Expansion._004CFM
{
	class Sim_CFM_063 : SimTemplate //* Kooky Chemist
	{
		// Battlecry: Swap the Attack and Health of a minion.

        public override void getBattlecryEffect(Playfield p, Minion m, Minion target, int choice)
        {
            if (target != null) p.minionSwapAngrAndHP(target);
        }
    }
}