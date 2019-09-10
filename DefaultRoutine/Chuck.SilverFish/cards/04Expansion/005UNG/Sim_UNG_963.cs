using Chuck.SilverFish;
using SilverFish.Enums;

namespace SilverFish.cards._04Expansion._005UNG
{
	class Sim_UNG_963 : SimTemplate //* Lyra the Sunshard
	{
		//Whenever you cast a spell, add a random Priest spell to your hand.

        public override void onCardIsGoingToBePlayed(Playfield p, Handmanager.Handcard hc, bool wasOwnCard, Minion triggerEffectMinion)
        {
            if (hc.card.type == CardType.SPELL && wasOwnCard == triggerEffectMinion.own)
            {
                p.drawACard(CardName.unknown, wasOwnCard);
            }
        }
	}
}