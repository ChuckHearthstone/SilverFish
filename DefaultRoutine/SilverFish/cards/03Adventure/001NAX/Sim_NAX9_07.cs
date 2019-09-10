using Chuck.SilverFish;

namespace SilverFish.cards._03Adventure._001NAX
{
	class Sim_NAX9_07 : SimTemplate //* Mark of the Horsemen
	{
		// Give your minions and your weapon +1/+1.
		
		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
			p.allMinionOfASideGetBuffed(ownplay, 1, 1);
			
			if (ownplay)
            {
                if (p.ownWeapon.Durability >= 1)
                {
                    p.ownWeapon.Durability++;
                    p.ownWeapon.Angr++;
                    p.ownHero.Attack++;
                }
            }
            else
            {
                if (p.enemyWeapon.Durability >= 1)
                {
                    p.enemyWeapon.Durability++;
                    p.enemyWeapon.Angr++;
                    p.enemyHero.Attack++;
                }
            }
		}
	}
}