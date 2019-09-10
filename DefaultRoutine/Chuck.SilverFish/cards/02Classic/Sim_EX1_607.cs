using Chuck.SilverFish;

namespace SilverFish.cards._02Classic
{
	class Sim_EX1_607 : SimTemplate //innerrage
	{

//    fügt einem diener $1 schaden zu. der diener erhält +2 angriff.

		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            int dmg = (ownplay) ? p.getSpellDamageDamage(1) : p.getEnemySpellDamageDamage(1);
            p.minionGetDamageOrHeal(target, dmg);
            p.minionGetTempBuff(target, 2,0);
		}

	}
}