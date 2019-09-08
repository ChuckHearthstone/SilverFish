using HREngine.Bots;
using SilverFish.Enums;

namespace SilverFish.cards._04Expansion._005UNG
{
	class Sim_UNG_018 : SimTemplate //* Flame Geyser
	{
		//Deal $2 damage. Add a 1/2 Elemental to your hand.

		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            int dmg = (ownplay) ? p.getSpellDamageDamage(2) : p.getEnemySpellDamageDamage(2);
            p.minionGetDamageOrHeal(target, dmg);
            p.drawACard(CardName.flameelemental, ownplay, true);
		}
	}
}