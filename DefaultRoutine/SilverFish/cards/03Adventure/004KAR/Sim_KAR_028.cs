using HREngine.Bots;
using SilverFish.Enums;

namespace SilverFish.cards._03Adventure._004KAR
{
	class Sim_KAR_028 : SimTemplate //* Fool's Bane
	{
        //Unlimited attacks each turn. Can't attack heroes.
        // handled in public void getMoveList

        CardDB.Card weapon = CardDB.Instance.getCardDataFromID(CardIdEnum.KAR_028);

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.equipWeapon(weapon, ownplay);
        }
	}
}