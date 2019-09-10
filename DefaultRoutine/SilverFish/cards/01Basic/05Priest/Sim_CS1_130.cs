using Chuck.SilverFish;

namespace SilverFish.cards._01Basic._05Priest
{
	class Sim_CS1_130 : SimTemplate //holysmite
	{

//    verursacht $2 schaden.
		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            int dmg = (ownplay) ? p.getSpellDamageDamage(2) : p.getEnemySpellDamageDamage(2);
            p.minionGetDamageOrHeal(target, dmg);
		}

	}
}