using HREngine.Bots;

namespace SilverFish.cards._01Basic._01Druid
{
	class Sim_EX1_173 : SimTemplate //starfire
	{

//    verursacht $5 schaden. zieht eine karte.

		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            int dmg = (ownplay) ? p.getSpellDamageDamage(5) : p.getEnemySpellDamageDamage(5);
            p.minionGetDamageOrHeal(target, dmg);
            //this.owncarddraw++;
            p.drawACard(CardDB.CardName.unknown, ownplay);
		}

	}
}