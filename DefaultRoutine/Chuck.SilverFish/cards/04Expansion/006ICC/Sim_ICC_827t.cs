using Chuck.SilverFish;

namespace SilverFish.cards._04Expansion._006ICC
{
    /// <summary>
    /// Shadow Reflection
    /// 暗影映像
    /// </summary>
    class Sim_ICC_827t : SimTemplate //* Shadow Reflection
    {
        /// <summary>
        /// Each time you play a card, transform this into a copy of it.
        /// 每当你使用一张牌，变形成为该卡牌的复制。
        /// </summary>
        /// <param name="p"></param>
        /// <param name="hc"></param>
        /// <param name="wasOwnCard"></param>
        /// <param name="triggerhc"></param>
        public override void onCardIsGoingToBePlayed(Playfield p, Handmanager.Handcard hc, bool wasOwnCard, Handmanager.Handcard triggerhc)
        {
            triggerhc.setHCtoHC(hc);
        }
    }
}