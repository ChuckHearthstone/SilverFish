using HREngine.Bots;

namespace SilverFish.cards._02Classic
{
	class Sim_EX1_278 : SimTemplate //shiv
	{

//    verursacht $1 schaden. zieht eine karte.

		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            int dmg = (ownplay) ? p.getSpellDamageDamage(1) : p.getEnemySpellDamageDamage(1);
            p.minionGetDamageOrHeal(target, dmg);
           p.drawACard(CardDB.CardName.unknown, ownplay);
		}

	}
}