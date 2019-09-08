using HREngine.Bots;

namespace SilverFish.cards._02Classic
{
	class Sim_EX1_055 : SimTemplate //manaaddict
	{

//    erhält jedes mal +2 angriff in diesem zug, wenn ihr einen zauber wirkt.
        public override void onCardIsGoingToBePlayed(Playfield p, Handmanager.Handcard hc, bool wasOwnCard, Minion triggerEffectMinion)
        {
            if (triggerEffectMinion.own == wasOwnCard && hc.card.type == CardDB.CardType.SPELL)
            {
                p.minionGetTempBuff(triggerEffectMinion, 2, 0);
            }
        }

	}
}