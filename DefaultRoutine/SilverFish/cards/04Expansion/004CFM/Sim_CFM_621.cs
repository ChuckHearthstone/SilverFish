using Chuck.SilverFish;
using SilverFish.Enums;

namespace SilverFish.cards._04Expansion._004CFM
{
	class Sim_CFM_621 : SimTemplate //* Kazakus
	{
		// Battlecry: If your deck has no duplicates, create a custom spell.

        public override void getBattlecryEffect(Playfield p, Minion m, Minion target, int choice)
        {
            if (m.own && p.prozis.noDuplicates) p.drawACard(CardName.thecoin, m.own, true);
        }
    }
}