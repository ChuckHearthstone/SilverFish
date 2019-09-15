namespace Chuck.SilverFish.cards._04Expansion._012ULD
{
    /// <summary>
    /// Salhet's Pride
    /// 萨赫特的傲狮
    /// </summary>
	public class Sim_ULD_438 : SimTemplate
    {
        /// <summary>
        /// Deathrattle: Draw two 1-Health minions from your deck.
        /// 亡语：从你的牌库中抽两张生命值为1的随从牌。
        /// </summary>
        /// <param name="p"></param>
        /// <param name="m"></param>
        public override void onDeathrattle(Playfield p, Minion m)
        {
            if (m.own)
            {
                CardDB.Card c;
                int count = 0;
                foreach (var cid in p.prozis.turnDeck)
                {
                    c = CardDB.Instance.getCardDataFromID(cid.Key);
                    if (c.Health == 1)
                    {
                        for (int i = 0; i < cid.Value; i++)
                        {
                            p.drawACard(c.name, m.own);
                            count++;
                            if (count > 1) break;
                        }
                        if (count > 1) break;
                    }
                }
            }
        }
    }
}
