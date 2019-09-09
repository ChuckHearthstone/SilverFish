using HREngine.Bots;
using SilverFish.Enums;

namespace SilverFish.cards._04Expansion._012ULD
{
    /// <summary>
    /// Crystal Merchant
    /// 水晶商人
    /// </summary>
    public class Sim_ULD_133 : SimTemplate
    {
        /// <summary>
        /// If you have any unspent Mana at the end of your turn, draw a card.
        /// 在你的回合结束时，如果你有未使用的法力水晶，抽一张牌。
        /// </summary>
        /// <param name="p"></param>
        /// <param name="triggerEffectMinion"></param>
        /// <param name="turnEndOfOwner"></param>
        public override void onTurnEndsTrigger(Playfield p, Minion triggerEffectMinion, bool turnEndOfOwner)
        {
            if (turnEndOfOwner == triggerEffectMinion.own && p.manaTurnEnd > 0)
            {
                p.drawACard(CardName.unknown, turnEndOfOwner);
            }
        }
    }
}
