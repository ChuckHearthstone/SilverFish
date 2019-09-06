using HREngine.Bots;

namespace SilverFish.cards._04Expansion._001GvG
{
    class Sim_GVG_103 : SimTemplate //Micro Machine
    {

        //   At the start of each turn, gain +1 Attack.

        public override void onTurnStartTrigger(Playfield p, Minion triggerEffectMinion, bool turnStartOfOwner)
        {
            p.minionGetBuffed(triggerEffectMinion, 1, 0);
        }


    }

}