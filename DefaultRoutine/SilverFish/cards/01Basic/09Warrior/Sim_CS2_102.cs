using HREngine.Bots;

namespace SilverFish.cards._01Basic._09Warrior
{
	class Sim_CS2_102 : SimTemplate //armorup
	{

//    heldenfähigkeit/\nerhaltet 2 rüstung.

		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            if (ownplay)
            {
                p.minionGetArmor(p.ownHero, 2);
            }
            else
            {
                p.minionGetArmor(p.enemyHero, 2);
            }
		}

	}
}