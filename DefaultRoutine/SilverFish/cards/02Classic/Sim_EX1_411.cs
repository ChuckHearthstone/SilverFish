using HREngine.Bots;
using SilverFish.Enums;

namespace SilverFish.cards._02Classic
{
    class Sim_EX1_411 : SimTemplate//Gorehowl
    {
        CardDB.Card wcard = CardDB.Instance.getCardDataFromID(CardIdEnum.EX1_411);
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.equipWeapon(wcard, ownplay);
        }

    }
}
