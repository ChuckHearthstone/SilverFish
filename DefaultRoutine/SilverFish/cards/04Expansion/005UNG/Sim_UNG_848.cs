using Chuck.SilverFish;

namespace SilverFish.cards._04Expansion._005UNG
{
	class Sim_UNG_848 : SimTemplate //* Primordial Drake
	{
		//Taunt Battlecry: Deal 2 damage to all other minions.

		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            p.allMinionsGetDamage(2, own.entitiyID);
        }
	}
}