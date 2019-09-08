using HREngine.Bots;
using SilverFish.Enums;

namespace SilverFish.cards._03Adventure._001NAX
{
	class Sim_NAX1h_04 : SimTemplate //* Skitter
	{
		// Hero Power: Summon a 4/4 Nerubian.
		
		CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardIdEnum.NAX1h_03);//4/4Nerubian
		
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            int place = (ownplay) ? p.ownMinions.Count : p.enemyMinions.Count;
            p.CallKid(kid, place, ownplay, false);
        }
	}
}