using HREngine.Bots;

namespace SilverFish.cards._04Expansion._004CFM
{
	class Sim_CFM_321 : SimTemplate //* Grimestreet Informant
	{
		// Battlecry: Discover a Hunter, Paladin or Warrior card.

        public override void getBattlecryEffect(Playfield p, Minion m, Minion target, int choice)
        {
            p.drawACard(CardDB.cardName.shieldbearer, m.own, true);
        }
    }
}