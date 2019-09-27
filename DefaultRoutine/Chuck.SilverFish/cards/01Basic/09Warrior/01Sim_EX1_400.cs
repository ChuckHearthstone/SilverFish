namespace Chuck.SilverFish.cards._01Basic._09Warrior
{
	class Sim_EX1_400 : SimTemplate //whirlwind
	{

//    fügt allen dienern $1 schaden zu.

		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            int dmg = (ownplay) ? p.getSpellDamageDamage(1) : p.getEnemySpellDamageDamage(1);
            p.allMinionsGetDamage(dmg);
		}

	}
}