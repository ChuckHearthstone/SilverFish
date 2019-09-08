using HREngine.Bots;
using SilverFish.Enums;

namespace SilverFish.cards._02Classic
{
	class Sim_EX1_154b : SimTemplate //wrath
	{

//    fügt einem diener $1 schaden zu. zieht eine karte.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            int damage = (ownplay) ? p.getSpellDamageDamage(1) : p.getEnemySpellDamageDamage(1);
            //this.owncarddraw++;

            p.minionGetDamageOrHeal(target, damage);
            p.drawACard(CardName.unknown, ownplay);
        }

	}
}