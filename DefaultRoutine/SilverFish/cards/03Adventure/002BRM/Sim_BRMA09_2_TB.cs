using HREngine.Bots;

namespace SilverFish.cards._03Adventure._002BRM
{
	class Sim_BRMA09_2_TB : SimTemplate //* Open the Gates
	{
		// Hero Power: Summon three 1/1 Whelps. Get a new Hero Power.

		CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardIdEnum.BRMA09_2t);//1/1Whelp
		
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            int place = (ownplay) ? p.ownMinions.Count : p.enemyMinions.Count;
            p.CallKid(kid, place, ownplay, false);
            p.CallKid(kid, place, ownplay);
            p.CallKid(kid, place, ownplay);
        }
	}
}