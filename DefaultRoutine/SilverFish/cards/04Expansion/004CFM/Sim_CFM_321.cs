using HREngine.Bots;
using SilverFish.Enums;

namespace SilverFish.cards._04Expansion._004CFM
{
	class Sim_CFM_321 : SimTemplate //* Grimestreet Informant
	{
		// Battlecry: Discover a Hunter, Paladin or Warrior card.

        public override void getBattlecryEffect(Playfield p, Minion m, Minion target, int choice)
        {
            p.drawACard(CardName.shieldbearer, m.own, true);
        }
    }
}