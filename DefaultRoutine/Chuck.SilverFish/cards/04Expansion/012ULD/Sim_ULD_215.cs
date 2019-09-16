using SilverFish.Enums;

namespace Chuck.SilverFish.cards._04Expansion._012ULD
{
    /// <summary>
    /// Wrapped Golem
    /// 被缚的魔像
    /// </summary>
    public class Sim_ULD_215 : SimTemplate
    {
        /// <summary>
        /// Reborn At the end of your turn, summon a 1/1 Scarab with Taunt.
        /// 复生在你的回合结束时，召唤一只1/1并具有嘲讽的甲虫。
        /// </summary>
        /// <param name="p"></param>
        /// <param name="triggerEffectMinion"></param>
        /// <param name="turnEndOfOwner"></param>
        public override void onTurnEndsTrigger(Playfield p, Minion triggerEffectMinion, bool turnEndOfOwner)
        {
            CardDB.Card scarab = CardDB.Instance.getCardDataFromID(CardIdEnum.ULD_215t);
            if (triggerEffectMinion.own == turnEndOfOwner)
            {
                int place = triggerEffectMinion.zonepos;
                p.CallKid(scarab, place, triggerEffectMinion.own);
            }
        }
    }
}