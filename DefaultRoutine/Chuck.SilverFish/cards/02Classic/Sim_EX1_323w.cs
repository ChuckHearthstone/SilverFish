using Chuck.SilverFish;
using SilverFish.Enums;

namespace SilverFish.cards._02Classic
{
    class Sim_EX1_323w : SimTemplate //* Blood Fury
	{
        CardDB.Card weapon = CardDB.Instance.getCardDataFromID(CardIdEnum.EX1_323w);

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.equipWeapon(weapon, ownplay);
        }
	}
}