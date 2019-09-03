using HREngine.Bots;

namespace SilverFish.cards._04Expansion._008GIL
{
    /// <summary>
    /// Bogshaper
    /// 塑沼者
    /// </summary>
    public class Sim_GIL_807 : SimTemplate
{
    /// <summary>
    /// Whenever you cast a spell, draw a minion from your deck.
    /// 每当你施放一个法术，从你的牌库中抽一张随从牌。
    /// </summary>
    /// <param name="p"></param>
    /// <param name="hc"></param>
    /// <param name="wasOwnCard"></param>
    /// <param name="triggerEffectMinion"></param>
 public override void onCardIsGoingToBePlayed(Playfield p, Handmanager.Handcard hc, bool wasOwnCard, Minion triggerEffectMinion)
        {
            if (wasOwnCard == triggerEffectMinion.own && hc.card.type == CardDB.cardtype.SPELL)
            {
                p.drawACard(CardDB.cardName.unknown, wasOwnCard, true);
            }
        }
}
}
