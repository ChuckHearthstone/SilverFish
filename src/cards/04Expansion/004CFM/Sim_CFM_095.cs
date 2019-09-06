using HREngine.Bots;

namespace SilverFish.cards._04Expansion._004CFM
{
	class Sim_CFM_095 : SimTemplate //* Weasel Tunneler
	{
		// Deathrattle: Shuffle this minion into your opponent's deck.

        public override void onDeathrattle(Playfield p, Minion m)
        {
            if (m.own) p.enemyDeckSize++;
            else p.ownDeckSize++;
        }
    }
}