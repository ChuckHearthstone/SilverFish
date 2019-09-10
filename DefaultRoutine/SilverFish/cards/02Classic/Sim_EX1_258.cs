using Chuck.SilverFish;

namespace SilverFish.cards._02Classic
{
    class Sim_EX1_258 : SimTemplate//Unbound Elemental
    {
        // erhält jedes Mal +1/+1, wenn Ihr eine Karte mit uberladung&lt; ausspielt.
        public override void onCardIsGoingToBePlayed(Playfield p, Handmanager.Handcard hc, bool wasOwnCard, Minion triggerEffectMinion)
        {
            if (wasOwnCard == triggerEffectMinion.own && hc.card.overload > 0)
            {
                p.minionGetBuffed(triggerEffectMinion, 1, 1);
            }
        }

    }
}
