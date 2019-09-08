using HREngine.Bots;

namespace SilverFish.cards._01Basic
{
	class Sim_CS2_072 : SimTemplate //backstab
	{

//    fügt einem unverletzten diener $2 schaden zu.
		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            int dmg = (ownplay) ? p.getSpellDamageDamage(2) : p.getEnemySpellDamageDamage(2);
            p.minionGetDamageOrHeal(target, dmg);
		}

	}
}