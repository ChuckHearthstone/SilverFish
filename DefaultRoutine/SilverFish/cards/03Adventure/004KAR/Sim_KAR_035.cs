using HREngine.Bots;
using SilverFish.Enums;

namespace SilverFish.cards._03Adventure._004KAR
{
	class Sim_KAR_035 : SimTemplate //* Priest of the Feast
	{
		//Whenever you cast a spell, restore 3 Health to your hero.

        public override void onCardIsGoingToBePlayed(Playfield p, Handmanager.Handcard hc, bool wasOwnCard, Minion triggerEffectMinion)
        {
            if (triggerEffectMinion.own == wasOwnCard && hc.card.type == CardType.SPELL)
            {
				int heal = (wasOwnCard) ? p.getMinionHeal(3) : p.getEnemyMinionHeal(3);
				p.minionGetDamageOrHeal(wasOwnCard ? p.ownHero : p.enemyHero, -heal);
            }
        }
	}
}