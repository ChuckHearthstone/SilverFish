using Chuck.SilverFish;

namespace SilverFish.cards._02Classic
{
	class Sim_EX1_279 : SimTemplate //pyroblast
	{

//    verursacht $10 schaden.

		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            int dmg = (ownplay) ? p.getSpellDamageDamage(10) : p.getEnemySpellDamageDamage(10);
            p.minionGetDamageOrHeal(target, dmg);
		}

	}
}