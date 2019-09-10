using Chuck.SilverFish;

namespace SilverFish.cards._03Adventure._002BRM
{
	class Sim_BRM_018 : SimTemplate //* Dragon Consort
	{
		// Battlecry: The next Dragon you play costs (2) less.

		public override void getBattlecryEffect(Playfield p, Minion m, Minion target, int choice)
		{
            if (m.own) p.anzOwnDragonConsort++;
		}
	}
}