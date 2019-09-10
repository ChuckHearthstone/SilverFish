using Chuck.SilverFish;
using SilverFish.Enums;

namespace SilverFish.cards._01Basic._02Hunter
{
	class Sim_CS2_237 : SimTemplate //starvingbuzzard
	{

//    zieht jedes mal eine karte, wenn ihr ein wildtier herbeiruft.
        public override void onMinionIsSummoned(Playfield p, Minion triggerEffectMinion, Minion summonedMinion)
        {
            if (triggerEffectMinion.own == summonedMinion.own && (TAG_RACE)summonedMinion.handcard.card.race == TAG_RACE.PET)
            {
                p.drawACard(CardName.unknown, triggerEffectMinion.own);
            }
        }

	}
}