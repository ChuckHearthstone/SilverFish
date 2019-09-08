using HREngine.Bots;

namespace SilverFish.cards._04Expansion._002AT
{
	class Sim_AT_132_ROGUE : SimTemplate //* Poisoned Daggers
	{
		//Hero Power. Equip a 2/2 Weapon.

        CardDB.Card weapon = CardDB.Instance.getCardDataFromID(CardIdEnum.AT_132_ROGUEt);
		
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.equipWeapon(weapon, ownplay);
        }
	}
}