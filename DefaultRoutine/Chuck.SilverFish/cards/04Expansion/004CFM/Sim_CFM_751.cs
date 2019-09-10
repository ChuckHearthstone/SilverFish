using Chuck.SilverFish;

namespace SilverFish.cards._04Expansion._004CFM
{
	class Sim_CFM_751 : SimTemplate //* Abyssal Enforcer
	{
		// Battlecry: Deal 3 damage to all other characters.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            p.allCharsGetDamage(3, own.entitiyID);
        }
    }
}