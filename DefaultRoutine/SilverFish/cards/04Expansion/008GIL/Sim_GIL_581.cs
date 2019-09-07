using HREngine.Bots;

namespace SilverFish.cards._04Expansion._008GIL
{
    /// <summary>
    /// Sandbinder
    /// 缚沙者
    /// </summary>
    public class Sim_GIL_581 : SimTemplate
    {
        /// <summary>
        /// Battlecry: Draw an Elemental from your deck.
        /// 战吼：从你的牌库中抽一张元素牌。
        /// </summary>
        /// <param name="p"></param>
        /// <param name="own"></param>
        /// <param name="target"></param>
        /// <param name="choice"></param>
        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            p.drawACard(CardDB.cardName.unknown, own.own);
        }
    }
}
