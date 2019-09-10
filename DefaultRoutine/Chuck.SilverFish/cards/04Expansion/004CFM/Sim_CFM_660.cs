using Chuck.SilverFish;

namespace SilverFish.cards._04Expansion._004CFM
{
	class Sim_CFM_660 : SimTemplate //* Manic Soulcaster
	{
		// Battlecry: Choose a friendly minion. Shuffle a copy into your deck.

        public override void getBattlecryEffect(Playfield p, Minion m, Minion target, int choice)
        {
            if (target != null)
            {
                if (m.own) p.ownDeckSize++;
                else p.enemyDeckSize++;
            }
        }
    }
}