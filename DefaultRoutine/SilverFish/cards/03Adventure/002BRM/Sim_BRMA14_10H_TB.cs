using HREngine.Bots;

namespace SilverFish.cards._03Adventure._002BRM
{
	class Sim_BRMA14_10H_TB : SimTemplate //* Activate!
	{
		// Hero Power: Activate a random Tron.

		CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardIdEnum.BRMA14_5H);//4/4toxitron
		
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            int place = (ownplay) ? p.ownMinions.Count : p.enemyMinions.Count;
            p.CallKid(kid, place, ownplay, false);
        }
	}
}