using Chuck.SilverFish;

namespace SilverFish.cards._01Basic._04Paladin
{
	class Sim_CS2_093 : SimTemplate //consecration
	{

//    fügt allen feinden $2 schaden zu.
		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            int dmg = (ownplay) ? p.getSpellDamageDamage(2) : p.getEnemySpellDamageDamage(2);
            p.allCharsOfASideGetDamage(!ownplay, dmg);
		}

	}
}