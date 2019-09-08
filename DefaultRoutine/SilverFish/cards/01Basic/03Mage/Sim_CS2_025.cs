using HREngine.Bots;

namespace SilverFish.cards._01Basic._03Mage
{
	class Sim_CS2_025 : SimTemplate //arcaneexplosion
	{

//    fügt allen feindlichen dienern $1 schaden zu.
		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            int dmg = (ownplay) ? p.getSpellDamageDamage(1) : p.getEnemySpellDamageDamage(1);
            p.allMinionOfASideGetDamage(!ownplay, dmg);
		}

	}
}