using Chuck.SilverFish;
using SilverFish.Enums;

namespace SilverFish.cards._04Expansion._008GIL
{
    /// <summary>
    /// Bewitch
    /// 蛊惑
    /// </summary>
    public class Sim_GIL_504h : SimTemplate
    {
        /// <summary>
        /// Passive Hero Power After you play a minion, add a random Shaman spell to your hand.
        /// 被动英雄技能 在你使用一张随从牌后，随机将一张萨满祭司法术牌置入你的手牌。
        /// </summary>
        /// <param name="p"></param>
        /// <param name="ownplay"></param>
        /// <param name="target"></param>
        /// <param name="choice"></param>
        public override void onMinionWasSummoned(Playfield p, Minion m, Minion summonedMinion)
        {
            if (summonedMinion.playedFromHand && summonedMinion.own == m.own && summonedMinion.entitiyID != m.entitiyID)
            {
                p.drawACard(CardName.unknown, m.own, true);
            }
        }
    }
}
