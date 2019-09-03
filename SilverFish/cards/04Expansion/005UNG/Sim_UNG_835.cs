using HREngine.Bots;

namespace SilverFish.cards._04Expansion._005UNG
{
	class Sim_UNG_835 : SimTemplate //* Chittering Tunneler
	{
		//Battlecry: Discover a spell. Deal damage to your hero equal to its Cost.

		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            p.drawACard(CardDB.cardName.thecoin, own.own, true);
            p.minionGetDamageOrHeal(own.own ? p.ownHero : p.enemyHero, 3);
		}
	}
}