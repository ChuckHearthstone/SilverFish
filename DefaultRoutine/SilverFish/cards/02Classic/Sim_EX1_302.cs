using HREngine.Bots;

namespace SilverFish.cards._02Classic
{
	class Sim_EX1_302 : SimTemplate //mortalcoil
	{

//    fügt einem diener $1 schaden zu. zieht eine karte, wenn er dadurch vernichtet wird.

		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            int dmg = (ownplay) ? p.getSpellDamageDamage(1) : p.getEnemySpellDamageDamage(1);
            if (dmg >= target.HealthPoints && !target.divineshild && !target.immune)
            {
                //this.owncarddraw++;
                p.drawACard(CardDB.CardName.unknown, ownplay);
            }
            p.minionGetDamageOrHeal(target, dmg);
            
		}

	}
}