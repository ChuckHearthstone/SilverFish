using HREngine.Bots;
using SilverFish.Enums;

namespace SilverFish.cards._04Expansion._008GIL
{
    /// <summary>
    /// Pick Pocket
    /// 搜索
    /// </summary>
    public class Sim_GIL_696 : SimTemplate
    {
        /// <summary>
        /// Echo Add a random card to your hand from your opponent's class.
        /// 回响 随机将一张你对手职业的卡牌置入你的手牌。
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
