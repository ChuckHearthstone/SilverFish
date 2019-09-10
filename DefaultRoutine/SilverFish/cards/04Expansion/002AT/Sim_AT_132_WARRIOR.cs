using Chuck.SilverFish;

namespace SilverFish.cards._04Expansion._002AT
{
	class Sim_AT_132_WARRIOR : SimTemplate //* Tank Up!
	{
		//Hero Power. Gain 4 Armor.
		
		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            if (ownplay)
            {
                p.minionGetArmor(p.ownHero, 4);
            }
            else
            {
                p.minionGetArmor(p.enemyHero, 4);
            }
		}
	}
}