using Chuck.SilverFish;
using SilverFish.Enums;

namespace SilverFish.cards._04Expansion._008GIL
{
    /// <summary>
    /// Blink Fox
    /// 闪狐
    /// </summary>
    public class Sim_GIL_827 : SimTemplate
    {
        /// <summary>
        /// Battlecry: Add a random card to your hand from your opponent's class.
        /// 战吼：随机将一张你对手职业的卡牌置入你的手牌。
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
