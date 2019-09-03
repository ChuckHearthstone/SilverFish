using HREngine.Bots;

namespace SilverFish.cards._04Expansion._005UNG
{
	class Sim_UNG_829t2 : SimTemplate //* Nether Portal
	{
		//At the end of your turn, summon two 3/2 Imps.

        CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.UNG_829t3); //Nether Imp

        public override void onTurnEndsTrigger(Playfield p, Minion triggerEffectMinion, bool turnEndOfOwner)
        {
            if (triggerEffectMinion.own == turnEndOfOwner)
            {
                p.CallKid(kid, triggerEffectMinion.zonepos - 1, triggerEffectMinion.own); //1st left
                p.CallKid(kid, triggerEffectMinion.zonepos, triggerEffectMinion.own); 
            }
        }
	}
}