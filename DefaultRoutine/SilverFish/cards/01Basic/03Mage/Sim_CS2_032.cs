using Chuck.SilverFish;

namespace SilverFish.cards._01Basic._03Mage
{
	class Sim_CS2_032 : SimTemplate //flamestrike
	{

//    fügt allen feindlichen dienern $4 schaden zu.
		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            int dmg = (ownplay) ? p.getSpellDamageDamage(4) : p.getEnemySpellDamageDamage(4);
            p.allMinionOfASideGetDamage(!ownplay, dmg);
		}

	}
}