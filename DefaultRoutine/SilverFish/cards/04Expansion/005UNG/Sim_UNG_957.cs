using Chuck.SilverFish;

namespace SilverFish.cards._04Expansion._005UNG
{
	class Sim_UNG_957 : SimTemplate //* Direhorn Hatchling
	{
		//Taunt. Deathrattle: Shuffle a 6/9 Direhorn with Taunt into your deck.

        public override void onDeathrattle(Playfield p, Minion m)
        {
            if (m.own) p.ownDeckSize++;
            else p.enemyDeckSize++;
        }
    }
}