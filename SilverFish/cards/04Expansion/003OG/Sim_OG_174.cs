using HREngine.Bots;

namespace SilverFish.cards._04Expansion._003OG
{
	class Sim_OG_174 : SimTemplate //* Faceless Shambler
	{
		//Battlecry: Copy a friendly minion's Attack and Health.
		
		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            if (target != null)
			{
				own.HealthPoints = target.HealthPoints;
				own.Attack = target.Attack;
			}
		}
	}
}