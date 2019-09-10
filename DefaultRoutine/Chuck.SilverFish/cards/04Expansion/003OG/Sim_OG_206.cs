using Chuck.SilverFish;

namespace SilverFish.cards._04Expansion._003OG
{
	class Sim_OG_206 : SimTemplate //* Stormcrack
	{
		//Deal 4 damage to a minion. Overload: (1)
		
		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            int dmg = (ownplay) ? p.getSpellDamageDamage(4) : p.getEnemySpellDamageDamage(4);
            p.minionGetDamageOrHeal(target, dmg);
            if (ownplay) p.ueberladung++;
		}
	}
}