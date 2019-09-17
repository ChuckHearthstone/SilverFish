using SilverFish.Enums;

namespace Chuck.SilverFish.cards._04Expansion._012ULD
{
    /// <summary>
    /// Octosari 
    /// 八爪巨怪
    /// </summary>
    public class Sim_ULD_177 : SimTemplate
    {
        /// <summary>
        /// Deathrattle: Draw 8 cards.
        /// 亡语：抽八张牌。
        /// </summary>
        /// <param name="p"></param>
        /// <param name="m"></param>
        public override void onDeathrattle(Playfield p, Minion m)
        {
            for (int i = 0; i < 8; i++)
            {
                p.drawACard(CardName.unknown, m.own);
            }
        }
    }
}