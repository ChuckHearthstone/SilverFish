namespace Chuck.SilverFish.cards._04Expansion._008GIL
{
    /// <summary>
    /// Countess Ashmore
    /// 女伯爵阿莎摩尔
    /// </summary>
    public class Sim_GIL_578 : SimTemplate
    {
        /// <summary>
        /// Battlecry: Draw a Rush, Lifesteal, and Deathrattle card from your deck.
        /// 战吼：从你的牌库中抽一张突袭牌、吸血牌和亡语牌。
        /// </summary>
        /// <param name="p"></param>
        /// <param name="own"></param>
        /// <param name="target"></param>
        /// <param name="choice"></param>
        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            if (own.own)
            {
                bool rushDrew, lifestealDrew, deathrattleDrew;
                rushDrew = lifestealDrew = deathrattleDrew = false;
                var deck = p.prozis.turnDeck;
                foreach (var item in deck)
                {
                    var card = CardDB.Instance.getCardDataFromID(item.Key);
                    if (!rushDrew && (GAME_TAGs)card.race == GAME_TAGs.RUSH)
                    {
                        p.drawACard(card.name, own.own);
                        rushDrew = true;
                    }

                    if (!lifestealDrew && (GAME_TAGs)card.race == GAME_TAGs.LIFESTEAL)
                    {
                        p.drawACard(card.name, own.own);
                        lifestealDrew = true;
                    }

                    if (!deathrattleDrew && (GAME_TAGs)card.race == GAME_TAGs.DEATHRATTLE)
                    {
                        p.drawACard(card.name, own.own);
                        deathrattleDrew = true;
                    }
                    if (rushDrew && lifestealDrew && deathrattleDrew) break;
                }
            }
        }
    }
}