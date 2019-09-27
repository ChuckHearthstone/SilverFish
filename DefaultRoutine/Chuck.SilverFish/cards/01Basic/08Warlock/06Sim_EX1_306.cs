namespace Chuck.SilverFish.cards._01Basic._08Warlock
{
    /// <summary>
    /// Felstalker
    /// 魔犬
    /// </summary>
    class Sim_EX1_306 : SimTemplate
	{
        /// <summary>
        /// Battlecry: Discard a random card.
        /// 战吼： 随机弃一张牌。
        /// </summary>
        /// <param name="p"></param>
        /// <param name="own"></param>
        /// <param name="target"></param>
        /// <param name="choice"></param>
		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            p.discardCards(1, own.own);
		}
	}
}