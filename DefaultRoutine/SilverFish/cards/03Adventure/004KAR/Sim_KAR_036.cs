using HREngine.Bots;

namespace SilverFish.cards._03Adventure._004KAR
{
	class Sim_KAR_036 : SimTemplate //* Arcane Anomaly
	{
		//Whenever you cast a spell, give this minion +1 Health.
		
        public override void onCardIsGoingToBePlayed(Playfield p, Handmanager.Handcard hc, bool wasOwnCard, Minion triggerEffectMinion)
        {
            if (triggerEffectMinion.own == wasOwnCard && hc.card.type == CardDB.CardType.SPELL)
            {
				p.minionGetBuffed(triggerEffectMinion, 0, 1);
            }
        }
	}
}