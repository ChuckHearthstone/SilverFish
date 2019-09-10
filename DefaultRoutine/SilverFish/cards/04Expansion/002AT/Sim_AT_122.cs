using Chuck.SilverFish;

namespace SilverFish.cards._04Expansion._002AT
{
	class Sim_AT_122 : SimTemplate //* Gormok the Impaler
	{
		//Battlecry: If you have at least 4 other minions, deal 4 damage.

        public override void getBattlecryEffect(Playfield p, Minion m, Minion target, int choice)
        {
            if (target != null) p.minionGetDamageOrHeal(target, 4);
        }
    }
}