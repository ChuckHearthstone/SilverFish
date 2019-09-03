using HREngine.Bots;

namespace SilverFish.cards._04Expansion._005UNG
{
	class Sim_UNG_847 : SimTemplate //* Blazecaller
	{
		//Battlecry: If you played an Elemental last turn, deal 5 damage.

		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            if (target != null) p.minionGetDamageOrHeal(target, 5);
		}
	}
}