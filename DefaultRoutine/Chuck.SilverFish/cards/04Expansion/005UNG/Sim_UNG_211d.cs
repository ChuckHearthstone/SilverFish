using Chuck.SilverFish;

namespace SilverFish.cards._04Expansion._005UNG
{
	class Sim_UNG_211d : SimTemplate //* Invocation of Air
	{
		//Deal 3 damage to all enemy minions.

		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            int dmg = (ownplay) ? p.getSpellDamageDamage(3) : p.getEnemySpellDamageDamage(3);
            p.allMinionOfASideGetDamage(!ownplay, dmg);
		}
	}
}