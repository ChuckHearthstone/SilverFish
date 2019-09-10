using Chuck.SilverFish;
using SilverFish.Enums;

namespace SilverFish.cards._04Expansion._008GIL
{
    /// <summary>
    /// Ravencaller
    /// 唤鸦者
    /// </summary>
    public class Sim_GIL_212 : SimTemplate
    {
        /// <summary>
        /// Battlecry: Add two random 1-Cost minions to your hand.
        /// 战吼：随机将两张法力值消耗为1点的随从牌置入你的手牌。
        /// </summary>
        /// <param name="p"></param>
        /// <param name="own"></param>
        /// <param name="target"></param>
        /// <param name="choice"></param>
        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            p.drawACard(CardName.unknown, own.own, true);
            p.drawACard(CardName.unknown, own.own, true);
        }
    }
}