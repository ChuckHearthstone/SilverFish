using HREngine.Bots;

namespace SilverFish.cards._04Expansion._002AT
{
	class Sim_AT_064 : SimTemplate //* Bash
	{
		//Deal 3 Damage. Gain 3 Armor.
		
		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            int dmg = (ownplay) ? p.getSpellDamageDamage(3) : p.getEnemySpellDamageDamage(3);
            p.minionGetDamageOrHeal(target, dmg);
            p.minionGetArmor(ownplay ? p.ownHero : p.enemyHero, 3);			
		}
	}
}