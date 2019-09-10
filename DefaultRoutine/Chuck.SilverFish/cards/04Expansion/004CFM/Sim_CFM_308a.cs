using Chuck.SilverFish;

namespace SilverFish.cards._04Expansion._004CFM
{
	class Sim_CFM_308a : SimTemplate //* Forgotten Armor
	{
		// Gain 10 Armor.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.minionGetArmor(ownplay ? p.ownHero : p.enemyHero, 10);
        }
    }
}