using Chuck.SilverFish;

namespace SilverFish.cards._04Expansion._004CFM
{
	class Sim_CFM_647 : SimTemplate //* Blowgill Sniper
	{
		// Battlecry: Deal 1 damage.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            p.minionGetDamageOrHeal(target, 1);
        }
    }
}