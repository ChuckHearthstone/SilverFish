using Chuck.SilverFish;

namespace SilverFish.cards._02Classic
{
    class Sim_EX1_249 : SimTemplate //* Baron Geddon
	{
        // At the end of your turn, deal 2 damage to ALL other characters.

        public override void onTurnEndsTrigger(Playfield p, Minion triggerEffectMinion, bool turnEndOfOwner)
        {
            if (turnEndOfOwner == triggerEffectMinion.own)
            {
                p.allCharsGetDamage(2, triggerEffectMinion.entitiyID);
            }
        }
	}
}