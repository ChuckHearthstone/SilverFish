using Chuck.SilverFish;
using SilverFish.Enums;

namespace SilverFish.cards._04Expansion._004CFM
{
	class Sim_CFM_649 : SimTemplate //* Kabal Courier
	{
		// Battlecry: Discover a Mage, Priest or Warlock card.

        public override void getBattlecryEffect(Playfield p, Minion m, Minion target, int choice)
        {
            p.drawACard(CardName.shieldbearer, m.own, true);
        }
    }
}