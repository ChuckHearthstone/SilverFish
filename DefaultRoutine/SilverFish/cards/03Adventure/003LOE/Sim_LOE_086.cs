using HREngine.Bots;

namespace SilverFish.cards._03Adventure._003LOE
{
	class Sim_LOE_086 : SimTemplate //* Summoning Stone
	{
		//Whenever you cast a spell, summon a random minion of the same Cost.
		
        public override void onCardIsGoingToBePlayed(Playfield p, Handmanager.Handcard hc, bool wasOwnCard, Minion triggerEffectMinion)
        {
            if (triggerEffectMinion.own == wasOwnCard && hc.card.type == CardDB.CardType.SPELL)
            {
                int pos = (wasOwnCard) ? p.ownMinions.Count : p.enemyMinions.Count;
                p.CallKid(p.getRandomCardForManaMinion(hc.manacost), pos, wasOwnCard);
            }
        }
	}
}