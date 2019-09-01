using HREngine.Bots;

namespace SilverFish.cards._04Expansion._001GvG
{
    class Sim_GVG_025 : SimTemplate //One-eyed Cheat
    {

        //    Whenever you summon a Pirate, gain Stealth.

        public override void onMinionIsSummoned(Playfield p, Minion triggerEffectMinion, Minion summonedMinion)
        {
            if ((TAG_RACE)summonedMinion.handcard.card.race == TAG_RACE.PIRATE)
            {
                triggerEffectMinion.stealth = true;
            }
        }


    }

}