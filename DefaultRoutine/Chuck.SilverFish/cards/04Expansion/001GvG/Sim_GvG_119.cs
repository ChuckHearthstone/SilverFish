using Chuck.SilverFish;
using SilverFish.Enums;

namespace SilverFish.cards._04Expansion._001GvG
{
    class Sim_GVG_119 : SimTemplate //Blingtron 3000
    {

        //   Battlecry: Equip a random weapon for each player.
        CardDB.Card w = CardDB.Instance.getCardDataFromID(CardIdEnum.CS2_080);

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            p.equipWeapon(w, true);
            p.equipWeapon(w, false);
        }


    }

}