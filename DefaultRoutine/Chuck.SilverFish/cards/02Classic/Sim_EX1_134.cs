using Chuck.SilverFish;

namespace SilverFish.cards._02Classic
{
	class Sim_EX1_134 : SimTemplate //* si7agent
	{
        // Combo:: Deal 2 damage.

		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            if (p.cardsPlayedThisTurn >= 1 && target != null)
            {
                p.minionGetDamageOrHeal(target, 2);
            }
		}
	}
}