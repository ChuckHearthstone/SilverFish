using HREngine.Bots;
using SilverFish.Enums;

namespace SilverFish.cards._04Expansion._001GvG
{
    class Sim_GVG_054 : SimTemplate //Ogre Warmaul
    {

        //   50% chance to attack the wrong enemy.
        // yolo!?
        CardDB.Card w = CardDB.Instance.getCardDataFromID(CardIdEnum.GVG_054);
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.equipWeapon(w, ownplay);
        }



    }

}