namespace Chuck.SilverFish.cards._01Basic._08Warlock
{
    class Sim_EX1_308 : SimTemplate //* Soulfire
	{
        // Deal $4 damage. Discard a random card.

		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            int dmg = (ownplay) ? p.getSpellDamageDamage(4) : p.getEnemySpellDamageDamage(4);
            p.minionGetDamageOrHeal(target, dmg);
            p.discardCards(1, ownplay);
		}
	}
}