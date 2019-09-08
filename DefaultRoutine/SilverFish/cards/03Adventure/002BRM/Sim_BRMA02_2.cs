using HREngine.Bots;
using SilverFish.Enums;

namespace SilverFish.cards._03Adventure._002BRM
{
	class Sim_BRMA02_2 : SimTemplate //* Jeering Crowd
	{
		// Hero Power: Summon a 1/1 Spectator with Taunt.
		
		CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardIdEnum.BRMA02_2t);//Dark Iron Spectator
		
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            int place = (ownplay) ? p.ownMinions.Count : p.enemyMinions.Count;
            p.CallKid(kid, place, ownplay, false);
        }
	}
}