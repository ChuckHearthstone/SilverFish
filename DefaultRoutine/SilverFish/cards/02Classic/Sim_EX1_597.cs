using Chuck.SilverFish;
using SilverFish.Enums;

namespace SilverFish.cards._02Classic
{
	class Sim_EX1_597 : SimTemplate //impmaster
	{

//    fügt am ende eures zuges diesem diener 1 schaden zu und beschwört einen wichtel (1/1).

        CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardIdEnum.EX1_598);//imp

        public override void onTurnEndsTrigger(Playfield p, Minion triggerEffectMinion, bool turnEndOfOwner)
        {
            if (triggerEffectMinion.own == turnEndOfOwner)
            {
                int posi = triggerEffectMinion.zonepos;
                if (triggerEffectMinion.HealthPoints == 1) posi--;
                p.minionGetDamageOrHeal(triggerEffectMinion, 1);
                p.CallKid(kid, posi, triggerEffectMinion.own);
                triggerEffectMinion.stealth = false;
            }
        }

	}
}