using HREngine.Bots;

namespace SilverFish.cards._04Expansion._004CFM
{
	class Sim_CFM_691 : SimTemplate //* Jade Swarmer
	{
		// Stealth, Deathrattle: Summon a Jade Golem.

        public override void onDeathrattle(Playfield p, Minion m)
        {
            p.CallKid(p.getNextJadeGolem(m.own), m.zonepos - 1, m.own);
        }
    }
}