using HREngine.Bots;

namespace SilverFish.cards._01Basic
{
	class Sim_CS2_074 : SimTemplate //deadlypoison
	{

//    eure waffe erhält +2 angriff.
		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            if (ownplay)
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