using HREngine.Bots;

namespace SilverFish.cards._04Expansion._004CFM
{
	class Sim_CFM_066 : SimTemplate //* Kabal Lackey
	{
		// Battlecry: The next Secret you play this turn costs (0).

        public override void getBattlecryEffect(Playfield p, Minion m, Minion target, int choice)
        {
            if (m.own) p.nextSecretThisTurnCost0 = true;
        }
    }
}