using HREngine.Bots;

namespace SilverFish.cards._04Expansion._004CFM
{
	class Sim_CFM_639 : SimTemplate //* Grimestreet Enforcer
	{
		// At the end of your turn, give all minions in your hand +1/+1.

        public override void onTurnEndsTrigger(Playfield p, Minion triggerEffectMinion, bool turnEndOfOwner)
        {
            if (turnEndOfOwner == triggerEffectMinion.own)
            {
                if (triggerEffectMinion.own)
                {
                    foreach (Handmanager.Handcard hc in p.owncards)
                    {
                        if (hc.card.type == CardDB.cardtype.MOB)
                        {
                            hc.addattack++;
                            hc.addHp++;
                            p.anzOwnExtraAngrHp += 2;
                        }
                    }
                }
                else
                {
                    if (p.enemyAnzCards > 0) p.anzEnemyExtraAngrHp += 2 * p.enemyAnzCards - 1;
                }
            }
        }
    }
}