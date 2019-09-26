using Chuck.SilverFish;
using SilverFish.Enums;

namespace SilverFish.cards._04Expansion._011DAL
{
    /// <summary>
    /// Underbelly Angler
    /// 下水道渔人
    /// </summary>
    public class Sim_DAL_049 : SimTemplate
    {
        /// <summary>
        /// After you play a Murloc, add a random Murloc to your hand.
        /// 在你使用一张鱼人牌后，随机将一张鱼人牌置入你的手牌。
        /// </summary>
        /// <param name="p"></param>
        /// <param name="hc"></param>
        /// <param name="wasOwnCard"></param>
        /// <param name="triggerEffectMinion"></param>
        public override void onCardIsGoingToBePlayed(Playfield p, Handmanager.Handcard hc, bool wasOwnCard, Minion triggerEffectMinion)
        {
            if (triggerEffectMinion.own == wasOwnCard)
            {
                int murlocEnumValue = (int)TAG_RACE.MURLOC;
                if (hc.card.race == murlocEnumValue)
                {
                    //Bluegill Warrior 蓝腮战士
                    p.drawACard(CardIdEnum.CS2_173, wasOwnCard, true);
                }
            }
        }
    }
}
