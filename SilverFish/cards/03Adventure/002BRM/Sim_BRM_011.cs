using HREngine.Bots;

namespace SilverFish.cards._03Adventure._002BRM
{
	class Sim_BRM_011 : SimTemplate //* Lava Shock
	{
		// Deal 2 damage. Unlock your Overloaded Mana Crystals.
		
		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            int dmg = (ownplay) ? p.getSpellDamageDamage(2) : p.getEnemySpellDamageDamage(2);
            p.minionGetDamageOrHeal(target, dmg);
            if (ownplay) p.unlockMana();
		}
	}
}