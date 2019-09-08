using HREngine.Bots;
using SilverFish.Enums;

namespace SilverFish.cards._04Expansion._002AT
{
	class Sim_AT_132_ROGUEt : SimTemplate //* Poisoned Dagger
	{
        CardDB.Card weapon = CardDB.Instance.getCardDataFromID(CardIdEnum.AT_132_ROGUEt);

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.equipWeapon(weapon, ownplay);
        }
	}
}