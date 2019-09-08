using HREngine.Bots;
using SilverFish.Enums;

namespace SilverFish.cards._04Expansion._008GIL
{
    /// <summary>
    /// Bonfire Elemental
    /// 篝火元素
    /// </summary>
    public class Sim_GIL_645 : SimTemplate
    {
        /// <summary>
        /// Battlecry: If you played an Elemental last turn, draw a card.
        /// 战吼：如果你在上个回合使用过元素牌，抽一张牌。
        /// </summary>
        /// <param name="p"></param>
        /// <param name="own"></param>
        /// <param name="target"></param>
        /// <param name="choice"></param>
        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            if (p.anzOwnElementalsLastTurn > 0 && own.own) p.drawACard(CardName.unknown, own.own);
        }
    }
}
