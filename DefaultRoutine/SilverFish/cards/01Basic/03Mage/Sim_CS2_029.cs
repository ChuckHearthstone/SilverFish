using HREngine.Bots;

namespace SilverFish.cards._01Basic._03Mage
{
	class Sim_CS2_029 : SimTemplate //fireball
	{

//    verursacht $6 schaden.
		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            int dmg = (ownplay) ? p.getSpellDamageDamage(6) : p.getEnemySpellDamageDamage(6);
            p.minionGetDamageOrHeal(target, dmg);
		}

	}
}