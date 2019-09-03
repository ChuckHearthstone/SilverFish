using HREngine.Bots;

namespace SilverFish.cards._04Expansion._008GIL
{
    /// <summary>
    /// Forest Guide
    /// 森林向导
    /// </summary>
    public class Sim_GIL_833 : SimTemplate
    {
        /// <summary>
        /// "LocStringEnUs": "At the end of your turn, both players draw a card.",
        /// "LocStringZhCn": "在你的回合结束时，双方玩家各抽 一张牌。",
        /// </summary>
        /// <param name="p"></param>
        /// <param name="triggerEffectMinion"></param>
        /// <param name="turnEndOfOwner"></param>
        public override void onTurnEndsTrigger(Playfield p, Minion triggerEffectMinion, bool turnEndOfOwner)
        {
            if (triggerEffectMinion.own == turnEndOfOwner)
            {
                p.drawACard(CardDB.cardName.unknown, true);
                p.drawACard(CardDB.cardName.unknown, false);
            }
        }
    }
}
