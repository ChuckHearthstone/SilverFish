using Chuck.SilverFish;
using SilverFish.Enums;

namespace SilverFish.cards._04Expansion._005UNG
{
	class Sim_UNG_846 : SimTemplate //* Shimmering Tempest
	{
		//Deathrattle: Add a random Mage spell to your hand.

        public override void onDeathrattle(Playfield p, Minion m)
        {
            p.drawACard(CardName.unknown, m.own, true);
        }
	}
}