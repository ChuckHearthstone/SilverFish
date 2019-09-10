using Chuck.SilverFish;
using SilverFish.Enums;

namespace SilverFish.cards._04Expansion._012ULD
{
    /// <summary>
    /// Whirlkick Master
    /// 连环腿大师
    /// </summary>
    public class Sim_ULD_231 : SimTemplate
    {
        /// <summary>
        /// Whenever you play a Combo card, add a random Combo card to your hand.
        /// 每当你使用一张连击牌时，随机将一张连击牌置入你的手牌。
        /// </summary>
        /// <param name="p"></param>
        /// <param name="hc"></param>
        /// <param name="wasOwnCard"></param>
        /// <param name="triggerEffectMinion"></param>
        public override void onCardIsGoingToBePlayed(Playfield p, Handmanager.Handcard hc, bool wasOwnCard, Minion triggerEffectMinion)
        {
            if (wasOwnCard == triggerEffectMinion.own && hc.card.Combo)
            {
                p.drawACard(CardName.unknown, wasOwnCard, true);
            }
        }
    }
}
