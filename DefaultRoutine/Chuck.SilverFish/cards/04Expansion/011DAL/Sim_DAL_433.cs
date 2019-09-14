using Chuck.SilverFish;
using SilverFish.Helpers;

namespace Chuck.SilverFish._cards._04Expansion._011DAL
{
    /// <summary>
    /// Sludge Slurper
    /// 淤泥吞食者
    /// </summary>
    public class Sim_DAL_433 : SimTemplate
    {
        /// <summary>
        /// Battlecry: Add a Lackey to your hand. Overload: (1)
        /// 战吼：将一张跟班牌置入你的手牌。过载：（1）
        /// </summary>
        /// <param name="p"></param>
        /// <param name="own"></param>
        /// <param name="target"></param>
        /// <param name="choice"></param>
        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            var cardIdEnum = LackeyHelper.Instance.GetRandomLackey();
            p.drawACard(cardIdEnum, own.own, true);
            if (own.own) p.ueberladung++;
        }
    }
}