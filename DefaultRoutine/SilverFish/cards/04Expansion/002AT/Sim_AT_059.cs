using HREngine.Bots;

namespace SilverFish.cards._04Expansion._002AT
{
    /// <summary>
    /// Brave Archer
    /// 神勇弓箭手
    /// </summary>
	public class Sim_AT_059 : SimTemplate //* Brave Archer
	{
        /// <summary>
        /// Inspire: If your hand is empty, deal 2 damage to the enemy hero.
        /// 激励：如果你没有其他手牌，则对敌方英雄造成2点伤害。
        /// </summary>
        /// <param name="p"></param>
        /// <param name="m"></param>
        /// <param name="own"></param>
		public override void onInspire(Playfield p, Minion m, bool own)
        {
			if (m.own == own)
			{
	            int cardsCount = (own) ? p.owncards.Count : p.enemyAnzCards;
				if (cardsCount <= 0)
				{
					p.minionGetDamageOrHeal(own ? p.enemyHero : p.ownHero, 2);
				}
			}
        }
	}
}