using Chuck.SilverFish;

namespace SilverFish.cards._04Expansion._002AT
{
	class Sim_AT_089 : SimTemplate //* Boneguard Lieutenant
	{
		//Inspire: Gain +1 Health

		public override void onInspire(Playfield p, Minion m, bool own)
        {
			if (m.own == own)
			{
				p.minionGetBuffed(m, 0, 1);
			}
        }
	}
}