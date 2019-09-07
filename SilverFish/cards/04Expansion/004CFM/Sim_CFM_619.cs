using HREngine.Bots;

namespace SilverFish.cards._04Expansion._004CFM
{
	class Sim_CFM_619 : SimTemplate //* Kabal Chemist
	{
		// Battlecry: Add a random Potion to your hand.

        public override void getBattlecryEffect(Playfield p, Minion m, Minion target, int choice)
        {
            p.drawACard(CardDB.cardName.frostbolt, m.own, true);
        }
    }
}