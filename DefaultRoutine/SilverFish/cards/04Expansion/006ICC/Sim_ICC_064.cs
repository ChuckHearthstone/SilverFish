using HREngine.Bots;
using SilverFish.Enums;

namespace SilverFish.cards._04Expansion._006ICC
{
    class Sim_ICC_064: SimTemplate //* Blood Razor
    {
        // Battlecry and Deathrattle: Deal 1 damage to all minions.

        CardDB.Card weapon = CardDB.Instance.getCardDataFromID(CardIdEnum.ICC_064);

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.equipWeapon(weapon, ownplay);

            p.allMinionsGetDamage(1);
            p.doDmgTriggers();
        }

        public override void onDeathrattle(Playfield p, Minion m)
        {
            p.allMinionsGetDamage(1);
            p.doDmgTriggers();
        }
    }
}