using HREngine.Bots;

namespace SilverFish.cards._04Expansion._008GIL
{
    /// <summary>
    /// Cursed Castaway
    /// 被诅咒的海盗
    /// </summary>
    public class Sim_GIL_557 : SimTemplate
    {
        /// <summary>
        /// Rush Deathrattle: Draw a Combo card from your deck.
        /// 突袭，亡语： 从你的牌库中抽一张连击牌。
        /// </summary>
        /// <param name="p"></param>
        /// <param name="m"></param>
        public override void onDeathrattle(Playfield p, Minion m)
        {
            p.drawACard(CardDB.cardName.unknown, m.own);
        }
    }
}
