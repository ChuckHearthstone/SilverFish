using HREngine.Bots;

namespace SilverFish.cards._04Expansion._008GIL
{
    /// <summary>
    /// Face Collector
    /// 面具收集者
    /// </summary>
    public class Sim_GIL_677 : SimTemplate
    {
        /// <summary>
        /// Echo Battlecry: Add a random Legendary minion to your hand.
        /// 回响，战吼：随机将一张传说随从牌置入你的手牌。
        /// </summary>
        /// <param name="p"></param>
        /// <param name="own"></param>
        /// <param name="target"></param>
        /// <param name="choice"></param>
        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            p.drawACard(CardDB.cardName.unknown, own.own, true);
        }
    }
}
