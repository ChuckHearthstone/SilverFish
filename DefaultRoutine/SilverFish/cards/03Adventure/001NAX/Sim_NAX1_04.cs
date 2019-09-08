using HREngine.Bots;

namespace SilverFish.cards._03Adventure._001NAX
{
	class Sim_NAX1_04 : SimTemplate //* Skitter
	{
		// Hero Power: Summon a 3/1 Nerubian.
		
		CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardIdEnum.NAX1_03);//3/1Nerubian
		
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            int place = (ownplay) ? p.ownMinions.Count : p.enemyMinions.Count;
            p.CallKid(kid, place, ownplay, false);
        }
	}
}