using HREngine.Bots;

namespace SilverFish.cards._03Adventure._002BRM
{
	class Sim_BRM_005 : SimTemplate //* Demonwrath
	{
		// Deal 2 damage to all non-Demon minions.
		
		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            int dmg = (ownplay) ? p.getSpellDamageDamage(2) : p.getEnemySpellDamageDamage(2);
			
			foreach (Minion m in p.ownMinions)
            {
                if ((TAG_RACE)m.handcard.card.race != TAG_RACE.DEMON) p.minionGetDamageOrHeal(m, dmg);
            }
            foreach (Minion m in p.enemyMinions)
            {
                if ((TAG_RACE)m.handcard.card.race != TAG_RACE.DEMON) p.minionGetDamageOrHeal(m, dmg);
            }
		}
	}
}