using HREngine.Bots;

namespace SilverFish.cards._03Adventure._003LOE
{
	class Sim_LOE_002t : SimTemplate //* Roaring Torch
	{
		//Deal 6 damage.
		
		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            int dmg = (ownplay) ? p.getSpellDamageDamage(6) : p.getEnemySpellDamageDamage(6);
            p.minionGetDamageOrHeal(target, dmg);
		}
	}
}