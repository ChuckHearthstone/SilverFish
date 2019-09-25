using SilverFish.Enums;

namespace Chuck.SilverFish.cards._02Classic
{
    /// <summary>
    /// Call of the Void
    /// 虚空召唤
    /// </summary>
    public class Sim_EX1_181 : SimTemplate
    {
        /// <summary>
        /// Add a random Demon to your hand.
        /// 随机将一张恶魔牌置入你的手牌。
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