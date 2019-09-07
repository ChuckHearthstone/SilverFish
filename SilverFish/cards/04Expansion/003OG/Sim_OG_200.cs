using HREngine.Bots;

namespace SilverFish.cards._04Expansion._003OG
{
    class Sim_OG_200 : SimTemplate //* Validated Doomsayer
    {
        //At the start of your turn, set this minion's Attack to 7.

        public override void onTurnStartTrigger(Playfield p, Minion triggerEffectMinion, bool turnStartOfOwner)
        {
            if (triggerEffectMinion.own == turnStartOfOwner)
            {
                if (triggerEffectMinion.Attack != 7) triggerEffectMinion.Attack = 7;
            }
        }
    }
}