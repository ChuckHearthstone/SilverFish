using HREngine.Bots;

namespace SilverFish.cards._03Adventure._004KAR
{
	class Sim_KAR_044 : SimTemplate //* Moroes
	{
		//Stealth. At the end of your turn, summon a 1/1 Steward.
		
        CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardIdEnum.KAR_044a); //Steward

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