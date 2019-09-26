using SilverFish.Enums;

namespace Chuck.SilverFish.cards._02Classic._03Mage
{
    /// <summary>
    /// Tome of Intellect
    /// 智慧秘典
    /// </summary>
    public class Sim_EX1_180 : SimTemplate
    {
        /// <summary>
        /// Add a random Mage spell to your hand.
        /// 随机将一张法师法术牌置入你的手牌。
        /// </summary>
        /// <param name="p"></param>
        /// <param name="ownplay"></param>
        /// <param name="target"></param>
        /// <param name="choice"></param>
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.drawACard(CardName.unknown, ownplay, true);
        }
    }
}