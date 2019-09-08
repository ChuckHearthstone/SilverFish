using HREngine.Bots;
using SilverFish.Enums;

namespace SilverFish.cards._03Adventure._002BRM
{
	class Sim_BRM_010b : SimTemplate //* Fire Hawk Form
	{
		// Transform into a 2/5 minion.

        CardDB.Card hawk = CardDB.Instance.getCardDataFromID(CardIdEnum.BRM_010t2);

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.minionTransform(target, hawk);
        }
	}
}