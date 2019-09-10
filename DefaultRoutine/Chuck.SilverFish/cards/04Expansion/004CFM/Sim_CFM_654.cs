using Chuck.SilverFish;

namespace SilverFish.cards._04Expansion._004CFM
{
	class Sim_CFM_654 : SimTemplate //* Friendly Bartender
	{
		// At the end of your turn, restore 1 Health to your Hero.

        public override void onTurnEndsTrigger(Playfield p, Minion triggerEffectMinion, bool turnEndOfOwner)
        {
            if (triggerEffectMinion.own == turnEndOfOwner)
            {

                if (triggerEffectMinion.own)
                {
                    int heal = p.getMinionHeal(1);
                    p.minionGetDamageOrHeal(p.ownHero, -heal, true);
                }
                else
                {
                    int heal = p.getEnemyMinionHeal(1);
                    p.minionGetDamageOrHeal(p.enemyHero, -heal, true);
                }
            }
        }
    }
}