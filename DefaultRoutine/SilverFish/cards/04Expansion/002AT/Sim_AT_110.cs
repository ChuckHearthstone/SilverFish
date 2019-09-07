using HREngine.Bots;

namespace SilverFish.cards._04Expansion._002AT
{
	class Sim_AT_110 : SimTemplate //* Coliseum Manager
	{
		//Inspire: Return this minion to your hand.

		public override void onInspire(Playfield p, Minion m, bool own)
        {
			if (m.own == own)
			{
				p.minionReturnToHand(m, own, 0);
			}
        }
	}
}