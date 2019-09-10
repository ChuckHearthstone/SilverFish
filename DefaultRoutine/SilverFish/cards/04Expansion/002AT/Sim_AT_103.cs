using Chuck.SilverFish;

namespace SilverFish.cards._04Expansion._002AT
{
	class Sim_AT_103 : SimTemplate //* North Sea Kraken
	{
		//Battlecry: Deal 4 damage.
		
		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            int dmg = 4;
            p.minionGetDamageOrHeal(target, dmg);
		}
	}
}