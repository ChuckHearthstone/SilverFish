using HREngine.Bots;
using SilverFish.Enums;

namespace SilverFish.cards._03Adventure._003LOE
{
	class Sim_LOE_009 : SimTemplate //* Obsidian Destroyer
	{
		//At the end of your turn, summon a 1/1 Scarab with Taunt.

        CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardIdEnum.LOE_009t); //Scarab

        public override void onTurnEndsTrigger(Playfield p, Minion triggerEffectMinion, bool turnEndOfOwner)
        {
            if (triggerEffectMinion.own == turnEndOfOwner)
            {
                int place = triggerEffectMinion.zonepos;
                p.CallKid(kid, place, triggerEffectMinion.own);
            }
        }
	}
}