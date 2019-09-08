using HREngine.Bots;
using SilverFish.Enums;

namespace SilverFish.cards._04Expansion._001GvG
{
    class Sim_GVG_061 : SimTemplate //* Muster for Battle
    {
        // Summon three 1/1 Silver Hand Recruits. Equip a 1/4 Weapon.

        CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardIdEnum.CS2_101t);
        CardDB.Card w = CardDB.Instance.getCardDataFromID(CardIdEnum.CS2_091);

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            int pos = (ownplay) ? p.ownMinions.Count : p.enemyMinions.Count;

            p.CallKid(kid, pos, ownplay, false);
            for (int i = 0; i < 2; i++) p.CallKid(kid, pos, ownplay);

            p.equipWeapon(w, ownplay);
        }
    }
}