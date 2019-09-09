using HREngine.Bots;

namespace SilverFish.cards._04Expansion._003OG
{
	class Sim_OG_310 : SimTemplate //* Steward of Darkshire
	{
		//Whenever you summon a 1-Health minion, give it Divine Shield.

        public override void onMinionWasSummoned(Playfield p, Minion m, Minion summonedMinion)
        {
            if (summonedMinion.HealthPoints == 1 && m.own == summonedMinion.own && m.entitiyID != summonedMinion.entitiyID)
            {
                summonedMinion.DivineShield = true;
            }
        }
    }
}