using HREngine.Bots;
using SilverFish.Enums;

namespace SilverFish.cards._01Basic.Mage
{
	class Sim_NEW1_012 : SimTemplate //* Mana Wyrm
	{
		//Whenever you cast a spell, gain +1 Attack.

        public override void onCardIsGoingToBePlayed(Playfield p, Handmanager.Handcard hc, bool wasOwnCard, Minion triggerEffectMinion)
        {
            if (triggerEffectMinion.own == wasOwnCard && hc.card.type == CardType.SPELL)
            {
				p.minionGetBuffed(triggerEffectMinion, 1, 0);
            }
        }
	}
}