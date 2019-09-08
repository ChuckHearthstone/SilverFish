using HREngine.Bots;

namespace SilverFish.cards._03Adventure._002BRM
{
	class Sim_BRMA06_2H : SimTemplate //* The Majordomo
	{
		// Hero Power: Summon a 3/3 Flamewaker Acolyte.
		
		CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardIdEnum.BRMA06_4H);//3/3Flamewaker Acolyte
		
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            int place = (ownplay) ? p.ownMinions.Count : p.enemyMinions.Count;
            p.CallKid(kid, place, ownplay, false);
        }
	}
}