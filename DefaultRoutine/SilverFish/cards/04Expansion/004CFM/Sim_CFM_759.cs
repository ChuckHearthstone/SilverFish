using HREngine.Bots;
using SilverFish.Enums;

namespace SilverFish.cards._04Expansion._004CFM
{
	class Sim_CFM_759 : SimTemplate //* Meanstreet Marshal
	{
		// Deathrattle: If this minion has 2 or more Attack, draw a card.

        public override void onDeathrattle(Playfield p, Minion m)
        {
            if (m.Attack >= 2) p.drawACard(CardName.unknown, m.own);
        }
    }
}