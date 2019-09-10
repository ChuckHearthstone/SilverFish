using Chuck.SilverFish;

namespace SilverFish.cards._04Expansion._003OG
{
	class Sim_OG_267 : SimTemplate //* Southsea Squidface
	{
		//Deathrattle: Give your weapon +2 Attack.
		
        public override void onDeathrattle(Playfield p, Minion m)
        {
            if (m.own)
            {
                if (p.ownWeapon.Durability >= 1)
                {
                    p.ownWeapon.Angr += 2;
                    p.ownHero.Attack += 2;
                }
            }
            else
            {
                if (p.enemyWeapon.Durability >= 1)
                {
                    p.enemyWeapon.Angr += 2;
                    p.enemyHero.Attack += 2;
                }
            }
        }
	}
}