using Chuck.SilverFish;
using SilverFish.Enums;

namespace SilverFish.cards._02Classic
{
	class Sim_EX1_095 : SimTemplate //gadgetzanauctioneer
	{

//    zieht jedes mal eine karte, wenn ihr einen zauber wirkt.

        public override void onCardIsGoingToBePlayed(Playfield p, Handmanager.Handcard hc, bool wasOwnCard, Minion triggerEffectMinion)
        {
            if (hc.card.type == CardType.SPELL && wasOwnCard == triggerEffectMinion.own)
            {
                p.drawACard(CardName.unknown, wasOwnCard);
            }

        }

	}
}