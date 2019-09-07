using HREngine.Bots;

namespace SilverFish.cards._04Expansion._004CFM
{
	class Sim_CFM_902 : SimTemplate //* Aya Blackpaw
	{
		// Battlecry and Deathrattle: Summon a Jade Golem.

        public override void getBattlecryEffect(Playfield p, Minion m, Minion target, int choice)
        {
            p.CallKid(p.getNextJadeGolem(m.own), m.zonepos, m.own);
        }

        public override void onDeathrattle(Playfield p, Minion m)
        {
            p.CallKid(p.getNextJadeGolem(m.own), m.zonepos - 1, m.own);
        }
    }
}