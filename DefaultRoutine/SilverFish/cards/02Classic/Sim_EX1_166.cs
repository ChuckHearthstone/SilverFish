using HREngine.Bots;

namespace SilverFish.cards._02Classic
{
    class Sim_EX1_166 : SimTemplate //* Keeper of the Grove
	{
        // Choose One - Deal 2 damage; or Silence a minion.

		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            if (choice == 1 || (p.ownFandralStaghelm > 0 && own.own))
            {
                p.minionGetDamageOrHeal(target, 2);
            }

            if (choice == 2 || (p.ownFandralStaghelm > 0 && own.own))
            {
                p.minionGetSilenced(target);
            }
		}
	}
}