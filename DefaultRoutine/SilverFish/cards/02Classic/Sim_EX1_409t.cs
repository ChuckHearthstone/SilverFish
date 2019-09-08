using HREngine.Bots;
using SilverFish.Enums;

namespace SilverFish.cards._02Classic
{
    class Sim_EX1_409t : SimTemplate //* Heavy Axe
	{
        CardDB.Card weapon = CardDB.Instance.getCardDataFromID(CardIdEnum.EX1_409t);

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.equipWeapon(weapon, ownplay);
        }
	}
}