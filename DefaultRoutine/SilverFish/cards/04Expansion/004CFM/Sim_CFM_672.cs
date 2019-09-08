using HREngine.Bots;

namespace SilverFish.cards._04Expansion._004CFM
{
	class Sim_CFM_672 : SimTemplate //* Madam Goya
	{
		// Battlecry: Choose a friendly minion. Swap it with a minion in your deck.

        public override void getBattlecryEffect(Playfield p, Minion m, Minion target, int choice)
        {
            if (target != null)
            {
                p.minionGetFrozen(target);
                p.drawACard(CardDB.CardName.aberration, m.own, true);
            }
        }
    }
}