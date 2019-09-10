using Chuck.SilverFish;

namespace SilverFish.cards._01Basic._04Paladin
{
	class Sim_CS2_089 : SimTemplate //holylight
	{

//    stellt #6 leben wieder her.
		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            int heal = (ownplay) ? p.getSpellHeal(6) : p.getEnemySpellHeal(6);
            p.minionGetDamageOrHeal(target, -heal);
		}

	}
}