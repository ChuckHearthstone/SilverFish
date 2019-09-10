using Chuck.SilverFish;

namespace SilverFish.cards._04Expansion._005UNG
{
	class Sim_UNG_099 : SimTemplate //* Charged Devilsaur
	{
		//Charge Battlecry: Can't attack heroes this turn.

		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            own.cantAttackHeroes = true;
		}

        public override void onTurnStartTrigger(Playfield p, Minion triggerEffectMinion, bool turnStartOfOwner)
        {
            if (triggerEffectMinion.own == turnStartOfOwner) triggerEffectMinion.cantAttackHeroes = false;
        }
    }
}