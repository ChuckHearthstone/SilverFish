using HREngine.Bots;

namespace SilverFish.cards._03Adventure._004KAR
{
	class Sim_KAR_057 : SimTemplate //* Ivory Knight
	{
		//Battlecry: Discover a spell. Restore Health to your hero equal to its Cost.

		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            p.drawACard(CardDB.CardName.thecoin, own.own, true);
			int heal = (own.own) ? p.getMinionHeal(3) : p.getEnemyMinionHeal(3);
            p.minionGetDamageOrHeal(own.own ? p.ownHero : p.enemyHero, -heal);
		}
	}
}