using HREngine.Bots;
using SilverFish.Enums;

namespace SilverFish.cards._04Expansion._012ULD
{
    /// <summary>
    /// Clever Disguise
    /// 聪明的伪装
    /// </summary>
    public class Sim_ULD_328 : SimTemplate
    {
        /// <summary>
        /// Add 2 random spells from another class to your hand.
        /// 随机将两张其他职业的法术牌置入你的手牌。
        /// </summary>
        /// <param name="p"></param>
        /// <param name="ownplay"></param>
        /// <param name="target"></param>
        /// <param name="choice"></param>
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.drawACard(CardName.unknown, ownplay, true);
            p.drawACard(CardName.unknown, ownplay, true);
        }
    }
}