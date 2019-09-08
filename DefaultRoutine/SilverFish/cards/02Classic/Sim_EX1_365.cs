using HREngine.Bots;

namespace SilverFish.cards._02Classic
{
	class Sim_EX1_365 : SimTemplate //holywrath
	{
        // todo ask the posibility manager!
//    zieht eine karte und verursacht schaden, der ihren kosten entspricht.
		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            p.drawACard(CardDB.CardName.unknown, ownplay);

            int dmg = (ownplay) ? p.getSpellDamageDamage(3) : p.getEnemySpellDamageDamage(3);
            p.minionGetDamageOrHeal(target, dmg);
		}

	}
}