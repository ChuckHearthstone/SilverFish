using Chuck.SilverFish;
using SilverFish.Helpers;

namespace SilverFish.cards._04Expansion._011DAL
{
    /// <summary>
    /// EVIL Genius
    /// 怪盗天才
    /// </summary>
    public class Sim_DAL_606 : SimTemplate
    {
        /// <summary>
        /// Battlecry: Destroy a friendly minion to add 2 random Lackeys to your hand.
        /// 战吼：消灭一个友方随从，随机将两张跟班牌置入你的手牌。
        /// </summary>
        /// <param name="p"></param>
        /// <param name="own"></param>
        /// <param name="target"></param>
        /// <param name="choice"></param>
        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            if (target == null)
            {
                return;
            }
            p.minionGetDestroyed(target);
            var count = 2;
            for (var i = 1; i <= count; i++)
            {
                var cardIdEnum = LackeyHelper.Instance.GetRandomLackey();
                p.drawACard(cardIdEnum, own.own, true);
            }
        }
    }
}