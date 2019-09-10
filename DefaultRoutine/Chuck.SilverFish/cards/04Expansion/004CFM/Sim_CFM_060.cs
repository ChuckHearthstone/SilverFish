using Chuck.SilverFish;
using SilverFish.Enums;

namespace SilverFish.cards._04Expansion._004CFM
{
	class Sim_CFM_060 : SimTemplate //* Red Mana Wyrm
	{
		// Whenever you cast a spell, gain +2 Attack.

        public override void onCardIsGoingToBePlayed(Playfield p, Handmanager.Handcard hc, bool wasOwnCard, Minion triggerEffectMinion)
        {
            if (triggerEffectMinion.own == wasOwnCard && hc.card.type == CardType.SPELL)
            {
                p.minionGetBuffed(triggerEffectMinion, 2, 0);
            }
        }
    }
}