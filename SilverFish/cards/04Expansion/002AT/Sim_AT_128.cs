using HREngine.Bots;

namespace SilverFish.cards._04Expansion._002AT
{
	class Sim_AT_128 : SimTemplate //* The Skeleton Knight
	{
		//Deathrattle: Reveal a minion in each deck. If yours costs more, return this to your hand.
		
        public override void onDeathrattle(Playfield p, Minion m)
        {
			p.minionReturnToHand(m, m.own, 0); // optimistic		
        }
	}
}