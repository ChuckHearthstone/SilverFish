using HREngine.Bots;

namespace SilverFish.cards._04Expansion._006ICC
{
    class Sim_ICC_901: SimTemplate //* Drakkari Enchanter
    {
        // Your end of turn effects trigger twice.

        public override void onAuraStarts(Playfield p, Minion own)
        {
            if (own.own) p.ownTurnEndEffectsTriggerTwice++;
            else p.enemyTurnEndEffectsTriggerTwice++;
        }

        public override void onAuraEnds(Playfield p, Minion m)
        {
            if (m.own) p.ownTurnEndEffectsTriggerTwice--;
            else p.enemyTurnEndEffectsTriggerTwice--;
        }
    }
}