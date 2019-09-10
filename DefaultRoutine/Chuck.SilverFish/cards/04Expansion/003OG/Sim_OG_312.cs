using Chuck.SilverFish;
using SilverFish.Enums;

namespace SilverFish.cards._04Expansion._003OG
{
	class Sim_OG_312 : SimTemplate //* N'Zoth's First Mate
	{
		//Battlecry: Equip a 1/3 Rusty Hook.

        CardDB.Card w = CardDB.Instance.getCardDataFromID(CardIdEnum.OG_058);

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            p.equipWeapon(w, own.own);
        }
    }
}
