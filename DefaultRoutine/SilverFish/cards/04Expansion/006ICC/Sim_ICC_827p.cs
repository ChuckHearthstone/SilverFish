using HREngine.Bots;
using SilverFish.Enums;

namespace SilverFish.cards._04Expansion._006ICC
{
    class Sim_ICC_827p: SimTemplate //* Death's Shadow
    {
        // Passive Hero Power: During your turn, add a 'Shadow Reflection' to your hand.

        public override void onTurnStartTrigger(Playfield p, Minion triggerEffectMinion, bool turnStartOfOwner)
        {
            //!triggerEffectMinion = null
            bool found = false;
            if (turnStartOfOwner)
            {
                foreach (Handmanager.Handcard hc in p.owncards)
                {
                    if (hc.card.name == CardName.shadowreflection)
                    {
                        found = true;
                        break;
                    }
                }
            }
            if (!found) p.drawACard(CardName.shadowreflection, turnStartOfOwner, true);
        }
    }
}