using Chuck.SilverFish;

namespace SilverFish.cards._03Adventure._001NAX
{
    class Sim_NAX8_03t : SimTemplate //* Spectral Trainee
    {
        //    At the start of your turn, deal 1 damage to your hero.

        public override void onTurnStartTrigger(Playfield p, Minion triggerEffectMinion, bool turnStartOfOwner)
        {
            if (triggerEffectMinion.own == turnStartOfOwner)
            {
				p.minionGetDamageOrHeal(turnStartOfOwner ? p.ownHero : p.enemyHero, 1);
            }
        }

    }
}