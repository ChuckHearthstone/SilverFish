using HREngine.Bots;
using SilverFish.Enums;

namespace SilverFish.cards._04Expansion._004CFM
{
	class Sim_CFM_606 : SimTemplate //* Mana Geode
	{
		// Whenever this minion is healed, summon a 2/2 Crystal.

        CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardIdEnum.CFM_606t); //2/2 Crystal

        public override void onAMinionGotHealedTrigger(Playfield p, Minion triggerEffectMinion, int minionsGotHealed)
        {
            if (triggerEffectMinion.anzGotHealed > 0)
            {
                int tmp = triggerEffectMinion.anzGotHealed;
                triggerEffectMinion.anzGotHealed = 0;
                for (int i = 0; i < tmp; i++)
                {
                    p.CallKid(kid, triggerEffectMinion.zonepos, triggerEffectMinion.own);
                }
            }
        }
    }
}