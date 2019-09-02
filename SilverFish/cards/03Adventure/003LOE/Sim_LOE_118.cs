using HREngine.Bots;

namespace SilverFish.cards._03Adventure._003LOE
{
	class Sim_LOE_118 : SimTemplate //* Cursed Blade
	{
		//Double all damage dealt to your hero.
        //handled in getDamageOrHeal

        CardDB.Card weapon = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.LOE_118);

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.equipWeapon(weapon, ownplay);
        }
	}
}