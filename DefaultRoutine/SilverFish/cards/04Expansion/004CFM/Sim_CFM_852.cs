using HREngine.Bots;

namespace SilverFish.cards._04Expansion._004CFM
{
	class Sim_CFM_852 : SimTemplate //* Lotus Agents
	{
		// Battlecry: Discover a Druid, Rogue or Shaman card.

        public override void getBattlecryEffect(Playfield p, Minion m, Minion target, int choice)
        {
            p.drawACard(CardDB.CardName.shieldbearer, m.own, true);
        }
    }
}