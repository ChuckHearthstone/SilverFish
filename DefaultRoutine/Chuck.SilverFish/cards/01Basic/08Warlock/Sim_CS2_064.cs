using Chuck.SilverFish;

namespace SilverFish.cards._01Basic._08Warlock
{
    class Sim_CS2_064 : SimTemplate //* Dread Infernal
	{
        // Battlecry: Deal 1 damage to ALL other characters.

		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            p.allCharsGetDamage(1, own.entitiyID);
		}
	}
}