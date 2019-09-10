using Chuck.SilverFish;

namespace SilverFish.cards._04Expansion._004CFM
{
	class Sim_CFM_611 : SimTemplate //* Bloodfury Potion
	{
		// Give a minion +3 Attack. If it's a Demon, also give it +3 Health.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            int hpbaff = 0;
            if ((TAG_RACE)target.handcard.card.race == TAG_RACE.DEMON) hpbaff = 3;
            p.minionGetBuffed(target, 3, hpbaff);
        }
    }
}