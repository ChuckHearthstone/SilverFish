using HREngine.Bots;

namespace SilverFish.cards._04Expansion._005UNG
{
	class Sim_UNG_923 : SimTemplate //* Iron Hide
	{
		//Gain 5 Armor.

		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            if (ownplay)
            {
                p.minionGetArmor(p.ownHero, 5);
            }
            else
            {
                p.minionGetArmor(p.enemyHero, 5);
            }
		}

	}
}