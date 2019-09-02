using HREngine.Bots;

namespace SilverFish.cards._03Adventure._002BRM
{
	class Sim_BRM_010a : SimTemplate //* Firecat Form
	{
		// Transform into a 5/2 minion.
		
        CardDB.Card cat = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.BRM_010t);

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.minionTransform(target, cat);
        }
	}
}