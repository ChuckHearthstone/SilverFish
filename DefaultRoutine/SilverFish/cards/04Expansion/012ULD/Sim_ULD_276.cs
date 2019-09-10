using Chuck.SilverFish;
using SilverFish.Helpers;

namespace SilverFish.cards._04Expansion._012ULD
{
    /// <summary>
    /// EVIL Totem
    /// 怪盗图腾
    /// </summary>
    public class Sim_ULD_276 : SimTemplate
    {
        /// <summary>
        /// At the end of your turn, add a Lackey to your hand.
        /// 在你的回合结束时，将一张跟班牌置入你的手牌。
        /// </summary>
        /// <param name="p"></param>
        /// <param name="triggerEffectMinion"></param>
        /// <param name="turnEndOfOwner"></param>
        public override void onTurnEndsTrigger(Playfield p, Minion triggerEffectMinion, bool turnEndOfOwner)
        {
            if (triggerEffectMinion.own == turnEndOfOwner)
            {
                var cardIdEnum = LackeyHelper.Instance.GetRandomLackey();
                p.drawACard(cardIdEnum, turnEndOfOwner, true);
            }
        }
    }
}