using HREngine.Bots;

namespace SilverFish.cards._04Expansion._003OG
{
	class Sim_OG_290 : SimTemplate //* Ancient Harbinger
	{
		//At the start of your turn, put a 10-Cost minion from your deck into your hand.
		
        public override void onTurnStartTrigger(Playfield p, Minion triggerEffectMinion, bool turnStartOfOwner)
        {
            if (triggerEffectMinion.own == turnStartOfOwner)
            {
				p.drawACard(CardDB.CardName.varianwrynn, turnStartOfOwner);
            }
        }
	}
}