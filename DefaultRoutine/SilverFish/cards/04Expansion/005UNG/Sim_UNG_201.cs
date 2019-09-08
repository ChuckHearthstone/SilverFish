using HREngine.Bots;
using SilverFish.Enums;

namespace SilverFish.cards._04Expansion._005UNG
{
	class Sim_UNG_201 : SimTemplate //* Primalfin Totem
	{
		//At the end of your turn, summon a 1/1 Murloc.

        CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardIdEnum.UNG_201t); //Primalfin

        public override void onTurnEndsTrigger(Playfield p, Minion triggerEffectMinion, bool turnEndOfOwner)
        {
            if (triggerEffectMinion.own == turnEndOfOwner)
            {
                int pos = triggerEffectMinion.zonepos;
                p.CallKid(kid, pos, triggerEffectMinion.own);
            }
        }
	}
}