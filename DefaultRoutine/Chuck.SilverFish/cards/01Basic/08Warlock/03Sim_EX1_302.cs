using SilverFish.Enums;

namespace Chuck.SilverFish.cards._01Basic._08Warlock
{
	class Sim_EX1_302 : SimTemplate //mortalcoil
	{

//    fügt einem diener $1 schaden zu. zieht eine karte, wenn er dadurch vernichtet wird.

		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            int dmg = (ownplay) ? p.getSpellDamageDamage(1) : p.getEnemySpellDamageDamage(1);
            if (dmg >= target.HealthPoints && !target.DivineShield && !target.immune)
            {
                //this.owncarddraw++;
                p.drawACard(CardName.unknown, ownplay);
            }
            p.minionGetDamageOrHeal(target, dmg);
            
		}

	}
}