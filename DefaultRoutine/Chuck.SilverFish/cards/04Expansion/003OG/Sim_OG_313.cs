using Chuck.SilverFish;

namespace SilverFish.cards._04Expansion._003OG
{
	class Sim_OG_313 : SimTemplate //* Addled Grizzly
	{
		//After you summon a minion, give it +1/+1.
		
		public override void onMinionWasSummoned(Playfield p, Minion m, Minion summonedMinion)
        {
			if (m.own == summonedMinion.own && m.entitiyID != summonedMinion.entitiyID)
			{
				p.minionGetBuffed(summonedMinion, 1, 1);
			}
        }
	}
}