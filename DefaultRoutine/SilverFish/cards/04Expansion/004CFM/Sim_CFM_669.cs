using HREngine.Bots;
using SilverFish.Enums;

namespace SilverFish.cards._04Expansion._004CFM
{
	class Sim_CFM_669 : SimTemplate //* Burgly Bully
	{
		// Whenever your opponent casts a spell, add a Coin to your hand.

        public override void onCardIsGoingToBePlayed(Playfield p, Handmanager.Handcard hc, bool wasOwnCard, Minion triggerEffectMinion)
        {
            if (hc.card.type == CardDB.CardType.SPELL && wasOwnCard != triggerEffectMinion.own)
            {
                p.drawACard(CardName.thecoin, triggerEffectMinion.own);
            }
        }
    }
}