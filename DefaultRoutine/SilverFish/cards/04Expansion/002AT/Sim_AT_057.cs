using Chuck.SilverFish;

namespace SilverFish.cards._04Expansion._002AT
{
	class Sim_AT_057 : SimTemplate //* Stablemaster
	{
		//Battlecry: Give a friendly Beast Immune this Turn.

		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            if (target != null) target.immune = true;
		}
	}
}