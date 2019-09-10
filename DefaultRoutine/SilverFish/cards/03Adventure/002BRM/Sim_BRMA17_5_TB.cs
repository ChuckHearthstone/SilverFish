using Chuck.SilverFish;
using SilverFish.Enums;

namespace SilverFish.cards._03Adventure._002BRM
{
	class Sim_BRMA17_5_TB : SimTemplate //* Bone Minions
	{
		// Hero Power: Summon two 2/1 Bone Constructs.

		CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardIdEnum.BRMA17_6);//2/1Bone Construct
		
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            int place = (ownplay) ? p.ownMinions.Count : p.enemyMinions.Count;
            p.CallKid(kid, place, ownplay, false);
            p.CallKid(kid, place, ownplay);
        }
	}
}