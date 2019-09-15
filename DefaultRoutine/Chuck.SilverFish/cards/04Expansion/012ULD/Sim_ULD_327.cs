using SilverFish.Enums;

namespace Chuck.SilverFish.cards._04Expansion._012ULD
{
    /// <summary>
    /// Bazaar Mugger 
    /// 集市恶痞
    /// </summary>
    public class Sim_ULD_327 : SimTemplate
    {
        /// <summary>
        /// Rush Battlecry: Add a random minion from another class to your hand.
        /// 突袭战吼：随机将一张其他职业的随从牌置入你的手牌。
        /// </summary>
        /// <param name="p"></param>
        /// <param name="own"></param>
        /// <param name="target"></param>
        /// <param name="choice"></param>
        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            p.drawACard(CardName.unknown, own.own, true);
        }
    }
}