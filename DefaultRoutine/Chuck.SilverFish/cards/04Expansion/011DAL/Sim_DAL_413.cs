using SilverFish.Helpers;

namespace Chuck.SilverFish
{
    /// <summary>
    /// EVIL Conscripter
    /// 怪盗征募员
    /// </summary>
    public class Sim_DAL_413:SimTemplate
    {
        /// <summary>
        /// Deathrattle: Add a Lackey to your hand.
        /// 亡语：将一张跟班牌置入你的手牌。
        /// </summary>
        /// <param name="p"></param>
        /// <param name="m"></param>
        public override void onDeathrattle(Playfield p, Minion m)
        {
            var cardIdEnum = LackeyHelper.Instance.GetRandomLackey();
            p.drawACard(cardIdEnum, m.own, true);
        }
    }
}