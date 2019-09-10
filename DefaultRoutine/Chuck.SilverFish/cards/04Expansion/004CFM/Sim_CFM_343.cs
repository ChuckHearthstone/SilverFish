using Chuck.SilverFish;

namespace SilverFish.cards._04Expansion._004CFM
{
	class Sim_CFM_343 : SimTemplate //* Jade Behemoth
	{
		// Taunt. Battlecry: Summon a Jade Golem.

        public override void getBattlecryEffect(Playfield p, Minion m, Minion target, int choice)
        {
            p.CallKid(p.getNextJadeGolem(m.own), m.zonepos, m.own);
        }
    }
}