using HREngine.Bots;

namespace SilverFish.cards._04Expansion._004CFM
{
	class Sim_CFM_337 : SimTemplate //* Piranha Launcher
	{
		// Whenever your hero attacks, summon a 1/1 Piranha.

        CardDB.Card weapon = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.CFM_337);
        
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.equipWeapon(weapon, ownplay);
        }
    }
}