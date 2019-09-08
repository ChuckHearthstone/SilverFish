using HREngine.Bots;

namespace SilverFish.cards._02Classic
{
	class Sim_EX1_100 : SimTemplate //lorewalkercho
	{

//    wenn ein spieler einen zauber wirkt, erhält der andere spieler eine kopie desselben auf seine hand.

        public override void onCardIsGoingToBePlayed(Playfield p, Handmanager.Handcard hc, bool wasOwnCard, Minion triggerEffectMinion)
        {
            if (hc.card.type == CardDB.CardType.SPELL)
            {
                p.drawACard(hc.card.name, !wasOwnCard, true);
            }
        }

	}
}