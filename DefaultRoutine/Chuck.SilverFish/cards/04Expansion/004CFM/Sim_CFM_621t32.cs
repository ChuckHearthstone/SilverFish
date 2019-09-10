using Chuck.SilverFish;

namespace SilverFish.cards._04Expansion._004CFM
{
	class Sim_CFM_621t32 : SimTemplate //* Goldthorn
	{
		// Give your minions +6 Health.
		
		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
			p.allMinionOfASideGetBuffed(ownplay, 0, 6);
		}
	}
}