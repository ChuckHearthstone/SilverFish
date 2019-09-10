using Chuck.SilverFish;

namespace SilverFish.cards._03Adventure._002BRM
{
	class Sim_BRM_003 : SimTemplate //* Dragon's Breath
	{
		// Deal 4 damage. Costs (1) less for each minion that died this turn.
		
		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            int dmg = (ownplay) ? p.getSpellDamageDamage(4) : p.getEnemySpellDamageDamage(4);
            p.minionGetDamageOrHeal(target, dmg);
        }
	}
}