using Chuck.SilverFish;

namespace SilverFish.cards._02Classic
{
	class Sim_EX1_400 : SimTemplate //whirlwind
	{

//    fügt allen dienern $1 schaden zu.

		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            int dmg = (ownplay) ? p.getSpellDamageDamage(1) : p.getEnemySpellDamageDamage(1);
            p.allMinionsGetDamage(dmg);
		}

	}
}