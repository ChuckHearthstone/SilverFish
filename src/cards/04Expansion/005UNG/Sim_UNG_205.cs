using HREngine.Bots;

namespace SilverFish.cards._04Expansion._005UNG
{
	class Sim_UNG_205 : SimTemplate //* Glacial Shard
	{
		//Battlecry: Freeze an enemy.

		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            if (target != null) p.minionGetFrozen(target);
		}
	}
}