using HREngine.Bots;

namespace SilverFish.cards._04Expansion._002AT
{
	class Sim_AT_082 : SimTemplate //* Lowly Squire
	{
		//Inspire: Gain +1 Attack.
				
		public override void onInspire(Playfield p, Minion m, bool own)
        {
			if (m.own == own)
			{
				p.minionGetBuffed(m, 1, 0);
			}
        }
	}
}