using HREngine.Bots;
using SilverFish.Enums;

namespace SilverFish.cards._01Basic._00Neutral
{
	class Sim_NEW1_040 : SimTemplate //hogger
	{
        CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardIdEnum.NEW1_040t);//gnoll
//    ruft am ende eures zuges einen gnoll (2/2) mit spott/ herbei.

        public override void onTurnEndsTrigger(Playfield p, Minion triggerEffectMinion, bool turnEndOfOwner)
        {
            if (triggerEffectMinion.own == turnEndOfOwner)
            {
                int posi = triggerEffectMinion.zonepos;

                p.CallKid(kid, posi, triggerEffectMinion.own);
            }
        }

	}
}