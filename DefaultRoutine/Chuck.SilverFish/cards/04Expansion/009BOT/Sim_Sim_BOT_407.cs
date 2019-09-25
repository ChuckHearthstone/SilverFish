using SilverFish.Enums;

namespace Chuck.SilverFish.cards._04Expansion._009BOT
{
    /// <summary>
    /// Thunderhead
    /// 雷云元素
    /// </summary>
    public class Sim_Sim_BOT_407 : SimTemplate
    {
        /// <summary>
        /// After you play a card with Overload, summon two 1/1 Sparks with Rush.
        /// 在你使用一张过载牌后，召唤两个1/1并具有突袭的“火花”。
        /// </summary>
        /// <param name="p"></param>
        /// <param name="hc"></param>
        /// <param name="wasOwnCard"></param>
        /// <param name="triggerEffectMinion"></param>
        public override void onCardIsGoingToBePlayed(Playfield p, Handmanager.Handcard hc, bool wasOwnCard, Minion triggerEffectMinion)
        {
            CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardIdEnum.BOT_102t);

            if (triggerEffectMinion.own == wasOwnCard && hc.card.overload > 0)
            {
                p.CallKid(kid, triggerEffectMinion.zonepos - 1, triggerEffectMinion.own);
                p.CallKid(kid, triggerEffectMinion.zonepos + 1, triggerEffectMinion.own);
            }
        }
    }
}