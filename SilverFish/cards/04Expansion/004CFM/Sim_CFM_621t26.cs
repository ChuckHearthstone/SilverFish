using HREngine.Bots;

namespace SilverFish.cards._04Expansion._004CFM
{
	class Sim_CFM_621t26 : SimTemplate //* Stonescale Oil
	{
		// Gain 10 Armor.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.minionGetArmor(ownplay ? p.ownHero : p.enemyHero, 10);
        }
    }
}