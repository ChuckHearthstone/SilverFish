using HREngine.Bots;

namespace SilverFish.cards._02Classic
{
	class Sim_EX1_559 : SimTemplate //archmageantonidas
	{

//    erhaltet jedes mal einen „feuerball“-zauber auf eure hand, wenn ihr einen zauber wirkt.

        public override void onCardIsGoingToBePlayed(Playfield p, Handmanager.Handcard hc, bool wasOwnCard, Minion triggerEffectMinion)
        {
            if (wasOwnCard == triggerEffectMinion.own && hc.card.type == CardDB.CardType.SPELL)
            {
                p.drawACard(CardDB.CardName.fireball, wasOwnCard, true);
            }
        }

	}
}