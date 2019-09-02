using HREngine.Bots;

namespace SilverFish.cards._03Adventure._004KAR
{
	class Sim_KAR_710 : SimTemplate //* Arcanosmith
	{
		//Battlecry: Summon a 0/5 minion with Taunt.
		
        CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.KAR_710m);//Animated Shield
		
		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            p.CallKid(kid, own.zonepos, own.own);
		}
	}
}