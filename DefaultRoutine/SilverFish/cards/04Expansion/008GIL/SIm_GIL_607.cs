using HREngine.Bots;
using SilverFish.Enums;

namespace SilverFish.cards._04Expansion._008GIL
{
    /// <summary>
    /// Toxmonger
    /// 毒药贩子
    /// </summary>
    public class Sim_GIL_607 : SimTemplate
    {
        /// <summary>
        /// "Whenever you play a 1-Cost minion, give it Poisonous.",
        /// "每当你使用一张法力值消耗为1点的随从牌，使其获得 剧毒。",
        /// </summary>
        /// </summary>
        /// <param name="p"></param>
        /// <param name="hc"></param>
        /// <param name="wasOwnCard"></param>
        /// <param name="triggerEffectMinion"></param>
        public override void onCardIsGoingToBePlayed(Playfield p, Handmanager.Handcard hc, bool wasOwnCard, Minion triggerEffectMinion)
        {
            if (triggerEffectMinion.own == wasOwnCard)
            {
                if (hc.card.type == CardType.MOB && hc.manacost == 1)
                {
                    triggerEffectMinion.poisonous = true;
                }
            }
        }
    }
}
