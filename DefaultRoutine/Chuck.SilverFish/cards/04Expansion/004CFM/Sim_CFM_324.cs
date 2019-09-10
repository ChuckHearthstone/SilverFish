using Chuck.SilverFish;

namespace SilverFish.cards._04Expansion._004CFM
{
	class Sim_CFM_324 : SimTemplate //* White Eyes
	{
		// Taunt. Deathrattle: Shuffle 'The Storm Guardian' into your deck.

        public override void onDeathrattle(Playfield p, Minion m)
        {
            if (m.own) p.ownDeckSize++;
            else p.enemyDeckSize++;
        }
    }
}