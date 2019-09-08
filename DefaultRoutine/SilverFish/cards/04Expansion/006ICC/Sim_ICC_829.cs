using HREngine.Bots;
using SilverFish.Enums;

namespace SilverFish.cards._04Expansion._006ICC
{
    class Sim_ICC_829: SimTemplate //* Uther of the Ebon Blade
    {
        // Battlecry: Equip a 5/3 Lifesteal weapon.

        CardDB.Card w = CardDB.Instance.getCardDataFromID(CardIdEnum.ICC_829t); //Grave Vengeance

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.setNewHeroPower(CardIdEnum.ICC_829p, ownplay); // The Four Horsemen
            if (ownplay) p.ownHero.armor += 5;
            else p.enemyHero.armor += 5;

            p.equipWeapon(w, ownplay);
        }
    }
}