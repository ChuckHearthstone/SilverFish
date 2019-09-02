using HREngine.Bots;

namespace SilverFish.cards._04Expansion._003OG
{
	class Sim_OG_149 : SimTemplate //* Ravaging Ghoul
	{
		//Battlecry: Deal 1 damage to all other minions.
		
		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            p.allMinionsGetDamage(1, own.entitiyID);
        }
	}
}